// File: Behaviors/ButtonPressAnimationBehavior.cs
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using TBRAppMobile.Helpers;

namespace TBRAppMobile.Behaviors
{
    public class ButtonPressAnimationBehavior : Behavior<Button>
    {
        public uint PressDuration { get; set; } = 90;
        public double PressScale { get; set; } = 0.96;

        public uint ClickFlashDuration { get; set; } = 180;

        public Color? FlashColor { get; set; }  // optional override

        Color? _originalBg;
        Button? _button;

        protected override void OnAttachedTo(Button button)
        {
            base.OnAttachedTo(button);
            _button = button;
            _originalBg = button.BackgroundColor;

            button.Pressed += OnPressed;
            button.Released += OnReleased;
            button.Clicked += OnClicked;
            button.PropertyChanged += OnButtonPropertyChanged; // instead of IsEnabledChanged
        }

        protected override void OnDetachingFrom(Button button)
        {
            base.OnDetachingFrom(button);
            button.Pressed -= OnPressed;
            button.Released -= OnReleased;
            button.Clicked -= OnClicked;
            button.PropertyChanged -= OnButtonPropertyChanged;
            _button = null;
        }

        void OnButtonPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_button is null) return;
            if (e.PropertyName == nameof(Button.IsEnabled) && !_button.IsEnabled)
            {
                _ = _button.ScaleTo(1.0, 80);
            }
        }

        async void OnPressed(object? sender, EventArgs e)
        {
            if (_button is null) return;
            try { await _button.ScaleTo(PressScale, PressDuration, Easing.CubicOut); }
            catch { /* ignore */ }
        }

        async void OnReleased(object? sender, EventArgs e)
        {
            if (_button is null) return;
            try { await _button.ScaleTo(1.0, PressDuration, Easing.CubicIn); }
            catch { /* ignore */ }
        }

        async void OnClicked(object? sender, EventArgs e)
        {
            if (_button is null) return;

            var from = _button.BackgroundColor ?? Colors.Transparent;
            var to = FlashColor ?? Colors.White.WithAlpha(0.35f);

            try
            {
                await _button.ColorTo(from, to, c => _button.BackgroundColor = c, ClickFlashDuration / 2, Easing.CubicOut);
                await _button.ColorTo(to, from, c => _button.BackgroundColor = c, ClickFlashDuration / 2, Easing.CubicIn);
            }
            catch { /* ignore */ }
        }
    }
}
