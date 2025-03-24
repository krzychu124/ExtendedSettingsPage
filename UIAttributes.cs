using System;
using Game.Input;
using Game.Settings;

namespace ExtendedSettingsPage
{
    public static class UIAttributes
    {
        
        /// <summary>
        /// Extends vanilla [SettingsUIKeyboardBinding] with an icon (partial constructor support - example implementation)
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class CustomUIExtendedKeybindingAttribute : SettingsUIKeyboardBindingAttribute
        {
            public readonly string icon;
            
            public CustomUIExtendedKeybindingAttribute(
                string icon,
                BindingKeyboard defaultKey,
                string actionName = null,
                bool alt = false,
                bool ctrl = false,
                bool shift = false)
                : base(defaultKey, actionName, alt, ctrl, shift)
            {
                this.icon = icon;
            }
        }
    }
}
