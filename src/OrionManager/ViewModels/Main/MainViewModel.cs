﻿using OrionManager.Interfaces;
using OrionManager.Views.Regions;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel : ViewModelBase<AppSettings, AppCommands>, IInit
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            Container.RegisterInstance(this);
        }

        public GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        public ObservableRangeCollection<GameConfigurationViewModel> GameConfigurations { get; } =
            new ObservableRangeCollection<GameConfigurationViewModel>();

        public void Init()
        {
            NavigateToRegionCommand.Execute(typeof(StartRegion));
        }

        #region IsGameStarted: bool

        public bool IsGameStarted
        {
            get => _isGameStarted;
            set => SetProperty(ref _isGameStarted, value);
        }

        private bool _isGameStarted;

        #endregion

        #region SelectedConfiguration: GameConfigurationViewModel

        public GameConfigurationViewModel SelectedConfiguration
        {
            get => _selectedConfiguration;
            set => SetProperty(ref _selectedConfiguration, value);
        }

        private GameConfigurationViewModel _selectedConfiguration;

        #endregion

        #region CurrentConfiguration: GameConfigurationViewModel

        public GameConfigurationViewModel CurrentConfiguration
        {
            get => _currentConfiguration;
            set => SetProperty(ref _currentConfiguration, value);
        }

        private GameConfigurationViewModel _currentConfiguration;

        #endregion
    }
}