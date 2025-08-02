using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Courtesy of SoBad on the GameDevStudy Discord (I modified it a bit)
//Makes sure the game view matches a designated aspect ratio
public class GameCanvasAdjuster : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private Vector2 targetAspect = new Vector2(16, 9);
    [SerializeField] private CanvasScaler scaler;
    [SerializeField] private bool barMode;
    private float screenRatio;


    private void Start()
    {
        if(barMode)
        {
            Crop(GetCurrentRatio());
        }
        SceneManager.sceneLoaded += CropOnScene;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= CropOnScene;
    }

    private void CropOnScene(Scene arg0, LoadSceneMode arg1)
    {
        Crop(GetCurrentRatio());
    }

    private void Update()
    {
        float currentRatio = GetCurrentRatio();
        if(barMode)
        {
            if (!Mathf.Approximately(currentRatio, screenRatio))
            {
                Crop(currentRatio);
            }
        }
        else
        {
            if (currentRatio > (float)(targetAspect.x / targetAspect.y))
            {
                scaler.matchWidthOrHeight = 1;
            }
            else if (currentRatio < (float)(targetAspect.x / targetAspect.y))
            {
                scaler.matchWidthOrHeight = 0;
            }
        }
    }

    public void Crop(float newRatio)
    {
        float targetRatio = targetAspect.x / targetAspect.y;

        if (Mathf.Approximately(newRatio, targetRatio))
        {
            SetRect(0, 0, 1, 1);
        }
        else if (newRatio > targetRatio)
        {
            float normalizedWidth = targetRatio / newRatio;
            float barThickness = (1f - normalizedWidth) / 2f;
            SetRect(barThickness, 0, normalizedWidth, 1);
        }
        else
        {
            float normalizedHeight = newRatio / targetRatio;
            float barThickness = (1f - normalizedHeight) / 2f;
            SetRect(0, barThickness, 1, normalizedHeight);
        }
        screenRatio = newRatio;
    }

    private void SetRect(float x, float y, float width, float height)
    {
        targetCamera.rect = new Rect(x, y, width, height);
    }

    private float GetCurrentRatio()
    {
        return Screen.width / (float)Screen.height;
    }
}
