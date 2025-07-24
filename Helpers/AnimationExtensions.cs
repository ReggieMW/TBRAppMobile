using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Threading.Tasks;


//this helper is for animations on buttons, making them more dynamic so the user recognizes clicks/taps
namespace TBRAppMobile.Helpers
{
    public static class AnimationExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing? easing = null)
        {
            easing ??= Easing.Linear;

            var animation = new Animation(v =>
            {
                var r = fromColor.Red + (toColor.Red - fromColor.Red) * v;
                var g = fromColor.Green + (toColor.Green - fromColor.Green) * v;
                var b = fromColor.Blue + (toColor.Blue - fromColor.Blue) * v;
                var a = fromColor.Alpha + (toColor.Alpha - fromColor.Alpha) * v;
                callback(Color.FromRgba(r, g, b, a));
            });

            return self.AnimateAsync("ColorTo", animation, 16, length, easing);
        }

        public static Task<bool> AnimateAsync(this VisualElement element, string name, Animation animation, uint rate, uint length, Easing easing)
        {
            var tcs = new TaskCompletionSource<bool>();

            animation.Commit(element, name, rate, length, easing, (v, c) => tcs.SetResult(c));

            return tcs.Task;
        }
    }
}
