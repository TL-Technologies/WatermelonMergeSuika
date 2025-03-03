using UnityEngine;

public class Fruit : MonoBehaviour
{
	public enum FruitType
	{
		Cherry = 0,
		Strawberry = 1,
		Grape = 2,
		Nasi = 3,
		Orange = 4,
		Apple = 5,
		Pear = 6,
		Peach = 7,
		Pineapple = 8,
		Melon = 9,
		WaterMelon = 10
	}

	public bool bActive;

	public FruitType MyType;

	[HideInInspector] public Rigidbody2D MyRigidbody2D;

	[HideInInspector] public CircleCollider2D MyCollider;

	[HideInInspector] public GameManager MyGM;
	[HideInInspector] public float raduis;

	public SpriteRenderer MySpriteRenderer;

	public Sprite NormalSprite;

	public Sprite GameOverSprite;

	public Sprite WinkSprite;

	public Sprite StartSprite;

	private void Awake()
	{
		MyRigidbody2D = GetComponent<Rigidbody2D>();
		MyGM = FindObjectOfType<GameManager>();
		MyCollider = GetComponent<CircleCollider2D>();
	}
	private void Start()
	{

		raduis = MyCollider.radius;
	}

	public void Initialize()
	{
		MySpriteRenderer.gameObject.GetComponent<Animator>().enabled = true;
	}
	private void Update()
	{
	}

	public void DoWink()
	{
		MySpriteRenderer.sprite = WinkSprite;
		Invoke("StopWink",.3f);
	}
	public void Release()
	{
		MyRigidbody2D.simulated = true;
		MySpriteRenderer.sprite = NormalSprite;
	}

	public void GameOver(){
		MySpriteRenderer.sprite = GameOverSprite;
	}

	private void StopWink()
	{
		MySpriteRenderer.sprite = NormalSprite;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
		{
			if (fruit.MyType == MyType && bActive)
			{
				bActive = false;
				fruit.bActive = false;
				MyGM.MergeFruit(this, fruit);

			}
		}

	}

	private void OnCollisionStay2D(Collision2D col)
	{

	}
}
