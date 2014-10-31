﻿using System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace SFML.Utils
{
    public class AnimatedSprite : Sprite
    {
        RenderTarget _renderTarget;
        RenderStates _renderStates;
        int _fps, _frameWidth, _frameHeight, _frameCount, _currentFrame, _firstFrame, _lastFrame;
        TimeSpan _clock, _interval;
        bool _isAnimated = false;
        bool _isLooped = true;

        /// <summary>
        /// Create new SpriteAnimated.
        /// </summary>
        /// <param name="texture">Texture to use in your sprite.</param>
        /// <param name="FrameWidth">Width of one frame in pixels.</param>
        /// <param name="FrameHeight">Height of one frame in pixels.</param>
        /// <param name="FramesPerSecond">Your sprite's FPS.</param>
        /// <param name="RTarget">RenderTarget reference.</param>
        /// <param name="RStates">RenderStates object.</param>
        /// <param name="FirstFrame">First frame of animation sequence.</param>
        /// <param name="LastFrame">Last frame of animation sequence.</param>
        /// <param name="IsAnimated">Should sequence be played immediately after creation? If false, first frame will be paused.</param>
        /// <param name="IsLooped">Should sequence be looped? If false, animation will stop after one full sequence.</param>
        public AnimatedSprite(Texture texture, int FrameWidth, int FrameHeight, int FramesPerSecond, RenderTarget RTarget, RenderStates RStates, int FirstFrame = 0, int LastFrame = 0, bool IsAnimated = false, bool IsLooped = true)
            : base(texture)
        {
            _renderTarget = RTarget;
            _renderStates = RStates;
            _fps = FramesPerSecond;
            _interval = TimeSpan.FromSeconds(1f / _fps);
            _frameWidth = FrameWidth;
            _frameHeight = FrameHeight;
            _frameCount = LastFrame - FirstFrame;
            _firstFrame = FirstFrame;
            _currentFrame = FirstFrame;
            _lastFrame = LastFrame;
            _isAnimated = IsAnimated;
            _isLooped = IsLooped;
            _clock = TimeSpan.Zero;
            this.TextureRect = this.GetFramePosition(_currentFrame);
        }

        /// <summary>
        /// This method calculates TextureRect coordinates for a certain frame.
        /// </summary>
        /// <param name="frame">Frame which coordinates you need.</param>
        /// <returns>Returns frame coordinates as IntRect.</returns>
        public IntRect GetFramePosition(int frame)
        {
            int WCount = (int)this.Texture.Size.X / _frameWidth;
            int XPos = frame % WCount;
            int YPos = frame / WCount;

            IntRect Position = new IntRect(_frameWidth * XPos, _frameHeight * YPos, _frameWidth, _frameHeight);
            return Position;
        }

        /// <summary>
        /// This method is used to update animation state and draw sprite.
        /// You should avoid using Draw() method if you use this.
        /// </summary>
        public void Update(TimeSpan delta)
        {
            _clock += delta;
            if (_isAnimated & _clock >= _interval)
            {
                this.TextureRect = this.GetFramePosition(_currentFrame);
                if (_currentFrame < _lastFrame)
                    _currentFrame++;
                else
                    _currentFrame = _firstFrame;
                _clock = TimeSpan.Zero;
            }

            if (!_isLooped & (_currentFrame == _lastFrame))
            {
                _isAnimated = false;
            }

            this.Draw(_renderTarget, _renderStates);
        }

        /// <summary>
        /// Get or set current framerate.
        /// </summary>
        public int FPS
        {
            set
            {
                _fps = value;
                _interval = TimeSpan.FromSeconds(1f/_fps);
            }
            get
            {
                return _fps;
            }
        }

        /// <summary>
        /// Resume animation with current settings.
        /// </summary>
        public void Play()
        {
            _isAnimated = true;
        }

        /// <summary>
        /// Pause current animation.
        /// </summary>
        public void Pause()
        {
            _isAnimated = false;
        }

        /// <summary>
        /// Stop animation and return to frame zero.
        /// </summary>
        public void Reset()
        {
            _isAnimated = false;
            _currentFrame = 0;
            this.TextureRect = new IntRect(0, 0, _frameWidth, _frameHeight);
        }

        /// <summary>
        /// Set new animation sequence.
        /// </summary>
        /// <param name="FirstFrame">First frame of new sequence.</param>
        /// <param name="LastFrame">Last frame of new sequence.</param>
        /// <param name="IsAnimated">Should sequence be played immediately? If false, first sequence frame will be paused.</param>
        /// <param name="IsLooped">Should sequence be looped? If false, animation will stop after one full sequence.</param>
        public void SetAnimation(int FirstFrame, int LastFrame, bool IsAnimated = true, bool IsLooped = true)
        {
            _firstFrame = FirstFrame;
            _lastFrame = LastFrame;
            _isAnimated = IsAnimated;
            _isLooped = IsLooped;

            _frameCount = (LastFrame + 1) - FirstFrame;
            if (!IsAnimated)
            {
                this.TextureRect = this.GetFramePosition(FirstFrame);
            }
        }
        /// <summary>
        /// Pause on particular frame.
        /// </summary>
        /// <param name="Frame">Frame number.</param>
        public void SetFrame(int Frame)
        {
            _currentFrame = Frame;
            _isAnimated = true;
            _isLooped = false;
        }
    }
}