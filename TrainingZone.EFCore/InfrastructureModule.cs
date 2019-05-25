using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Interfaces;
using TrainingZone.Core.Interfaces.Services;
using TrainingZone.EFCore.Auth;
using TrainingZone.EFCore.Repositories;

namespace TrainingZone.EFCore
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<ScoreRepository>().As<IScoreRepository>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
        }
    }
}
