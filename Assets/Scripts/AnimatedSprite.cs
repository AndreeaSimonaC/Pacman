using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimatedSprite : MonoBehaviour
{
    
    
    public SpriteRenderer spriteRenderer { get; private set; }
    //Array os Sprite objects - will be used to animate the sprite
    public Sprite[] sprites;
    //time in seconds - between each animation frame
    public float animationTime = 0.25f;
    //property - public read access to the current animation frame index
    //and private write access to the same index
    public int animationFrame { get; private set; }
    //boolean flag that indicates whether the animation should loop or not
    public bool loop = true;

    //method called when the script instance is being loaded
    private void Awake()
    { 
        //sets the value of spriteRenderer property to
        //'SpriteRenderer' component of the game object
        this.spriteRenderer = GetComponent < SpriteRenderer>();

    }
    //method called on the frame when a script is enabled
    //before any 'Update' methods are called
    private void Start()
    {
        //sets a repeating invoke call to the 'Advance' method with a delay
        //of animationTime - seconds, before the first call
        //and repeat rate of 'animationTime' seconds between subsequent calls
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime);
    }
    private void Advance()
    {
        if(!this.spriteRenderer.enabled)
        {
            return;
        }


        this.animationFrame++;
        if (this.animationFrame >= this.sprites.Length && this.loop)
        {
            this.animationFrame = 0;
        }
        if(this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
        {
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];
        }
    }
    //method resets the animation to the beginning
    //by setting the animationFrame component's sprite to the first sprite
    //in the sprite array
    public void Restart()
    {
        this.animationFrame = -1;
        Advance();
    }


}
