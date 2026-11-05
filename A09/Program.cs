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
WriteLine ("Enqueued items: 10, 20, 30, 40");
TQueue<int> queue = new (10, 20, 30, 40);
WriteLine ("Initial queue size: " + queue.Size);
WriteLine ("Is empty: " + queue.IsEmpty);
// Test Dequeue (FIFO)
WriteLine ("Dequeued: " + queue.Dequeue ());
WriteLine ("Dequeued: " + queue.Dequeue ());
WriteLine ("Queue size after dequeue: " + queue.Size);

// Test Enqueue and circular behavior
WriteLine ("Enqueued: " + 50);
queue.Enqueue (50);
WriteLine ("Enqueued: " + 60);
queue.Enqueue (60);
WriteLine ("Queue size after enqueue: " + queue.Size);
// Test resizing (capacity will grow from 4 to 8)
WriteLine ("Enqueued: " + 70);
queue.Enqueue (70);
WriteLine ("Enqueued: " + 80);
queue.Enqueue (80);
WriteLine ("Enqueued: " + 90);
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

#region class TQueue ------------------------------------------------------------------------------
class TQueue<T> {
   #region Constructor ----------------------------------------------
   public TQueue (params T[] data) {
      foreach (T item in data) Enqueue (item);
   }
   #endregion

   #region Methods --------------------------------------------------
   /// <summary>Adds an item to the queue and doubles the queue if full</summary>
   public void Enqueue (T a) {
      if (mCount == mQueue.Length) Resize ();
      mQueue[mTail] = a;
      mTail = (mTail + 1) % mQueue.Length;
      mCount++;
   }

   /// <summary>Removes and returns the item at the head of the queue</summary>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Queue is empty.");
      T item = mQueue[mHead];
      mQueue[mHead] = default!;
      mHead = (mHead + 1) % mQueue.Length;
      mCount--;
      return item;
   }

   /// <summary>Doubles the queue size</summary>
   void Resize () {
      T[] newQueue = new T[mQueue.Length * 2];
      for (int i = 0; i < mCount; i++) newQueue[i] = mQueue[(mHead + i) % mQueue.Length];
      mQueue = newQueue;
      mHead = 0;
      mTail = mCount;
   }
   #endregion

   #region Properties -----------------------------------------------
   public bool IsEmpty => mCount == 0;
   public int Size => mCount;
   #endregion

   #region Private data ---------------------------------------------
   T[] mQueue = new T[4];
   int mHead;
   int mTail;
   int mCount;
   #endregion
}
#endregion