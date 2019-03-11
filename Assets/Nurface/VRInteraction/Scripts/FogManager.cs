using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour {
    [SerializeField] private float lower_bound, upper_bound, speed;
    private bool axis;

    private void FixedUpdate() {
        ClampFog(lower_bound, upper_bound, speed);
    }


    /// <summary>
    /// Clamp the current value of fog
    /// </summary>
    /// <param name="min">Minimium value</param>
    /// <param name="max">Maximum value </param>
    /// <param name="speed">Speed</param>
    private void ClampFog(float min, float max, float speed) {
        {
            var density = RenderSettings.fogDensity;
            if (axis == false && density < max) {
                density += speed * Time.deltaTime;
                if (density >= max) axis = true;
            }
            else if (axis = true) {
                density -= speed * Time.deltaTime;
                if (density <= min) axis = false;
            }

            RenderSettings.fogDensity = density;
        }
    }
}