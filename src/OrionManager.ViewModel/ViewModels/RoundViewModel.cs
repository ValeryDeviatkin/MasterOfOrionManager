﻿using OrionManager.Common.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModel.ViewModels
{
    public class RoundViewModel : ObservableObject
    {
        public int Number { get; set; }

        #region State: RoundState

        public RoundStates State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private RoundStates _state;

        #endregion
    }
}