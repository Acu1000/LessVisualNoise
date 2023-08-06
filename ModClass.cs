using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UObject = UnityEngine.Object;

namespace LessVisualNoise
{
    public class LessVisualNoise : Mod
    {
        internal static LessVisualNoise Instance;

        //public override List<ValueTuple<string, string>> GetPreloadNames()
        //{
        //    return new List<ValueTuple<string, string>>
        //    {
        //        new ValueTuple<string, string>("White_Palace_18", "White Palace Fly")
        //    };
        //}

        public override string GetVersion() => "v1.0.7.0";


        public LessVisualNoise() : base("LessVisualNoise")
        {
            Instance = this;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            On.GameManager.OnNextLevelReady += OnSceneLoad;
        }

        public void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);
            CreateBlackBackground();
            RemoveBackgroundObjects();
        }

        private void CreateBlackBackground()
        {
            var blurPlane = GameObject.Find("BlurPlane");
            if (blurPlane != null)
            {
                blurPlane.SetActive(false);
            }

            var black = GameObject.CreatePrimitive(PrimitiveType.Plane);
            black.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Sprites/Default"))
            {
                color = new Color(0, 0, 0, 255)
            };
            black.transform.position = new UnityEngine.Vector3(0f, 0f, 2f);
            black.transform.localScale = new UnityEngine.Vector3(1000f, 1f, 1000f);
            black.transform.rotation = UnityEngine.Quaternion.Euler(90f, 180f, 0f);
        }

        private void RemoveBackgroundObjects() // TODO
        {

            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            
        }

    }
}