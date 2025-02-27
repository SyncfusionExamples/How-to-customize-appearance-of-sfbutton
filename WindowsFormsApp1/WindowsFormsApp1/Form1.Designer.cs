using System.Drawing.Drawing2D;
using System.Drawing;
using Syncfusion.WinForms.Controls;
using System;
using Syncfusion.Drawing;
using Syncfusion.WinForms.Controls.Styles;
using Syncfusion.Windows.Forms;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Tracks the button's pressed and hovered states
        private bool isPressed = false;
        private bool isHovered = false;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // sfButton1
            // 
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(280, 152);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(96, 28);
            this.sfButton1.TabIndex = 0;
            this.sfButton1.Text = "sfButton1";

            //Customize the button's border colors for different states
            this.sfButton1.Style.HoverBorder = new Pen(Color.Green);
            this.sfButton1.Style.PressedBorder = new Pen(Color.Blue);
            this.sfButton1.Style.DisabledBorder = new Pen(Color.Yellow);
            this.sfButton1.Style.FocusedBorder = new Pen(Color.Red);

            //Set the defult background and foreground colors
            sfButton1.Style.BackColor = Color.Gray; 
            sfButton1.Style.ForeColor = Color.Black;

            //Customize the button's colors for hover,focus,pressed and disabled states
            sfButton1.Style.HoverBackColor = Color.White;
            sfButton1.Style.HoverForeColor = Color.Green;

            sfButton1.Style.FocusedBackColor = Color.White;
            sfButton1.Style.FocusedForeColor = Color.Black;

            sfButton1.Style.PressedBackColor = Color.White;
            sfButton1.Style.PressedForeColor = Color.Black;

            sfButton1.Style.DisabledBackColor = Color.DarkGray;
            sfButton1.Style.DisabledForeColor = Color.Black;

            //Attach event handlers for custom painting and mouse interactions
            this.sfButton1.Paint += SfButton1_Paint;
            this.sfButton1.MouseDown += SfButton1_MouseDown;
            this.sfButton1.MouseHover += SfButton1_MouseHover;
            this.sfButton1.MouseLeave += SfButton1_MouseLeave;
            this.sfButton1.MouseUp += SfButton1_MouseUp;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sfButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        //Event handler for Mouseup Event
        private void SfButton1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            sfButton1.Invalidate();
        }

        //Event handler for MouseLeave Event
        private void SfButton1_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            sfButton1.Invalidate();
        }

        //Event handler for MouseHover Event
        private void SfButton1_MouseHover(object sender, EventArgs e)
        {
            isHovered = true;
            sfButton1.Invalidate();
        }

        //Event handler for MouseDown Event
        private void SfButton1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            sfButton1.Invalidate();
        }

        //Event handler for Paint Event
        private void SfButton1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Rounded rectangle corder radius. The radius must be less than 10.
            int radius = 5;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(
             this.sfButton1.ClientRectangle.X + 1,
             this.sfButton1.ClientRectangle.Y + 1,
             this.sfButton1.ClientRectangle.Width - 2,
             this.sfButton1.ClientRectangle.Height - 2
            );
            sfButton1.Region = new Region(GetRoundedRect(rect, radius));
            rect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);

            Pen borderPen;

            if (!sfButton1.Enabled) // Disabled state
            {
                borderPen = new Pen(sfButton1.Style.DisabledBorder.Color);
            }
            else if (isPressed) // Pressed state (based on MouseDown)
            {
                borderPen = new Pen(sfButton1.Style.PressedBorder.Color);
            }
            else if (isHovered) // Hover state (based on MouseHover)
            {
                borderPen = new Pen(sfButton1.Style.HoverBorder.Color);
            }
            else // Focused state
            {
                borderPen = new Pen(sfButton1.Style.FocusedBorder.Color);
            }

            // Draw the path with the determined border color
            e.Graphics.DrawPath(borderPen, GetRoundedRect(rect, radius));

        }

        //Helper method to create a rounded rectangle path
        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            // Top-left corner
            graphicsPath.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);

            // Top edge
            graphicsPath.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y);

            // Top-right corner
            graphicsPath.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);

            // Right edge
            graphicsPath.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom - radius);

            // Bottom-right corner
            graphicsPath.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);

            // Bottom edge
            graphicsPath.AddLine(rect.Right - radius, rect.Bottom, rect.X + radius, rect.Bottom);

            // Bottom-left corner
            graphicsPath.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);

            // Left edge
            graphicsPath.AddLine(rect.X, rect.Bottom - radius, rect.X, rect.Y + radius);

            // Close the figure to complete the path
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton sfButton1;
    }
}

