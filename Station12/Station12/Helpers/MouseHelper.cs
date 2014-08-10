using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Station12
{
    class MouseHelper
    {
        #region  Instance data 
        private Vector2 _mouseLocation;
        private Vector2 _mouseLocationChange;
        private Vector2 _mouseLocationPrevious;

        private int _rotationTrackingState;
        private float _rotation;
        private float _startingRotation;
        private float _firstRotation;
        private Vector2 _rotationCenter;

        private int _scrollWheelValue;

        MouseState _current;
        MouseState _previous;

        #endregion


        #region  Left Mouse Button Methods 

        /// <summary>
        /// Checks the state of the left mouse button.  Default:  Pressed
        /// </summary>
        public bool LeftButton()
        {
            return _current.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Checks the state of the left mouse button.  Default:  Pressed
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool LeftButton(ButtonState state)
        {
            return (_current.LeftButton == state);
        }


        /// <summary>
        /// Checks the state of the left mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        public bool LeftButtonNew()
        {
            return (_current.LeftButton == ButtonState.Pressed && 
                _previous.LeftButton == ButtonState.Released);
        }

        /// <summary>
        /// Checks the state of the left mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool LeftButtonNew(ButtonState state)
        {
            return (_current.LeftButton == state && 
                _previous.LeftButton != state);
        }

        #endregion

        #region  Right Mouse Button Methods 

        /// <summary>
        /// Checks the state of the right mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        public bool RightButton()
        {
            return _current.RightButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Checks the state of the right mouse button.  Default:  Pressed
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool RightButton(ButtonState state)
        {
            return (_current.RightButton == state);
        }

        /// <summary>
        /// Checks the state of the right mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        public bool RightButtonNew()
        {
            return (_current.RightButton == ButtonState.Pressed &&
                _previous.RightButton == ButtonState.Released);
        }

        /// <summary>
        /// Checks the state of the right mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool RightButtonNew(ButtonState state)
        {
            return (_current.RightButton == state &&
                _previous.RightButton != state);
        }

        #endregion

        #region  Middle Mouse Button Methods 

        /// <summary>
        /// Checks the state of the middle mouse button.  Default:  Pressed
        /// </summary>
        public bool MiddleButton()
        {
            return _current.MiddleButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Checks the state of the middle mouse button.  Default:  Pressed
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool MiddleButton(ButtonState state)
        {
            return (_current.MiddleButton == state);
        }

        /// <summary>
        /// Checks the state of the middle mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        public bool MiddleButtonNew()
        {
            return (_current.MiddleButton == ButtonState.Pressed &&
                _previous.MiddleButton == ButtonState.Released);
        }

        /// <summary>
        /// Checks the state of the middle mouse button.  Default:  Pressed
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        /// <param name="state">State to check for</param>
        public bool MiddleButtonNew(ButtonState state)
        {
            return (_current.MiddleButton == state &&
                _previous.MiddleButton != state);
        }

        #endregion

        #region  Scroll Checking Methods 

        /// <summary>
        /// Checks the direction of scrolling, if any has occured
        /// </summary>
        public bool ScrolledUp() { return _current.ScrollWheelValue > _previous.ScrollWheelValue; }
        
        /// <summary>
        /// Checks the direction of scrolling, if any has occured
        /// </summary>
        public bool ScrolledDown() { return _current.ScrollWheelValue < _previous.ScrollWheelValue; }

        #endregion

        #region  Mouse Position Methods 

        /// <summary>
        /// Checks if the mouse is inside a given rectangle
        /// </summary>
        /// <param name="state">Rectangle to check for</param>
        public bool MouseIntersects(Rectangle target)
        {
            return target.Contains((int)_mouseLocation.X, (int)_mouseLocation.Y);
        }

        /// <summary>
        /// Checks if the mouse is inside a given rectangle
        /// Only returns true if the action is new this update cycle.
        /// </summary>
        /// <param name="state">Rectangle to check for</param>
        public bool MouseIntersectsNew(Rectangle target)
        {
            return (!target.Contains((int)_mouseLocationPrevious.X, (int)_mouseLocationPrevious.Y) &&
                target.Contains((int)_mouseLocation.X, (int)_mouseLocation.Y));
        }

        public Vector2 Location 
        {
            get
            {
                return _mouseLocation;
            }
            set
            {
                Mouse.SetPosition((int)value.X, (int)value.Y);
                _mouseLocation = value;

            }
        }

        public Vector2 LocationChange 
        {
            get
            {
                return _mouseLocationChange;
            }
        }

        /// <summary>
        /// Begins rotation tracking
        /// </summary>
        /// <param name="startingRotation">The starting camera rotation</param>
        public void BeginRotationTracking(float startingRotation)
        {
            _rotationTrackingState = 1;
            _startingRotation = startingRotation;
            _rotationCenter = _mouseLocation;
            _rotation = _startingRotation;
        }

        /// <summary>
        /// Ends rotation tracking
        /// </summary>
        public void EndRotationTracking()
        {
            _rotationTrackingState = 0;
            _rotation = 0.0f;
            _startingRotation = 0.0f;
            _firstRotation = 0.0f;
        }

        /// <summary>
        /// Checks to see if the MouseHelper is tracking rotation
        /// </summary>
        /// <returns></returns>
        public bool IsTrackingRotation()
        {
            return _rotationTrackingState > 0;
        }

        /// <summary>
        /// Gets the rotation thathas been tracked.
        /// </summary>
        /// <returns></returns>
        public float GetRotation()
        {
            return _rotation;
        }

        #endregion

        #region  Main methods

        /// <summary>
        /// Updates the mouse states.
        /// Must be called every in every iteration of the main update loop.
        /// </summary>
        public void Update()
        {
            _previous = _current;
            _current = Mouse.GetState();
            _mouseLocationPrevious = _mouseLocation;
            _mouseLocationChange = _mouseLocation - new Vector2(_current.X, _current.Y);
            _mouseLocation = new Vector2(_current.X, _current.Y);

            if (_rotationTrackingState == 1 && _mouseLocation != _rotationCenter)
            {
                _firstRotation = (float)Math.Atan2((_mouseLocation - _rotationCenter).X, (_mouseLocation - _rotationCenter).Y);
                _rotationTrackingState = 2;
            }
            else if (_rotationTrackingState == 2)
            {
                _rotation = -((float)Math.Atan2((_mouseLocation - _rotationCenter).X, (_mouseLocation - _rotationCenter).Y) + _firstRotation) + _startingRotation;
            }
        }

        /// <summary>
        /// Provides diagnostic information about the MouseHelper class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Location: " + _mouseLocation + "\nLocation Change: " + _mouseLocationChange +"\nTracking Rotation?  " + _rotationTrackingState + "\nRotation: " + _rotation + "\nStarting Rotation: " + _startingRotation + "\nFirst: " + _firstRotation;
        }

        #endregion
    }
}
