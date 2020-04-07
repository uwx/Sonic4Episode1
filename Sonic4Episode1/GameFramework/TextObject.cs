﻿// Decompiled with JetBrains decompiler
// Type: GameFramework.TextObject
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\wamwo\Documents\GitHub\Sonic4Ep1-WP7-Decompilation\XAP\Sonic4 ep I.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
  public class TextObject : SpriteObject
  {
    private SpriteFont _font;
    private string _text;
    private TextObject.TextAlignment _horizontalAlignment;
    private TextObject.TextAlignment _verticalAlignment;

    public TextObject(Game game)
      : base(game)
    {
      this.ScaleX = 1f;
      this.ScaleY = 1f;
      this.SpriteColor = Color.White;
    }

    public TextObject(Game game, SpriteFont font)
      : this(game)
    {
      this.Font = font;
    }

    public TextObject(Game game, SpriteFont font, Vector2 position)
      : this(game, font)
    {
      this.PositionX = position.X;
      this.PositionY = position.Y;
    }

    public TextObject(Game game, SpriteFont font, Vector2 position, string text)
      : this(game, font, position)
    {
      this.Text = text;
    }

    public TextObject(
      Game game,
      SpriteFont font,
      Vector2 position,
      string text,
      TextObject.TextAlignment horizontalAlignment,
      TextObject.TextAlignment verticalAlignment)
      : this(game, font, position, text)
    {
      this.HorizontalAlignment = horizontalAlignment;
      this.VerticalAlignment = verticalAlignment;
    }

    public SpriteFont Font
    {
      get
      {
        return this._font;
      }
      set
      {
        if (this._font == value)
          return;
        this._font = value;
        this.CalculateAlignmentOrigin();
      }
    }

    public string Text
    {
      get
      {
        return this._text;
      }
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        this.CalculateAlignmentOrigin();
      }
    }

    public TextObject.TextAlignment HorizontalAlignment
    {
      get
      {
        return this._horizontalAlignment;
      }
      set
      {
        if (this._horizontalAlignment == value)
          return;
        this._horizontalAlignment = value;
        this.CalculateAlignmentOrigin();
      }
    }

    public TextObject.TextAlignment VerticalAlignment
    {
      get
      {
        return this._verticalAlignment;
      }
      set
      {
        if (this._verticalAlignment == value)
          return;
        this._verticalAlignment = value;
        this.CalculateAlignmentOrigin();
      }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.Font == null || this.Text == null || this.Text.Length <= 0)
        return;
      spriteBatch.DrawString(this.Font, this.Text, this.Position, this.SpriteColor, this.Angle, this.Origin, this.Scale, SpriteEffects.None, this.LayerDepth);
    }

    public override Rectangle BoundingBox
    {
      get
      {
        Vector2 vector2 = this.Font.MeasureString(this.Text);
        Rectangle rectangle = new Rectangle((int) this.PositionX, (int) this.PositionY, (int) ((double) vector2.X * (double) this.ScaleX), (int) ((double) vector2.Y * (double) this.ScaleY));
        rectangle.Offset((int) (-(double) this.OriginX * (double) this.ScaleX), (int) (-(double) this.OriginY * (double) this.ScaleY));
        return rectangle;
      }
    }

    private void CalculateAlignmentOrigin()
    {
      if (this.HorizontalAlignment == TextObject.TextAlignment.Manual && this.VerticalAlignment == TextObject.TextAlignment.Manual || (this.Font == null || this.Text == null) || this.Text.Length == 0)
        return;
      Vector2 vector2 = this.Font.MeasureString(this.Text);
      switch (this.HorizontalAlignment)
      {
        case TextObject.TextAlignment.Near:
          this.OriginX = 0.0f;
          break;
        case TextObject.TextAlignment.Center:
          this.OriginX = vector2.X / 2f;
          break;
        case TextObject.TextAlignment.Far:
          this.OriginX = vector2.X;
          break;
      }
      switch (this.VerticalAlignment)
      {
        case TextObject.TextAlignment.Near:
          this.OriginY = 0.0f;
          break;
        case TextObject.TextAlignment.Center:
          this.OriginY = vector2.Y / 2f;
          break;
        case TextObject.TextAlignment.Far:
          this.OriginY = vector2.Y;
          break;
      }
    }

    public enum TextAlignment
    {
      Manual,
      Near,
      Center,
      Far,
    }
  }
}
