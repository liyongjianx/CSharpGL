﻿using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something using 'glMultiDrawArrays'.
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class MultiDrawArraysCmd : IDrawCommand
    {

        /// <summary>
        /// 
        /// </summary>
        public int[] First { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int[] Count { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        public MultiDrawArraysCmd(DrawMode mode, int[] first, int[] count)
        {
            if (first == null || count == null) { throw new System.ArgumentNullException(); }
            if (first.Length != count.Length) { throw new System.ArgumentException(); }

            this.Mode = mode;
            this.First = first;
            this.Count = count;
        }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        /// <param name="indexAccessMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(IndexAccessMode indexAccessMode)
        {
            GL.Instance.MultiDrawArrays((uint)this.Mode, this.First, this.Count, this.First.Length);
        }

        #endregion IDrawCommand

    }
}