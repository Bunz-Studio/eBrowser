using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace eBrowser
{
    public class Themer
    {
        public ColorScheme Scheme { get; set; } = new ColorScheme();

        public void Apply(Control control)
        {
        }

        public static List<Control> GetControls(Control control)
        {
            var list = new List<Control>();
            foreach (Control c in control.Controls)
            {
                var controls = GetControls(c);
                list.AddRange(controls);
            }
            list.Add(control);
            return list;
        }
    }

    public class ColorScheme
    {
        public Color Background = Color.FromArgb(255, 0, 45, 85);
        public Color Foreground = Color.White;
        public Color LinkForeground = Color.FromArgb(255, 180, 199, 209);

        public Color BackgroundDark = Color.FromArgb(255, 2, 15, 35);
        public Color BackgroundLight = Color.FromArgb(255, 31, 60, 103);
        public Color BackgroundLighter = Color.FromArgb(255, 42, 70, 111);

        public Color Success = Color.FromArgb(255, 62, 146, 90);
        public Color Failed = Color.FromArgb(255, 228, 95, 95);
        public Color Download = Color.FromArgb(255, 160, 82, 45);

        public Color Copyright = Color.FromArgb(255, 221, 0, 221);
        public Color Species = Color.FromArgb(255, 202, 93, 31);
        public Color Artist = Color.FromArgb(255, 206, 172, 8);

        public Color Safe = Color.FromArgb(255, 55, 158, 73);
        public Color Questionable = Color.FromArgb(255, 255, 230, 102);
        public Color Explicit = Color.FromArgb(255, 228, 85, 116);
    }
}
