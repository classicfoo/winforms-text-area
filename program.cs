using System;
using System.Windows.Forms;
using System.Drawing;

public class Program
{
	public static void Main(string[] args)
	{
		Application.Run(new MainForm(args));
	}
}

public class MainForm: Form
{
	RichTextBox rtb1;

	public MainForm(string[] args)
	{
		var padding = 10;
		var p = new Point(padding, padding);
		var text = args.Length == 1 ? args[0] : "label";
		var label1 = new Label() { Location=p, Text=text } ;

		p.Offset(0, label1.Height);
		var width = this.ClientSize.Width - ( 2 * padding );
		var anchors = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom);
		rtb1 = new RichTextBox() { Location=p, Anchor=anchors, AutoSize=false, Width=width, Height=200 };

		p.Offset(this.ClientSize.Width-(new Button().Width + (2 *padding)),rtb1.Height + padding);
		var btn1 = new Button() { Location=p, Text="OK", Anchor=(AnchorStyles.Right | AnchorStyles.Bottom) };
		btn1.Click += btn1_clicked;

		this.Controls.Add(label1);
		this.Controls.Add(rtb1);
		this.Controls.Add(btn1);
	}

	public void btn1_clicked(Object sender, EventArgs e)
	{
		Console.WriteLine(rtb1.Text);
		this.Close();
	}
}
