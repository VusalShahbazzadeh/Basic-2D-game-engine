using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ExpressedEngine.ExpressedEngine
{
	public class Sprite2D
	{
		public Vector2 Position = null;
		public Vector2 Scale = null;
		public string Directory = "";
		public string Tag = "";
		public Bitmap Sprite = null;

		public Sprite2D(Vector2 Position, Vector2 Scale, string Directory, string Tag)
		{
			this.Position = Position;
			this.Scale = Scale;
			this.Directory = Directory;
			this.Tag = Tag;

			Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
			Bitmap sprite = new Bitmap(tmp,(int)this.Scale.X, (int)this.Scale.Y);

			Sprite = sprite;
			
			Log.Info($"[SHAPE2D]({Tag}) - Has been registered! ");
			ExpressedEngine.RegisterSprite(this);
		}

		public bool IsColliding(string tag)
		{
			/*
			if (a.Position.X < b.Position.X+b.Scale.X&&
				a.Position.X+a.Scale.X>b.Position.X&&
				a.Position.Y < b.Position.Y  + b.Scale.Y &&
				a.Position.Y + a.Scale.Y > b.Position.Y
				)
				return true;*/
			foreach (Sprite2D b in ExpressedEngine.AllSprites)
			{
				if(b.Tag == tag)
				{
					if (Position.X < b.Position.X + b.Scale.X &&
					Position.X + Scale.X > b.Position.X &&
					Position.Y < b.Position.Y + b.Scale.Y &&
					Position.Y + Scale.Y > b.Position.Y
					)
						return true;
				}
			}
			return false;
		}

		public void DestroySelf()
		{
			ExpressedEngine.UnRegisterSprite(this);
		}
	}
}
