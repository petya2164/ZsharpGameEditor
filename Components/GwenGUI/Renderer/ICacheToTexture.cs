
namespace Gwen.Renderer
{
    public interface ICacheToTexture
    {
        void Initialize();
        void ShutDown();

        /// <summary>
        /// Called to set the target up for rendering.
        /// </summary>
        /// <param name="control">Control to be rendered.</param>
        void SetupCacheTexture(Control.GUIControl control);

        /// <summary>
        /// Called when cached rendering is done.
        /// </summary>
        /// <param name="control">Control to be rendered.</param>
        void FinishCacheTexture(Control.GUIControl control);

        /// <summary>
        /// Called when gwen wants to draw the cached version of the control. 
        /// </summary>
        /// <param name="control">Control to be rendered.</param>
        void DrawCachedControlTexture(Control.GUIControl control);

        /// <summary>
        /// Called to actually create a cached texture. 
        /// </summary>
        /// <param name="control">Control to be rendered.</param>
        void CreateControlCacheTexture(Control.GUIControl control);
        
        void UpdateControlCacheTexture(Control.GUIControl control);
        void SetRenderer(RendererBase renderer);
    }
}
