﻿using System;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;
using Urho.Gui;

namespace UrhoSharp.Demo
{
    public class HelloWorld : Application
    {
        int counter = 0;

        //public HelloWorld() { }
        public HelloWorld(ApplicationOptions options) : base(options) { }

        protected override void Start()
        {
            base.Start();

            CreateText();
        }

        private void CreateText()
        {
            counter++;

            // Create Text Element
            var text = new Text()
            {
                Value = "Hello World!" + counter,
                Position = new IntVector2(100, 100 + counter * 100),
                //HorizontalAlignment = HorizontalAlignment.Center,
                //VerticalAlignment = VerticalAlignment.Center
            };

            text.SetColor(Color.Cyan);
            text.SetFont(font: ResourceCache.GetFont("Fonts/Anonymous Pro.ttf"), size: 30);
            // Add to UI Root
            UI.Root.AddChild(text);

        }

        internal void AddSampleNodes()
        {
            // NOTE UrhoSharp - Sending events is only supported from the main thread
            Urho.Application.InvokeOnMain(() =>
            {
                CreateText();
            });
        }
    }
}
