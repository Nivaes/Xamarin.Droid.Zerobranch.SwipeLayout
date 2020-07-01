using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net.Wifi.Aware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Com.Zerobranch.Layout;

namespace Nivaes.Zerobranch.SwipeLayout.Droid
{
    public class HorizontalAdapter : RecyclerView.Adapter
    {
        private List<string> mItems;

        public HorizontalAdapter(List<string> items)
        {
            mItems = items;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup viewGroup, int viewType)
        {
            switch (viewType)
            {
                case 0:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_0, viewGroup, false));
                case 1:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_1, viewGroup, false));
                case 2:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_2, viewGroup, false));
                case 3:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_3, viewGroup, false));
                case 4:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_4, viewGroup, false));
                case 5:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_5, viewGroup, false));
                default:
                    return new ItemHolder(LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.horizontal_layout_item_6, viewGroup, false));
            }
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
            private readonly HorizontalAdapter mAdapter;

            public ItemHolder(HorizontalAdapter adapter, View itemView)
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
