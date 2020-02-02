using System;
using System.Windows.Media.Animation;

namespace ChatAplicationFaseto
{
    public static class StoryBoardHelper
    {
        /// <summary>
        /// add slide and fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">Storyboard to animate to</param>
        /// <param name="seconds">duration of animation</param>
        /// <param name="offset">distance to the right to start from</param>
        /// <param name="decelaration">decelaration rate</param>
        /// <param name=""></param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelaration = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),

                From = new System.Windows.Thickness(offset, 0, -offset, 0),


                To = new System.Windows.Thickness(0),

                DecelerationRatio = 0.9f


            };

            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }


        public static void FadeIn(this Storyboard storyboard, float seconds)
        {
            var slideAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds))
            };

            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Opacity"));
            storyboard.Children.Add(slideAnimation);
        }






        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelaration = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds)),

                From = new System.Windows.Thickness(0),


                To = new System.Windows.Thickness(-offset, 0, offset, 0),

                DecelerationRatio = 0.9f


            };

            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void FadeOut(this Storyboard storyboard, float seconds)
        {
            var slideAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new System.Windows.Duration(TimeSpan.FromSeconds(seconds * 0.4))

            };

            Storyboard.SetTargetProperty(slideAnimation, new System.Windows.PropertyPath("Opacity"));
            storyboard.Children.Add(slideAnimation);
        }

    }
}
