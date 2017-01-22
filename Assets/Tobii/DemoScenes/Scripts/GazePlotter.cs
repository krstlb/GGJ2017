using System.Collections;
using System.Collections.Generic;
using Tobii.EyeTracking;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

/// <summary>
/// Draws the gaze point positions as a point cloud, or, if the use filtering
/// toggle is on, with a single bubble sprite with smoother movements.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class GazePlotter : MonoBehaviour
{
    [Range(3.0f, 15.0f), Tooltip("Number of gaze points in point cloud.")]
    public int PointCloudSize = 10;
    [Tooltip("Sprite to use for gaze points in the point cloud.")]
    public Sprite PointSprite;
    [Range(0.0f, 1.0f), Tooltip("Scale to draw the point sprites in the point cloud.")]
    public float PointScale = 0.1f;
    [Tooltip("Distance from screen to visualization plane in the World.")]
    public float VisualizationDistance = 10f;
    [Range(0.1f, 1.0f), Tooltip("How heavy filtering to apply to gaze point bubble movements. 0.1f is most responsive, 1.0f is least responsive.")]
    public float FilterSmoothingFactor = 0.15f;

	public GameObject wave;
	GazePoint gazePoint;

    private GazePoint       _lastGazePoint = GazePoint.Invalid;

    // Members used for the gaze point cloud:
    private const float     MaxVisibleDurationInSeconds = 0.5f;
    private GazePoint[]     _gazePoints;
    private int             _last;
    private GameObject[]    _gazePointCloudSprites;

    // Members used for gaze bubble (filtered gaze visualization):
    private SpriteRenderer  _gazeBubbleRenderer;      // the gaze bubble sprite is attached to the GazePlotter game object itself
    private bool            _useFilter = false;
    private bool            _hasHistoricPoint;
    private Vector3         _historicPoint;

	public bool eyeTracking;
    public bool UseFilter
    {
        get { return _useFilter; }
        set { _useFilter = value; }
    }

   



    void Start()
    {


 
       

        InitializeGazePointBuffer();
        InitializeGazePointCloudSprites();

        _last = PointCloudSize - 1;

        _gazeBubbleRenderer = GetComponent<SpriteRenderer>();
        UpdateGazeBubbleVisibility();

		/*************
		 * me did this
		 */
		if (eyeTracking) {
			InvokeRepeating (
				"spawnWave", 1.2f, 1.025f
			);
		} 
		if(!eyeTracking) {
			_gazeBubbleRenderer.enabled = false;
			GetComponent<CircleCollider2D> ().enabled = false;
		}


		/***end of me do*/
    }

    void Update()
    {
		if (!eyeTracking) {
			if (Input.GetButtonDown ("Fire1")) {
				spawnWaveAtTap ();
			}
		}

		//if(Input.GetKey(KeyCode.R)){



		//	SceneManager.LoadScene(0);
		//}

        gazePoint = EyeTracking.GetGazePoint();
		if (eyeTracking) {
			if (gazePoint.SequentialId > _lastGazePoint.SequentialId &&
			         gazePoint.IsWithinScreenBounds) {
				UpdateGazeBubblePosition (gazePoint);

				_lastGazePoint = gazePoint;
			}
			
			UpdateGazePointCloudVisibility ();
			UpdateGazeBubbleVisibility (); 
		}
    }

    private void InitializeGazePointBuffer()
    {
        _gazePoints = new GazePoint[PointCloudSize];
        for (int i = 0; i < PointCloudSize; i++)
        {
            _gazePoints[i] = GazePoint.Invalid;
        }
    }

	//Me do
	private void spawnWave(){
		Transform transform = GameObject.FindGameObjectWithTag ("GazePoint").transform;
		GameObject newWave = Instantiate (wave, transform.position, Quaternion.identity) as GameObject;
	}

	private void spawnWaveAtTap(){
		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;
		GameObject clickWave = Instantiate (wave, position, Quaternion.identity) as GameObject;
	}

    private void InitializeGazePointCloudSprites()
    {
        _gazePointCloudSprites = new GameObject[PointCloudSize];
        for (int i = 0; i < PointCloudSize; i++)
        {
            var pointCloudSprite = new GameObject("PointCloudSprite" + i);

            var spriteRenderer = pointCloudSprite.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = PointSprite;

            var cloudPointVisualizer = pointCloudSprite.AddComponent<CloudPointVisualizer>();
            cloudPointVisualizer.Scale = PointScale;

            pointCloudSprite.SetActive(false);
            _gazePointCloudSprites[i] = pointCloudSprite;
        }
    }

    private void UpdateGazePointCloudVisibility()
    {
        bool isPointCloudVisible = !UseFilter;

        for (int i = 0; i < PointCloudSize; i++)
        {
            if (IsNotTooOld(_gazePoints[i]))
            {
                _gazePointCloudSprites[i].SetActive(isPointCloudVisible);
            }
            else
            {
                _gazePointCloudSprites[i].SetActive(false);
            }
        }
    }

    private bool IsNotTooOld(GazePoint gazePoint)
    {
        return (Time.time - gazePoint.Timestamp) < MaxVisibleDurationInSeconds;
    }

    private void UpdateGazeBubblePosition(GazePoint gazePoint)
    {
        Vector3 gazePointInWorld = ProjectToPlaneInWorld(gazePoint);
        transform.position = Smoothify(gazePointInWorld);
    }

    private void UpdateGazePointCloud(GazePoint gazePoint)
    {
        _last = Next();
        _gazePoints[_last] = gazePoint;
        var cloudPointVisualizer = _gazePointCloudSprites[_last].GetComponent<CloudPointVisualizer>();
        Vector3 gazePointInWorld = ProjectToPlaneInWorld(gazePoint);
        cloudPointVisualizer.NewPosition(gazePoint.Timestamp, gazePointInWorld);
    }

    private void UpdateGazeBubbleVisibility()
    {
        _gazeBubbleRenderer.enabled = true;
    }

    private int Next()
    {
        return ((_last + 1) % PointCloudSize);
    }

    private Vector3 ProjectToPlaneInWorld(GazePoint gazePoint)
    {
        Vector3 gazeOnScreen = gazePoint.Screen;
        gazeOnScreen += (transform.forward * VisualizationDistance);
        return Camera.main.ScreenToWorldPoint(gazeOnScreen);
    }

    private Vector3 Smoothify(Vector3 point)
    {
        if (!_hasHistoricPoint)
        {
            _historicPoint = point;
            _hasHistoricPoint = true;
        }

        var smoothedPoint = new Vector3(
            point.x * (1.0f - FilterSmoothingFactor) + _historicPoint.x * FilterSmoothingFactor,
            point.y * (1.0f - FilterSmoothingFactor) + _historicPoint.y * FilterSmoothingFactor, 
            point.z * (1.0f - FilterSmoothingFactor) + _historicPoint.z * FilterSmoothingFactor);

        _historicPoint = smoothedPoint;

        return smoothedPoint;
    }
}
