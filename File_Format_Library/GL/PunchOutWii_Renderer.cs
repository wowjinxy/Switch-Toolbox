﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Library.Rendering;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Toolbox.Library;

namespace FirstPlugin.PunchOutWii
{
    public class PunchOutWii_Renderer : GenericModelRenderer
    {
        public Dictionary<string, STGenericTexture> TextureList = new Dictionary<string, STGenericTexture>();

        public override void OnRender(GLControl control)
        {

        }

        public override int BindTexture(STGenericMatTexture tex, ShaderProgram shader)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + tex.textureUnit + 1);
            GL.BindTexture(TextureTarget.Texture2D, RenderTools.defaultTex.RenderableTex.TexID);

            string activeTex = tex.Name;
            foreach (var texture in TextureList.Values)
            {
                if (texture.Text == tex.Name)
                {
                    BindGLTexture(tex, shader, texture);
                    return tex.textureUnit + 1;
                }
            }

            return tex.textureUnit + 1;
        }
    }
}
