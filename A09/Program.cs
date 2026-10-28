// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Custom Queue
// Implement a Custom Queue for all types
// ------------------------------------------------------------------------------------------------
using static System.Console;

// Test Queue initialization
TQueue<int> queue = new TQueue<int> (10, 20, 30, 40);
WriteLine ("Initial queue size: " + queue.Size);
WriteLine ("Is empty: " + queue.IsEmpty);
// Test Dequeue (FIFO)
WriteLine ("Dequeued: " + queue.Dequeue ());
WriteLine ("Dequeued: " + queue.Dequeue ());
// Test Enqueue and circular behavior
queue.Enqueue (50);
queue.Enqueue (60);
WriteLine ("Queue size after enqueue: " + queue.Size);
// Test resizing (capacity will grow from 4 to 8)
queue.Enqueue (70);
queue.Enqueue (80);
queue.Enqueue (90);
WriteLine ("Queue size after resizing: " + queue.Size);
// Drain the queue
WriteLine ("\nDequeuing all items:");
while (!queue.IsEmpty) WriteLine (queue.Dequeue ());
WriteLine ("Is empty after draining: " + queue.IsEmpty);
// Test dequeue on an empty queue
try {
   queue.Dequeue ();
} catch (InvalidOperationException ex) {
   WriteLine ("Exception: " + ex.Message);
}

class TQueue<T> {
   private T[] mQueue = new T[4];
   private int mHead;
   private int mTail;
   private int mCount;

   public TQueue (params T[] data) {
      foreach (T item in data) Enqueue (item);
   }

   public bool IsEmpty => mCount == 0;
   public int Size => mCount;

   public void Enqueue (T a) {
      if (mCount == mQueue.Length) Resize ();
      mQueue[mTail] = a;
      mTail = (mTail + 1) % mQueue.Length;
      mCount++;
   }

   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Queue is empty.");
      T item = mQueue[mHead];
      mQueue[mHead] = default!;
      mHead = (mHead + 1) % mQueue.Length;
      mCount--;
      return item;
   }

   private void Resize () {
      T[] newQueue = new T[mQueue.Length * 2];
      for (int i = 0; i < mCount; i++) newQueue[i] = mQueue[(mHead + i) % mQueue.Length];
      mQueue = newQueue;
      mHead = 0;
      mTail = mCount;
   }
}