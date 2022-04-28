/*
	TUIO C# Demo - part of the reacTIVision project
	http://reactivision.sourceforge.net/

	Copyright (c) 2005-2009 Martin Kaltenbrunner <martin@tuio.org>

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
*/

using System;

using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TUIO;

	public class TuioDemoObject : TuioObject
	{

		SolidBrush black = new SolidBrush(Color.Green);
		SolidBrush white = new SolidBrush(Color.Red);
	Timer ttk= new Timer();

		public TuioDemoObject (long s_id, int f_id, float xpos, float ypos, float angle) : base(s_id,f_id,xpos,ypos,angle) {

		}


		public TuioDemoObject (TuioObject o) : base(o) {
		ttk.Start();
        ttk.Tick += Ttk_Tick;
		
	
		}
	public int ct = 0;
	public void check(int x ,int y,int s)
	{
		
		
		if (symbol_id == 21)
		{
			if(x-s>470&&x-s<620&&y-s>250&&y-s<400)
				{
				ct = 1;
				//MessageBox.Show("in mate");
			}
		}
		if (symbol_id == 22)
		{
			if (x - s > 30 && x - s < 170 && y - s > 250 && y - s < 400)
			{
				ct = 2;
				//MessageBox.Show("in mate");
			}
		}

	}
    private void Ttk_Tick(object sender, EventArgs e)
    {
		//check();
		MessageBox.Show("int");
		//paint(g2);
    }
	int p1 = 470,p3=170, p2 = 250,f=0;
	

    //
    Bitmap img1 = new Bitmap("C:/Users/jhonm/Downloads/21.jpg");
	//img1.MakeTransparent(img1.GetPixel(0, 0));

		Bitmap img2 = new Bitmap("C:/Users/jhonm/Downloads/22.jpg");
	//img2.MakeTransparent(img2.GetPixel(0, 0));
	public void paint(Graphics g,ref int l1,ref int l2) {
		if (ct == 1)
		{
			if (p1 <= 160)
			{
				//MessageBox.Show("player one won");
				ct = 0;
				p1 = 470; p3 = 170; p2 = 250;
				l1--;
			}
			g.FillEllipse(black, new Rectangle(p1, p2, 30, 30));
			p1 -= 4;
			if (p1 > 295)
			{ 
				p2 -= 1; }
			else
			{	p2 += 2;
				
		}
			
		}
		if (ct == 2)
		{
			if (p3 >= 480)
			{
				ct = 0;
				p1 = 470; p3 = 170; p2 = 250;
				//MessageBox.Show("player two won");
				l2--;
			}
			g.FillEllipse(white, new Rectangle(p3, p2, 30, 30));
			p3 += 4;
			if (p3 > 295)
			{
				p2 += 2;
			}
			else
			{
				p2 -= 2;

			}

		}
		//g.Clear(Color.Gray);
		int Xpos = (int)(xpos*TuioDemo.width);
			int Ypos = (int)(ypos*TuioDemo.height);
			int size = TuioDemo.height/10;
		
		g.TranslateTransform(Xpos,Ypos);
			g.RotateTransform((float)(angle/Math.PI*180.0f));
			g.TranslateTransform(-1*Xpos,-1*Ypos);
		if (symbol_id == 21)
		{
			check(Xpos, Ypos,size);
			g.FillEllipse(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));
		}
		else if (symbol_id == 22)
		{
			check(Xpos, Ypos, size);
			g.FillEllipse(white, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));
		}
		else {
			g.FillRectangle(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size , size));
			Font font = new Font("Arial", 10.0f);
			g.DrawString(symbol_id+" Hi man ",font, white, new PointF(Xpos-10,Ypos-10));
		}
		g.TranslateTransform(Xpos,Ypos);
			g.RotateTransform(-1*(float)(angle/Math.PI*180.0f));
			g.TranslateTransform(-1*Xpos,-1*Ypos);

			
		}

	}
