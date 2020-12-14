﻿using System;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class StartNewRoundCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public StartNewRoundCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            var game = _container.Resolve<GameDataViewModel>();

            if (game.Round == game.Rounds.Length)
            {
                throw new NotSupportedException();
            }

            game.Rounds[game.Round].State = RoundStates.Passed;
            game.Round++;
            game.Rounds[game.Round].State = RoundStates.Current;
            game.UpdateIsGameCanBeFinished();
        }
    }
}