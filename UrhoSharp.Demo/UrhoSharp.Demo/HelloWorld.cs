using System;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;
using Urho.Gui;

namespace UrhoSharp.Demo
{
    public class HelloWorld : Application
    {
        int counter = 0;
        Scene scene;
        Camera camera;
        Node worldNode;

        //public HelloWorld() { }
        public HelloWorld(ApplicationOptions options) : base(options) { }

        protected override void Start()
        {
            base.Start();

            CreateScene();
            CreateText();
            SetupViewport();
        }

        void CreateScene()
        {
            // Create a top-level scene, must add the Octree
            // to visualize any 3D content.
            scene = new Scene();
            scene.CreateComponent<Octree>();

            // Camera
            var cameraNode = scene.CreateChild("Camera");
            camera = cameraNode.CreateComponent<Camera>();

            // Set camera orthographic
            camera.Orthographic = true;

            // Set camera ortho size (the value of PIXEL_SIZE is 0.01)
            var PIXEL_SIZE = 0.01f;
            camera.SetOrthoSize(new Vector2(20, 20));
            //camera.SetOrthoSize(0.01f);
            //camera.SetOrthoSize((float)500f * PIXEL_SIZE);

            // Light
            Node lightNode = cameraNode.CreateChild(name: "light");
            var light = lightNode.CreateComponent<Light>();
            light.LightType = LightType.Point;
            light.Range = 100;
            light.Brightness = 1.3f;

            worldNode = scene.CreateChild();
            worldNode.Position = new Vector3(0, 0, 5);
            worldNode.Rotation = new Quaternion(60, 0, 30);
            worldNode.SetScale(10f);

            // Add Pyramid Model
            StaticModel modelObject = worldNode.CreateComponent<StaticModel>();
            modelObject.Model = ResourceCache.GetModel("Models/Pyramid.mdl");

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

        void SetupViewport()
        {
            // Viewport
            Renderer.SetViewport(0, new Viewport(scene, camera, null));
        }

        internal void AddSampleNodes()
        {
            // NOTE UrhoSharp - Sending events is only supported from the main thread
            Urho.Application.InvokeOnMain(() =>
            {
                CreateText();
            });
        }

        internal async void RotateWorld(float angle)
        {
            await worldNode.RunActionsAsync(new RepeatForever(
                new RotateBy(duration: 1, deltaAngleX: 0, deltaAngleY: angle, deltaAngleZ: 0)));
            //worldNode.Rotate2D(angle, );
        }
    }
}
