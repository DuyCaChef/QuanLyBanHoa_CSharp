using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHoa.UI
{
    // Simple flat renderer to keep ToolStrip background and selection readable on blue bar
    public class FlatToolStripRenderer : ToolStripProfessionalRenderer
    {
        public FlatToolStripRenderer() : base(new FlatColors())
        {
            RoundedEdges = false;
        }
    }

    internal class FlatColors : ProfessionalColorTable
    {
        // Gradient màu thanh chính
        public override Color ToolStripGradientBegin => Color.FromArgb(41, 128, 185);
        public override Color ToolStripGradientMiddle => Color.FromArgb(41, 128, 185);
        public override Color ToolStripGradientEnd => Color.FromArgb(41, 128, 185);
        public override Color MenuStripGradientBegin => Color.FromArgb(41, 128, 185);
        public override Color MenuStripGradientEnd => Color.FromArgb(41, 128, 185);

        // Item hover / pressed
        public override Color MenuItemSelected => Color.FromArgb(33, 97, 140);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(33, 97, 140);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(33, 97, 140);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(33, 97, 140);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(33, 97, 140);
        public override Color MenuItemBorder => Color.FromArgb(41, 128, 185);

        // Dropdown background
        public override Color ToolStripDropDownBackground => Color.White;
        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
    }
}
