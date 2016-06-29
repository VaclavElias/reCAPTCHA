﻿#region License
//Copyright(c) Paul Biccherai
//Licensed under the MIT license. See LICENSE file in the project root for full license information.
#endregion

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace PaulMiami.AspNetCore.Mvc.Recaptcha
{
    public class RecaptchaService : IRecaptchaValidationService
    {
        private RecaptchaOptions _options;
        private HttpClient _backChannel;
        private RecaptchaControlSettings _controlSettings;
        private string _validationMessage;

        public RecaptchaService(IOptions<RecaptchaOptions> options)
        {
            options.CheckArgumentNull(nameof(options));

            _options = options.Value;

            _options.ResponseValidationEndpoint.CheckMandatoryOption(nameof(_options.ResponseValidationEndpoint));

            _options.JavaScriptUrl.CheckMandatoryOption(nameof(_options.JavaScriptUrl));

            _options.SiteKey.CheckMandatoryOption(nameof(_options.SiteKey));

            _options.SecretKey.CheckMandatoryOption(nameof(_options.SecretKey));

            _controlSettings = _options.ControlSettings ?? new RecaptchaControlSettings();
            _validationMessage = _options.ValidationMessage ?? Resources.Default_ValidationMessage;
            _backChannel = new HttpClient(_options.BackchannelHttpHandler ?? new HttpClientHandler());
            _backChannel.Timeout = _options.BackchannelTimeout;
        }

        public string SiteKey
        {
            get
            {
                return _options.SiteKey;
            }
        }

        public string JavaScriptUrl
        {
            get
            {
                return _options.JavaScriptUrl;
            }
        }

        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
        }
     
        public RecaptchaControlSettings ControlSettings
        {
            get
            {
                return _controlSettings;
            }
        }

        public async Task ValidateResponseAsync(string response, string remoteIp)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, RecaptchaDefaults.ResponseValidationEndpoint);
            var paramaters = new Dictionary<string, string>();
            paramaters["secret"] = _options.SecretKey;
            paramaters["response"] = response;
            paramaters["remoteip"] = remoteIp;
            request.Content = new FormUrlEncodedContent(paramaters);

            var resp = await _backChannel.SendAsync(request);
            resp.EnsureSuccessStatusCode();

            var responseText = await resp.Content.ReadAsStringAsync();

            var validationResponse = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RecaptchaValidationResponse>(responseText));

            if (!validationResponse.Success)
                throw new RecaptchaValidationException(GetErrrorMessage(validationResponse));
        }

        private string GetErrrorMessage(RecaptchaValidationResponse validationResponse)
        {
            var errorList = new List<string>();

            if (validationResponse.ErrorCodes != null)
            {
                foreach (var error in validationResponse.ErrorCodes)
                {
                    switch (error)
                    {
                        case "missing-input-secret":
                            errorList.Add(Resources.ValidateError_MissingInputSecret);
                            break;
                        case "invalid-input-secret":
                            errorList.Add(Resources.ValidateError_InvalidInputSecret);
                            break;
                        case "missing-input-response":
                            errorList.Add(Resources.ValidateError_MissingInputResponse);
                            break;
                        case "invalid-input-response":
                            errorList.Add(Resources.ValidateError_InvalidInputResponse);
                            break;
                        default:
                            errorList.Add(string.Format(Resources.ValidateError_Unknown, error));
                            break;
                    }
                }
            }
            else
            {
                return Resources.ValidateError_UnspecifiedRemoteServerError;
            }

            return string.Join(Environment.NewLine, errorList);
        }
    }
}
