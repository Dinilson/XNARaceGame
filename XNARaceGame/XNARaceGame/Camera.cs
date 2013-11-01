using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNARaceGame {
    class Camera {
        private Viewport viewport;
        public Viewport viewportCopy;
        private int x;
        private int y;
        private int width;
        private int height;
        public float scale { get; set; }
        public Vector2 coords { get; set; }
        private Vector2 nextCoords;

        public Camera(Viewport viewport, int x, int y, int width, int height, float scale) {
            coords = new Vector2(0, 0);
            this.viewport = viewport;
            viewportCopy = viewport;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;
        }

        public void preUpdate() {
            coords = nextCoords;
            viewportCopy = viewport;
            Viewport vp = viewport;
            vp.X = x;
            vp.Y = y;
            vp.Width = width;
            vp.Height = height;
            viewport = vp;
            viewport = viewportCopy;
        }

        public void postUpdate() {
            viewport = viewportCopy;
        }

        public void setCoords(Vector2 coords) {
            nextCoords = Vector2.Subtract(coords * scale, new Vector2(width / 2, height / 2));
            nextCoords = Vector2.Clamp(nextCoords, new Vector2((-1920 / 2) * scale / 2 - width / 2, (-1080 / 2) * scale / 2 - height / 2), new Vector2(width / 2, height / 2));
            nextCoords = coords;
        }
    }
}
