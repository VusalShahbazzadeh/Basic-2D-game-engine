using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressedEngine.ExpressedEngine;
using System.Drawing;
using System.Windows.Forms;

namespace ExpressedEngine
{
	class DemoGame : ExpressedEngine.ExpressedEngine
	{
		bool left, right, up, down;


		public DemoGame() : base(new Vector2(615, 515), "Expressed Engine Demo") { }
		Sprite2D player;
		Sprite2D player2;

		Vector2 lastPos = Vector2.Zero();

		string[,] Map =
		{
			{"g","g","g","g","g","g","g" },
			{"g","c","c","c","c","c","g" },
			{"g","c","c","c","g","c","g" },
			{"g","c","g","g","g","c","g" },
			{"g","c","g","c","g","c","g" },
			{"g","c","g","c","c","c","g" },
			{"g","g","g","g","g","g","g" }
		};


		public override void OnLoad()
		{
			BackgroundColor = Color.Black;

			//player = new Sprite2D(new Vector2(10, 10), new Vector2(91, 80),"Players/skull" , "Player");
			for (int i = 0; i < Map.GetLength(1); i++)
			{
				for (int j = 0; j < Map.GetLength(0); j++)
				{
					if (Map[j, i] == "g")
						new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Tiles/ground", "Ground");
					if (Map[j, i] == "c")
						new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Collectables/star", "Coin");
				}
			}

			player = new Sprite2D(new Vector2(50, 50), new Vector2(40, 40), "Players/skull", "Player");
			//player2 = new Sprite2D(new Vector2(100, 0), new Vector2(200, 200), "Players/skull", "Player2");

		}
		public override void OnDraw()
		{
		}
		int times = 0;
		public override void OnUpdate()
		{
			if (up)
			{
				player.Position.Y -= 1f;
			}
			if (down)
			{

				player.Position.Y += 1f;
			}
			if (left)
			{
				player.Position.X  -= 1f;

			}
			if (right)
			{
				player.Position.X  += 1f;
			}
			if (player.IsColliding("Ground"))
			{
				//times++;
				//Log.Info($"Colliding {times}");
				player.Position = lastPos.Copy();
			}
			else
			{
				lastPos = player.Position.Copy();
			}
				


		}

		public override void GetKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.W) up = true;
			if (e.KeyCode == Keys.S) down = true;
			if (e.KeyCode == Keys.A) left = true;
			if (e.KeyCode == Keys.D) right = true;
		}
		public override void GetKeyUp(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.W) up = false;
			if (e.KeyCode == Keys.S) down = false;
			if (e.KeyCode == Keys.A) left = false;
			if (e.KeyCode == Keys.D) right = false;
		}
	}
	
}
