using ChatAplicationFaseto.Animation;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatAplicationFaseto
{
    public class BasePageAnimation : Page
    {

        #region Property
        public PageSlide PageLoad { get; set; } = PageSlide.SlideinFromRight;
        public PageSlide PageUnload { get; set; } = PageSlide.SlideOutToLeft;

        public float SlideSec { get; set; } = 1.5f;
        #endregion

        #region Constructor
        public BasePageAnimation()
        {
            this.Loaded += BasePageAnimation_Loaded;
            this.Visibility = System.Windows.Visibility.Collapsed;
        } 
        #endregion

        private async void BasePageAnimation_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
           
                await AnimateIn();
            

        }

        public async Task AnimateIn()
        {
            if (this.PageLoad == PageSlide.NOne) return;

            switch (this.PageLoad)
            {
                case PageSlide.NOne:
                    break;

                case PageSlide.SlideinFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSec);
                    break;

                case PageSlide.SlideOutToLeft:
                    await this.SlideAndFadeInToLeft(this.SlideSec); 
                    break;

                default:
                    break;
            }

        }

        


        
    }
}
