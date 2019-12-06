﻿using OnlineServices.Shared.TranslationServices;
using Serilog;
using System;
using TranslationServices.DataLayer.ServiceAgents;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem : ITRSOnlineServicesSystem
    {
        private readonly ILogger logger;
        private readonly ITRSTranslationService Translator;

        public OnlineServicesSystem(ILogger logger, ITRSTranslationService Translator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (Translator is null)
            {
                var exceptionMSG = $"ITRSTranslationService should not be null. {nameof(Translator)} @ CTOR in OnlineServicesSystem";
                logger.Error(exceptionMSG);
                throw new ArgumentNullException(nameof(Translator));
            }
            else
                this.Translator = Translator;
        }
    }
}
