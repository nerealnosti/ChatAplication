using ChatAplicationFaseto.DataModels;
using ChatAplicationFaseto.VeiwModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ChatAplicationFaseto.VeiwModel
{
    /// <summary>
    /// View model for custom flat window
    /// </summary>
    class WindowViewModel:BaseViewModel
    {
        #region PrivateProp
        /// <summary>
        /// Window for this view model control
        /// </summary>
        private Window Window;


        /// <summary>
        /// Margin around the window to allow to drop shadow
        /// </summary>
        private int outerMargin = 10;

        

        /// <summary>
        /// The radius of the egges of the window
        /// </summary>
        private int WindowsRadius = 10;

        
        
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            Window = window;
            Window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowsRadiusSize));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeWindow = new RelayCommand(() => Window.WindowState = WindowState.Minimized);
            MaximizeWindow = new RelayCommand(() => Window.WindowState ^= WindowState.Maximized);
            CloseWindow = new RelayCommand(() => Window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(Window, Window.PointToScreen(Mouse.GetPosition(Window))));
            
        }



        #endregion

        #region Commands
        public ICommand MinimizeWindow { get; set; }
        public ICommand CloseWindow { get; set; }
        public ICommand MaximizeWindow { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region PublicProp

        public ApplicationPage CurrnetPage { get; set; } = ApplicationPage.Login;

        public double MinWith { get; set; }
        public double MinHeight { get; set; }

        public int ResizeBorder { get { return BorderLess ? 0 : 6; } }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public Thickness innerContentThickeness { get; set; } = new Thickness(0);


        public bool BorderLess { get { return Window.WindowState == WindowState.Maximized; } }

        /// <summary>
        /// Margin around the window to allow to drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return Window.WindowState == WindowState.Maximized ? 0 : outerMargin; }
            set { OuterMarginSize = value; }
        }

        

        public int WindowsRadiusSize
        {
            get { return Window.WindowState == WindowState.Maximized ? 0 : WindowsRadius; }
            set { WindowsRadius = value; }
        }

        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(outerMargin); }
            
        }

        public int LargeFontSize { get; set; } = 34;

        public double RegularFontSize { get; set; } = 20;

        public double SmallFontSize { get; set; } = 4;



        public CornerRadius WindowCornerRadius { get { return new CornerRadius(OuterMarginSize); } }

        public int TitleHeight { get; set; } = 32;

        public GridLength TitleHeightGridLenth { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion
    }
}
