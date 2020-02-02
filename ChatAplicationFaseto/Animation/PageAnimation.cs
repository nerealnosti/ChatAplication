using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatAplicationFaseto.Animation
{
    public static class PageAnimation
    {
        public static async Task SlideAndFadeInFromRight(this Page page,float sec)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(sec, page.WindowWidth);


            sb.FadeIn(sec);


            sb.Begin(page);
            page.Visibility = System.Windows.Visibility.Visible;
        }


        public static async Task SlideAndFadeInToLeft(this Page page, float sec)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(sec, page.WindowWidth);


            sb.FadeOut(sec);


            sb.Begin(page);
            page.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
