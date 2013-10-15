using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame
{
    class RaceGame : Microsoft.Xna.Framework.Game
    {
        private static int FPS = 60;

        private Map map;
        private UI ui;
        private Controller controller;
        private View view;
        private List<Entity> entities;
        private bool running;
        private int nextTick;

        public RaceGame()
        {
            running = false;
            map=new Map();
            ui=new UI(this);
            controller=new Controller(this);
            view=new View(this);
        }

        public void render() {
            map.render(view);
            foreach (Entity entity in entities) {
                entity.render(view);
            }
        }

        public void update(int dt) {
            Collision.CheckMapCollisions(dt, map, entities);
            Collision.CheckEntityCollisions(dt, entities);

            foreach (Entity entity in entities) {
                if (!entity.update(dt, controller)) {
                    entities.Remove(entity);
                }
            }
        }

        public void run()
        {
            nextTick = Environment.TickCount + 1000 / FPS;
            int currentTick=Environment.TickCount;
            int lastTick = currentTick;
            running = true;
            while (running) {
                do {
                    update(currentTick - lastTick);
                    lastTick = currentTick;
                } while ((currentTick = Environment.TickCount) < nextTick);
                render();
                nextTick += 1000 / FPS;
            }
        }

        public Map Map {
            get {
                return map;
            }
            set {
                map = value;
            }
        }

        public UI UI {
            get {
                return ui;
            }
            set {
                ui = value;
            }
        }
        public Controller Controller {
            get {
                return controller;
            }
            set {
                controller = value;
            }
        }
        public View View {
            get {
                return view;
            }
            set {
                view = value;
            }
        }
        public List<Entity> Entities {
            get {
                return entities;
            }
        }
    }
}
