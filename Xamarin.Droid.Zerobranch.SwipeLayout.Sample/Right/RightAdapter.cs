namespace Nivaes.Zerobranch.SwipeLayout.Droid
{
    using System.Collections.Generic;
    using Android.Content;
    using Android.Views;
    using Android.Widget;
    using AndroidX.RecyclerView.Widget;

    public class RightAdapter : RecyclerView.Adapter
    {
        private List<string> mItems;

        public RightAdapter(List<string> items)
        {
            mItems = items;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup viewGroup, int viewType)
        {
            return viewType switch
            {
                0 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_0, viewGroup, false)),
                1 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_1, viewGroup, false)),
                2 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_2, viewGroup, false)),
                3 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_3, viewGroup, false)),
                4 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_4, viewGroup, false)),
                5 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_5, viewGroup, false)),
                6 => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_6, viewGroup, false)),
                _ => new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.right_layout_item_7, viewGroup, false)),
            };
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var ItemHolder = (ItemHolder)holder;
            ItemHolder.DragItem.Text = mItems[position];
        }

        public override int ItemCount => mItems.Count;

        private void Remove(Context context, int position)
        {
            Toast.MakeText(context, "removed item " + position, ToastLength.Short).Show();
        }

        private void Upload(Context context, int position)
        {
            Toast.MakeText(context, "upload item " + position, ToastLength.Short).Show();
        }

        private class ItemHolder : RecyclerView.ViewHolder
        {
            public TextView DragItem { get; private set; }
            private readonly ImageView mLeftView;
            private readonly ImageView mRightView;
            private readonly Com.Zerobranch.Layout.SwipeLayout mSwipeLayout;
            private readonly RightAdapter mAdapter;

            public ItemHolder(RightAdapter adapter, View itemView)
                : base(itemView)
            {
                mAdapter = adapter;
            }

            public ItemHolder(View itemView)
                :base(itemView)
            {
                DragItem = itemView.FindViewById<TextView>(Resource.Id.drag_item);
                mSwipeLayout = itemView.FindViewById<Com.Zerobranch.Layout.SwipeLayout>(Resource.Id.swipe_layout);
                mLeftView = itemView.FindViewById<ImageView>(Resource.Id.left_view);
                mRightView = itemView.FindViewById<ImageView>(Resource.Id.right_view);

                mRightView.Click += (o, e) =>
                {
                    if (base.AdapterPosition != RecyclerView.NoPosition)
                    {
                        mAdapter.Remove(itemView.Context, base.AdapterPosition);
                    }
                };

                mLeftView.Click += (o, e) =>
                {
                    if (base.AdapterPosition != RecyclerView.NoPosition)
                    {
                        mAdapter.Upload(itemView.Context, base.AdapterPosition);
                    }
                };
            }
        }
    }
}
