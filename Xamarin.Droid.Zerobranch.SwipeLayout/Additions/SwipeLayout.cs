namespace Com.Zerobranch.Layout
{
    using System;
    using Android.Runtime;
    using Java.Interop;

    public partial class SwipeLayout
    {
//#pragma warning disable CS0109
        [Register("LEFT")]
        public new const int Left = 1;

        [Register("RIGHT")]
        public new const int Right = Left << 1;

        //[Register("HORIZONTAL")]
        //public const int Horizontal = Left | Right;

        [Register("CLOSE_POSITION")]
        public const int ClosePosition = 0;

        [Register("NO_POSITION")]
        public const int NoPosition = -1;

        [Register("DEFAULT_AUTO_OPEN_SPEED")]
        public const int DefaultAutoOpenSpeed = 1000;
        //#pragma warning restore CS0109

        #region Evens
        private WeakReference mSwipeActionsListener;

        private ISwipeActionsListenerImplementor CreateSwipeActionsListenerImplementor()
        {
            return new ISwipeActionsListenerImplementor(this);
        }

        private bool DeleteSwipeActionsListenerImplementor(ISwipeActionsListenerImplementor implementor)
        {
            return true;
        }

        public event EventHandler<OpenEventArgs> OnOpen
        {
            add
            {
                EventHelper.AddEventHandler<ISwipeActionsListener, ISwipeActionsListenerImplementor>(
                ref mSwipeActionsListener, CreateSwipeActionsListenerImplementor,
                (swipeActionsListener) =>
                {
                    SetOnActionsListener(swipeActionsListener);
                },
                (implementor) =>
                {
                    implementor.OnOpenHandler = (EventHandler<OpenEventArgs>)Delegate.Combine(implementor.OnOpenHandler, value);
                });
            }
            remove
            {
                EventHelper.RemoveEventHandler<ISwipeActionsListener, ISwipeActionsListenerImplementor>(
                   ref mSwipeActionsListener, DeleteSwipeActionsListenerImplementor,
                   (swipeActionsListener) =>
                   {
                       //RemoveOnAttachStateChangeListener(swipeActionsListener);
                   },
                   (implementor) =>
                   {
                       implementor.OnOpenHandler = (EventHandler<OpenEventArgs>)Delegate.Remove(implementor.OnOpenHandler, value);
                   });
            }
        }

        public event EventHandler OnClose
        {
            add
            {
                EventHelper.AddEventHandler<ISwipeActionsListener, ISwipeActionsListenerImplementor>(
                ref mSwipeActionsListener, CreateSwipeActionsListenerImplementor,
                (swipeActionsListener) =>
                {
                    SetOnActionsListener(swipeActionsListener);
                },
                (implementor) =>
                {
                    implementor.OnCloseHandler = (EventHandler)Delegate.Combine(implementor.OnCloseHandler, value);
                });
            }
            remove
            {
                EventHelper.RemoveEventHandler<ISwipeActionsListener, ISwipeActionsListenerImplementor>(
                   ref mSwipeActionsListener, DeleteSwipeActionsListenerImplementor,
                   (swipeActionsListener) =>
                   {
                       //RemoveOnAttachStateChangeListener(swipeActionsListener);
                   },
                   (implementor) =>
                   {
                       implementor.OnCloseHandler = (EventHandler)Delegate.Remove(implementor.OnCloseHandler, value);
                   });
            }
        }
        #endregion
    }
}
