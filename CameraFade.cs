using UnityEngine;
/*
Script adapted from ReCogMission/FirstTutorials on Github
(MIT License)
*/
public class CameraFade : MonoBehaviour
{
    public KeyCode key = KeyCode.Space; // Which key should trigger the fade?
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve;
    public bool startFadedOut = false;


    private float alpha = 0f; 
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;


    // added GameManager integration
    public GameObject GameManager;
    private GameManagerScript manager;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();

        manager = GameManager.GetComponent<GameManagerScript>();
    }

    private void Update()
    {
        if (direction == 0 && manager.isTransitioning)
        {
            if (alpha >= 1f) // Fully faded out
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
            }
            else // Fully faded in
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }

        manager.isTransitioning = false;
        }
    }
    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }
}