#region License
//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2009 the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to 
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//
#endregion

using System;

namespace OpenTK.Graphics.OpenGL
{
    #pragma warning disable 1591

    public enum AccumOp : int
    {
        ACCUM = ((int)0x0100),
        LOAD = ((int)0x0101),
        RETURN = ((int)0x0102),
        MULT = ((int)0x0103),
        ADD = ((int)0x0104),
    }

    public enum ActiveAttribType : int
    {
        FLOAT = ((int)0x1406),
        FLOAT_VEC2 = ((int)0x8B50),
        FLOAT_VEC3 = ((int)0x8B51),
        FLOAT_VEC4 = ((int)0x8B52),
        FLOAT_MAT2 = ((int)0x8B5A),
        FLOAT_MAT3 = ((int)0x8B5B),
        FLOAT_MAT4 = ((int)0x8B5C),
    }

    public enum ActiveUniformBlockParameter : int
    {
        UNIFORM_BLOCK_BINDING = ((int)0x8A3F),
        UNIFORM_BLOCK_DATA_SIZE = ((int)0x8A40),
        UNIFORM_BLOCK_NAME_LENGTH = ((int)0x8A41),
        UNIFORM_BLOCK_ACTIVE_UNIFORMS = ((int)0x8A42),
        UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = ((int)0x8A43),
        UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = ((int)0x8A44),
        UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = ((int)0x8A46),
    }

    public enum ActiveUniformParameter : int
    {
        UNIFORM_TYPE = ((int)0x8A37),
        UNIFORM_SIZE = ((int)0x8A38),
        UNIFORM_NAME_LENGTH = ((int)0x8A39),
        UNIFORM_BLOCK_INDEX = ((int)0x8A3A),
        UNIFORM_OFFSET = ((int)0x8A3B),
        UNIFORM_ARRAY_STRIDE = ((int)0x8A3C),
        UNIFORM_MATRIX_STRIDE = ((int)0x8A3D),
        UNIFORM_IS_ROW_MAJOR = ((int)0x8A3E),
    }

    public enum ActiveUniformType : int
    {
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        FLOAT_VEC2 = ((int)0x8B50),
        FLOAT_VEC3 = ((int)0x8B51),
        FLOAT_VEC4 = ((int)0x8B52),
        INT_VEC2 = ((int)0x8B53),
        INT_VEC3 = ((int)0x8B54),
        INT_VEC4 = ((int)0x8B55),
        BOOL = ((int)0x8B56),
        BOOL_VEC2 = ((int)0x8B57),
        BOOL_VEC3 = ((int)0x8B58),
        BOOL_VEC4 = ((int)0x8B59),
        FLOAT_MAT2 = ((int)0x8B5A),
        FLOAT_MAT3 = ((int)0x8B5B),
        FLOAT_MAT4 = ((int)0x8B5C),
        SAMPLER_1D = ((int)0x8B5D),
        SAMPLER_2D = ((int)0x8B5E),
        SAMPLER_3D = ((int)0x8B5F),
        SAMPLER_CUBE = ((int)0x8B60),
        SAMPLER_1D_SHADOW = ((int)0x8B61),
        SAMPLER_2D_SHADOW = ((int)0x8B62),
        SAMPLER_2D_RECT = ((int)0x8B63),
        SAMPLER_2D_RECT_SHADOW = ((int)0x8B64),
        FLOAT_MAT2x3 = ((int)0x8B65),
        FLOAT_MAT2x4 = ((int)0x8B66),
        FLOAT_MAT3x2 = ((int)0x8B67),
        FLOAT_MAT3x4 = ((int)0x8B68),
        FLOAT_MAT4x2 = ((int)0x8B69),
        FLOAT_MAT4x3 = ((int)0x8B6A),
        SAMPLER_1D_ARRAY = ((int)0x8DC0),
        SAMPLER_2D_ARRAY = ((int)0x8DC1),
        SAMPLER_BUFFER = ((int)0x8DC2),
        SAMPLER_1D_ARRAY_SHADOW = ((int)0x8DC3),
        SAMPLER_2D_ARRAY_SHADOW = ((int)0x8DC4),
        SAMPLER_CUBE_SHADOW = ((int)0x8DC5),
        UNSIGNED_INT_VEC2 = ((int)0x8DC6),
        UNSIGNED_INT_VEC3 = ((int)0x8DC7),
        UNSIGNED_INT_VEC4 = ((int)0x8DC8),
        INT_SAMPLER_1D = ((int)0x8DC9),
        INT_SAMPLER_2D = ((int)0x8DCA),
        INT_SAMPLER_3D = ((int)0x8DCB),
        INT_SAMPLER_CUBE = ((int)0x8DCC),
        INT_SAMPLER_2D_RECT = ((int)0x8DCD),
        INT_SAMPLER_1D_ARRAY = ((int)0x8DCE),
        INT_SAMPLER_2D_ARRAY = ((int)0x8DCF),
        INT_SAMPLER_BUFFER = ((int)0x8DD0),
        UNSIGNED_INT_SAMPLER_1D = ((int)0x8DD1),
        UNSIGNED_INT_SAMPLER_2D = ((int)0x8DD2),
        UNSIGNED_INT_SAMPLER_3D = ((int)0x8DD3),
        UNSIGNED_INT_SAMPLER_CUBE = ((int)0x8DD4),
        UNSIGNED_INT_SAMPLER_2D_RECT = ((int)0x8DD5),
        UNSIGNED_INT_SAMPLER_1D_ARRAY = ((int)0x8DD6),
        UNSIGNED_INT_SAMPLER_2D_ARRAY = ((int)0x8DD7),
        UNSIGNED_INT_SAMPLER_BUFFER = ((int)0x8DD8),
        SAMPLER_2D_MULTISAMPLE = ((int)0x9108),
        INT_SAMPLER_2D_MULTISAMPLE = ((int)0x9109),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = ((int)0x910A),
        SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910B),
        INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910C),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910D),
    }

    public class All
    {
        public const int ABGR_EXT = ((int)0x8000);
        public const int ACCUM = ((int)0x0100);
        public const int ACCUM_ALPHA_BITS = ((int)0x0D5B);
        public const int ACCUM_BLUE_BITS = ((int)0x0D5A);
        public const int ACCUM_BUFFER_BIT = ((int)0x00000200);
        public const int ACCUM_CLEAR_VALUE = ((int)0x0B80);
        public const int ACCUM_GREEN_BITS = ((int)0x0D59);
        public const int ACCUM_RED_BITS = ((int)0x0D58);
        public const int ACTIVE_ATTRIBUTE_MAX_LENGTH = ((int)0x8B8A);
        public const int ACTIVE_ATTRIBUTES = ((int)0x8B89);
        public const int ACTIVE_STENCIL_FACE_EXT = ((int)0x8911);
        public const int ACTIVE_TEXTURE = ((int)0x84E0);
        public const int ACTIVE_TEXTURE_ARB = ((int)0x84E0);
        public const int ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = ((int)0x8A35);
        public const int ACTIVE_UNIFORM_BLOCKS = ((int)0x8A36);
        public const int ACTIVE_UNIFORM_MAX_LENGTH = ((int)0x8B87);
        public const int ACTIVE_UNIFORMS = ((int)0x8B86);
        public const int ACTIVE_VARYING_MAX_LENGTH_NV = ((int)0x8C82);
        public const int ACTIVE_VARYINGS_NV = ((int)0x8C81);
        public const int ACTIVE_VERTEX_UNITS_ARB = ((int)0x86A5);
        public const int ADD = ((int)0x0104);
        public const int ADD_SIGNED = ((int)0x8574);
        public const int ADD_SIGNED_ARB = ((int)0x8574);
        public const int ADD_SIGNED_EXT = ((int)0x8574);
        public const int ALIASED_LINE_WIDTH_RANGE = ((int)0x846E);
        public const int ALIASED_POINT_SIZE_RANGE = ((int)0x846D);
        public const int ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF);
        public const int ALPHA = ((int)0x1906);
        public const int ALPHA_BIAS = ((int)0x0D1D);
        public const int ALPHA_BITS = ((int)0x0D55);
        public const int ALPHA_INTEGER = ((int)0x8D97);
        public const int ALPHA_INTEGER_EXT = ((int)0x8D97);
        public const int ALPHA_SCALE = ((int)0x0D1C);
        public const int ALPHA_SNORM = ((int)0x9010);
        public const int ALPHA_TEST = ((int)0x0BC0);
        public const int ALPHA_TEST_FUNC = ((int)0x0BC1);
        public const int ALPHA_TEST_REF = ((int)0x0BC2);
        public const int ALPHA12 = ((int)0x803D);
        public const int ALPHA12_EXT = ((int)0x803D);
        public const int ALPHA16 = ((int)0x803E);
        public const int ALPHA16_EXT = ((int)0x803E);
        public const int ALPHA16_SNORM = ((int)0x9018);
        public const int ALPHA16F_ARB = ((int)0x881C);
        public const int ALPHA16I_EXT = ((int)0x8D8A);
        public const int ALPHA16UI_EXT = ((int)0x8D78);
        public const int ALPHA32F_ARB = ((int)0x8816);
        public const int ALPHA32I_EXT = ((int)0x8D84);
        public const int ALPHA32UI_EXT = ((int)0x8D72);
        public const int ALPHA4 = ((int)0x803B);
        public const int ALPHA4_EXT = ((int)0x803B);
        public const int ALPHA8 = ((int)0x803C);
        public const int ALPHA8_EXT = ((int)0x803C);
        public const int ALPHA8_SNORM = ((int)0x9014);
        public const int ALPHA8I_EXT = ((int)0x8D90);
        public const int ALPHA8UI_EXT = ((int)0x8D7E);
        public const int ALREADY_SIGNALED = ((int)0x911A);
        public const int ALWAYS = ((int)0x0207);
        public const int AMBIENT = ((int)0x1200);
        public const int AMBIENT_AND_DIFFUSE = ((int)0x1602);
        public const int AND = ((int)0x1501);
        public const int AND_INVERTED = ((int)0x1504);
        public const int AND_REVERSE = ((int)0x1502);
        public const int ARRAY_BUFFER = ((int)0x8892);
        public const int ARRAY_BUFFER_ARB = ((int)0x8892);
        public const int ARRAY_BUFFER_BINDING = ((int)0x8894);
        public const int ARRAY_BUFFER_BINDING_ARB = ((int)0x8894);
        public const int ARRAY_DIVISOR = ((int)0x88FE);
        public const int ARRAY_ELEMENT_LOCK_COUNT_EXT = ((int)0x81A9);
        public const int ARRAY_ELEMENT_LOCK_FIRST_EXT = ((int)0x81A8);
        public const int ARRAY_ENABLED = ((int)0x8622);
        public const int ARRAY_NORMALIZED = ((int)0x886A);
        public const int ARRAY_POINTER = ((int)0x8645);
        public const int ARRAY_SIZE = ((int)0x8623);
        public const int ARRAY_STRIDE = ((int)0x8624);
        public const int ARRAY_TYPE = ((int)0x8625);
        public const int ATTACHED_SHADERS = ((int)0x8B85);
        public const int ATTENUATION_EXT = ((int)0x834D);
        public const int ATTRIB_STACK_DEPTH = ((int)0x0BB0);
        public const int AUTO_NORMAL = ((int)0x0D80);
        public const int AUX_BUFFERS = ((int)0x0C00);
        public const int AUX0 = ((int)0x0409);
        public const int AUX1 = ((int)0x040A);
        public const int AUX2 = ((int)0x040B);
        public const int AUX3 = ((int)0x040C);
        public const int AVERAGE_EXT = ((int)0x8335);
        public const int BACK = ((int)0x0405);
        public const int BACK_LEFT = ((int)0x0402);
        public const int BACK_PRIMARY_COLOR_NV = ((int)0x8C77);
        public const int BACK_RIGHT = ((int)0x0403);
        public const int BACK_SECONDARY_COLOR_NV = ((int)0x8C78);
        public const int BGR = ((int)0x80E0);
        public const int BGR_EXT = ((int)0x80E0);
        public const int BGR_INTEGER = ((int)0x8D9A);
        public const int BGR_INTEGER_EXT = ((int)0x8D9A);
        public const int BGRA = ((int)0x80E1);
        public const int BGRA_EXT = ((int)0x80E1);
        public const int BGRA_INTEGER = ((int)0x8D9B);
        public const int BGRA_INTEGER_EXT = ((int)0x8D9B);
        public const int BINORMAL_ARRAY_EXT = ((int)0x843A);
        public const int BINORMAL_ARRAY_POINTER_EXT = ((int)0x8443);
        public const int BINORMAL_ARRAY_STRIDE_EXT = ((int)0x8441);
        public const int BINORMAL_ARRAY_TYPE_EXT = ((int)0x8440);
        public const int BITMAP = ((int)0x1A00);
        public const int BITMAP_TOKEN = ((int)0x0704);
        public const int BLEND = ((int)0x0BE2);
        public const int BLEND_COLOR = ((int)0x8005);
        public const int BLEND_COLOR_EXT = ((int)0x8005);
        public const int BLEND_DST = ((int)0x0BE0);
        public const int BLEND_DST_ALPHA = ((int)0x80CA);
        public const int BLEND_DST_ALPHA_EXT = ((int)0x80CA);
        public const int BLEND_DST_RGB = ((int)0x80C8);
        public const int BLEND_DST_RGB_EXT = ((int)0x80C8);
        public const int BLEND_EQUATION = ((int)0x8009);
        public const int BLEND_EQUATION_ALPHA = ((int)0x883D);
        public const int BLEND_EQUATION_ALPHA_EXT = ((int)0x883D);
        public const int BLEND_EQUATION_EXT = ((int)0x8009);
        public const int BLEND_EQUATION_RGB = ((int)0x8009);
        public const int BLEND_EQUATION_RGB_EXT = ((int)0x8009);
        public const int BLEND_SRC = ((int)0x0BE1);
        public const int BLEND_SRC_ALPHA = ((int)0x80CB);
        public const int BLEND_SRC_ALPHA_EXT = ((int)0x80CB);
        public const int BLEND_SRC_RGB = ((int)0x80C9);
        public const int BLEND_SRC_RGB_EXT = ((int)0x80C9);
        public const int BLUE = ((int)0x1905);
        public const int BLUE_BIAS = ((int)0x0D1B);
        public const int BLUE_BITS = ((int)0x0D54);
        public const int BLUE_INTEGER = ((int)0x8D96);
        public const int BLUE_INTEGER_EXT = ((int)0x8D96);
        public const int BLUE_SCALE = ((int)0x0D1A);
        public const int BOOL = ((int)0x8B56);
        public const int BOOL_ARB = ((int)0x8B56);
        public const int BOOL_VEC2 = ((int)0x8B57);
        public const int BOOL_VEC2_ARB = ((int)0x8B57);
        public const int BOOL_VEC3 = ((int)0x8B58);
        public const int BOOL_VEC3_ARB = ((int)0x8B58);
        public const int BOOL_VEC4 = ((int)0x8B59);
        public const int BOOL_VEC4_ARB = ((int)0x8B59);
        public const int BUFFER_ACCESS = ((int)0x88BB);
        public const int BUFFER_ACCESS_ARB = ((int)0x88BB);
        public const int BUFFER_ACCESS_FLAGS = ((int)0x911F);
        public const int BUFFER_MAP_LENGTH = ((int)0x9120);
        public const int BUFFER_MAP_OFFSET = ((int)0x9121);
        public const int BUFFER_MAP_POINTER = ((int)0x88BD);
        public const int BUFFER_MAP_POINTER_ARB = ((int)0x88BD);
        public const int BUFFER_MAPPED = ((int)0x88BC);
        public const int BUFFER_MAPPED_ARB = ((int)0x88BC);
        public const int BUFFER_SIZE = ((int)0x8764);
        public const int BUFFER_SIZE_ARB = ((int)0x8764);
        public const int BUFFER_USAGE = ((int)0x8765);
        public const int BUFFER_USAGE_ARB = ((int)0x8765);
        public const int BYTE = ((int)0x1400);
        public const int C3F_V3F = ((int)0x2A24);
        public const int C4F_N3F_V3F = ((int)0x2A26);
        public const int C4UB_V2F = ((int)0x2A22);
        public const int C4UB_V3F = ((int)0x2A23);
        public const int CCW = ((int)0x0901);
        public const int CLAMP = ((int)0x2900);
        public const int CLAMP_FRAGMENT_COLOR = ((int)0x891B);
        public const int CLAMP_FRAGMENT_COLOR_ARB = ((int)0x891B);
        public const int CLAMP_READ_COLOR = ((int)0x891C);
        public const int CLAMP_READ_COLOR_ARB = ((int)0x891C);
        public const int CLAMP_TO_BORDER = ((int)0x812D);
        public const int CLAMP_TO_BORDER_ARB = ((int)0x812D);
        public const int CLAMP_TO_BORDER_SGIS = ((int)0x812D);
        public const int CLAMP_TO_EDGE = ((int)0x812F);
        public const int CLAMP_TO_EDGE_SGIS = ((int)0x812F);
        public const int CLAMP_VERTEX_COLOR = ((int)0x891A);
        public const int CLAMP_VERTEX_COLOR_ARB = ((int)0x891A);
        public const int CLEAR = ((int)0x1500);
        public const int CLIENT_ACTIVE_TEXTURE = ((int)0x84E1);
        public const int CLIENT_ACTIVE_TEXTURE_ARB = ((int)0x84E1);
        public const int CLIENT_ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF);
        public const int CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0BB1);
        public const int CLIENT_PIXEL_STORE_BIT = ((int)0x00000001);
        public const int CLIENT_VERTEX_ARRAY_BIT = ((int)0x00000002);
        public const int CLIP_DISTANCE_NV = ((int)0x8C7A);
        public const int CLIP_DISTANCE0 = ((int)0x3000);
        public const int CLIP_DISTANCE1 = ((int)0x3001);
        public const int CLIP_DISTANCE2 = ((int)0x3002);
        public const int CLIP_DISTANCE3 = ((int)0x3003);
        public const int CLIP_DISTANCE4 = ((int)0x3004);
        public const int CLIP_DISTANCE5 = ((int)0x3005);
        public const int CLIP_DISTANCE6 = ((int)0x3006);
        public const int CLIP_DISTANCE7 = ((int)0x3007);
        public const int CLIP_PLANE0 = ((int)0x3000);
        public const int CLIP_PLANE1 = ((int)0x3001);
        public const int CLIP_PLANE2 = ((int)0x3002);
        public const int CLIP_PLANE3 = ((int)0x3003);
        public const int CLIP_PLANE4 = ((int)0x3004);
        public const int CLIP_PLANE5 = ((int)0x3005);
        public const int CLIP_VOLUME_CLIPPING_HINT_EXT = ((int)0x80F0);
        public const int CMYK_EXT = ((int)0x800C);
        public const int CMYKA_EXT = ((int)0x800D);
        public const int COEFF = ((int)0x0A00);
        public const int COLOR = ((int)0x1800);
        public const int COLOR_ARRAY = ((int)0x8076);
        public const int COLOR_ARRAY_BUFFER_BINDING = ((int)0x8898);
        public const int COLOR_ARRAY_BUFFER_BINDING_ARB = ((int)0x8898);
        public const int COLOR_ARRAY_COUNT_EXT = ((int)0x8084);
        public const int COLOR_ARRAY_EXT = ((int)0x8076);
        public const int COLOR_ARRAY_POINTER = ((int)0x8090);
        public const int COLOR_ARRAY_POINTER_EXT = ((int)0x8090);
        public const int COLOR_ARRAY_SIZE = ((int)0x8081);
        public const int COLOR_ARRAY_SIZE_EXT = ((int)0x8081);
        public const int COLOR_ARRAY_STRIDE = ((int)0x8083);
        public const int COLOR_ARRAY_STRIDE_EXT = ((int)0x8083);
        public const int COLOR_ARRAY_TYPE = ((int)0x8082);
        public const int COLOR_ARRAY_TYPE_EXT = ((int)0x8082);
        public const int COLOR_ATTACHMENT0 = ((int)0x8CE0);
        public const int COLOR_ATTACHMENT0_EXT = ((int)0x8CE0);
        public const int COLOR_ATTACHMENT1 = ((int)0x8CE1);
        public const int COLOR_ATTACHMENT1_EXT = ((int)0x8CE1);
        public const int COLOR_ATTACHMENT10 = ((int)0x8CEA);
        public const int COLOR_ATTACHMENT10_EXT = ((int)0x8CEA);
        public const int COLOR_ATTACHMENT11 = ((int)0x8CEB);
        public const int COLOR_ATTACHMENT11_EXT = ((int)0x8CEB);
        public const int COLOR_ATTACHMENT12 = ((int)0x8CEC);
        public const int COLOR_ATTACHMENT12_EXT = ((int)0x8CEC);
        public const int COLOR_ATTACHMENT13 = ((int)0x8CED);
        public const int COLOR_ATTACHMENT13_EXT = ((int)0x8CED);
        public const int COLOR_ATTACHMENT14 = ((int)0x8CEE);
        public const int COLOR_ATTACHMENT14_EXT = ((int)0x8CEE);
        public const int COLOR_ATTACHMENT15 = ((int)0x8CEF);
        public const int COLOR_ATTACHMENT15_EXT = ((int)0x8CEF);
        public const int COLOR_ATTACHMENT2 = ((int)0x8CE2);
        public const int COLOR_ATTACHMENT2_EXT = ((int)0x8CE2);
        public const int COLOR_ATTACHMENT3 = ((int)0x8CE3);
        public const int COLOR_ATTACHMENT3_EXT = ((int)0x8CE3);
        public const int COLOR_ATTACHMENT4 = ((int)0x8CE4);
        public const int COLOR_ATTACHMENT4_EXT = ((int)0x8CE4);
        public const int COLOR_ATTACHMENT5 = ((int)0x8CE5);
        public const int COLOR_ATTACHMENT5_EXT = ((int)0x8CE5);
        public const int COLOR_ATTACHMENT6 = ((int)0x8CE6);
        public const int COLOR_ATTACHMENT6_EXT = ((int)0x8CE6);
        public const int COLOR_ATTACHMENT7 = ((int)0x8CE7);
        public const int COLOR_ATTACHMENT7_EXT = ((int)0x8CE7);
        public const int COLOR_ATTACHMENT8 = ((int)0x8CE8);
        public const int COLOR_ATTACHMENT8_EXT = ((int)0x8CE8);
        public const int COLOR_ATTACHMENT9 = ((int)0x8CE9);
        public const int COLOR_ATTACHMENT9_EXT = ((int)0x8CE9);
        public const int COLOR_BUFFER_BIT = ((int)0x00004000);
        public const int COLOR_CLEAR_VALUE = ((int)0x0C22);
        public const int COLOR_INDEX = ((int)0x1900);
        public const int COLOR_INDEX1_EXT = ((int)0x80E2);
        public const int COLOR_INDEX12_EXT = ((int)0x80E6);
        public const int COLOR_INDEX16_EXT = ((int)0x80E7);
        public const int COLOR_INDEX2_EXT = ((int)0x80E3);
        public const int COLOR_INDEX4_EXT = ((int)0x80E4);
        public const int COLOR_INDEX8_EXT = ((int)0x80E5);
        public const int COLOR_INDEXES = ((int)0x1603);
        public const int COLOR_LOGIC_OP = ((int)0x0BF2);
        public const int COLOR_MATERIAL = ((int)0x0B57);
        public const int COLOR_MATERIAL_FACE = ((int)0x0B55);
        public const int COLOR_MATERIAL_PARAMETER = ((int)0x0B56);
        public const int COLOR_MATRIX = ((int)0x80B1);
        public const int COLOR_MATRIX_SGI = ((int)0x80B1);
        public const int COLOR_MATRIX_STACK_DEPTH = ((int)0x80B2);
        public const int COLOR_MATRIX_STACK_DEPTH_SGI = ((int)0x80B2);
        public const int COLOR_SUM = ((int)0x8458);
        public const int COLOR_SUM_ARB = ((int)0x8458);
        public const int COLOR_SUM_EXT = ((int)0x8458);
        public const int COLOR_TABLE = ((int)0x80D0);
        public const int COLOR_TABLE_ALPHA_SIZE = ((int)0x80DD);
        public const int COLOR_TABLE_ALPHA_SIZE_SGI = ((int)0x80DD);
        public const int COLOR_TABLE_BIAS = ((int)0x80D7);
        public const int COLOR_TABLE_BIAS_SGI = ((int)0x80D7);
        public const int COLOR_TABLE_BLUE_SIZE = ((int)0x80DC);
        public const int COLOR_TABLE_BLUE_SIZE_SGI = ((int)0x80DC);
        public const int COLOR_TABLE_FORMAT = ((int)0x80D8);
        public const int COLOR_TABLE_FORMAT_SGI = ((int)0x80D8);
        public const int COLOR_TABLE_GREEN_SIZE = ((int)0x80DB);
        public const int COLOR_TABLE_GREEN_SIZE_SGI = ((int)0x80DB);
        public const int COLOR_TABLE_INTENSITY_SIZE = ((int)0x80DF);
        public const int COLOR_TABLE_INTENSITY_SIZE_SGI = ((int)0x80DF);
        public const int COLOR_TABLE_LUMINANCE_SIZE = ((int)0x80DE);
        public const int COLOR_TABLE_LUMINANCE_SIZE_SGI = ((int)0x80DE);
        public const int COLOR_TABLE_RED_SIZE = ((int)0x80DA);
        public const int COLOR_TABLE_RED_SIZE_SGI = ((int)0x80DA);
        public const int COLOR_TABLE_SCALE = ((int)0x80D6);
        public const int COLOR_TABLE_SCALE_SGI = ((int)0x80D6);
        public const int COLOR_TABLE_SGI = ((int)0x80D0);
        public const int COLOR_TABLE_WIDTH = ((int)0x80D9);
        public const int COLOR_TABLE_WIDTH_SGI = ((int)0x80D9);
        public const int COLOR_WRITEMASK = ((int)0x0C23);
        public const int COMBINE = ((int)0x8570);
        public const int COMBINE_ALPHA = ((int)0x8572);
        public const int COMBINE_ALPHA_ARB = ((int)0x8572);
        public const int COMBINE_ALPHA_EXT = ((int)0x8572);
        public const int COMBINE_ARB = ((int)0x8570);
        public const int COMBINE_EXT = ((int)0x8570);
        public const int COMBINE_RGB = ((int)0x8571);
        public const int COMBINE_RGB_ARB = ((int)0x8571);
        public const int COMBINE_RGB_EXT = ((int)0x8571);
        public const int COMBINE4_NV = ((int)0x8503);
        public const int COMPARE_R_TO_TEXTURE = ((int)0x884E);
        public const int COMPARE_R_TO_TEXTURE_ARB = ((int)0x884E);
        public const int COMPARE_REF_DEPTH_TO_TEXTURE_EXT = ((int)0x884E);
        public const int COMPARE_REF_TO_TEXTURE = ((int)0x884E);
        public const int COMPILE = ((int)0x1300);
        public const int COMPILE_AND_EXECUTE = ((int)0x1301);
        public const int COMPILE_STATUS = ((int)0x8B81);
        public const int COMPRESSED_ALPHA = ((int)0x84E9);
        public const int COMPRESSED_ALPHA_ARB = ((int)0x84E9);
        public const int COMPRESSED_INTENSITY = ((int)0x84EC);
        public const int COMPRESSED_INTENSITY_ARB = ((int)0x84EC);
        public const int COMPRESSED_LUMINANCE = ((int)0x84EA);
        public const int COMPRESSED_LUMINANCE_ALPHA = ((int)0x84EB);
        public const int COMPRESSED_LUMINANCE_ALPHA_ARB = ((int)0x84EB);
        public const int COMPRESSED_LUMINANCE_ALPHA_LATC2_EXT = ((int)0x8C72);
        public const int COMPRESSED_LUMINANCE_ARB = ((int)0x84EA);
        public const int COMPRESSED_LUMINANCE_LATC1_EXT = ((int)0x8C70);
        public const int COMPRESSED_RED = ((int)0x8225);
        public const int COMPRESSED_RED_GREEN_RGTC2_EXT = ((int)0x8DBD);
        public const int COMPRESSED_RED_RGTC1 = ((int)0x8DBB);
        public const int COMPRESSED_RED_RGTC1_EXT = ((int)0x8DBB);
        public const int COMPRESSED_RG = ((int)0x8226);
        public const int COMPRESSED_RG_RGTC2 = ((int)0x8DBD);
        public const int COMPRESSED_RGB = ((int)0x84ED);
        public const int COMPRESSED_RGB_ARB = ((int)0x84ED);
        public const int COMPRESSED_RGB_S3TC_DXT1_EXT = ((int)0x83F0);
        public const int COMPRESSED_RGBA = ((int)0x84EE);
        public const int COMPRESSED_RGBA_ARB = ((int)0x84EE);
        public const int COMPRESSED_RGBA_S3TC_DXT1_EXT = ((int)0x83F1);
        public const int COMPRESSED_RGBA_S3TC_DXT3_EXT = ((int)0x83F2);
        public const int COMPRESSED_RGBA_S3TC_DXT5_EXT = ((int)0x83F3);
        public const int COMPRESSED_SIGNED_LUMINANCE_ALPHA_LATC2_EXT = ((int)0x8C73);
        public const int COMPRESSED_SIGNED_LUMINANCE_LATC1_EXT = ((int)0x8C71);
        public const int COMPRESSED_SIGNED_RED_GREEN_RGTC2_EXT = ((int)0x8DBE);
        public const int COMPRESSED_SIGNED_RED_RGTC1 = ((int)0x8DBC);
        public const int COMPRESSED_SIGNED_RED_RGTC1_EXT = ((int)0x8DBC);
        public const int COMPRESSED_SIGNED_RG_RGTC2 = ((int)0x8DBE);
        public const int COMPRESSED_SLUMINANCE = ((int)0x8C4A);
        public const int COMPRESSED_SLUMINANCE_ALPHA = ((int)0x8C4B);
        public const int COMPRESSED_SLUMINANCE_ALPHA_EXT = ((int)0x8C4B);
        public const int COMPRESSED_SLUMINANCE_EXT = ((int)0x8C4A);
        public const int COMPRESSED_SRGB = ((int)0x8C48);
        public const int COMPRESSED_SRGB_ALPHA = ((int)0x8C49);
        public const int COMPRESSED_SRGB_ALPHA_EXT = ((int)0x8C49);
        public const int COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = ((int)0x8C4D);
        public const int COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = ((int)0x8C4E);
        public const int COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = ((int)0x8C4F);
        public const int COMPRESSED_SRGB_EXT = ((int)0x8C48);
        public const int COMPRESSED_SRGB_S3TC_DXT1_EXT = ((int)0x8C4C);
        public const int COMPRESSED_TEXTURE_FORMATS = ((int)0x86A3);
        public const int COMPRESSED_TEXTURE_FORMATS_ARB = ((int)0x86A3);
        public const int CONDITION_SATISFIED = ((int)0x911C);
        public const int CONSTANT = ((int)0x8576);
        public const int CONSTANT_ALPHA = ((int)0x8003);
        public const int CONSTANT_ALPHA_EXT = ((int)0x8003);
        public const int CONSTANT_ARB = ((int)0x8576);
        public const int CONSTANT_ATTENUATION = ((int)0x1207);
        public const int CONSTANT_BORDER = ((int)0x8151);
        public const int CONSTANT_COLOR = ((int)0x8001);
        public const int CONSTANT_COLOR_EXT = ((int)0x8001);
        public const int CONSTANT_EXT = ((int)0x8576);
        public const int CONTEXT_COMPATIBILITY_PROFILE_BIT = ((int)0x00000002);
        public const int CONTEXT_CORE_PROFILE_BIT = ((int)0x00000001);
        public const int CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = ((int)0x0001);
        public const int CONTEXT_FLAGS = ((int)0x821E);
        public const int CONTEXT_PROFILE_MASK = ((int)0x9126);
        public const int CONTINUOUS_AMD = ((int)0x9007);
        public const int CONVOLUTION_1D = ((int)0x8010);
        public const int CONVOLUTION_1D_EXT = ((int)0x8010);
        public const int CONVOLUTION_2D = ((int)0x8011);
        public const int CONVOLUTION_2D_EXT = ((int)0x8011);
        public const int CONVOLUTION_BORDER_COLOR = ((int)0x8154);
        public const int CONVOLUTION_BORDER_MODE = ((int)0x8013);
        public const int CONVOLUTION_BORDER_MODE_EXT = ((int)0x8013);
        public const int CONVOLUTION_FILTER_BIAS = ((int)0x8015);
        public const int CONVOLUTION_FILTER_BIAS_EXT = ((int)0x8015);
        public const int CONVOLUTION_FILTER_SCALE = ((int)0x8014);
        public const int CONVOLUTION_FILTER_SCALE_EXT = ((int)0x8014);
        public const int CONVOLUTION_FORMAT = ((int)0x8017);
        public const int CONVOLUTION_FORMAT_EXT = ((int)0x8017);
        public const int CONVOLUTION_HEIGHT = ((int)0x8019);
        public const int CONVOLUTION_HEIGHT_EXT = ((int)0x8019);
        public const int CONVOLUTION_WIDTH = ((int)0x8018);
        public const int CONVOLUTION_WIDTH_EXT = ((int)0x8018);
        public const int COORD_REPLACE = ((int)0x8862);
        public const int COORD_REPLACE_ARB = ((int)0x8862);
        public const int COPY = ((int)0x1503);
        public const int COPY_INVERTED = ((int)0x150C);
        public const int COPY_PIXEL_TOKEN = ((int)0x0706);
        public const int COPY_READ_BUFFER = ((int)0x8F36);
        public const int COPY_WRITE_BUFFER = ((int)0x8F37);
        public const int COUNTER_RANGE_AMD = ((int)0x8BC1);
        public const int COUNTER_TYPE_AMD = ((int)0x8BC0);
        public const int CUBIC_EXT = ((int)0x8334);
        public const int CULL_FACE = ((int)0x0B44);
        public const int CULL_FACE_MODE = ((int)0x0B45);
        public const int CULL_VERTEX_EXT = ((int)0x81AA);
        public const int CULL_VERTEX_EYE_POSITION_EXT = ((int)0x81AB);
        public const int CULL_VERTEX_OBJECT_POSITION_EXT = ((int)0x81AC);
        public const int CURRENT_BINORMAL_EXT = ((int)0x843C);
        public const int CURRENT_BIT = ((int)0x00000001);
        public const int CURRENT_COLOR = ((int)0x0B00);
        public const int CURRENT_FOG_COORD = ((int)0x8453);
        public const int CURRENT_FOG_COORDINATE = ((int)0x8453);
        public const int CURRENT_FOG_COORDINATE_EXT = ((int)0x8453);
        public const int CURRENT_INDEX = ((int)0x0B01);
        public const int CURRENT_MATRIX_ARB = ((int)0x8641);
        public const int CURRENT_MATRIX_INDEX_ARB = ((int)0x8845);
        public const int CURRENT_MATRIX_STACK_DEPTH_ARB = ((int)0x8640);
        public const int CURRENT_NORMAL = ((int)0x0B02);
        public const int CURRENT_PALETTE_MATRIX_ARB = ((int)0x8843);
        public const int CURRENT_PROGRAM = ((int)0x8B8D);
        public const int CURRENT_QUERY = ((int)0x8865);
        public const int CURRENT_QUERY_ARB = ((int)0x8865);
        public const int CURRENT_RASTER_COLOR = ((int)0x0B04);
        public const int CURRENT_RASTER_DISTANCE = ((int)0x0B09);
        public const int CURRENT_RASTER_INDEX = ((int)0x0B05);
        public const int CURRENT_RASTER_POSITION = ((int)0x0B07);
        public const int CURRENT_RASTER_POSITION_VALID = ((int)0x0B08);
        public const int CURRENT_RASTER_SECONDARY_COLOR = ((int)0x845F);
        public const int CURRENT_RASTER_TEXTURE_COORDS = ((int)0x0B06);
        public const int CURRENT_SECONDARY_COLOR = ((int)0x8459);
        public const int CURRENT_SECONDARY_COLOR_EXT = ((int)0x8459);
        public const int CURRENT_TANGENT_EXT = ((int)0x843B);
        public const int CURRENT_TEXTURE_COORDS = ((int)0x0B03);
        public const int CURRENT_TIME_NV = ((int)0x8E28);
        public const int CURRENT_VERTEX_ATTRIB = ((int)0x8626);
        public const int CURRENT_VERTEX_ATTRIB_ARB = ((int)0x8626);
        public const int CURRENT_VERTEX_EXT = ((int)0x87E2);
        public const int CURRENT_VERTEX_WEIGHT_EXT = ((int)0x850B);
        public const int CURRENT_WEIGHT_ARB = ((int)0x86A8);
        public const int CW = ((int)0x0900);
        public const int DECAL = ((int)0x2101);
        public const int DECR = ((int)0x1E03);
        public const int DECR_WRAP = ((int)0x8508);
        public const int DECR_WRAP_EXT = ((int)0x8508);
        public const int DELETE_STATUS = ((int)0x8B80);
        public const int DEPTH = ((int)0x1801);
        public const int DEPTH_ATTACHMENT = ((int)0x8D00);
        public const int DEPTH_ATTACHMENT_EXT = ((int)0x8D00);
        public const int DEPTH_BIAS = ((int)0x0D1F);
        public const int DEPTH_BITS = ((int)0x0D56);
        public const int DEPTH_BOUNDS_EXT = ((int)0x8891);
        public const int DEPTH_BOUNDS_TEST_EXT = ((int)0x8890);
        public const int DEPTH_BUFFER = ((int)0x8223);
        public const int DEPTH_BUFFER_BIT = ((int)0x00000100);
        public const int DEPTH_CLAMP = ((int)0x864F);
        public const int DEPTH_CLEAR_VALUE = ((int)0x0B73);
        public const int DEPTH_COMPONENT = ((int)0x1902);
        public const int DEPTH_COMPONENT16 = ((int)0x81A5);
        public const int DEPTH_COMPONENT16_ARB = ((int)0x81A5);
        public const int DEPTH_COMPONENT24 = ((int)0x81A6);
        public const int DEPTH_COMPONENT24_ARB = ((int)0x81A6);
        public const int DEPTH_COMPONENT32 = ((int)0x81A7);
        public const int DEPTH_COMPONENT32_ARB = ((int)0x81A7);
        public const int DEPTH_COMPONENT32F = ((int)0x8CAC);
        public const int DEPTH_FUNC = ((int)0x0B74);
        public const int DEPTH_RANGE = ((int)0x0B70);
        public const int DEPTH_SCALE = ((int)0x0D1E);
        public const int DEPTH_STENCIL = ((int)0x84F9);
        public const int DEPTH_STENCIL_ATTACHMENT = ((int)0x821A);
        public const int DEPTH_STENCIL_EXT = ((int)0x84F9);
        public const int DEPTH_TEST = ((int)0x0B71);
        public const int DEPTH_TEXTURE_MODE = ((int)0x884B);
        public const int DEPTH_TEXTURE_MODE_ARB = ((int)0x884B);
        public const int DEPTH_WRITEMASK = ((int)0x0B72);
        public const int DEPTH24_STENCIL8 = ((int)0x88F0);
        public const int DEPTH24_STENCIL8_EXT = ((int)0x88F0);
        public const int DEPTH32F_STENCIL8 = ((int)0x8CAD);
        public const int DIFFUSE = ((int)0x1201);
        public const int DISCRETE_AMD = ((int)0x9006);
        public const int DISTANCE_ATTENUATION_EXT = ((int)0x8129);
        public const int DITHER = ((int)0x0BD0);
        public const int DOMAIN = ((int)0x0A02);
        public const int DONT_CARE = ((int)0x1100);
        public const int DOT3_RGB = ((int)0x86AE);
        public const int DOT3_RGB_ARB = ((int)0x86AE);
        public const int DOT3_RGB_EXT = ((int)0x8740);
        public const int DOT3_RGBA = ((int)0x86AF);
        public const int DOT3_RGBA_ARB = ((int)0x86AF);
        public const int DOT3_RGBA_EXT = ((int)0x8741);
        public const int DOUBLE = ((int)0x140A);
        public const int DOUBLE_EXT = ((int)0x140A);
        public const int DOUBLEBUFFER = ((int)0x0C32);
        public const int DRAW_BUFFER = ((int)0x0C01);
        public const int DRAW_BUFFER0 = ((int)0x8825);
        public const int DRAW_BUFFER0_ARB = ((int)0x8825);
        public const int DRAW_BUFFER1 = ((int)0x8826);
        public const int DRAW_BUFFER1_ARB = ((int)0x8826);
        public const int DRAW_BUFFER10 = ((int)0x882F);
        public const int DRAW_BUFFER10_ARB = ((int)0x882F);
        public const int DRAW_BUFFER11 = ((int)0x8830);
        public const int DRAW_BUFFER11_ARB = ((int)0x8830);
        public const int DRAW_BUFFER12 = ((int)0x8831);
        public const int DRAW_BUFFER12_ARB = ((int)0x8831);
        public const int DRAW_BUFFER13 = ((int)0x8832);
        public const int DRAW_BUFFER13_ARB = ((int)0x8832);
        public const int DRAW_BUFFER14 = ((int)0x8833);
        public const int DRAW_BUFFER14_ARB = ((int)0x8833);
        public const int DRAW_BUFFER15 = ((int)0x8834);
        public const int DRAW_BUFFER15_ARB = ((int)0x8834);
        public const int DRAW_BUFFER2 = ((int)0x8827);
        public const int DRAW_BUFFER2_ARB = ((int)0x8827);
        public const int DRAW_BUFFER3 = ((int)0x8828);
        public const int DRAW_BUFFER3_ARB = ((int)0x8828);
        public const int DRAW_BUFFER4 = ((int)0x8829);
        public const int DRAW_BUFFER4_ARB = ((int)0x8829);
        public const int DRAW_BUFFER5 = ((int)0x882A);
        public const int DRAW_BUFFER5_ARB = ((int)0x882A);
        public const int DRAW_BUFFER6 = ((int)0x882B);
        public const int DRAW_BUFFER6_ARB = ((int)0x882B);
        public const int DRAW_BUFFER7 = ((int)0x882C);
        public const int DRAW_BUFFER7_ARB = ((int)0x882C);
        public const int DRAW_BUFFER8 = ((int)0x882D);
        public const int DRAW_BUFFER8_ARB = ((int)0x882D);
        public const int DRAW_BUFFER9 = ((int)0x882E);
        public const int DRAW_BUFFER9_ARB = ((int)0x882E);
        public const int DRAW_FRAMEBUFFER = ((int)0x8CA9);
        public const int DRAW_FRAMEBUFFER_BINDING = ((int)0x8CA6);
        public const int DRAW_FRAMEBUFFER_BINDING_EXT = ((int)0x8CA6);
        public const int DRAW_FRAMEBUFFER_EXT = ((int)0x8CA9);
        public const int DRAW_PIXEL_TOKEN = ((int)0x0705);
        public const int DST_ALPHA = ((int)0x0304);
        public const int DST_COLOR = ((int)0x0306);
        public const int DYNAMIC_COPY = ((int)0x88EA);
        public const int DYNAMIC_COPY_ARB = ((int)0x88EA);
        public const int DYNAMIC_DRAW = ((int)0x88E8);
        public const int DYNAMIC_DRAW_ARB = ((int)0x88E8);
        public const int DYNAMIC_READ = ((int)0x88E9);
        public const int DYNAMIC_READ_ARB = ((int)0x88E9);
        public const int EDGE_FLAG = ((int)0x0B43);
        public const int EDGE_FLAG_ARRAY = ((int)0x8079);
        public const int EDGE_FLAG_ARRAY_BUFFER_BINDING = ((int)0x889B);
        public const int EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = ((int)0x889B);
        public const int EDGE_FLAG_ARRAY_COUNT_EXT = ((int)0x808D);
        public const int EDGE_FLAG_ARRAY_EXT = ((int)0x8079);
        public const int EDGE_FLAG_ARRAY_POINTER = ((int)0x8093);
        public const int EDGE_FLAG_ARRAY_POINTER_EXT = ((int)0x8093);
        public const int EDGE_FLAG_ARRAY_STRIDE = ((int)0x808C);
        public const int EDGE_FLAG_ARRAY_STRIDE_EXT = ((int)0x808C);
        public const int ELEMENT_ARRAY_BUFFER = ((int)0x8893);
        public const int ELEMENT_ARRAY_BUFFER_ARB = ((int)0x8893);
        public const int ELEMENT_ARRAY_BUFFER_BINDING = ((int)0x8895);
        public const int ELEMENT_ARRAY_BUFFER_BINDING_ARB = ((int)0x8895);
        public const int EMBOSS_CONSTANT_NV = ((int)0x855E);
        public const int EMBOSS_LIGHT_NV = ((int)0x855D);
        public const int EMBOSS_MAP_NV = ((int)0x855F);
        public const int EMISSION = ((int)0x1600);
        public const int ENABLE_BIT = ((int)0x00002000);
        public const int EQUAL = ((int)0x0202);
        public const int EQUIV = ((int)0x1509);
        public const int EVAL_BIT = ((int)0x00010000);
        public const int EXP = ((int)0x0800);
        public const int EXP2 = ((int)0x0801);
        public const int EXTENSIONS = ((int)0x1F03);
        public const int EYE_LINEAR = ((int)0x2400);
        public const int EYE_PLANE = ((int)0x2502);
        public const int EYE_PLANE_ABSOLUTE_NV = ((int)0x855C);
        public const int EYE_RADIAL_NV = ((int)0x855B);
        public const int FALSE = ((int)0);
        public const int FASTEST = ((int)0x1101);
        public const int FEEDBACK = ((int)0x1C01);
        public const int FEEDBACK_BUFFER_POINTER = ((int)0x0DF0);
        public const int FEEDBACK_BUFFER_SIZE = ((int)0x0DF1);
        public const int FEEDBACK_BUFFER_TYPE = ((int)0x0DF2);
        public const int FIELDS_NV = ((int)0x8E27);
        public const int FILL = ((int)0x1B02);
        public const int FILTER4_SGIS = ((int)0x8146);
        public const int FIRST_VERTEX_CONVENTION = ((int)0x8E4D);
        public const int FIRST_VERTEX_CONVENTION_EXT = ((int)0x8E4D);
        public const int FIXED_ONLY = ((int)0x891D);
        public const int FIXED_ONLY_ARB = ((int)0x891D);
        public const int FLAT = ((int)0x1D00);
        public const int FLOAT = ((int)0x1406);
        public const int FLOAT_32_UNSIGNED_INT_24_8_REV = ((int)0x8DAD);
        public const int FLOAT_MAT2 = ((int)0x8B5A);
        public const int FLOAT_MAT2_ARB = ((int)0x8B5A);
        public const int FLOAT_MAT2x3 = ((int)0x8B65);
        public const int FLOAT_MAT2x4 = ((int)0x8B66);
        public const int FLOAT_MAT3 = ((int)0x8B5B);
        public const int FLOAT_MAT3_ARB = ((int)0x8B5B);
        public const int FLOAT_MAT3x2 = ((int)0x8B67);
        public const int FLOAT_MAT3x4 = ((int)0x8B68);
        public const int FLOAT_MAT4 = ((int)0x8B5C);
        public const int FLOAT_MAT4_ARB = ((int)0x8B5C);
        public const int FLOAT_MAT4x2 = ((int)0x8B69);
        public const int FLOAT_MAT4x3 = ((int)0x8B6A);
        public const int FLOAT_VEC2 = ((int)0x8B50);
        public const int FLOAT_VEC2_ARB = ((int)0x8B50);
        public const int FLOAT_VEC3 = ((int)0x8B51);
        public const int FLOAT_VEC3_ARB = ((int)0x8B51);
        public const int FLOAT_VEC4 = ((int)0x8B52);
        public const int FLOAT_VEC4_ARB = ((int)0x8B52);
        public const int FOG = ((int)0x0B60);
        public const int FOG_BIT = ((int)0x00000080);
        public const int FOG_COLOR = ((int)0x0B66);
        public const int FOG_COORD = ((int)0x8451);
        public const int FOG_COORD_ARRAY = ((int)0x8457);
        public const int FOG_COORD_ARRAY_BUFFER_BINDING = ((int)0x889D);
        public const int FOG_COORD_ARRAY_POINTER = ((int)0x8456);
        public const int FOG_COORD_ARRAY_STRIDE = ((int)0x8455);
        public const int FOG_COORD_ARRAY_TYPE = ((int)0x8454);
        public const int FOG_COORD_SRC = ((int)0x8450);
        public const int FOG_COORDINATE = ((int)0x8451);
        public const int FOG_COORDINATE_ARRAY = ((int)0x8457);
        public const int FOG_COORDINATE_ARRAY_BUFFER_BINDING = ((int)0x889D);
        public const int FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = ((int)0x889D);
        public const int FOG_COORDINATE_ARRAY_EXT = ((int)0x8457);
        public const int FOG_COORDINATE_ARRAY_POINTER = ((int)0x8456);
        public const int FOG_COORDINATE_ARRAY_POINTER_EXT = ((int)0x8456);
        public const int FOG_COORDINATE_ARRAY_STRIDE = ((int)0x8455);
        public const int FOG_COORDINATE_ARRAY_STRIDE_EXT = ((int)0x8455);
        public const int FOG_COORDINATE_ARRAY_TYPE = ((int)0x8454);
        public const int FOG_COORDINATE_ARRAY_TYPE_EXT = ((int)0x8454);
        public const int FOG_COORDINATE_EXT = ((int)0x8451);
        public const int FOG_COORDINATE_SOURCE = ((int)0x8450);
        public const int FOG_COORDINATE_SOURCE_EXT = ((int)0x8450);
        public const int FOG_DENSITY = ((int)0x0B62);
        public const int FOG_DISTANCE_MODE_NV = ((int)0x855A);
        public const int FOG_END = ((int)0x0B64);
        public const int FOG_HINT = ((int)0x0C54);
        public const int FOG_INDEX = ((int)0x0B61);
        public const int FOG_MODE = ((int)0x0B65);
        public const int FOG_START = ((int)0x0B63);
        public const int FOUR = ((int)4);
        public const int FRAGMENT_COLOR_EXT = ((int)0x834C);
        public const int FRAGMENT_DEPTH = ((int)0x8452);
        public const int FRAGMENT_DEPTH_EXT = ((int)0x8452);
        public const int FRAGMENT_MATERIAL_EXT = ((int)0x8349);
        public const int FRAGMENT_NORMAL_EXT = ((int)0x834A);
        public const int FRAGMENT_PROGRAM = ((int)0x8804);
        public const int FRAGMENT_PROGRAM_ARB = ((int)0x8804);
        public const int FRAGMENT_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA4);
        public const int FRAGMENT_SHADER = ((int)0x8B30);
        public const int FRAGMENT_SHADER_ARB = ((int)0x8B30);
        public const int FRAGMENT_SHADER_DERIVATIVE_HINT = ((int)0x8B8B);
        public const int FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = ((int)0x8B8B);
        public const int FRAME_NV = ((int)0x8E26);
        public const int FRAMEBUFFER = ((int)0x8D40);
        public const int FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = ((int)0x8215);
        public const int FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = ((int)0x8214);
        public const int FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = ((int)0x8210);
        public const int FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = ((int)0x8211);
        public const int FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = ((int)0x8216);
        public const int FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = ((int)0x8213);
        public const int FRAMEBUFFER_ATTACHMENT_LAYERED = ((int)0x8DA7);
        public const int FRAMEBUFFER_ATTACHMENT_LAYERED_ARB = ((int)0x8DA7);
        public const int FRAMEBUFFER_ATTACHMENT_LAYERED_EXT = ((int)0x8DA7);
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = ((int)0x8CD1);
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = ((int)0x8CD1);
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = ((int)0x8CD0);
        public const int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = ((int)0x8CD0);
        public const int FRAMEBUFFER_ATTACHMENT_RED_SIZE = ((int)0x8212);
        public const int FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = ((int)0x8217);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = ((int)0x8CD4);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = ((int)0x8CD3);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = ((int)0x8CD3);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = ((int)0x8CD4);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = ((int)0x8CD2);
        public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = ((int)0x8CD2);
        public const int FRAMEBUFFER_BINDING = ((int)0x8CA6);
        public const int FRAMEBUFFER_BINDING_EXT = ((int)0x8CA6);
        public const int FRAMEBUFFER_COMPLETE = ((int)0x8CD5);
        public const int FRAMEBUFFER_COMPLETE_EXT = ((int)0x8CD5);
        public const int FRAMEBUFFER_DEFAULT = ((int)0x8218);
        public const int FRAMEBUFFER_EXT = ((int)0x8D40);
        public const int FRAMEBUFFER_INCOMPLETE_ATTACHMENT = ((int)0x8CD6);
        public const int FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = ((int)0x8CD6);
        public const int FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = ((int)0x8CD9);
        public const int FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = ((int)0x8CDB);
        public const int FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = ((int)0x8CDB);
        public const int FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = ((int)0x8CDA);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_COUNT = ((int)0x8DA9);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_ARB = ((int)0x8DA9);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT = ((int)0x8DA9);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = ((int)0x8DA8);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_ARB = ((int)0x8DA8);
        public const int FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT = ((int)0x8DA8);
        public const int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = ((int)0x8CD7);
        public const int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = ((int)0x8CD7);
        public const int FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = ((int)0x8D56);
        public const int FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_EXT = ((int)0x8D56);
        public const int FRAMEBUFFER_INCOMPLETE_READ_BUFFER = ((int)0x8CDC);
        public const int FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = ((int)0x8CDC);
        public const int FRAMEBUFFER_SRGB = ((int)0x8DB9);
        public const int FRAMEBUFFER_SRGB_CAPABLE_EXT = ((int)0x8DBA);
        public const int FRAMEBUFFER_SRGB_EXT = ((int)0x8DB9);
        public const int FRAMEBUFFER_UNDEFINED = ((int)0x8219);
        public const int FRAMEBUFFER_UNSUPPORTED = ((int)0x8CDD);
        public const int FRAMEBUFFER_UNSUPPORTED_EXT = ((int)0x8CDD);
        public const int FRONT = ((int)0x0404);
        public const int FRONT_AND_BACK = ((int)0x0408);
        public const int FRONT_FACE = ((int)0x0B46);
        public const int FRONT_LEFT = ((int)0x0400);
        public const int FRONT_RIGHT = ((int)0x0401);
        public const int FULL_RANGE_EXT = ((int)0x87E1);
        public const int FUNC_ADD = ((int)0x8006);
        public const int FUNC_ADD_EXT = ((int)0x8006);
        public const int FUNC_REVERSE_SUBTRACT = ((int)0x800B);
        public const int FUNC_REVERSE_SUBTRACT_EXT = ((int)0x800B);
        public const int FUNC_SUBTRACT = ((int)0x800A);
        public const int FUNC_SUBTRACT_EXT = ((int)0x800A);
        public const int GENERATE_MIPMAP = ((int)0x8191);
        public const int GENERATE_MIPMAP_HINT = ((int)0x8192);
        public const int GENERIC_ATTRIB_NV = ((int)0x8C7D);
        public const int GEOMETRY_INPUT_TYPE = ((int)0x8917);
        public const int GEOMETRY_INPUT_TYPE_ARB = ((int)0x8DDB);
        public const int GEOMETRY_INPUT_TYPE_EXT = ((int)0x8DDB);
        public const int GEOMETRY_OUTPUT_TYPE = ((int)0x8918);
        public const int GEOMETRY_OUTPUT_TYPE_ARB = ((int)0x8DDC);
        public const int GEOMETRY_OUTPUT_TYPE_EXT = ((int)0x8DDC);
        public const int GEOMETRY_PROGRAM_NV = ((int)0x8C26);
        public const int GEOMETRY_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA3);
        public const int GEOMETRY_SHADER = ((int)0x8DD9);
        public const int GEOMETRY_SHADER_ARB = ((int)0x8DD9);
        public const int GEOMETRY_SHADER_EXT = ((int)0x8DD9);
        public const int GEOMETRY_VERTICES_OUT = ((int)0x8916);
        public const int GEOMETRY_VERTICES_OUT_ARB = ((int)0x8DDA);
        public const int GEOMETRY_VERTICES_OUT_EXT = ((int)0x8DDA);
        public const int GEQUAL = ((int)0x0206);
        public const int GL_1PASS_EXT = ((int)0x80A1);
        public const int GL_1PASS_SGIS = ((int)0x80A1);
        public const int GL_2_BYTES = ((int)0x1407);
        public const int GL_2D = ((int)0x0600);
        public const int GL_2PASS_0_EXT = ((int)0x80A2);
        public const int GL_2PASS_0_SGIS = ((int)0x80A2);
        public const int GL_2PASS_1_EXT = ((int)0x80A3);
        public const int GL_2PASS_1_SGIS = ((int)0x80A3);
        public const int GL_3_BYTES = ((int)0x1408);
        public const int GL_3D = ((int)0x0601);
        public const int GL_3D_COLOR = ((int)0x0602);
        public const int GL_3D_COLOR_TEXTURE = ((int)0x0603);
        public const int GL_4_BYTES = ((int)0x1409);
        public const int GL_422_AVERAGE_EXT = ((int)0x80CE);
        public const int GL_422_EXT = ((int)0x80CC);
        public const int GL_422_REV_AVERAGE_EXT = ((int)0x80CF);
        public const int GL_422_REV_EXT = ((int)0x80CD);
        public const int GL_4D_COLOR_TEXTURE = ((int)0x0604);
        public const int GL_4PASS_0_EXT = ((int)0x80A4);
        public const int GL_4PASS_0_SGIS = ((int)0x80A4);
        public const int GL_4PASS_1_EXT = ((int)0x80A5);
        public const int GL_4PASS_1_SGIS = ((int)0x80A5);
        public const int GL_4PASS_2_EXT = ((int)0x80A6);
        public const int GL_4PASS_2_SGIS = ((int)0x80A6);
        public const int GL_4PASS_3_EXT = ((int)0x80A7);
        public const int GL_4PASS_3_SGIS = ((int)0x80A7);
        public const int GREATER = ((int)0x0204);
        public const int GREEN = ((int)0x1904);
        public const int GREEN_BIAS = ((int)0x0D19);
        public const int GREEN_BITS = ((int)0x0D53);
        public const int GREEN_INTEGER = ((int)0x8D95);
        public const int GREEN_INTEGER_EXT = ((int)0x8D95);
        public const int GREEN_SCALE = ((int)0x0D18);
        public const int HALF_FLOAT = ((int)0x140B);
        public const int HALF_FLOAT_ARB = ((int)0x140B);
        public const int HINT_BIT = ((int)0x00008000);
        public const int HISTOGRAM = ((int)0x8024);
        public const int HISTOGRAM_ALPHA_SIZE = ((int)0x802B);
        public const int HISTOGRAM_ALPHA_SIZE_EXT = ((int)0x802B);
        public const int HISTOGRAM_BLUE_SIZE = ((int)0x802A);
        public const int HISTOGRAM_BLUE_SIZE_EXT = ((int)0x802A);
        public const int HISTOGRAM_EXT = ((int)0x8024);
        public const int HISTOGRAM_FORMAT = ((int)0x8027);
        public const int HISTOGRAM_FORMAT_EXT = ((int)0x8027);
        public const int HISTOGRAM_GREEN_SIZE = ((int)0x8029);
        public const int HISTOGRAM_GREEN_SIZE_EXT = ((int)0x8029);
        public const int HISTOGRAM_LUMINANCE_SIZE = ((int)0x802C);
        public const int HISTOGRAM_LUMINANCE_SIZE_EXT = ((int)0x802C);
        public const int HISTOGRAM_RED_SIZE = ((int)0x8028);
        public const int HISTOGRAM_RED_SIZE_EXT = ((int)0x8028);
        public const int HISTOGRAM_SINK = ((int)0x802D);
        public const int HISTOGRAM_SINK_EXT = ((int)0x802D);
        public const int HISTOGRAM_WIDTH = ((int)0x8026);
        public const int HISTOGRAM_WIDTH_EXT = ((int)0x8026);
        public const int IMPLEMENTATION_COLOR_READ_FORMAT_OES = ((int)0x8B9B);
        public const int IMPLEMENTATION_COLOR_READ_TYPE_OES = ((int)0x8B9A);
        public const int INCR = ((int)0x1E02);
        public const int INCR_WRAP = ((int)0x8507);
        public const int INCR_WRAP_EXT = ((int)0x8507);
        public const int INDEX = ((int)0x8222);
        public const int INDEX_ARRAY = ((int)0x8077);
        public const int INDEX_ARRAY_BUFFER_BINDING = ((int)0x8899);
        public const int INDEX_ARRAY_BUFFER_BINDING_ARB = ((int)0x8899);
        public const int INDEX_ARRAY_COUNT_EXT = ((int)0x8087);
        public const int INDEX_ARRAY_EXT = ((int)0x8077);
        public const int INDEX_ARRAY_POINTER = ((int)0x8091);
        public const int INDEX_ARRAY_POINTER_EXT = ((int)0x8091);
        public const int INDEX_ARRAY_STRIDE = ((int)0x8086);
        public const int INDEX_ARRAY_STRIDE_EXT = ((int)0x8086);
        public const int INDEX_ARRAY_TYPE = ((int)0x8085);
        public const int INDEX_ARRAY_TYPE_EXT = ((int)0x8085);
        public const int INDEX_BITS = ((int)0x0D51);
        public const int INDEX_CLEAR_VALUE = ((int)0x0C20);
        public const int INDEX_LOGIC_OP = ((int)0x0BF1);
        public const int INDEX_MATERIAL_EXT = ((int)0x81B8);
        public const int INDEX_MATERIAL_FACE_EXT = ((int)0x81BA);
        public const int INDEX_MATERIAL_PARAMETER_EXT = ((int)0x81B9);
        public const int INDEX_MODE = ((int)0x0C30);
        public const int INDEX_OFFSET = ((int)0x0D13);
        public const int INDEX_SHIFT = ((int)0x0D12);
        public const int INDEX_TEST_EXT = ((int)0x81B5);
        public const int INDEX_TEST_FUNC_EXT = ((int)0x81B6);
        public const int INDEX_TEST_REF_EXT = ((int)0x81B7);
        public const int INDEX_WRITEMASK = ((int)0x0C21);
        public const int INFO_LOG_LENGTH = ((int)0x8B84);
        public const int INT = ((int)0x1404);
        public const int INT_SAMPLER_1D = ((int)0x8DC9);
        public const int INT_SAMPLER_1D_ARRAY = ((int)0x8DCE);
        public const int INT_SAMPLER_1D_ARRAY_EXT = ((int)0x8DCE);
        public const int INT_SAMPLER_1D_EXT = ((int)0x8DC9);
        public const int INT_SAMPLER_2D = ((int)0x8DCA);
        public const int INT_SAMPLER_2D_ARRAY = ((int)0x8DCF);
        public const int INT_SAMPLER_2D_ARRAY_EXT = ((int)0x8DCF);
        public const int INT_SAMPLER_2D_EXT = ((int)0x8DCA);
        public const int INT_SAMPLER_2D_MULTISAMPLE = ((int)0x9109);
        public const int INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910C);
        public const int INT_SAMPLER_2D_RECT = ((int)0x8DCD);
        public const int INT_SAMPLER_2D_RECT_EXT = ((int)0x8DCD);
        public const int INT_SAMPLER_3D = ((int)0x8DCB);
        public const int INT_SAMPLER_3D_EXT = ((int)0x8DCB);
        public const int INT_SAMPLER_BUFFER = ((int)0x8DD0);
        public const int INT_SAMPLER_BUFFER_AMD = ((int)0x9002);
        public const int INT_SAMPLER_BUFFER_EXT = ((int)0x8DD0);
        public const int INT_SAMPLER_CUBE = ((int)0x8DCC);
        public const int INT_SAMPLER_CUBE_EXT = ((int)0x8DCC);
        public const int INT_SAMPLER_CUBE_MAP_ARRAY = ((int)0x900E);
        public const int INT_SAMPLER_RENDERBUFFER_NV = ((int)0x8E57);
        public const int INT_VEC2 = ((int)0x8B53);
        public const int INT_VEC2_ARB = ((int)0x8B53);
        public const int INT_VEC3 = ((int)0x8B54);
        public const int INT_VEC3_ARB = ((int)0x8B54);
        public const int INT_VEC4 = ((int)0x8B55);
        public const int INT_VEC4_ARB = ((int)0x8B55);
        public const int INTENSITY = ((int)0x8049);
        public const int INTENSITY_EXT = ((int)0x8049);
        public const int INTENSITY_SNORM = ((int)0x9013);
        public const int INTENSITY12 = ((int)0x804C);
        public const int INTENSITY12_EXT = ((int)0x804C);
        public const int INTENSITY16 = ((int)0x804D);
        public const int INTENSITY16_EXT = ((int)0x804D);
        public const int INTENSITY16_SNORM = ((int)0x901B);
        public const int INTENSITY16F_ARB = ((int)0x881D);
        public const int INTENSITY16I_EXT = ((int)0x8D8B);
        public const int INTENSITY16UI_EXT = ((int)0x8D79);
        public const int INTENSITY32F_ARB = ((int)0x8817);
        public const int INTENSITY32I_EXT = ((int)0x8D85);
        public const int INTENSITY32UI_EXT = ((int)0x8D73);
        public const int INTENSITY4 = ((int)0x804A);
        public const int INTENSITY4_EXT = ((int)0x804A);
        public const int INTENSITY8 = ((int)0x804B);
        public const int INTENSITY8_EXT = ((int)0x804B);
        public const int INTENSITY8_SNORM = ((int)0x9017);
        public const int INTENSITY8I_EXT = ((int)0x8D91);
        public const int INTENSITY8UI_EXT = ((int)0x8D7F);
        public const int INTERLEAVED_ATTRIBS = ((int)0x8C8C);
        public const int INTERLEAVED_ATTRIBS_EXT = ((int)0x8C8C);
        public const int INTERLEAVED_ATTRIBS_NV = ((int)0x8C8C);
        public const int INTERPOLATE = ((int)0x8575);
        public const int INTERPOLATE_ARB = ((int)0x8575);
        public const int INTERPOLATE_EXT = ((int)0x8575);
        public const int INVALID_ENUM = ((int)0x0500);
        public const int INVALID_FRAMEBUFFER_OPERATION = ((int)0x0506);
        public const int INVALID_FRAMEBUFFER_OPERATION_EXT = ((int)0x0506);
        public const int INVALID_INDEX = unchecked((int)0xFFFFFFFF);
        public const int INVALID_OPERATION = ((int)0x0502);
        public const int INVALID_VALUE = ((int)0x0501);
        public const int INVARIANT_DATATYPE_EXT = ((int)0x87EB);
        public const int INVARIANT_EXT = ((int)0x87C2);
        public const int INVARIANT_VALUE_EXT = ((int)0x87EA);
        public const int INVERT = ((int)0x150A);
        public const int INVERTED_SCREEN_W_REND = ((int)0x8491);
        public const int IUI_N3F_V2F_EXT = ((int)0x81AF);
        public const int IUI_N3F_V3F_EXT = ((int)0x81B0);
        public const int IUI_V2F_EXT = ((int)0x81AD);
        public const int IUI_V3F_EXT = ((int)0x81AE);
        public const int KEEP = ((int)0x1E00);
        public const int LAST_VERTEX_CONVENTION = ((int)0x8E4E);
        public const int LAST_VERTEX_CONVENTION_EXT = ((int)0x8E4E);
        public const int LEFT = ((int)0x0406);
        public const int LEQUAL = ((int)0x0203);
        public const int LESS = ((int)0x0201);
        public const int LIGHT_MODEL_AMBIENT = ((int)0x0B53);
        public const int LIGHT_MODEL_COLOR_CONTROL = ((int)0x81F8);
        public const int LIGHT_MODEL_COLOR_CONTROL_EXT = ((int)0x81F8);
        public const int LIGHT_MODEL_LOCAL_VIEWER = ((int)0x0B51);
        public const int LIGHT_MODEL_TWO_SIDE = ((int)0x0B52);
        public const int LIGHT0 = ((int)0x4000);
        public const int LIGHT1 = ((int)0x4001);
        public const int LIGHT2 = ((int)0x4002);
        public const int LIGHT3 = ((int)0x4003);
        public const int LIGHT4 = ((int)0x4004);
        public const int LIGHT5 = ((int)0x4005);
        public const int LIGHT6 = ((int)0x4006);
        public const int LIGHT7 = ((int)0x4007);
        public const int LIGHTING = ((int)0x0B50);
        public const int LIGHTING_BIT = ((int)0x00000040);
        public const int LINE = ((int)0x1B01);
        public const int LINE_BIT = ((int)0x00000004);
        public const int LINE_LOOP = ((int)0x0002);
        public const int LINE_RESET_TOKEN = ((int)0x0707);
        public const int LINE_SMOOTH = ((int)0x0B20);
        public const int LINE_SMOOTH_HINT = ((int)0x0C52);
        public const int LINE_STIPPLE = ((int)0x0B24);
        public const int LINE_STIPPLE_PATTERN = ((int)0x0B25);
        public const int LINE_STIPPLE_REPEAT = ((int)0x0B26);
        public const int LINE_STRIP = ((int)0x0003);
        public const int LINE_STRIP_ADJACENCY = ((int)0x000B);
        public const int LINE_STRIP_ADJACENCY_ARB = ((int)0x000B);
        public const int LINE_STRIP_ADJACENCY_EXT = ((int)0x000B);
        public const int LINE_TOKEN = ((int)0x0702);
        public const int LINE_WIDTH = ((int)0x0B21);
        public const int LINE_WIDTH_GRANULARITY = ((int)0x0B23);
        public const int LINE_WIDTH_RANGE = ((int)0x0B22);
        public const int LINEAR = ((int)0x2601);
        public const int LINEAR_ATTENUATION = ((int)0x1208);
        public const int LINEAR_MIPMAP_LINEAR = ((int)0x2703);
        public const int LINEAR_MIPMAP_NEAREST = ((int)0x2701);
        public const int LINES = ((int)0x0001);
        public const int LINES_ADJACENCY = ((int)0x000A);
        public const int LINES_ADJACENCY_ARB = ((int)0x000A);
        public const int LINES_ADJACENCY_EXT = ((int)0x000A);
        public const int LINK_STATUS = ((int)0x8B82);
        public const int LIST_BASE = ((int)0x0B32);
        public const int LIST_BIT = ((int)0x00020000);
        public const int LIST_INDEX = ((int)0x0B33);
        public const int LIST_MODE = ((int)0x0B30);
        public const int LOAD = ((int)0x0101);
        public const int LOCAL_CONSTANT_DATATYPE_EXT = ((int)0x87ED);
        public const int LOCAL_CONSTANT_EXT = ((int)0x87C3);
        public const int LOCAL_CONSTANT_VALUE_EXT = ((int)0x87EC);
        public const int LOCAL_EXT = ((int)0x87C4);
        public const int LOGIC_OP = ((int)0x0BF1);
        public const int LOGIC_OP_MODE = ((int)0x0BF0);
        public const int LOWER_LEFT = ((int)0x8CA1);
        public const int LUMINANCE = ((int)0x1909);
        public const int LUMINANCE_ALPHA = ((int)0x190A);
        public const int LUMINANCE_ALPHA_INTEGER_EXT = ((int)0x8D9D);
        public const int LUMINANCE_ALPHA_SNORM = ((int)0x9012);
        public const int LUMINANCE_ALPHA16F_ARB = ((int)0x881F);
        public const int LUMINANCE_ALPHA16I_EXT = ((int)0x8D8D);
        public const int LUMINANCE_ALPHA16UI_EXT = ((int)0x8D7B);
        public const int LUMINANCE_ALPHA32F_ARB = ((int)0x8819);
        public const int LUMINANCE_ALPHA32I_EXT = ((int)0x8D87);
        public const int LUMINANCE_ALPHA32UI_EXT = ((int)0x8D75);
        public const int LUMINANCE_ALPHA8I_EXT = ((int)0x8D93);
        public const int LUMINANCE_ALPHA8UI_EXT = ((int)0x8D81);
        public const int LUMINANCE_INTEGER_EXT = ((int)0x8D9C);
        public const int LUMINANCE_SNORM = ((int)0x9011);
        public const int LUMINANCE12 = ((int)0x8041);
        public const int LUMINANCE12_ALPHA12 = ((int)0x8047);
        public const int LUMINANCE12_ALPHA12_EXT = ((int)0x8047);
        public const int LUMINANCE12_ALPHA4 = ((int)0x8046);
        public const int LUMINANCE12_ALPHA4_EXT = ((int)0x8046);
        public const int LUMINANCE12_EXT = ((int)0x8041);
        public const int LUMINANCE16 = ((int)0x8042);
        public const int LUMINANCE16_ALPHA16 = ((int)0x8048);
        public const int LUMINANCE16_ALPHA16_EXT = ((int)0x8048);
        public const int LUMINANCE16_ALPHA16_SNORM = ((int)0x901A);
        public const int LUMINANCE16_EXT = ((int)0x8042);
        public const int LUMINANCE16_SNORM = ((int)0x9019);
        public const int LUMINANCE16F_ARB = ((int)0x881E);
        public const int LUMINANCE16I_EXT = ((int)0x8D8C);
        public const int LUMINANCE16UI_EXT = ((int)0x8D7A);
        public const int LUMINANCE32F_ARB = ((int)0x8818);
        public const int LUMINANCE32I_EXT = ((int)0x8D86);
        public const int LUMINANCE32UI_EXT = ((int)0x8D74);
        public const int LUMINANCE4 = ((int)0x803F);
        public const int LUMINANCE4_ALPHA4 = ((int)0x8043);
        public const int LUMINANCE4_ALPHA4_EXT = ((int)0x8043);
        public const int LUMINANCE4_EXT = ((int)0x803F);
        public const int LUMINANCE6_ALPHA2 = ((int)0x8044);
        public const int LUMINANCE6_ALPHA2_EXT = ((int)0x8044);
        public const int LUMINANCE8 = ((int)0x8040);
        public const int LUMINANCE8_ALPHA8 = ((int)0x8045);
        public const int LUMINANCE8_ALPHA8_EXT = ((int)0x8045);
        public const int LUMINANCE8_ALPHA8_SNORM = ((int)0x9016);
        public const int LUMINANCE8_EXT = ((int)0x8040);
        public const int LUMINANCE8_SNORM = ((int)0x9015);
        public const int LUMINANCE8I_EXT = ((int)0x8D92);
        public const int LUMINANCE8UI_EXT = ((int)0x8D80);
        public const int MAJOR_VERSION = ((int)0x821B);
        public const int MAP_COLOR = ((int)0x0D10);
        public const int MAP_FLUSH_EXPLICIT_BIT = ((int)0x0010);
        public const int MAP_INVALIDATE_BUFFER_BIT = ((int)0x0008);
        public const int MAP_INVALIDATE_RANGE_BIT = ((int)0x0004);
        public const int MAP_READ_BIT = ((int)0x0001);
        public const int MAP_STENCIL = ((int)0x0D11);
        public const int MAP_UNSYNCHRONIZED_BIT = ((int)0x0020);
        public const int MAP_WRITE_BIT = ((int)0x0002);
        public const int MAP1_BINORMAL_EXT = ((int)0x8446);
        public const int MAP1_COLOR_4 = ((int)0x0D90);
        public const int MAP1_GRID_DOMAIN = ((int)0x0DD0);
        public const int MAP1_GRID_SEGMENTS = ((int)0x0DD1);
        public const int MAP1_INDEX = ((int)0x0D91);
        public const int MAP1_NORMAL = ((int)0x0D92);
        public const int MAP1_TANGENT_EXT = ((int)0x8444);
        public const int MAP1_TEXTURE_COORD_1 = ((int)0x0D93);
        public const int MAP1_TEXTURE_COORD_2 = ((int)0x0D94);
        public const int MAP1_TEXTURE_COORD_3 = ((int)0x0D95);
        public const int MAP1_TEXTURE_COORD_4 = ((int)0x0D96);
        public const int MAP1_VERTEX_3 = ((int)0x0D97);
        public const int MAP1_VERTEX_4 = ((int)0x0D98);
        public const int MAP2_BINORMAL_EXT = ((int)0x8447);
        public const int MAP2_COLOR_4 = ((int)0x0DB0);
        public const int MAP2_GRID_DOMAIN = ((int)0x0DD2);
        public const int MAP2_GRID_SEGMENTS = ((int)0x0DD3);
        public const int MAP2_INDEX = ((int)0x0DB1);
        public const int MAP2_NORMAL = ((int)0x0DB2);
        public const int MAP2_TANGENT_EXT = ((int)0x8445);
        public const int MAP2_TEXTURE_COORD_1 = ((int)0x0DB3);
        public const int MAP2_TEXTURE_COORD_2 = ((int)0x0DB4);
        public const int MAP2_TEXTURE_COORD_3 = ((int)0x0DB5);
        public const int MAP2_TEXTURE_COORD_4 = ((int)0x0DB6);
        public const int MAP2_VERTEX_3 = ((int)0x0DB7);
        public const int MAP2_VERTEX_4 = ((int)0x0DB8);
        public const int MATRIX_EXT = ((int)0x87C0);
        public const int MATRIX_INDEX_ARRAY_ARB = ((int)0x8844);
        public const int MATRIX_INDEX_ARRAY_POINTER_ARB = ((int)0x8849);
        public const int MATRIX_INDEX_ARRAY_SIZE_ARB = ((int)0x8846);
        public const int MATRIX_INDEX_ARRAY_STRIDE_ARB = ((int)0x8848);
        public const int MATRIX_INDEX_ARRAY_TYPE_ARB = ((int)0x8847);
        public const int MATRIX_MODE = ((int)0x0BA0);
        public const int MATRIX_PALETTE_ARB = ((int)0x8840);
        public const int MATRIX0 = ((int)0x88C0);
        public const int MATRIX0_ARB = ((int)0x88C0);
        public const int MATRIX1 = ((int)0x88C1);
        public const int MATRIX1_ARB = ((int)0x88C1);
        public const int MATRIX10 = ((int)0x88CA);
        public const int MATRIX10_ARB = ((int)0x88CA);
        public const int MATRIX11 = ((int)0x88CB);
        public const int MATRIX11_ARB = ((int)0x88CB);
        public const int MATRIX12 = ((int)0x88CC);
        public const int MATRIX12_ARB = ((int)0x88CC);
        public const int MATRIX13 = ((int)0x88CD);
        public const int MATRIX13_ARB = ((int)0x88CD);
        public const int MATRIX14 = ((int)0x88CE);
        public const int MATRIX14_ARB = ((int)0x88CE);
        public const int MATRIX15 = ((int)0x88CF);
        public const int MATRIX15_ARB = ((int)0x88CF);
        public const int MATRIX16 = ((int)0x88D0);
        public const int MATRIX16_ARB = ((int)0x88D0);
        public const int MATRIX17 = ((int)0x88D1);
        public const int MATRIX17_ARB = ((int)0x88D1);
        public const int MATRIX18 = ((int)0x88D2);
        public const int MATRIX18_ARB = ((int)0x88D2);
        public const int MATRIX19 = ((int)0x88D3);
        public const int MATRIX19_ARB = ((int)0x88D3);
        public const int MATRIX2 = ((int)0x88C2);
        public const int MATRIX2_ARB = ((int)0x88C2);
        public const int MATRIX20 = ((int)0x88D4);
        public const int MATRIX20_ARB = ((int)0x88D4);
        public const int MATRIX21 = ((int)0x88D5);
        public const int MATRIX21_ARB = ((int)0x88D5);
        public const int MATRIX22 = ((int)0x88D6);
        public const int MATRIX22_ARB = ((int)0x88D6);
        public const int MATRIX23 = ((int)0x88D7);
        public const int MATRIX23_ARB = ((int)0x88D7);
        public const int MATRIX24 = ((int)0x88D8);
        public const int MATRIX24_ARB = ((int)0x88D8);
        public const int MATRIX25 = ((int)0x88D9);
        public const int MATRIX25_ARB = ((int)0x88D9);
        public const int MATRIX26 = ((int)0x88DA);
        public const int MATRIX26_ARB = ((int)0x88DA);
        public const int MATRIX27 = ((int)0x88DB);
        public const int MATRIX27_ARB = ((int)0x88DB);
        public const int MATRIX28 = ((int)0x88DC);
        public const int MATRIX28_ARB = ((int)0x88DC);
        public const int MATRIX29 = ((int)0x88DD);
        public const int MATRIX29_ARB = ((int)0x88DD);
        public const int MATRIX3 = ((int)0x88C3);
        public const int MATRIX3_ARB = ((int)0x88C3);
        public const int MATRIX30 = ((int)0x88DE);
        public const int MATRIX30_ARB = ((int)0x88DE);
        public const int MATRIX31 = ((int)0x88DF);
        public const int MATRIX31_ARB = ((int)0x88DF);
        public const int MATRIX4 = ((int)0x88C4);
        public const int MATRIX4_ARB = ((int)0x88C4);
        public const int MATRIX5 = ((int)0x88C5);
        public const int MATRIX5_ARB = ((int)0x88C5);
        public const int MATRIX6 = ((int)0x88C6);
        public const int MATRIX6_ARB = ((int)0x88C6);
        public const int MATRIX7 = ((int)0x88C7);
        public const int MATRIX7_ARB = ((int)0x88C7);
        public const int MATRIX8 = ((int)0x88C8);
        public const int MATRIX8_ARB = ((int)0x88C8);
        public const int MATRIX9 = ((int)0x88C9);
        public const int MATRIX9_ARB = ((int)0x88C9);
        public const int MAX = ((int)0x8008);
        public const int MAX_3D_TEXTURE_SIZE = ((int)0x8073);
        public const int MAX_3D_TEXTURE_SIZE_EXT = ((int)0x8073);
        public const int MAX_4D_TEXTURE_SIZE_SGIS = ((int)0x8138);
        public const int MAX_ARRAY_TEXTURE_LAYERS = ((int)0x88FF);
        public const int MAX_ARRAY_TEXTURE_LAYERS_EXT = ((int)0x88FF);
        public const int MAX_ATTRIB_STACK_DEPTH = ((int)0x0D35);
        public const int MAX_BINDABLE_UNIFORM_SIZE_EXT = ((int)0x8DED);
        public const int MAX_CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0D3B);
        public const int MAX_CLIP_DISTANCES = ((int)0x0D32);
        public const int MAX_CLIP_PLANES = ((int)0x0D32);
        public const int MAX_COLOR_ATTACHMENTS = ((int)0x8CDF);
        public const int MAX_COLOR_ATTACHMENTS_EXT = ((int)0x8CDF);
        public const int MAX_COLOR_MATRIX_STACK_DEPTH = ((int)0x80B3);
        public const int MAX_COLOR_MATRIX_STACK_DEPTH_SGI = ((int)0x80B3);
        public const int MAX_COLOR_TEXTURE_SAMPLES = ((int)0x910E);
        public const int MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8A33);
        public const int MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8A32);
        public const int MAX_COMBINED_TEXTURE_IMAGE_UNITS = ((int)0x8B4D);
        public const int MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8B4D);
        public const int MAX_COMBINED_UNIFORM_BLOCKS = ((int)0x8A2E);
        public const int MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = ((int)0x8A31);
        public const int MAX_CONVOLUTION_HEIGHT = ((int)0x801B);
        public const int MAX_CONVOLUTION_HEIGHT_EXT = ((int)0x801B);
        public const int MAX_CONVOLUTION_WIDTH = ((int)0x801A);
        public const int MAX_CONVOLUTION_WIDTH_EXT = ((int)0x801A);
        public const int MAX_CUBE_MAP_TEXTURE_SIZE = ((int)0x851C);
        public const int MAX_CUBE_MAP_TEXTURE_SIZE_ARB = ((int)0x851C);
        public const int MAX_CUBE_MAP_TEXTURE_SIZE_EXT = ((int)0x851C);
        public const int MAX_DEPTH_TEXTURE_SAMPLES = ((int)0x910F);
        public const int MAX_DRAW_BUFFERS = ((int)0x8824);
        public const int MAX_DRAW_BUFFERS_ARB = ((int)0x8824);
        public const int MAX_ELEMENTS_INDICES = ((int)0x80E9);
        public const int MAX_ELEMENTS_INDICES_EXT = ((int)0x80E9);
        public const int MAX_ELEMENTS_VERTICES = ((int)0x80E8);
        public const int MAX_ELEMENTS_VERTICES_EXT = ((int)0x80E8);
        public const int MAX_EVAL_ORDER = ((int)0x0D30);
        public const int MAX_EXT = ((int)0x8008);
        public const int MAX_FRAGMENT_BINDABLE_UNIFORMS_EXT = ((int)0x8DE3);
        public const int MAX_FRAGMENT_INPUT_COMPONENTS = ((int)0x9125);
        public const int MAX_FRAGMENT_UNIFORM_BLOCKS = ((int)0x8A2D);
        public const int MAX_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8B49);
        public const int MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = ((int)0x8B49);
        public const int MAX_GEOMETRY_BINDABLE_UNIFORMS_EXT = ((int)0x8DE4);
        public const int MAX_GEOMETRY_INPUT_COMPONENTS = ((int)0x9123);
        public const int MAX_GEOMETRY_OUTPUT_COMPONENTS = ((int)0x9124);
        public const int MAX_GEOMETRY_OUTPUT_VERTICES = ((int)0x8DE0);
        public const int MAX_GEOMETRY_OUTPUT_VERTICES_ARB = ((int)0x8DE0);
        public const int MAX_GEOMETRY_OUTPUT_VERTICES_EXT = ((int)0x8DE0);
        public const int MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = ((int)0x8C29);
        public const int MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8C29);
        public const int MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT = ((int)0x8C29);
        public const int MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = ((int)0x8DE1);
        public const int MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_ARB = ((int)0x8DE1);
        public const int MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_EXT = ((int)0x8DE1);
        public const int MAX_GEOMETRY_UNIFORM_BLOCKS = ((int)0x8A2C);
        public const int MAX_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8DDF);
        public const int MAX_GEOMETRY_UNIFORM_COMPONENTS_ARB = ((int)0x8DDF);
        public const int MAX_GEOMETRY_UNIFORM_COMPONENTS_EXT = ((int)0x8DDF);
        public const int MAX_GEOMETRY_VARYING_COMPONENTS = ((int)0x8DDD);
        public const int MAX_GEOMETRY_VARYING_COMPONENTS_ARB = ((int)0x8DDD);
        public const int MAX_GEOMETRY_VARYING_COMPONENTS_EXT = ((int)0x8DDD);
        public const int MAX_INTEGER_SAMPLES = ((int)0x9110);
        public const int MAX_LIGHTS = ((int)0x0D31);
        public const int MAX_LIST_NESTING = ((int)0x0B31);
        public const int MAX_MATRIX_PALETTE_STACK_DEPTH_ARB = ((int)0x8841);
        public const int MAX_MODELVIEW_STACK_DEPTH = ((int)0x0D36);
        public const int MAX_NAME_STACK_DEPTH = ((int)0x0D37);
        public const int MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87CA);
        public const int MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87CD);
        public const int MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87CC);
        public const int MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT = ((int)0x87CE);
        public const int MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT = ((int)0x87CB);
        public const int MAX_PALETTE_MATRICES_ARB = ((int)0x8842);
        public const int MAX_PIXEL_MAP_TABLE = ((int)0x0D34);
        public const int MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = ((int)0x8337);
        public const int MAX_PROGRAM_ADDRESS_REGISTERS = ((int)0x88B1);
        public const int MAX_PROGRAM_ADDRESS_REGISTERS_ARB = ((int)0x88B1);
        public const int MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x880B);
        public const int MAX_PROGRAM_ATTRIB_COMPONENTS_NV = ((int)0x8908);
        public const int MAX_PROGRAM_ATTRIBS = ((int)0x88AD);
        public const int MAX_PROGRAM_ATTRIBS_ARB = ((int)0x88AD);
        public const int MAX_PROGRAM_ENV_PARAMETERS = ((int)0x88B5);
        public const int MAX_PROGRAM_ENV_PARAMETERS_ARB = ((int)0x88B5);
        public const int MAX_PROGRAM_GENERIC_ATTRIBS_NV = ((int)0x8DA5);
        public const int MAX_PROGRAM_GENERIC_RESULTS_NV = ((int)0x8DA6);
        public const int MAX_PROGRAM_INSTRUCTIONS = ((int)0x88A1);
        public const int MAX_PROGRAM_INSTRUCTIONS_ARB = ((int)0x88A1);
        public const int MAX_PROGRAM_LOCAL_PARAMETERS = ((int)0x88B4);
        public const int MAX_PROGRAM_LOCAL_PARAMETERS_ARB = ((int)0x88B4);
        public const int MAX_PROGRAM_MATRICES_ARB = ((int)0x862F);
        public const int MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = ((int)0x862E);
        public const int MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS = ((int)0x88B3);
        public const int MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = ((int)0x88B3);
        public const int MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x880E);
        public const int MAX_PROGRAM_NATIVE_ATTRIBS = ((int)0x88AF);
        public const int MAX_PROGRAM_NATIVE_ATTRIBS_ARB = ((int)0x88AF);
        public const int MAX_PROGRAM_NATIVE_INSTRUCTIONS = ((int)0x88A3);
        public const int MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = ((int)0x88A3);
        public const int MAX_PROGRAM_NATIVE_PARAMETERS = ((int)0x88AB);
        public const int MAX_PROGRAM_NATIVE_PARAMETERS_ARB = ((int)0x88AB);
        public const int MAX_PROGRAM_NATIVE_TEMPORARIES = ((int)0x88A7);
        public const int MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = ((int)0x88A7);
        public const int MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x8810);
        public const int MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x880F);
        public const int MAX_PROGRAM_OUTPUT_VERTICES_NV = ((int)0x8C27);
        public const int MAX_PROGRAM_PARAMETER_BUFFER_BINDINGS_NV = ((int)0x8DA0);
        public const int MAX_PROGRAM_PARAMETER_BUFFER_SIZE_NV = ((int)0x8DA1);
        public const int MAX_PROGRAM_PARAMETERS = ((int)0x88A9);
        public const int MAX_PROGRAM_PARAMETERS_ARB = ((int)0x88A9);
        public const int MAX_PROGRAM_RESULT_COMPONENTS_NV = ((int)0x8909);
        public const int MAX_PROGRAM_TEMPORARIES = ((int)0x88A5);
        public const int MAX_PROGRAM_TEMPORARIES_ARB = ((int)0x88A5);
        public const int MAX_PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x880D);
        public const int MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x880C);
        public const int MAX_PROGRAM_TEXEL_OFFSET = ((int)0x8905);
        public const int MAX_PROGRAM_TEXEL_OFFSET_NV = ((int)0x8905);
        public const int MAX_PROGRAM_TEXTURE_GATHER_COMPONENTS = ((int)0x8F9F);
        public const int MAX_PROGRAM_TEXTURE_GATHER_OFFSET = ((int)0x8E5F);
        public const int MAX_PROGRAM_TOTAL_OUTPUT_COMPONENTS_NV = ((int)0x8C28);
        public const int MAX_PROJECTION_STACK_DEPTH = ((int)0x0D38);
        public const int MAX_RECTANGLE_TEXTURE_SIZE = ((int)0x84F8);
        public const int MAX_RECTANGLE_TEXTURE_SIZE_ARB = ((int)0x84F8);
        public const int MAX_RENDERBUFFER_SIZE = ((int)0x84E8);
        public const int MAX_RENDERBUFFER_SIZE_EXT = ((int)0x84E8);
        public const int MAX_SAMPLE_MASK_WORDS = ((int)0x8E59);
        public const int MAX_SAMPLE_MASK_WORDS_NV = ((int)0x8E59);
        public const int MAX_SAMPLES = ((int)0x8D57);
        public const int MAX_SAMPLES_EXT = ((int)0x8D57);
        public const int MAX_SERVER_WAIT_TIMEOUT = ((int)0x9111);
        public const int MAX_TEXTURE_BUFFER_SIZE = ((int)0x8C2B);
        public const int MAX_TEXTURE_BUFFER_SIZE_ARB = ((int)0x8C2B);
        public const int MAX_TEXTURE_BUFFER_SIZE_EXT = ((int)0x8C2B);
        public const int MAX_TEXTURE_COORDS = ((int)0x8871);
        public const int MAX_TEXTURE_COORDS_ARB = ((int)0x8871);
        public const int MAX_TEXTURE_IMAGE_UNITS = ((int)0x8872);
        public const int MAX_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8872);
        public const int MAX_TEXTURE_LOD_BIAS = ((int)0x84FD);
        public const int MAX_TEXTURE_LOD_BIAS_EXT = ((int)0x84FD);
        public const int MAX_TEXTURE_MAX_ANISOTROPY_EXT = ((int)0x84FF);
        public const int MAX_TEXTURE_SIZE = ((int)0x0D33);
        public const int MAX_TEXTURE_STACK_DEPTH = ((int)0x0D39);
        public const int MAX_TEXTURE_UNITS = ((int)0x84E2);
        public const int MAX_TEXTURE_UNITS_ARB = ((int)0x84E2);
        public const int MAX_TRANSFORM_FEEDBACK_INTERLEAVED_ATTRIBS_NV = ((int)0x8C8A);
        public const int MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = ((int)0x8C8A);
        public const int MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_EXT = ((int)0x8C8A);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = ((int)0x8C8B);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_EXT = ((int)0x8C8B);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_NV = ((int)0x8C8B);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = ((int)0x8C80);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_EXT = ((int)0x8C80);
        public const int MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_NV = ((int)0x8C80);
        public const int MAX_UNIFORM_BLOCK_SIZE = ((int)0x8A30);
        public const int MAX_UNIFORM_BUFFER_BINDINGS = ((int)0x8A2F);
        public const int MAX_VARYING_COMPONENTS = ((int)0x8B4B);
        public const int MAX_VARYING_COMPONENTS_EXT = ((int)0x8B4B);
        public const int MAX_VARYING_FLOATS = ((int)0x8B4B);
        public const int MAX_VARYING_FLOATS_ARB = ((int)0x8B4B);
        public const int MAX_VERTEX_ATTRIBS = ((int)0x8869);
        public const int MAX_VERTEX_ATTRIBS_ARB = ((int)0x8869);
        public const int MAX_VERTEX_BINDABLE_UNIFORMS_EXT = ((int)0x8DE2);
        public const int MAX_VERTEX_OUTPUT_COMPONENTS = ((int)0x9122);
        public const int MAX_VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87C5);
        public const int MAX_VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87C7);
        public const int MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87C8);
        public const int MAX_VERTEX_SHADER_LOCALS_EXT = ((int)0x87C9);
        public const int MAX_VERTEX_SHADER_VARIANTS_EXT = ((int)0x87C6);
        public const int MAX_VERTEX_TEXTURE_IMAGE_UNITS = ((int)0x8B4C);
        public const int MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8B4C);
        public const int MAX_VERTEX_UNIFORM_BLOCKS = ((int)0x8A2B);
        public const int MAX_VERTEX_UNIFORM_COMPONENTS = ((int)0x8B4A);
        public const int MAX_VERTEX_UNIFORM_COMPONENTS_ARB = ((int)0x8B4A);
        public const int MAX_VERTEX_UNITS_ARB = ((int)0x86A4);
        public const int MAX_VERTEX_VARYING_COMPONENTS = ((int)0x8DDE);
        public const int MAX_VERTEX_VARYING_COMPONENTS_ARB = ((int)0x8DDE);
        public const int MAX_VERTEX_VARYING_COMPONENTS_EXT = ((int)0x8DDE);
        public const int MAX_VIEWPORT_DIMS = ((int)0x0D3A);
        public const int MIN = ((int)0x8007);
        public const int MIN_EXT = ((int)0x8007);
        public const int MIN_PROGRAM_TEXEL_OFFSET = ((int)0x8904);
        public const int MIN_PROGRAM_TEXEL_OFFSET_NV = ((int)0x8904);
        public const int MIN_PROGRAM_TEXTURE_GATHER_OFFSET = ((int)0x8E5E);
        public const int MIN_SAMPLE_SHADING_VALUE = ((int)0x8C37);
        public const int MINMAX = ((int)0x802E);
        public const int MINMAX_EXT = ((int)0x802E);
        public const int MINMAX_FORMAT = ((int)0x802F);
        public const int MINMAX_FORMAT_EXT = ((int)0x802F);
        public const int MINMAX_SINK = ((int)0x8030);
        public const int MINMAX_SINK_EXT = ((int)0x8030);
        public const int MINOR_VERSION = ((int)0x821C);
        public const int MIRROR_CLAMP_EXT = ((int)0x8742);
        public const int MIRROR_CLAMP_TO_BORDER_EXT = ((int)0x8912);
        public const int MIRROR_CLAMP_TO_EDGE_EXT = ((int)0x8743);
        public const int MIRRORED_REPEAT = ((int)0x8370);
        public const int MIRRORED_REPEAT_ARB = ((int)0x8370);
        public const int MODELVIEW = ((int)0x1700);
        public const int MODELVIEW_MATRIX = ((int)0x0BA6);
        public const int MODELVIEW_STACK_DEPTH = ((int)0x0BA3);
        public const int MODELVIEW0_ARB = ((int)0x1700);
        public const int MODELVIEW0_EXT = ((int)0x1700);
        public const int MODELVIEW0_MATRIX_EXT = ((int)0x0BA6);
        public const int MODELVIEW0_STACK_DEPTH_EXT = ((int)0x0BA3);
        public const int MODELVIEW1_ARB = ((int)0x850A);
        public const int MODELVIEW1_EXT = ((int)0x850A);
        public const int MODELVIEW1_MATRIX_EXT = ((int)0x8506);
        public const int MODELVIEW1_STACK_DEPTH_EXT = ((int)0x8502);
        public const int MODELVIEW10_ARB = ((int)0x872A);
        public const int MODELVIEW11_ARB = ((int)0x872B);
        public const int MODELVIEW12_ARB = ((int)0x872C);
        public const int MODELVIEW13_ARB = ((int)0x872D);
        public const int MODELVIEW14_ARB = ((int)0x872E);
        public const int MODELVIEW15_ARB = ((int)0x872F);
        public const int MODELVIEW16_ARB = ((int)0x8730);
        public const int MODELVIEW17_ARB = ((int)0x8731);
        public const int MODELVIEW18_ARB = ((int)0x8732);
        public const int MODELVIEW19_ARB = ((int)0x8733);
        public const int MODELVIEW2_ARB = ((int)0x8722);
        public const int MODELVIEW20_ARB = ((int)0x8734);
        public const int MODELVIEW21_ARB = ((int)0x8735);
        public const int MODELVIEW22_ARB = ((int)0x8736);
        public const int MODELVIEW23_ARB = ((int)0x8737);
        public const int MODELVIEW24_ARB = ((int)0x8738);
        public const int MODELVIEW25_ARB = ((int)0x8739);
        public const int MODELVIEW26_ARB = ((int)0x873A);
        public const int MODELVIEW27_ARB = ((int)0x873B);
        public const int MODELVIEW28_ARB = ((int)0x873C);
        public const int MODELVIEW29_ARB = ((int)0x873D);
        public const int MODELVIEW3_ARB = ((int)0x8723);
        public const int MODELVIEW30_ARB = ((int)0x873E);
        public const int MODELVIEW31_ARB = ((int)0x873F);
        public const int MODELVIEW4_ARB = ((int)0x8724);
        public const int MODELVIEW5_ARB = ((int)0x8725);
        public const int MODELVIEW6_ARB = ((int)0x8726);
        public const int MODELVIEW7_ARB = ((int)0x8727);
        public const int MODELVIEW8_ARB = ((int)0x8728);
        public const int MODELVIEW9_ARB = ((int)0x8729);
        public const int MODULATE = ((int)0x2100);
        public const int MULT = ((int)0x0103);
        public const int MULTISAMPLE = ((int)0x809D);
        public const int MULTISAMPLE_ARB = ((int)0x809D);
        public const int MULTISAMPLE_BIT = ((int)0x20000000);
        public const int MULTISAMPLE_BIT_ARB = ((int)0x20000000);
        public const int MULTISAMPLE_BIT_EXT = ((int)0x20000000);
        public const int MULTISAMPLE_EXT = ((int)0x809D);
        public const int MULTISAMPLE_SGIS = ((int)0x809D);
        public const int MVP_MATRIX_EXT = ((int)0x87E3);
        public const int N3F_V3F = ((int)0x2A25);
        public const int NAME_STACK_DEPTH = ((int)0x0D70);
        public const int NAND = ((int)0x150E);
        public const int NEAREST = ((int)0x2600);
        public const int NEAREST_MIPMAP_LINEAR = ((int)0x2702);
        public const int NEAREST_MIPMAP_NEAREST = ((int)0x2700);
        public const int NEGATIVE_ONE_EXT = ((int)0x87DF);
        public const int NEGATIVE_W_EXT = ((int)0x87DC);
        public const int NEGATIVE_X_EXT = ((int)0x87D9);
        public const int NEGATIVE_Y_EXT = ((int)0x87DA);
        public const int NEGATIVE_Z_EXT = ((int)0x87DB);
        public const int NEVER = ((int)0x0200);
        public const int NICEST = ((int)0x1102);
        public const int NO_ERROR = ((int)0);
        public const int NONE = ((int)0);
        public const int NOOP = ((int)0x1505);
        public const int NOR = ((int)0x1508);
        public const int NORMAL_ARRAY = ((int)0x8075);
        public const int NORMAL_ARRAY_BUFFER_BINDING = ((int)0x8897);
        public const int NORMAL_ARRAY_BUFFER_BINDING_ARB = ((int)0x8897);
        public const int NORMAL_ARRAY_COUNT_EXT = ((int)0x8080);
        public const int NORMAL_ARRAY_EXT = ((int)0x8075);
        public const int NORMAL_ARRAY_POINTER = ((int)0x808F);
        public const int NORMAL_ARRAY_POINTER_EXT = ((int)0x808F);
        public const int NORMAL_ARRAY_STRIDE = ((int)0x807F);
        public const int NORMAL_ARRAY_STRIDE_EXT = ((int)0x807F);
        public const int NORMAL_ARRAY_TYPE = ((int)0x807E);
        public const int NORMAL_ARRAY_TYPE_EXT = ((int)0x807E);
        public const int NORMAL_MAP = ((int)0x8511);
        public const int NORMAL_MAP_ARB = ((int)0x8511);
        public const int NORMAL_MAP_EXT = ((int)0x8511);
        public const int NORMALIZE = ((int)0x0BA1);
        public const int NORMALIZED_RANGE_EXT = ((int)0x87E0);
        public const int NOTEQUAL = ((int)0x0205);
        public const int NUM_COMPRESSED_TEXTURE_FORMATS = ((int)0x86A2);
        public const int NUM_COMPRESSED_TEXTURE_FORMATS_ARB = ((int)0x86A2);
        public const int NUM_EXTENSIONS = ((int)0x821D);
        public const int NUM_FILL_STREAMS_NV = ((int)0x8E29);
        public const int OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = ((int)0x8B8A);
        public const int OBJECT_ACTIVE_ATTRIBUTES_ARB = ((int)0x8B89);
        public const int OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = ((int)0x8B87);
        public const int OBJECT_ACTIVE_UNIFORMS_ARB = ((int)0x8B86);
        public const int OBJECT_ATTACHED_OBJECTS_ARB = ((int)0x8B85);
        public const int OBJECT_COMPILE_STATUS_ARB = ((int)0x8B81);
        public const int OBJECT_DELETE_STATUS_ARB = ((int)0x8B80);
        public const int OBJECT_INFO_LOG_LENGTH_ARB = ((int)0x8B84);
        public const int OBJECT_LINEAR = ((int)0x2401);
        public const int OBJECT_LINK_STATUS_ARB = ((int)0x8B82);
        public const int OBJECT_PLANE = ((int)0x2501);
        public const int OBJECT_SHADER_SOURCE_LENGTH_ARB = ((int)0x8B88);
        public const int OBJECT_SUBTYPE_ARB = ((int)0x8B4F);
        public const int OBJECT_TYPE = ((int)0x9112);
        public const int OBJECT_TYPE_ARB = ((int)0x8B4E);
        public const int OBJECT_VALIDATE_STATUS_ARB = ((int)0x8B83);
        public const int ONE = ((int)1);
        public const int ONE_EXT = ((int)0x87DE);
        public const int ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004);
        public const int ONE_MINUS_CONSTANT_ALPHA_EXT = ((int)0x8004);
        public const int ONE_MINUS_CONSTANT_COLOR = ((int)0x8002);
        public const int ONE_MINUS_CONSTANT_COLOR_EXT = ((int)0x8002);
        public const int ONE_MINUS_DST_ALPHA = ((int)0x0305);
        public const int ONE_MINUS_DST_COLOR = ((int)0x0307);
        public const int ONE_MINUS_SRC_ALPHA = ((int)0x0303);
        public const int ONE_MINUS_SRC_COLOR = ((int)0x0301);
        public const int OP_ADD_EXT = ((int)0x8787);
        public const int OP_CLAMP_EXT = ((int)0x878E);
        public const int OP_CROSS_PRODUCT_EXT = ((int)0x8797);
        public const int OP_DOT3_EXT = ((int)0x8784);
        public const int OP_DOT4_EXT = ((int)0x8785);
        public const int OP_EXP_BASE_2_EXT = ((int)0x8791);
        public const int OP_FLOOR_EXT = ((int)0x878F);
        public const int OP_FRAC_EXT = ((int)0x8789);
        public const int OP_INDEX_EXT = ((int)0x8782);
        public const int OP_LOG_BASE_2_EXT = ((int)0x8792);
        public const int OP_MADD_EXT = ((int)0x8788);
        public const int OP_MAX_EXT = ((int)0x878A);
        public const int OP_MIN_EXT = ((int)0x878B);
        public const int OP_MOV_EXT = ((int)0x8799);
        public const int OP_MUL_EXT = ((int)0x8786);
        public const int OP_MULTIPLY_MATRIX_EXT = ((int)0x8798);
        public const int OP_NEGATE_EXT = ((int)0x8783);
        public const int OP_POWER_EXT = ((int)0x8793);
        public const int OP_RECIP_EXT = ((int)0x8794);
        public const int OP_RECIP_SQRT_EXT = ((int)0x8795);
        public const int OP_ROUND_EXT = ((int)0x8790);
        public const int OP_SET_GE_EXT = ((int)0x878C);
        public const int OP_SET_LT_EXT = ((int)0x878D);
        public const int OP_SUB_EXT = ((int)0x8796);
        public const int OPERAND0_ALPHA = ((int)0x8598);
        public const int OPERAND0_ALPHA_ARB = ((int)0x8598);
        public const int OPERAND0_ALPHA_EXT = ((int)0x8598);
        public const int OPERAND0_RGB = ((int)0x8590);
        public const int OPERAND0_RGB_ARB = ((int)0x8590);
        public const int OPERAND0_RGB_EXT = ((int)0x8590);
        public const int OPERAND1_ALPHA = ((int)0x8599);
        public const int OPERAND1_ALPHA_ARB = ((int)0x8599);
        public const int OPERAND1_ALPHA_EXT = ((int)0x8599);
        public const int OPERAND1_RGB = ((int)0x8591);
        public const int OPERAND1_RGB_ARB = ((int)0x8591);
        public const int OPERAND1_RGB_EXT = ((int)0x8591);
        public const int OPERAND2_ALPHA = ((int)0x859A);
        public const int OPERAND2_ALPHA_ARB = ((int)0x859A);
        public const int OPERAND2_ALPHA_EXT = ((int)0x859A);
        public const int OPERAND2_RGB = ((int)0x8592);
        public const int OPERAND2_RGB_ARB = ((int)0x8592);
        public const int OPERAND2_RGB_EXT = ((int)0x8592);
        public const int OPERAND3_ALPHA_NV = ((int)0x859B);
        public const int OPERAND3_RGB_NV = ((int)0x8593);
        public const int OR = ((int)0x1507);
        public const int OR_INVERTED = ((int)0x150D);
        public const int OR_REVERSE = ((int)0x150B);
        public const int ORDER = ((int)0x0A01);
        public const int OUT_OF_MEMORY = ((int)0x0505);
        public const int OUTPUT_COLOR0_EXT = ((int)0x879B);
        public const int OUTPUT_COLOR1_EXT = ((int)0x879C);
        public const int OUTPUT_FOG_EXT = ((int)0x87BD);
        public const int OUTPUT_TEXTURE_COORD0_EXT = ((int)0x879D);
        public const int OUTPUT_TEXTURE_COORD1_EXT = ((int)0x879E);
        public const int OUTPUT_TEXTURE_COORD10_EXT = ((int)0x87A7);
        public const int OUTPUT_TEXTURE_COORD11_EXT = ((int)0x87A8);
        public const int OUTPUT_TEXTURE_COORD12_EXT = ((int)0x87A9);
        public const int OUTPUT_TEXTURE_COORD13_EXT = ((int)0x87AA);
        public const int OUTPUT_TEXTURE_COORD14_EXT = ((int)0x87AB);
        public const int OUTPUT_TEXTURE_COORD15_EXT = ((int)0x87AC);
        public const int OUTPUT_TEXTURE_COORD16_EXT = ((int)0x87AD);
        public const int OUTPUT_TEXTURE_COORD17_EXT = ((int)0x87AE);
        public const int OUTPUT_TEXTURE_COORD18_EXT = ((int)0x87AF);
        public const int OUTPUT_TEXTURE_COORD19_EXT = ((int)0x87B0);
        public const int OUTPUT_TEXTURE_COORD2_EXT = ((int)0x879F);
        public const int OUTPUT_TEXTURE_COORD20_EXT = ((int)0x87B1);
        public const int OUTPUT_TEXTURE_COORD21_EXT = ((int)0x87B2);
        public const int OUTPUT_TEXTURE_COORD22_EXT = ((int)0x87B3);
        public const int OUTPUT_TEXTURE_COORD23_EXT = ((int)0x87B4);
        public const int OUTPUT_TEXTURE_COORD24_EXT = ((int)0x87B5);
        public const int OUTPUT_TEXTURE_COORD25_EXT = ((int)0x87B6);
        public const int OUTPUT_TEXTURE_COORD26_EXT = ((int)0x87B7);
        public const int OUTPUT_TEXTURE_COORD27_EXT = ((int)0x87B8);
        public const int OUTPUT_TEXTURE_COORD28_EXT = ((int)0x87B9);
        public const int OUTPUT_TEXTURE_COORD29_EXT = ((int)0x87BA);
        public const int OUTPUT_TEXTURE_COORD3_EXT = ((int)0x87A0);
        public const int OUTPUT_TEXTURE_COORD30_EXT = ((int)0x87BB);
        public const int OUTPUT_TEXTURE_COORD31_EXT = ((int)0x87BC);
        public const int OUTPUT_TEXTURE_COORD4_EXT = ((int)0x87A1);
        public const int OUTPUT_TEXTURE_COORD5_EXT = ((int)0x87A2);
        public const int OUTPUT_TEXTURE_COORD6_EXT = ((int)0x87A3);
        public const int OUTPUT_TEXTURE_COORD7_EXT = ((int)0x87A4);
        public const int OUTPUT_TEXTURE_COORD8_EXT = ((int)0x87A5);
        public const int OUTPUT_TEXTURE_COORD9_EXT = ((int)0x87A6);
        public const int OUTPUT_VERTEX_EXT = ((int)0x879A);
        public const int PACK_ALIGNMENT = ((int)0x0D05);
        public const int PACK_CMYK_HINT_EXT = ((int)0x800E);
        public const int PACK_IMAGE_DEPTH_SGIS = ((int)0x8131);
        public const int PACK_IMAGE_HEIGHT = ((int)0x806C);
        public const int PACK_IMAGE_HEIGHT_EXT = ((int)0x806C);
        public const int PACK_LSB_FIRST = ((int)0x0D01);
        public const int PACK_ROW_LENGTH = ((int)0x0D02);
        public const int PACK_SKIP_IMAGES = ((int)0x806B);
        public const int PACK_SKIP_IMAGES_EXT = ((int)0x806B);
        public const int PACK_SKIP_PIXELS = ((int)0x0D04);
        public const int PACK_SKIP_ROWS = ((int)0x0D03);
        public const int PACK_SKIP_VOLUMES_SGIS = ((int)0x8130);
        public const int PACK_SWAP_BYTES = ((int)0x0D00);
        public const int PASS_THROUGH_TOKEN = ((int)0x0700);
        public const int PERCENTAGE_AMD = ((int)0x8BC3);
        public const int PERFMON_RESULT_AMD = ((int)0x8BC6);
        public const int PERFMON_RESULT_AVAILABLE_AMD = ((int)0x8BC4);
        public const int PERFMON_RESULT_SIZE_AMD = ((int)0x8BC5);
        public const int PERSPECTIVE_CORRECTION_HINT = ((int)0x0C50);
        public const int PERTURB_EXT = ((int)0x85AE);
        public const int PIXEL_CUBIC_WEIGHT_EXT = ((int)0x8333);
        public const int PIXEL_MAG_FILTER_EXT = ((int)0x8331);
        public const int PIXEL_MAP_A_TO_A = ((int)0x0C79);
        public const int PIXEL_MAP_A_TO_A_SIZE = ((int)0x0CB9);
        public const int PIXEL_MAP_B_TO_B = ((int)0x0C78);
        public const int PIXEL_MAP_B_TO_B_SIZE = ((int)0x0CB8);
        public const int PIXEL_MAP_G_TO_G = ((int)0x0C77);
        public const int PIXEL_MAP_G_TO_G_SIZE = ((int)0x0CB7);
        public const int PIXEL_MAP_I_TO_A = ((int)0x0C75);
        public const int PIXEL_MAP_I_TO_A_SIZE = ((int)0x0CB5);
        public const int PIXEL_MAP_I_TO_B = ((int)0x0C74);
        public const int PIXEL_MAP_I_TO_B_SIZE = ((int)0x0CB4);
        public const int PIXEL_MAP_I_TO_G = ((int)0x0C73);
        public const int PIXEL_MAP_I_TO_G_SIZE = ((int)0x0CB3);
        public const int PIXEL_MAP_I_TO_I = ((int)0x0C70);
        public const int PIXEL_MAP_I_TO_I_SIZE = ((int)0x0CB0);
        public const int PIXEL_MAP_I_TO_R = ((int)0x0C72);
        public const int PIXEL_MAP_I_TO_R_SIZE = ((int)0x0CB2);
        public const int PIXEL_MAP_R_TO_R = ((int)0x0C76);
        public const int PIXEL_MAP_R_TO_R_SIZE = ((int)0x0CB6);
        public const int PIXEL_MAP_S_TO_S = ((int)0x0C71);
        public const int PIXEL_MAP_S_TO_S_SIZE = ((int)0x0CB1);
        public const int PIXEL_MIN_FILTER_EXT = ((int)0x8332);
        public const int PIXEL_MODE_BIT = ((int)0x00000020);
        public const int PIXEL_PACK_BUFFER = ((int)0x88EB);
        public const int PIXEL_PACK_BUFFER_ARB = ((int)0x88EB);
        public const int PIXEL_PACK_BUFFER_BINDING = ((int)0x88ED);
        public const int PIXEL_PACK_BUFFER_BINDING_ARB = ((int)0x88ED);
        public const int PIXEL_PACK_BUFFER_BINDING_EXT = ((int)0x88ED);
        public const int PIXEL_PACK_BUFFER_EXT = ((int)0x88EB);
        public const int PIXEL_TRANSFORM_2D_EXT = ((int)0x8330);
        public const int PIXEL_TRANSFORM_2D_MATRIX_EXT = ((int)0x8338);
        public const int PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = ((int)0x8336);
        public const int PIXEL_UNPACK_BUFFER = ((int)0x88EC);
        public const int PIXEL_UNPACK_BUFFER_ARB = ((int)0x88EC);
        public const int PIXEL_UNPACK_BUFFER_BINDING = ((int)0x88EF);
        public const int PIXEL_UNPACK_BUFFER_BINDING_ARB = ((int)0x88EF);
        public const int PIXEL_UNPACK_BUFFER_BINDING_EXT = ((int)0x88EF);
        public const int PIXEL_UNPACK_BUFFER_EXT = ((int)0x88EC);
        public const int POINT = ((int)0x1B00);
        public const int POINT_BIT = ((int)0x00000002);
        public const int POINT_DISTANCE_ATTENUATION = ((int)0x8129);
        public const int POINT_DISTANCE_ATTENUATION_ARB = ((int)0x8129);
        public const int POINT_FADE_THRESHOLD_SIZE = ((int)0x8128);
        public const int POINT_FADE_THRESHOLD_SIZE_ARB = ((int)0x8128);
        public const int POINT_FADE_THRESHOLD_SIZE_EXT = ((int)0x8128);
        public const int POINT_SIZE = ((int)0x0B11);
        public const int POINT_SIZE_GRANULARITY = ((int)0x0B13);
        public const int POINT_SIZE_MAX = ((int)0x8127);
        public const int POINT_SIZE_MAX_ARB = ((int)0x8127);
        public const int POINT_SIZE_MAX_EXT = ((int)0x8127);
        public const int POINT_SIZE_MIN = ((int)0x8126);
        public const int POINT_SIZE_MIN_ARB = ((int)0x8126);
        public const int POINT_SIZE_MIN_EXT = ((int)0x8126);
        public const int POINT_SIZE_RANGE = ((int)0x0B12);
        public const int POINT_SMOOTH = ((int)0x0B10);
        public const int POINT_SMOOTH_HINT = ((int)0x0C51);
        public const int POINT_SPRITE = ((int)0x8861);
        public const int POINT_SPRITE_ARB = ((int)0x8861);
        public const int POINT_SPRITE_COORD_ORIGIN = ((int)0x8CA0);
        public const int POINT_TOKEN = ((int)0x0701);
        public const int POINTS = ((int)0x0000);
        public const int POLYGON = ((int)0x0009);
        public const int POLYGON_BIT = ((int)0x00000008);
        public const int POLYGON_MODE = ((int)0x0B40);
        public const int POLYGON_OFFSET_BIAS_EXT = ((int)0x8039);
        public const int POLYGON_OFFSET_EXT = ((int)0x8037);
        public const int POLYGON_OFFSET_FACTOR = ((int)0x8038);
        public const int POLYGON_OFFSET_FACTOR_EXT = ((int)0x8038);
        public const int POLYGON_OFFSET_FILL = ((int)0x8037);
        public const int POLYGON_OFFSET_LINE = ((int)0x2A02);
        public const int POLYGON_OFFSET_POINT = ((int)0x2A01);
        public const int POLYGON_OFFSET_UNITS = ((int)0x2A00);
        public const int POLYGON_SMOOTH = ((int)0x0B41);
        public const int POLYGON_SMOOTH_HINT = ((int)0x0C53);
        public const int POLYGON_STIPPLE = ((int)0x0B42);
        public const int POLYGON_STIPPLE_BIT = ((int)0x00000010);
        public const int POLYGON_TOKEN = ((int)0x0703);
        public const int POSITION = ((int)0x1203);
        public const int POST_COLOR_MATRIX_ALPHA_BIAS = ((int)0x80BB);
        public const int POST_COLOR_MATRIX_ALPHA_BIAS_SGI = ((int)0x80BB);
        public const int POST_COLOR_MATRIX_ALPHA_SCALE = ((int)0x80B7);
        public const int POST_COLOR_MATRIX_ALPHA_SCALE_SGI = ((int)0x80B7);
        public const int POST_COLOR_MATRIX_BLUE_BIAS = ((int)0x80BA);
        public const int POST_COLOR_MATRIX_BLUE_BIAS_SGI = ((int)0x80BA);
        public const int POST_COLOR_MATRIX_BLUE_SCALE = ((int)0x80B6);
        public const int POST_COLOR_MATRIX_BLUE_SCALE_SGI = ((int)0x80B6);
        public const int POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D2);
        public const int POST_COLOR_MATRIX_COLOR_TABLE_SGI = ((int)0x80D2);
        public const int POST_COLOR_MATRIX_GREEN_BIAS = ((int)0x80B9);
        public const int POST_COLOR_MATRIX_GREEN_BIAS_SGI = ((int)0x80B9);
        public const int POST_COLOR_MATRIX_GREEN_SCALE = ((int)0x80B5);
        public const int POST_COLOR_MATRIX_GREEN_SCALE_SGI = ((int)0x80B5);
        public const int POST_COLOR_MATRIX_RED_BIAS = ((int)0x80B8);
        public const int POST_COLOR_MATRIX_RED_BIAS_SGI = ((int)0x80B8);
        public const int POST_COLOR_MATRIX_RED_SCALE = ((int)0x80B4);
        public const int POST_COLOR_MATRIX_RED_SCALE_SGI = ((int)0x80B4);
        public const int POST_CONVOLUTION_ALPHA_BIAS = ((int)0x8023);
        public const int POST_CONVOLUTION_ALPHA_BIAS_EXT = ((int)0x8023);
        public const int POST_CONVOLUTION_ALPHA_SCALE = ((int)0x801F);
        public const int POST_CONVOLUTION_ALPHA_SCALE_EXT = ((int)0x801F);
        public const int POST_CONVOLUTION_BLUE_BIAS = ((int)0x8022);
        public const int POST_CONVOLUTION_BLUE_BIAS_EXT = ((int)0x8022);
        public const int POST_CONVOLUTION_BLUE_SCALE = ((int)0x801E);
        public const int POST_CONVOLUTION_BLUE_SCALE_EXT = ((int)0x801E);
        public const int POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D1);
        public const int POST_CONVOLUTION_COLOR_TABLE_SGI = ((int)0x80D1);
        public const int POST_CONVOLUTION_GREEN_BIAS = ((int)0x8021);
        public const int POST_CONVOLUTION_GREEN_BIAS_EXT = ((int)0x8021);
        public const int POST_CONVOLUTION_GREEN_SCALE = ((int)0x801D);
        public const int POST_CONVOLUTION_GREEN_SCALE_EXT = ((int)0x801D);
        public const int POST_CONVOLUTION_RED_BIAS = ((int)0x8020);
        public const int POST_CONVOLUTION_RED_BIAS_EXT = ((int)0x8020);
        public const int POST_CONVOLUTION_RED_SCALE = ((int)0x801C);
        public const int POST_CONVOLUTION_RED_SCALE_EXT = ((int)0x801C);
        public const int PRESENT_DURATION_NV = ((int)0x8E2B);
        public const int PRESENT_TIME_NV = ((int)0x8E2A);
        public const int PREVIOUS = ((int)0x8578);
        public const int PREVIOUS_ARB = ((int)0x8578);
        public const int PREVIOUS_EXT = ((int)0x8578);
        public const int PRIMARY_COLOR = ((int)0x8577);
        public const int PRIMARY_COLOR_ARB = ((int)0x8577);
        public const int PRIMARY_COLOR_EXT = ((int)0x8577);
        public const int PRIMITIVE_ID_NV = ((int)0x8C7C);
        public const int PRIMITIVE_RESTART = ((int)0x8F9D);
        public const int PRIMITIVE_RESTART_INDEX = ((int)0x8F9E);
        public const int PRIMITIVES_GENERATED = ((int)0x8C87);
        public const int PRIMITIVES_GENERATED_EXT = ((int)0x8C87);
        public const int PRIMITIVES_GENERATED_NV = ((int)0x8C87);
        public const int PROGRAM_ADDRESS_REGISTERS = ((int)0x88B0);
        public const int PROGRAM_ADDRESS_REGISTERS_ARB = ((int)0x88B0);
        public const int PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x8805);
        public const int PROGRAM_ATTRIB_COMPONENTS_NV = ((int)0x8906);
        public const int PROGRAM_ATTRIBS = ((int)0x88AC);
        public const int PROGRAM_ATTRIBS_ARB = ((int)0x88AC);
        public const int PROGRAM_BINDING = ((int)0x8677);
        public const int PROGRAM_BINDING_ARB = ((int)0x8677);
        public const int PROGRAM_ERROR_POSITION_ARB = ((int)0x864B);
        public const int PROGRAM_ERROR_STRING_ARB = ((int)0x8874);
        public const int PROGRAM_FORMAT = ((int)0x8876);
        public const int PROGRAM_FORMAT_ARB = ((int)0x8876);
        public const int PROGRAM_FORMAT_ASCII_ARB = ((int)0x8875);
        public const int PROGRAM_INSTRUCTION = ((int)0x88A0);
        public const int PROGRAM_INSTRUCTIONS_ARB = ((int)0x88A0);
        public const int PROGRAM_LENGTH = ((int)0x8627);
        public const int PROGRAM_LENGTH_ARB = ((int)0x8627);
        public const int PROGRAM_MATRIX_EXT = ((int)0x8E2D);
        public const int PROGRAM_MATRIX_STACK_DEPTH_EXT = ((int)0x8E2F);
        public const int PROGRAM_NATIVE_ADDRESS_REGISTERS = ((int)0x88B2);
        public const int PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = ((int)0x88B2);
        public const int PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x8808);
        public const int PROGRAM_NATIVE_ATTRIBS = ((int)0x88AE);
        public const int PROGRAM_NATIVE_ATTRIBS_ARB = ((int)0x88AE);
        public const int PROGRAM_NATIVE_INSTRUCTIONS = ((int)0x88A2);
        public const int PROGRAM_NATIVE_INSTRUCTIONS_ARB = ((int)0x88A2);
        public const int PROGRAM_NATIVE_PARAMETERS = ((int)0x88AA);
        public const int PROGRAM_NATIVE_PARAMETERS_ARB = ((int)0x88AA);
        public const int PROGRAM_NATIVE_TEMPORARIES = ((int)0x88A6);
        public const int PROGRAM_NATIVE_TEMPORARIES_ARB = ((int)0x88A6);
        public const int PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x880A);
        public const int PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x8809);
        public const int PROGRAM_OBJECT_ARB = ((int)0x8B40);
        public const int PROGRAM_PARAMETERS = ((int)0x88A8);
        public const int PROGRAM_PARAMETERS_ARB = ((int)0x88A8);
        public const int PROGRAM_POINT_SIZE = ((int)0x8642);
        public const int PROGRAM_POINT_SIZE_ARB = ((int)0x8642);
        public const int PROGRAM_POINT_SIZE_EXT = ((int)0x8642);
        public const int PROGRAM_RESULT_COMPONENTS_NV = ((int)0x8907);
        public const int PROGRAM_STRING = ((int)0x8628);
        public const int PROGRAM_STRING_ARB = ((int)0x8628);
        public const int PROGRAM_TEMPORARIES = ((int)0x88A4);
        public const int PROGRAM_TEMPORARIES_ARB = ((int)0x88A4);
        public const int PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x8807);
        public const int PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x8806);
        public const int PROGRAM_UNDER_NATIVE_LIMITS = ((int)0x88B6);
        public const int PROGRAM_UNDER_NATIVE_LIMITS_ARB = ((int)0x88B6);
        public const int PROJECTION = ((int)0x1701);
        public const int PROJECTION_MATRIX = ((int)0x0BA7);
        public const int PROJECTION_STACK_DEPTH = ((int)0x0BA4);
        public const int PROVOKING_VERTEX = ((int)0x8E4F);
        public const int PROVOKING_VERTEX_EXT = ((int)0x8E4F);
        public const int PROXY_COLOR_TABLE = ((int)0x80D3);
        public const int PROXY_COLOR_TABLE_SGI = ((int)0x80D3);
        public const int PROXY_HISTOGRAM = ((int)0x8025);
        public const int PROXY_HISTOGRAM_EXT = ((int)0x8025);
        public const int PROXY_POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D5);
        public const int PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = ((int)0x80D5);
        public const int PROXY_POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D4);
        public const int PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = ((int)0x80D4);
        public const int PROXY_TEXTURE_1D = ((int)0x8063);
        public const int PROXY_TEXTURE_1D_ARRAY = ((int)0x8C19);
        public const int PROXY_TEXTURE_1D_ARRAY_EXT = ((int)0x8C19);
        public const int PROXY_TEXTURE_1D_EXT = ((int)0x8063);
        public const int PROXY_TEXTURE_1D_STACK_MESAX = ((int)0x875B);
        public const int PROXY_TEXTURE_2D = ((int)0x8064);
        public const int PROXY_TEXTURE_2D_ARRAY = ((int)0x8C1B);
        public const int PROXY_TEXTURE_2D_ARRAY_EXT = ((int)0x8C1B);
        public const int PROXY_TEXTURE_2D_EXT = ((int)0x8064);
        public const int PROXY_TEXTURE_2D_MULTISAMPLE = ((int)0x9101);
        public const int PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9103);
        public const int PROXY_TEXTURE_2D_STACK_MESAX = ((int)0x875C);
        public const int PROXY_TEXTURE_3D = ((int)0x8070);
        public const int PROXY_TEXTURE_3D_EXT = ((int)0x8070);
        public const int PROXY_TEXTURE_4D_SGIS = ((int)0x8135);
        public const int PROXY_TEXTURE_CUBE_MAP = ((int)0x851B);
        public const int PROXY_TEXTURE_CUBE_MAP_ARB = ((int)0x851B);
        public const int PROXY_TEXTURE_CUBE_MAP_ARRAY = ((int)0x900B);
        public const int PROXY_TEXTURE_CUBE_MAP_EXT = ((int)0x851B);
        public const int PROXY_TEXTURE_RECTANGLE = ((int)0x84F7);
        public const int PROXY_TEXTURE_RECTANGLE_ARB = ((int)0x84F7);
        public const int Q = ((int)0x2003);
        public const int QUAD_STRIP = ((int)0x0008);
        public const int QUADRATIC_ATTENUATION = ((int)0x1209);
        public const int QUADS = ((int)0x0007);
        public const int QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = ((int)0x8E4C);
        public const int QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION_EXT = ((int)0x8E4C);
        public const int QUERY_BY_REGION_NO_WAIT = ((int)0x8E16);
        public const int QUERY_BY_REGION_NO_WAIT_NV = ((int)0x8E16);
        public const int QUERY_BY_REGION_WAIT = ((int)0x8E15);
        public const int QUERY_BY_REGION_WAIT_NV = ((int)0x8E15);
        public const int QUERY_COUNTER_BITS = ((int)0x8864);
        public const int QUERY_COUNTER_BITS_ARB = ((int)0x8864);
        public const int QUERY_NO_WAIT = ((int)0x8E14);
        public const int QUERY_NO_WAIT_NV = ((int)0x8E14);
        public const int QUERY_RESULT = ((int)0x8866);
        public const int QUERY_RESULT_ARB = ((int)0x8866);
        public const int QUERY_RESULT_AVAILABLE = ((int)0x8867);
        public const int QUERY_RESULT_AVAILABLE_ARB = ((int)0x8867);
        public const int QUERY_WAIT = ((int)0x8E13);
        public const int QUERY_WAIT_NV = ((int)0x8E13);
        public const int R = ((int)0x2002);
        public const int R11F_G11F_B10F = ((int)0x8C3A);
        public const int R11F_G11F_B10F_EXT = ((int)0x8C3A);
        public const int R16 = ((int)0x822A);
        public const int R16_SNORM = ((int)0x8F98);
        public const int R16F = ((int)0x822D);
        public const int R16I = ((int)0x8233);
        public const int R16UI = ((int)0x8234);
        public const int R3_G3_B2 = ((int)0x2A10);
        public const int R32F = ((int)0x822E);
        public const int R32I = ((int)0x8235);
        public const int R32UI = ((int)0x8236);
        public const int R8 = ((int)0x8229);
        public const int R8_SNORM = ((int)0x8F94);
        public const int R8I = ((int)0x8231);
        public const int R8UI = ((int)0x8232);
        public const int RASTERIZER_DISCARD = ((int)0x8C89);
        public const int RASTERIZER_DISCARD_EXT = ((int)0x8C89);
        public const int RASTERIZER_DISCARD_NV = ((int)0x8C89);
        public const int READ_BUFFER = ((int)0x0C02);
        public const int READ_FRAMEBUFFER = ((int)0x8CA8);
        public const int READ_FRAMEBUFFER_BINDING = ((int)0x8CAA);
        public const int READ_FRAMEBUFFER_BINDING_EXT = ((int)0x8CAA);
        public const int READ_FRAMEBUFFER_EXT = ((int)0x8CA8);
        public const int READ_ONLY = ((int)0x88B8);
        public const int READ_ONLY_ARB = ((int)0x88B8);
        public const int READ_WRITE = ((int)0x88BA);
        public const int READ_WRITE_ARB = ((int)0x88BA);
        public const int RED = ((int)0x1903);
        public const int RED_BIAS = ((int)0x0D15);
        public const int RED_BITS = ((int)0x0D52);
        public const int RED_INTEGER = ((int)0x8D94);
        public const int RED_INTEGER_EXT = ((int)0x8D94);
        public const int RED_SCALE = ((int)0x0D14);
        public const int RED_SNORM = ((int)0x8F90);
        public const int REDUCE = ((int)0x8016);
        public const int REDUCE_EXT = ((int)0x8016);
        public const int REFLECTION_MAP = ((int)0x8512);
        public const int REFLECTION_MAP_ARB = ((int)0x8512);
        public const int REFLECTION_MAP_EXT = ((int)0x8512);
        public const int RENDER = ((int)0x1C00);
        public const int RENDER_MODE = ((int)0x0C40);
        public const int RENDERBUFFER = ((int)0x8D41);
        public const int RENDERBUFFER_ALPHA_SIZE = ((int)0x8D53);
        public const int RENDERBUFFER_ALPHA_SIZE_EXT = ((int)0x8D53);
        public const int RENDERBUFFER_BINDING = ((int)0x8CA7);
        public const int RENDERBUFFER_BINDING_EXT = ((int)0x8CA7);
        public const int RENDERBUFFER_BLUE_SIZE = ((int)0x8D52);
        public const int RENDERBUFFER_BLUE_SIZE_EXT = ((int)0x8D52);
        public const int RENDERBUFFER_DEPTH_SIZE = ((int)0x8D54);
        public const int RENDERBUFFER_DEPTH_SIZE_EXT = ((int)0x8D54);
        public const int RENDERBUFFER_EXT = ((int)0x8D41);
        public const int RENDERBUFFER_FREE_MEMORY_ATI = ((int)0x87FD);
        public const int RENDERBUFFER_GREEN_SIZE = ((int)0x8D51);
        public const int RENDERBUFFER_GREEN_SIZE_EXT = ((int)0x8D51);
        public const int RENDERBUFFER_HEIGHT = ((int)0x8D43);
        public const int RENDERBUFFER_HEIGHT_EXT = ((int)0x8D43);
        public const int RENDERBUFFER_INTERNAL_FORMAT = ((int)0x8D44);
        public const int RENDERBUFFER_INTERNAL_FORMAT_EXT = ((int)0x8D44);
        public const int RENDERBUFFER_RED_SIZE = ((int)0x8D50);
        public const int RENDERBUFFER_RED_SIZE_EXT = ((int)0x8D50);
        public const int RENDERBUFFER_SAMPLES = ((int)0x8CAB);
        public const int RENDERBUFFER_SAMPLES_EXT = ((int)0x8CAB);
        public const int RENDERBUFFER_STENCIL_SIZE = ((int)0x8D55);
        public const int RENDERBUFFER_STENCIL_SIZE_EXT = ((int)0x8D55);
        public const int RENDERBUFFER_WIDTH = ((int)0x8D42);
        public const int RENDERBUFFER_WIDTH_EXT = ((int)0x8D42);
        public const int RENDERER = ((int)0x1F01);
        public const int REPEAT = ((int)0x2901);
        public const int REPLACE = ((int)0x1E01);
        public const int REPLACE_EXT = ((int)0x8062);
        public const int REPLICATE_BORDER = ((int)0x8153);
        public const int RESCALE_NORMAL = ((int)0x803A);
        public const int RESCALE_NORMAL_EXT = ((int)0x803A);
        public const int RETURN = ((int)0x0102);
        public const int RG = ((int)0x8227);
        public const int RG_INTEGER = ((int)0x8228);
        public const int RG_SNORM = ((int)0x8F91);
        public const int RG16 = ((int)0x822C);
        public const int RG16_SNORM = ((int)0x8F99);
        public const int RG16F = ((int)0x822F);
        public const int RG16I = ((int)0x8239);
        public const int RG16UI = ((int)0x823A);
        public const int RG32F = ((int)0x8230);
        public const int RG32I = ((int)0x823B);
        public const int RG32UI = ((int)0x823C);
        public const int RG8 = ((int)0x822B);
        public const int RG8_SNORM = ((int)0x8F95);
        public const int RG8I = ((int)0x8237);
        public const int RG8UI = ((int)0x8238);
        public const int RGB = ((int)0x1907);
        public const int RGB_INTEGER = ((int)0x8D98);
        public const int RGB_INTEGER_EXT = ((int)0x8D98);
        public const int RGB_SCALE = ((int)0x8573);
        public const int RGB_SCALE_ARB = ((int)0x8573);
        public const int RGB_SCALE_EXT = ((int)0x8573);
        public const int RGB_SNORM = ((int)0x8F92);
        public const int RGB10 = ((int)0x8052);
        public const int RGB10_A2 = ((int)0x8059);
        public const int RGB10_A2_EXT = ((int)0x8059);
        public const int RGB10_EXT = ((int)0x8052);
        public const int RGB12 = ((int)0x8053);
        public const int RGB12_EXT = ((int)0x8053);
        public const int RGB16 = ((int)0x8054);
        public const int RGB16_EXT = ((int)0x8054);
        public const int RGB16_SNORM = ((int)0x8F9A);
        public const int RGB16F = ((int)0x881B);
        public const int RGB16F_ARB = ((int)0x881B);
        public const int RGB16I = ((int)0x8D89);
        public const int RGB16I_EXT = ((int)0x8D89);
        public const int RGB16UI = ((int)0x8D77);
        public const int RGB16UI_EXT = ((int)0x8D77);
        public const int RGB2_EXT = ((int)0x804E);
        public const int RGB32F = ((int)0x8815);
        public const int RGB32F_ARB = ((int)0x8815);
        public const int RGB32I = ((int)0x8D83);
        public const int RGB32I_EXT = ((int)0x8D83);
        public const int RGB32UI = ((int)0x8D71);
        public const int RGB32UI_EXT = ((int)0x8D71);
        public const int RGB4 = ((int)0x804F);
        public const int RGB4_EXT = ((int)0x804F);
        public const int RGB5 = ((int)0x8050);
        public const int RGB5_A1 = ((int)0x8057);
        public const int RGB5_A1_EXT = ((int)0x8057);
        public const int RGB5_EXT = ((int)0x8050);
        public const int RGB8 = ((int)0x8051);
        public const int RGB8_EXT = ((int)0x8051);
        public const int RGB8_SNORM = ((int)0x8F96);
        public const int RGB8I = ((int)0x8D8F);
        public const int RGB8I_EXT = ((int)0x8D8F);
        public const int RGB8UI = ((int)0x8D7D);
        public const int RGB8UI_EXT = ((int)0x8D7D);
        public const int RGB9_E5 = ((int)0x8C3D);
        public const int RGB9_E5_EXT = ((int)0x8C3D);
        public const int RGBA = ((int)0x1908);
        public const int RGBA_FLOAT_MODE = ((int)0x8820);
        public const int RGBA_FLOAT_MODE_ARB = ((int)0x8820);
        public const int RGBA_INTEGER = ((int)0x8D99);
        public const int RGBA_INTEGER_EXT = ((int)0x8D99);
        public const int RGBA_INTEGER_MODE_EXT = ((int)0x8D9E);
        public const int RGBA_MODE = ((int)0x0C31);
        public const int RGBA_SIGNED_COMPONENTS_EXT = ((int)0x8C3C);
        public const int RGBA_SNORM = ((int)0x8F93);
        public const int RGBA12 = ((int)0x805A);
        public const int RGBA12_EXT = ((int)0x805A);
        public const int RGBA16 = ((int)0x805B);
        public const int RGBA16_EXT = ((int)0x805B);
        public const int RGBA16_SNORM = ((int)0x8F9B);
        public const int RGBA16F = ((int)0x881A);
        public const int RGBA16F_ARB = ((int)0x881A);
        public const int RGBA16I = ((int)0x8D88);
        public const int RGBA16I_EXT = ((int)0x8D88);
        public const int RGBA16UI = ((int)0x8D76);
        public const int RGBA16UI_EXT = ((int)0x8D76);
        public const int RGBA2 = ((int)0x8055);
        public const int RGBA2_EXT = ((int)0x8055);
        public const int RGBA32F = ((int)0x8814);
        public const int RGBA32F_ARB = ((int)0x8814);
        public const int RGBA32I = ((int)0x8D82);
        public const int RGBA32I_EXT = ((int)0x8D82);
        public const int RGBA32UI = ((int)0x8D70);
        public const int RGBA32UI_EXT = ((int)0x8D70);
        public const int RGBA4 = ((int)0x8056);
        public const int RGBA4_EXT = ((int)0x8056);
        public const int RGBA8 = ((int)0x8058);
        public const int RGBA8_EXT = ((int)0x8058);
        public const int RGBA8_SNORM = ((int)0x8F97);
        public const int RGBA8I = ((int)0x8D8E);
        public const int RGBA8I_EXT = ((int)0x8D8E);
        public const int RGBA8UI = ((int)0x8D7C);
        public const int RGBA8UI_EXT = ((int)0x8D7C);
        public const int RIGHT = ((int)0x0407);
        public const int S = ((int)0x2000);
        public const int SAMPLE_ALPHA_TO_COVERAGE = ((int)0x809E);
        public const int SAMPLE_ALPHA_TO_COVERAGE_ARB = ((int)0x809E);
        public const int SAMPLE_ALPHA_TO_MASK_EXT = ((int)0x809E);
        public const int SAMPLE_ALPHA_TO_MASK_SGIS = ((int)0x809E);
        public const int SAMPLE_ALPHA_TO_ONE = ((int)0x809F);
        public const int SAMPLE_ALPHA_TO_ONE_ARB = ((int)0x809F);
        public const int SAMPLE_ALPHA_TO_ONE_EXT = ((int)0x809F);
        public const int SAMPLE_ALPHA_TO_ONE_SGIS = ((int)0x809F);
        public const int SAMPLE_BUFFERS = ((int)0x80A8);
        public const int SAMPLE_BUFFERS_ARB = ((int)0x80A8);
        public const int SAMPLE_BUFFERS_EXT = ((int)0x80A8);
        public const int SAMPLE_BUFFERS_SGIS = ((int)0x80A8);
        public const int SAMPLE_COVERAGE = ((int)0x80A0);
        public const int SAMPLE_COVERAGE_ARB = ((int)0x80A0);
        public const int SAMPLE_COVERAGE_INVERT = ((int)0x80AB);
        public const int SAMPLE_COVERAGE_INVERT_ARB = ((int)0x80AB);
        public const int SAMPLE_COVERAGE_VALUE = ((int)0x80AA);
        public const int SAMPLE_COVERAGE_VALUE_ARB = ((int)0x80AA);
        public const int SAMPLE_MASK = ((int)0x8E51);
        public const int SAMPLE_MASK_EXT = ((int)0x80A0);
        public const int SAMPLE_MASK_INVERT_EXT = ((int)0x80AB);
        public const int SAMPLE_MASK_INVERT_SGIS = ((int)0x80AB);
        public const int SAMPLE_MASK_NV = ((int)0x8E51);
        public const int SAMPLE_MASK_SGIS = ((int)0x80A0);
        public const int SAMPLE_MASK_VALUE = ((int)0x8E52);
        public const int SAMPLE_MASK_VALUE_EXT = ((int)0x80AA);
        public const int SAMPLE_MASK_VALUE_NV = ((int)0x8E52);
        public const int SAMPLE_MASK_VALUE_SGIS = ((int)0x80AA);
        public const int SAMPLE_PATTERN_EXT = ((int)0x80AC);
        public const int SAMPLE_PATTERN_SGIS = ((int)0x80AC);
        public const int SAMPLE_POSITION = ((int)0x8E50);
        public const int SAMPLE_POSITION_NV = ((int)0x8E50);
        public const int SAMPLE_SHADING = ((int)0x8C36);
        public const int SAMPLER_1D = ((int)0x8B5D);
        public const int SAMPLER_1D_ARB = ((int)0x8B5D);
        public const int SAMPLER_1D_ARRAY = ((int)0x8DC0);
        public const int SAMPLER_1D_ARRAY_EXT = ((int)0x8DC0);
        public const int SAMPLER_1D_ARRAY_SHADOW = ((int)0x8DC3);
        public const int SAMPLER_1D_ARRAY_SHADOW_EXT = ((int)0x8DC3);
        public const int SAMPLER_1D_SHADOW = ((int)0x8B61);
        public const int SAMPLER_1D_SHADOW_ARB = ((int)0x8B61);
        public const int SAMPLER_2D = ((int)0x8B5E);
        public const int SAMPLER_2D_ARB = ((int)0x8B5E);
        public const int SAMPLER_2D_ARRAY = ((int)0x8DC1);
        public const int SAMPLER_2D_ARRAY_EXT = ((int)0x8DC1);
        public const int SAMPLER_2D_ARRAY_SHADOW = ((int)0x8DC4);
        public const int SAMPLER_2D_ARRAY_SHADOW_EXT = ((int)0x8DC4);
        public const int SAMPLER_2D_MULTISAMPLE = ((int)0x9108);
        public const int SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910B);
        public const int SAMPLER_2D_RECT = ((int)0x8B63);
        public const int SAMPLER_2D_RECT_ARB = ((int)0x8B63);
        public const int SAMPLER_2D_RECT_SHADOW = ((int)0x8B64);
        public const int SAMPLER_2D_RECT_SHADOW_ARB = ((int)0x8B64);
        public const int SAMPLER_2D_SHADOW = ((int)0x8B62);
        public const int SAMPLER_2D_SHADOW_ARB = ((int)0x8B62);
        public const int SAMPLER_3D = ((int)0x8B5F);
        public const int SAMPLER_3D_ARB = ((int)0x8B5F);
        public const int SAMPLER_BUFFER = ((int)0x8DC2);
        public const int SAMPLER_BUFFER_AMD = ((int)0x9001);
        public const int SAMPLER_BUFFER_EXT = ((int)0x8DC2);
        public const int SAMPLER_CUBE = ((int)0x8B60);
        public const int SAMPLER_CUBE_ARB = ((int)0x8B60);
        public const int SAMPLER_CUBE_MAP_ARRAY = ((int)0x900C);
        public const int SAMPLER_CUBE_MAP_ARRAY_SHADOW = ((int)0x900D);
        public const int SAMPLER_CUBE_SHADOW = ((int)0x8DC5);
        public const int SAMPLER_CUBE_SHADOW_EXT = ((int)0x8DC5);
        public const int SAMPLER_RENDERBUFFER_NV = ((int)0x8E56);
        public const int SAMPLES = ((int)0x80A9);
        public const int SAMPLES_ARB = ((int)0x80A9);
        public const int SAMPLES_EXT = ((int)0x80A9);
        public const int SAMPLES_PASSED = ((int)0x8914);
        public const int SAMPLES_PASSED_ARB = ((int)0x8914);
        public const int SAMPLES_SGIS = ((int)0x80A9);
        public const int SCALAR_EXT = ((int)0x87BE);
        public const int SCISSOR_BIT = ((int)0x00080000);
        public const int SCISSOR_BOX = ((int)0x0C10);
        public const int SCISSOR_TEST = ((int)0x0C11);
        public const int SCREEN_COORDINATES_REND = ((int)0x8490);
        public const int SECONDARY_COLOR_ARRAY = ((int)0x845E);
        public const int SECONDARY_COLOR_ARRAY_BUFFER_BINDING = ((int)0x889C);
        public const int SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = ((int)0x889C);
        public const int SECONDARY_COLOR_ARRAY_EXT = ((int)0x845E);
        public const int SECONDARY_COLOR_ARRAY_POINTER = ((int)0x845D);
        public const int SECONDARY_COLOR_ARRAY_POINTER_EXT = ((int)0x845D);
        public const int SECONDARY_COLOR_ARRAY_SIZE = ((int)0x845A);
        public const int SECONDARY_COLOR_ARRAY_SIZE_EXT = ((int)0x845A);
        public const int SECONDARY_COLOR_ARRAY_STRIDE = ((int)0x845C);
        public const int SECONDARY_COLOR_ARRAY_STRIDE_EXT = ((int)0x845C);
        public const int SECONDARY_COLOR_ARRAY_TYPE = ((int)0x845B);
        public const int SECONDARY_COLOR_ARRAY_TYPE_EXT = ((int)0x845B);
        public const int SELECT = ((int)0x1C02);
        public const int SELECTION_BUFFER_POINTER = ((int)0x0DF3);
        public const int SELECTION_BUFFER_SIZE = ((int)0x0DF4);
        public const int SEPARABLE_2D = ((int)0x8012);
        public const int SEPARABLE_2D_EXT = ((int)0x8012);
        public const int SEPARATE_ATTRIBS = ((int)0x8C8D);
        public const int SEPARATE_ATTRIBS_EXT = ((int)0x8C8D);
        public const int SEPARATE_ATTRIBS_NV = ((int)0x8C8D);
        public const int SEPARATE_SPECULAR_COLOR = ((int)0x81FA);
        public const int SEPARATE_SPECULAR_COLOR_EXT = ((int)0x81FA);
        public const int SET = ((int)0x150F);
        public const int SHADE_MODEL = ((int)0x0B54);
        public const int SHADER_OBJECT_ARB = ((int)0x8B48);
        public const int SHADER_SOURCE_LENGTH = ((int)0x8B88);
        public const int SHADER_TYPE = ((int)0x8B4F);
        public const int SHADING_LANGUAGE_VERSION = ((int)0x8B8C);
        public const int SHADING_LANGUAGE_VERSION_ARB = ((int)0x8B8C);
        public const int SHADOW_ATTENUATION_EXT = ((int)0x834E);
        public const int SHARED_TEXTURE_PALETTE_EXT = ((int)0x81FB);
        public const int SHININESS = ((int)0x1601);
        public const int SHORT = ((int)0x1402);
        public const int SIGNALED = ((int)0x9119);
        public const int SIGNED_NORMALIZED = ((int)0x8F9C);
        public const int SINGLE_COLOR = ((int)0x81F9);
        public const int SINGLE_COLOR_EXT = ((int)0x81F9);
        public const int SLUMINANCE = ((int)0x8C46);
        public const int SLUMINANCE_ALPHA = ((int)0x8C44);
        public const int SLUMINANCE_ALPHA_EXT = ((int)0x8C44);
        public const int SLUMINANCE_EXT = ((int)0x8C46);
        public const int SLUMINANCE8 = ((int)0x8C47);
        public const int SLUMINANCE8_ALPHA8 = ((int)0x8C45);
        public const int SLUMINANCE8_ALPHA8_EXT = ((int)0x8C45);
        public const int SLUMINANCE8_EXT = ((int)0x8C47);
        public const int SMOOTH = ((int)0x1D01);
        public const int SMOOTH_LINE_WIDTH_GRANULARITY = ((int)0x0B23);
        public const int SMOOTH_LINE_WIDTH_RANGE = ((int)0x0B22);
        public const int SMOOTH_POINT_SIZE_GRANULARITY = ((int)0x0B13);
        public const int SMOOTH_POINT_SIZE_RANGE = ((int)0x0B12);
        public const int SOURCE0_ALPHA = ((int)0x8588);
        public const int SOURCE0_ALPHA_ARB = ((int)0x8588);
        public const int SOURCE0_ALPHA_EXT = ((int)0x8588);
        public const int SOURCE0_RGB = ((int)0x8580);
        public const int SOURCE0_RGB_ARB = ((int)0x8580);
        public const int SOURCE0_RGB_EXT = ((int)0x8580);
        public const int SOURCE1_ALPHA = ((int)0x8589);
        public const int SOURCE1_ALPHA_ARB = ((int)0x8589);
        public const int SOURCE1_ALPHA_EXT = ((int)0x8589);
        public const int SOURCE1_RGB = ((int)0x8581);
        public const int SOURCE1_RGB_ARB = ((int)0x8581);
        public const int SOURCE1_RGB_EXT = ((int)0x8581);
        public const int SOURCE2_ALPHA = ((int)0x858A);
        public const int SOURCE2_ALPHA_ARB = ((int)0x858A);
        public const int SOURCE2_ALPHA_EXT = ((int)0x858A);
        public const int SOURCE2_RGB = ((int)0x8582);
        public const int SOURCE2_RGB_ARB = ((int)0x8582);
        public const int SOURCE2_RGB_EXT = ((int)0x8582);
        public const int SOURCE3_ALPHA_NV = ((int)0x858B);
        public const int SOURCE3_RGB_NV = ((int)0x8583);
        public const int SPECULAR = ((int)0x1202);
        public const int SPHERE_MAP = ((int)0x2402);
        public const int SPOT_CUTOFF = ((int)0x1206);
        public const int SPOT_DIRECTION = ((int)0x1204);
        public const int SPOT_EXPONENT = ((int)0x1205);
        public const int SRC_ALPHA = ((int)0x0302);
        public const int SRC_ALPHA_SATURATE = ((int)0x0308);
        public const int SRC_COLOR = ((int)0x0300);
        public const int SRC0_ALPHA = ((int)0x8588);
        public const int SRC0_RGB = ((int)0x8580);
        public const int SRC1_ALPHA = ((int)0x8589);
        public const int SRC1_RGB = ((int)0x8581);
        public const int SRC2_ALPHA = ((int)0x858A);
        public const int SRC2_RGB = ((int)0x8582);
        public const int SRGB = ((int)0x8C40);
        public const int SRGB_ALPHA = ((int)0x8C42);
        public const int SRGB_ALPHA_EXT = ((int)0x8C42);
        public const int SRGB_EXT = ((int)0x8C40);
        public const int SRGB8 = ((int)0x8C41);
        public const int SRGB8_ALPHA8 = ((int)0x8C43);
        public const int SRGB8_ALPHA8_EXT = ((int)0x8C43);
        public const int SRGB8_EXT = ((int)0x8C41);
        public const int STACK_OVERFLOW = ((int)0x0503);
        public const int STACK_UNDERFLOW = ((int)0x0504);
        public const int STATIC_COPY = ((int)0x88E6);
        public const int STATIC_COPY_ARB = ((int)0x88E6);
        public const int STATIC_DRAW = ((int)0x88E4);
        public const int STATIC_DRAW_ARB = ((int)0x88E4);
        public const int STATIC_READ = ((int)0x88E5);
        public const int STATIC_READ_ARB = ((int)0x88E5);
        public const int STENCIL = ((int)0x1802);
        public const int STENCIL_ATTACHMENT = ((int)0x8D20);
        public const int STENCIL_ATTACHMENT_EXT = ((int)0x8D20);
        public const int STENCIL_BACK_FAIL = ((int)0x8801);
        public const int STENCIL_BACK_FUNC = ((int)0x8800);
        public const int STENCIL_BACK_PASS_DEPTH_FAIL = ((int)0x8802);
        public const int STENCIL_BACK_PASS_DEPTH_PASS = ((int)0x8803);
        public const int STENCIL_BACK_REF = ((int)0x8CA3);
        public const int STENCIL_BACK_VALUE_MASK = ((int)0x8CA4);
        public const int STENCIL_BACK_WRITEMASK = ((int)0x8CA5);
        public const int STENCIL_BITS = ((int)0x0D57);
        public const int STENCIL_BUFFER = ((int)0x8224);
        public const int STENCIL_BUFFER_BIT = ((int)0x00000400);
        public const int STENCIL_CLEAR_TAG_VALUE_EXT = ((int)0x88F3);
        public const int STENCIL_CLEAR_VALUE = ((int)0x0B91);
        public const int STENCIL_FAIL = ((int)0x0B94);
        public const int STENCIL_FUNC = ((int)0x0B92);
        public const int STENCIL_INDEX = ((int)0x1901);
        public const int STENCIL_INDEX1 = ((int)0x8D46);
        public const int STENCIL_INDEX1_EXT = ((int)0x8D46);
        public const int STENCIL_INDEX16 = ((int)0x8D49);
        public const int STENCIL_INDEX16_EXT = ((int)0x8D49);
        public const int STENCIL_INDEX4 = ((int)0x8D47);
        public const int STENCIL_INDEX4_EXT = ((int)0x8D47);
        public const int STENCIL_INDEX8 = ((int)0x8D48);
        public const int STENCIL_INDEX8_EXT = ((int)0x8D48);
        public const int STENCIL_PASS_DEPTH_FAIL = ((int)0x0B95);
        public const int STENCIL_PASS_DEPTH_PASS = ((int)0x0B96);
        public const int STENCIL_REF = ((int)0x0B97);
        public const int STENCIL_TAG_BITS_EXT = ((int)0x88F2);
        public const int STENCIL_TEST = ((int)0x0B90);
        public const int STENCIL_TEST_TWO_SIDE_EXT = ((int)0x8910);
        public const int STENCIL_VALUE_MASK = ((int)0x0B93);
        public const int STENCIL_WRITEMASK = ((int)0x0B98);
        public const int STEREO = ((int)0x0C33);
        public const int STREAM_COPY = ((int)0x88E2);
        public const int STREAM_COPY_ARB = ((int)0x88E2);
        public const int STREAM_DRAW = ((int)0x88E0);
        public const int STREAM_DRAW_ARB = ((int)0x88E0);
        public const int STREAM_READ = ((int)0x88E1);
        public const int STREAM_READ_ARB = ((int)0x88E1);
        public const int SUBPIXEL_BITS = ((int)0x0D50);
        public const int SUBTRACT = ((int)0x84E7);
        public const int SUBTRACT_ARB = ((int)0x84E7);
        public const int SYNC_CONDITION = ((int)0x9113);
        public const int SYNC_FENCE = ((int)0x9116);
        public const int SYNC_FLAGS = ((int)0x9115);
        public const int SYNC_FLUSH_COMMANDS_BIT = ((int)0x00000001);
        public const int SYNC_GPU_COMMANDS_COMPLETE = ((int)0x9117);
        public const int SYNC_STATUS = ((int)0x9114);
        public const int T = ((int)0x2001);
        public const int T2F_C3F_V3F = ((int)0x2A2A);
        public const int T2F_C4F_N3F_V3F = ((int)0x2A2C);
        public const int T2F_C4UB_V3F = ((int)0x2A29);
        public const int T2F_IUI_N3F_V2F_EXT = ((int)0x81B3);
        public const int T2F_IUI_N3F_V3F_EXT = ((int)0x81B4);
        public const int T2F_IUI_V2F_EXT = ((int)0x81B1);
        public const int T2F_IUI_V3F_EXT = ((int)0x81B2);
        public const int T2F_N3F_V3F = ((int)0x2A2B);
        public const int T2F_V3F = ((int)0x2A27);
        public const int T4F_C4F_N3F_V4F = ((int)0x2A2D);
        public const int T4F_V4F = ((int)0x2A28);
        public const int TABLE_TOO_LARGE = ((int)0x8031);
        public const int TABLE_TOO_LARGE_EXT = ((int)0x8031);
        public const int TANGENT_ARRAY_EXT = ((int)0x8439);
        public const int TANGENT_ARRAY_POINTER_EXT = ((int)0x8442);
        public const int TANGENT_ARRAY_STRIDE_EXT = ((int)0x843F);
        public const int TANGENT_ARRAY_TYPE_EXT = ((int)0x843E);
        public const int TESSELLATION_FACTOR_AMD = ((int)0x9005);
        public const int TESSELLATION_MODE_AMD = ((int)0x9004);
        public const int TEXTURE = ((int)0x1702);
        public const int TEXTURE_1D = ((int)0x0DE0);
        public const int TEXTURE_1D_ARRAY = ((int)0x8C18);
        public const int TEXTURE_1D_ARRAY_EXT = ((int)0x8C18);
        public const int TEXTURE_1D_BINDING_EXT = ((int)0x8068);
        public const int TEXTURE_1D_STACK_BINDING_MESAX = ((int)0x875D);
        public const int TEXTURE_1D_STACK_MESAX = ((int)0x8759);
        public const int TEXTURE_2D = ((int)0x0DE1);
        public const int TEXTURE_2D_ARRAY = ((int)0x8C1A);
        public const int TEXTURE_2D_ARRAY_EXT = ((int)0x8C1A);
        public const int TEXTURE_2D_BINDING_EXT = ((int)0x8069);
        public const int TEXTURE_2D_MULTISAMPLE = ((int)0x9100);
        public const int TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102);
        public const int TEXTURE_2D_STACK_BINDING_MESAX = ((int)0x875E);
        public const int TEXTURE_2D_STACK_MESAX = ((int)0x875A);
        public const int TEXTURE_3D = ((int)0x806F);
        public const int TEXTURE_3D_BINDING_EXT = ((int)0x806A);
        public const int TEXTURE_3D_EXT = ((int)0x806F);
        public const int TEXTURE_4D_BINDING_SGIS = ((int)0x814F);
        public const int TEXTURE_4D_SGIS = ((int)0x8134);
        public const int TEXTURE_4DSIZE_SGIS = ((int)0x8136);
        public const int TEXTURE_ALPHA_SIZE = ((int)0x805F);
        public const int TEXTURE_ALPHA_SIZE_EXT = ((int)0x805F);
        public const int TEXTURE_ALPHA_TYPE = ((int)0x8C13);
        public const int TEXTURE_ALPHA_TYPE_ARB = ((int)0x8C13);
        public const int TEXTURE_APPLICATION_MODE_EXT = ((int)0x834F);
        public const int TEXTURE_BASE_LEVEL = ((int)0x813C);
        public const int TEXTURE_BASE_LEVEL_SGIS = ((int)0x813C);
        public const int TEXTURE_BINDING_1D = ((int)0x8068);
        public const int TEXTURE_BINDING_1D_ARRAY = ((int)0x8C1C);
        public const int TEXTURE_BINDING_1D_ARRAY_EXT = ((int)0x8C1C);
        public const int TEXTURE_BINDING_2D = ((int)0x8069);
        public const int TEXTURE_BINDING_2D_ARRAY = ((int)0x8C1D);
        public const int TEXTURE_BINDING_2D_ARRAY_EXT = ((int)0x8C1D);
        public const int TEXTURE_BINDING_2D_MULTISAMPLE = ((int)0x9104);
        public const int TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = ((int)0x9105);
        public const int TEXTURE_BINDING_3D = ((int)0x806A);
        public const int TEXTURE_BINDING_BUFFER = ((int)0x8C2C);
        public const int TEXTURE_BINDING_BUFFER_ARB = ((int)0x8C2C);
        public const int TEXTURE_BINDING_BUFFER_EXT = ((int)0x8C2C);
        public const int TEXTURE_BINDING_CUBE_MAP = ((int)0x8514);
        public const int TEXTURE_BINDING_CUBE_MAP_ARB = ((int)0x8514);
        public const int TEXTURE_BINDING_CUBE_MAP_ARRAY = ((int)0x900A);
        public const int TEXTURE_BINDING_CUBE_MAP_EXT = ((int)0x8514);
        public const int TEXTURE_BINDING_RECTANGLE = ((int)0x84F6);
        public const int TEXTURE_BINDING_RECTANGLE_ARB = ((int)0x84F6);
        public const int TEXTURE_BINDING_RENDERBUFFER_NV = ((int)0x8E53);
        public const int TEXTURE_BIT = ((int)0x00040000);
        public const int TEXTURE_BLUE_SIZE = ((int)0x805E);
        public const int TEXTURE_BLUE_SIZE_EXT = ((int)0x805E);
        public const int TEXTURE_BLUE_TYPE = ((int)0x8C12);
        public const int TEXTURE_BLUE_TYPE_ARB = ((int)0x8C12);
        public const int TEXTURE_BORDER = ((int)0x1005);
        public const int TEXTURE_BORDER_COLOR = ((int)0x1004);
        public const int TEXTURE_BUFFER = ((int)0x8C2A);
        public const int TEXTURE_BUFFER_ARB = ((int)0x8C2A);
        public const int TEXTURE_BUFFER_DATA_STORE_BINDING = ((int)0x8C2D);
        public const int TEXTURE_BUFFER_DATA_STORE_BINDING_ARB = ((int)0x8C2D);
        public const int TEXTURE_BUFFER_DATA_STORE_BINDING_EXT = ((int)0x8C2D);
        public const int TEXTURE_BUFFER_EXT = ((int)0x8C2A);
        public const int TEXTURE_BUFFER_FORMAT = ((int)0x8C2E);
        public const int TEXTURE_BUFFER_FORMAT_ARB = ((int)0x8C2E);
        public const int TEXTURE_BUFFER_FORMAT_EXT = ((int)0x8C2E);
        public const int TEXTURE_COMPARE_FAIL_VALUE = ((int)0x80BF);
        public const int TEXTURE_COMPARE_FAIL_VALUE_ARB = ((int)0x80BF);
        public const int TEXTURE_COMPARE_FUNC = ((int)0x884D);
        public const int TEXTURE_COMPARE_FUNC_ARB = ((int)0x884D);
        public const int TEXTURE_COMPARE_MODE = ((int)0x884C);
        public const int TEXTURE_COMPARE_MODE_ARB = ((int)0x884C);
        public const int TEXTURE_COMPONENTS = ((int)0x1003);
        public const int TEXTURE_COMPRESSED = ((int)0x86A1);
        public const int TEXTURE_COMPRESSED_ARB = ((int)0x86A1);
        public const int TEXTURE_COMPRESSED_IMAGE_SIZE = ((int)0x86A0);
        public const int TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = ((int)0x86A0);
        public const int TEXTURE_COMPRESSION_HINT = ((int)0x84EF);
        public const int TEXTURE_COMPRESSION_HINT_ARB = ((int)0x84EF);
        public const int TEXTURE_COORD_ARRAY = ((int)0x8078);
        public const int TEXTURE_COORD_ARRAY_BUFFER_BINDING = ((int)0x889A);
        public const int TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = ((int)0x889A);
        public const int TEXTURE_COORD_ARRAY_COUNT_EXT = ((int)0x808B);
        public const int TEXTURE_COORD_ARRAY_EXT = ((int)0x8078);
        public const int TEXTURE_COORD_ARRAY_POINTER = ((int)0x8092);
        public const int TEXTURE_COORD_ARRAY_POINTER_EXT = ((int)0x8092);
        public const int TEXTURE_COORD_ARRAY_SIZE = ((int)0x8088);
        public const int TEXTURE_COORD_ARRAY_SIZE_EXT = ((int)0x8088);
        public const int TEXTURE_COORD_ARRAY_STRIDE = ((int)0x808A);
        public const int TEXTURE_COORD_ARRAY_STRIDE_EXT = ((int)0x808A);
        public const int TEXTURE_COORD_ARRAY_TYPE = ((int)0x8089);
        public const int TEXTURE_COORD_ARRAY_TYPE_EXT = ((int)0x8089);
        public const int TEXTURE_COORD_NV = ((int)0x8C79);
        public const int TEXTURE_CUBE_MAP = ((int)0x8513);
        public const int TEXTURE_CUBE_MAP_ARB = ((int)0x8513);
        public const int TEXTURE_CUBE_MAP_ARRAY = ((int)0x9009);
        public const int TEXTURE_CUBE_MAP_EXT = ((int)0x8513);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_X = ((int)0x8516);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = ((int)0x8516);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_X_EXT = ((int)0x8516);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Y = ((int)0x8518);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = ((int)0x8518);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT = ((int)0x8518);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Z = ((int)0x851A);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = ((int)0x851A);
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT = ((int)0x851A);
        public const int TEXTURE_CUBE_MAP_POSITIVE_X = ((int)0x8515);
        public const int TEXTURE_CUBE_MAP_POSITIVE_X_ARB = ((int)0x8515);
        public const int TEXTURE_CUBE_MAP_POSITIVE_X_EXT = ((int)0x8515);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Y = ((int)0x8517);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = ((int)0x8517);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Y_EXT = ((int)0x8517);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Z = ((int)0x8519);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = ((int)0x8519);
        public const int TEXTURE_CUBE_MAP_POSITIVE_Z_EXT = ((int)0x8519);
        public const int TEXTURE_CUBE_MAP_SEAMLESS = ((int)0x884F);
        public const int TEXTURE_DEPTH = ((int)0x8071);
        public const int TEXTURE_DEPTH_EXT = ((int)0x8071);
        public const int TEXTURE_DEPTH_SIZE = ((int)0x884A);
        public const int TEXTURE_DEPTH_SIZE_ARB = ((int)0x884A);
        public const int TEXTURE_DEPTH_TYPE = ((int)0x8C16);
        public const int TEXTURE_DEPTH_TYPE_ARB = ((int)0x8C16);
        public const int TEXTURE_ENV = ((int)0x2300);
        public const int TEXTURE_ENV_COLOR = ((int)0x2201);
        public const int TEXTURE_ENV_MODE = ((int)0x2200);
        public const int TEXTURE_FILTER_CONTROL = ((int)0x8500);
        public const int TEXTURE_FILTER_CONTROL_EXT = ((int)0x8500);
        public const int TEXTURE_FILTER4_SIZE_SGIS = ((int)0x8147);
        public const int TEXTURE_FIXED_SAMPLE_LOCATIONS = ((int)0x9107);
        public const int TEXTURE_FREE_MEMORY_ATI = ((int)0x87FC);
        public const int TEXTURE_GEN_MODE = ((int)0x2500);
        public const int TEXTURE_GEN_Q = ((int)0x0C63);
        public const int TEXTURE_GEN_R = ((int)0x0C62);
        public const int TEXTURE_GEN_S = ((int)0x0C60);
        public const int TEXTURE_GEN_T = ((int)0x0C61);
        public const int TEXTURE_GREEN_SIZE = ((int)0x805D);
        public const int TEXTURE_GREEN_SIZE_EXT = ((int)0x805D);
        public const int TEXTURE_GREEN_TYPE = ((int)0x8C11);
        public const int TEXTURE_GREEN_TYPE_ARB = ((int)0x8C11);
        public const int TEXTURE_HEIGHT = ((int)0x1001);
        public const int TEXTURE_INDEX_SIZE_EXT = ((int)0x80ED);
        public const int TEXTURE_INTENSITY_SIZE = ((int)0x8061);
        public const int TEXTURE_INTENSITY_SIZE_EXT = ((int)0x8061);
        public const int TEXTURE_INTENSITY_TYPE = ((int)0x8C15);
        public const int TEXTURE_INTENSITY_TYPE_ARB = ((int)0x8C15);
        public const int TEXTURE_INTERNAL_FORMAT = ((int)0x1003);
        public const int TEXTURE_LIGHT_EXT = ((int)0x8350);
        public const int TEXTURE_LOD_BIAS = ((int)0x8501);
        public const int TEXTURE_LOD_BIAS_EXT = ((int)0x8501);
        public const int TEXTURE_LUMINANCE_SIZE = ((int)0x8060);
        public const int TEXTURE_LUMINANCE_SIZE_EXT = ((int)0x8060);
        public const int TEXTURE_LUMINANCE_TYPE = ((int)0x8C14);
        public const int TEXTURE_LUMINANCE_TYPE_ARB = ((int)0x8C14);
        public const int TEXTURE_MAG_FILTER = ((int)0x2800);
        public const int TEXTURE_MATERIAL_FACE_EXT = ((int)0x8351);
        public const int TEXTURE_MATERIAL_PARAMETER_EXT = ((int)0x8352);
        public const int TEXTURE_MATRIX = ((int)0x0BA8);
        public const int TEXTURE_MAX_ANISOTROPY_EXT = ((int)0x84FE);
        public const int TEXTURE_MAX_LEVEL = ((int)0x813D);
        public const int TEXTURE_MAX_LEVEL_SGIS = ((int)0x813D);
        public const int TEXTURE_MAX_LOD = ((int)0x813B);
        public const int TEXTURE_MAX_LOD_SGIS = ((int)0x813B);
        public const int TEXTURE_MIN_FILTER = ((int)0x2801);
        public const int TEXTURE_MIN_LOD = ((int)0x813A);
        public const int TEXTURE_MIN_LOD_SGIS = ((int)0x813A);
        public const int TEXTURE_NORMAL_EXT = ((int)0x85AF);
        public const int TEXTURE_PRIORITY = ((int)0x8066);
        public const int TEXTURE_PRIORITY_EXT = ((int)0x8066);
        public const int TEXTURE_RECTANGLE = ((int)0x84F5);
        public const int TEXTURE_RECTANGLE_ARB = ((int)0x84F5);
        public const int TEXTURE_RED_SIZE = ((int)0x805C);
        public const int TEXTURE_RED_SIZE_EXT = ((int)0x805C);
        public const int TEXTURE_RED_TYPE = ((int)0x8C10);
        public const int TEXTURE_RED_TYPE_ARB = ((int)0x8C10);
        public const int TEXTURE_RENDERBUFFER_DATA_STORE_BINDING_NV = ((int)0x8E54);
        public const int TEXTURE_RENDERBUFFER_NV = ((int)0x8E55);
        public const int TEXTURE_RESIDENT = ((int)0x8067);
        public const int TEXTURE_RESIDENT_EXT = ((int)0x8067);
        public const int TEXTURE_SAMPLES = ((int)0x9106);
        public const int TEXTURE_SHARED_SIZE = ((int)0x8C3F);
        public const int TEXTURE_SHARED_SIZE_EXT = ((int)0x8C3F);
        public const int TEXTURE_STACK_DEPTH = ((int)0x0BA5);
        public const int TEXTURE_STENCIL_SIZE = ((int)0x88F1);
        public const int TEXTURE_STENCIL_SIZE_EXT = ((int)0x88F1);
        public const int TEXTURE_SWIZZLE_A_EXT = ((int)0x8E45);
        public const int TEXTURE_SWIZZLE_B_EXT = ((int)0x8E44);
        public const int TEXTURE_SWIZZLE_G_EXT = ((int)0x8E43);
        public const int TEXTURE_SWIZZLE_R_EXT = ((int)0x8E42);
        public const int TEXTURE_SWIZZLE_RGBA_EXT = ((int)0x8E46);
        public const int TEXTURE_TOO_LARGE_EXT = ((int)0x8065);
        public const int TEXTURE_WIDTH = ((int)0x1000);
        public const int TEXTURE_WRAP_Q_SGIS = ((int)0x8137);
        public const int TEXTURE_WRAP_R = ((int)0x8072);
        public const int TEXTURE_WRAP_R_EXT = ((int)0x8072);
        public const int TEXTURE_WRAP_S = ((int)0x2802);
        public const int TEXTURE_WRAP_T = ((int)0x2803);
        public const int TEXTURE0 = ((int)0x84C0);
        public const int TEXTURE0_ARB = ((int)0x84C0);
        public const int TEXTURE1 = ((int)0x84C1);
        public const int TEXTURE1_ARB = ((int)0x84C1);
        public const int TEXTURE10 = ((int)0x84CA);
        public const int TEXTURE10_ARB = ((int)0x84CA);
        public const int TEXTURE11 = ((int)0x84CB);
        public const int TEXTURE11_ARB = ((int)0x84CB);
        public const int TEXTURE12 = ((int)0x84CC);
        public const int TEXTURE12_ARB = ((int)0x84CC);
        public const int TEXTURE13 = ((int)0x84CD);
        public const int TEXTURE13_ARB = ((int)0x84CD);
        public const int TEXTURE14 = ((int)0x84CE);
        public const int TEXTURE14_ARB = ((int)0x84CE);
        public const int TEXTURE15 = ((int)0x84CF);
        public const int TEXTURE15_ARB = ((int)0x84CF);
        public const int TEXTURE16 = ((int)0x84D0);
        public const int TEXTURE16_ARB = ((int)0x84D0);
        public const int TEXTURE17 = ((int)0x84D1);
        public const int TEXTURE17_ARB = ((int)0x84D1);
        public const int TEXTURE18 = ((int)0x84D2);
        public const int TEXTURE18_ARB = ((int)0x84D2);
        public const int TEXTURE19 = ((int)0x84D3);
        public const int TEXTURE19_ARB = ((int)0x84D3);
        public const int TEXTURE2 = ((int)0x84C2);
        public const int TEXTURE2_ARB = ((int)0x84C2);
        public const int TEXTURE20 = ((int)0x84D4);
        public const int TEXTURE20_ARB = ((int)0x84D4);
        public const int TEXTURE21 = ((int)0x84D5);
        public const int TEXTURE21_ARB = ((int)0x84D5);
        public const int TEXTURE22 = ((int)0x84D6);
        public const int TEXTURE22_ARB = ((int)0x84D6);
        public const int TEXTURE23 = ((int)0x84D7);
        public const int TEXTURE23_ARB = ((int)0x84D7);
        public const int TEXTURE24 = ((int)0x84D8);
        public const int TEXTURE24_ARB = ((int)0x84D8);
        public const int TEXTURE25 = ((int)0x84D9);
        public const int TEXTURE25_ARB = ((int)0x84D9);
        public const int TEXTURE26 = ((int)0x84DA);
        public const int TEXTURE26_ARB = ((int)0x84DA);
        public const int TEXTURE27 = ((int)0x84DB);
        public const int TEXTURE27_ARB = ((int)0x84DB);
        public const int TEXTURE28 = ((int)0x84DC);
        public const int TEXTURE28_ARB = ((int)0x84DC);
        public const int TEXTURE29 = ((int)0x84DD);
        public const int TEXTURE29_ARB = ((int)0x84DD);
        public const int TEXTURE3 = ((int)0x84C3);
        public const int TEXTURE3_ARB = ((int)0x84C3);
        public const int TEXTURE30 = ((int)0x84DE);
        public const int TEXTURE30_ARB = ((int)0x84DE);
        public const int TEXTURE31 = ((int)0x84DF);
        public const int TEXTURE31_ARB = ((int)0x84DF);
        public const int TEXTURE4 = ((int)0x84C4);
        public const int TEXTURE4_ARB = ((int)0x84C4);
        public const int TEXTURE5 = ((int)0x84C5);
        public const int TEXTURE5_ARB = ((int)0x84C5);
        public const int TEXTURE6 = ((int)0x84C6);
        public const int TEXTURE6_ARB = ((int)0x84C6);
        public const int TEXTURE7 = ((int)0x84C7);
        public const int TEXTURE7_ARB = ((int)0x84C7);
        public const int TEXTURE8 = ((int)0x84C8);
        public const int TEXTURE8_ARB = ((int)0x84C8);
        public const int TEXTURE9 = ((int)0x84C9);
        public const int TEXTURE9_ARB = ((int)0x84C9);
        public const int THREE = ((int)3);
        public const int TIME_ELAPSED_EXT = ((int)0x88BF);
        public const int TIMEOUT_EXPIRED = ((int)0x911B);
        public const int TIMEOUT_IGNORED = unchecked((int)0xFFFFFFFFFFFFFFFF);
        public const int TRANSFORM_BIT = ((int)0x00001000);
        public const int TRANSFORM_FEEDBACK_ATTRIBS_NV = ((int)0x8C7E);
        public const int TRANSFORM_FEEDBACK_BINDING_NV = ((int)0x8E25);
        public const int TRANSFORM_FEEDBACK_BUFFER = ((int)0x8C8E);
        public const int TRANSFORM_FEEDBACK_BUFFER_ACTIVE_NV = ((int)0x8E24);
        public const int TRANSFORM_FEEDBACK_BUFFER_BINDING = ((int)0x8C8F);
        public const int TRANSFORM_FEEDBACK_BUFFER_BINDING_EXT = ((int)0x8C8F);
        public const int TRANSFORM_FEEDBACK_BUFFER_BINDING_NV = ((int)0x8C8F);
        public const int TRANSFORM_FEEDBACK_BUFFER_EXT = ((int)0x8C8E);
        public const int TRANSFORM_FEEDBACK_BUFFER_MODE = ((int)0x8C7F);
        public const int TRANSFORM_FEEDBACK_BUFFER_MODE_EXT = ((int)0x8C7F);
        public const int TRANSFORM_FEEDBACK_BUFFER_MODE_NV = ((int)0x8C7F);
        public const int TRANSFORM_FEEDBACK_BUFFER_NV = ((int)0x8C8E);
        public const int TRANSFORM_FEEDBACK_BUFFER_PAUSED_NV = ((int)0x8E23);
        public const int TRANSFORM_FEEDBACK_BUFFER_SIZE = ((int)0x8C85);
        public const int TRANSFORM_FEEDBACK_BUFFER_SIZE_EXT = ((int)0x8C85);
        public const int TRANSFORM_FEEDBACK_BUFFER_SIZE_NV = ((int)0x8C85);
        public const int TRANSFORM_FEEDBACK_BUFFER_START = ((int)0x8C84);
        public const int TRANSFORM_FEEDBACK_BUFFER_START_EXT = ((int)0x8C84);
        public const int TRANSFORM_FEEDBACK_BUFFER_START_NV = ((int)0x8C84);
        public const int TRANSFORM_FEEDBACK_NV = ((int)0x8E22);
        public const int TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = ((int)0x8C88);
        public const int TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_EXT = ((int)0x8C88);
        public const int TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV = ((int)0x8C88);
        public const int TRANSFORM_FEEDBACK_RECORD_NV = ((int)0x8C86);
        public const int TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = ((int)0x8C76);
        public const int TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH_EXT = ((int)0x8C76);
        public const int TRANSFORM_FEEDBACK_VARYINGS = ((int)0x8C83);
        public const int TRANSFORM_FEEDBACK_VARYINGS_EXT = ((int)0x8C83);
        public const int TRANSFORM_FEEDBACK_VARYINGS_NV = ((int)0x8C83);
        public const int TRANSPOSE_COLOR_MATRIX = ((int)0x84E6);
        public const int TRANSPOSE_COLOR_MATRIX_ARB = ((int)0x84E6);
        public const int TRANSPOSE_CURRENT_MATRIX_ARB = ((int)0x88B7);
        public const int TRANSPOSE_MODELVIEW_MATRIX = ((int)0x84E3);
        public const int TRANSPOSE_MODELVIEW_MATRIX_ARB = ((int)0x84E3);
        public const int TRANSPOSE_PROGRAM_MATRIX_EXT = ((int)0x8E2E);
        public const int TRANSPOSE_PROJECTION_MATRIX = ((int)0x84E4);
        public const int TRANSPOSE_PROJECTION_MATRIX_ARB = ((int)0x84E4);
        public const int TRANSPOSE_TEXTURE_MATRIX = ((int)0x84E5);
        public const int TRANSPOSE_TEXTURE_MATRIX_ARB = ((int)0x84E5);
        public const int TRIANGLE_FAN = ((int)0x0006);
        public const int TRIANGLE_STRIP = ((int)0x0005);
        public const int TRIANGLE_STRIP_ADJACENCY = ((int)0x000D);
        public const int TRIANGLE_STRIP_ADJACENCY_ARB = ((int)0x000D);
        public const int TRIANGLE_STRIP_ADJACENCY_EXT = ((int)0x000D);
        public const int TRIANGLES = ((int)0x0004);
        public const int TRIANGLES_ADJACENCY = ((int)0x000C);
        public const int TRIANGLES_ADJACENCY_ARB = ((int)0x000C);
        public const int TRIANGLES_ADJACENCY_EXT = ((int)0x000C);
        public const int TRUE = ((int)1);
        public const int TWO = ((int)2);
        public const int UNIFORM_ARRAY_STRIDE = ((int)0x8A3C);
        public const int UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = ((int)0x8A43);
        public const int UNIFORM_BLOCK_ACTIVE_UNIFORMS = ((int)0x8A42);
        public const int UNIFORM_BLOCK_BINDING = ((int)0x8A3F);
        public const int UNIFORM_BLOCK_DATA_SIZE = ((int)0x8A40);
        public const int UNIFORM_BLOCK_INDEX = ((int)0x8A3A);
        public const int UNIFORM_BLOCK_NAME_LENGTH = ((int)0x8A41);
        public const int UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = ((int)0x8A46);
        public const int UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = ((int)0x8A45);
        public const int UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = ((int)0x8A44);
        public const int UNIFORM_BUFFER = ((int)0x8A11);
        public const int UNIFORM_BUFFER_BINDING = ((int)0x8A28);
        public const int UNIFORM_BUFFER_BINDING_EXT = ((int)0x8DEF);
        public const int UNIFORM_BUFFER_EXT = ((int)0x8DEE);
        public const int UNIFORM_BUFFER_OFFSET_ALIGNMENT = ((int)0x8A34);
        public const int UNIFORM_BUFFER_SIZE = ((int)0x8A2A);
        public const int UNIFORM_BUFFER_START = ((int)0x8A29);
        public const int UNIFORM_IS_ROW_MAJOR = ((int)0x8A3E);
        public const int UNIFORM_MATRIX_STRIDE = ((int)0x8A3D);
        public const int UNIFORM_NAME_LENGTH = ((int)0x8A39);
        public const int UNIFORM_OFFSET = ((int)0x8A3B);
        public const int UNIFORM_SIZE = ((int)0x8A38);
        public const int UNIFORM_TYPE = ((int)0x8A37);
        public const int UNPACK_ALIGNMENT = ((int)0x0CF5);
        public const int UNPACK_CMYK_HINT_EXT = ((int)0x800F);
        public const int UNPACK_IMAGE_DEPTH_SGIS = ((int)0x8133);
        public const int UNPACK_IMAGE_HEIGHT = ((int)0x806E);
        public const int UNPACK_IMAGE_HEIGHT_EXT = ((int)0x806E);
        public const int UNPACK_LSB_FIRST = ((int)0x0CF1);
        public const int UNPACK_ROW_LENGTH = ((int)0x0CF2);
        public const int UNPACK_SKIP_IMAGES = ((int)0x806D);
        public const int UNPACK_SKIP_IMAGES_EXT = ((int)0x806D);
        public const int UNPACK_SKIP_PIXELS = ((int)0x0CF4);
        public const int UNPACK_SKIP_ROWS = ((int)0x0CF3);
        public const int UNPACK_SKIP_VOLUMES_SGIS = ((int)0x8132);
        public const int UNPACK_SWAP_BYTES = ((int)0x0CF0);
        public const int UNSIGNALED = ((int)0x9118);
        public const int UNSIGNED_BYTE = ((int)0x1401);
        public const int UNSIGNED_BYTE_2_3_3_REV = ((int)0x8362);
        public const int UNSIGNED_BYTE_2_3_3_REV_EXT = ((int)0x8362);
        public const int UNSIGNED_BYTE_2_3_3_REVERSED = ((int)0x8362);
        public const int UNSIGNED_BYTE_3_3_2 = ((int)0x8032);
        public const int UNSIGNED_BYTE_3_3_2_EXT = ((int)0x8032);
        public const int UNSIGNED_INT = ((int)0x1405);
        public const int UNSIGNED_INT_10_10_10_2 = ((int)0x8036);
        public const int UNSIGNED_INT_10_10_10_2_EXT = ((int)0x8036);
        public const int UNSIGNED_INT_10F_11F_11F_REV = ((int)0x8C3B);
        public const int UNSIGNED_INT_10F_11F_11F_REV_EXT = ((int)0x8C3B);
        public const int UNSIGNED_INT_2_10_10_10_REV = ((int)0x8368);
        public const int UNSIGNED_INT_2_10_10_10_REV_EXT = ((int)0x8368);
        public const int UNSIGNED_INT_2_10_10_10_REVERSED = ((int)0x8368);
        public const int UNSIGNED_INT_24_8 = ((int)0x84FA);
        public const int UNSIGNED_INT_24_8_EXT = ((int)0x84FA);
        public const int UNSIGNED_INT_5_9_9_9_REV = ((int)0x8C3E);
        public const int UNSIGNED_INT_5_9_9_9_REV_EXT = ((int)0x8C3E);
        public const int UNSIGNED_INT_8_8_8_8 = ((int)0x8035);
        public const int UNSIGNED_INT_8_8_8_8_EXT = ((int)0x8035);
        public const int UNSIGNED_INT_8_8_8_8_REV = ((int)0x8367);
        public const int UNSIGNED_INT_8_8_8_8_REV_EXT = ((int)0x8367);
        public const int UNSIGNED_INT_8_8_8_8_REVERSED = ((int)0x8367);
        public const int UNSIGNED_INT_SAMPLER_1D = ((int)0x8DD1);
        public const int UNSIGNED_INT_SAMPLER_1D_ARRAY = ((int)0x8DD6);
        public const int UNSIGNED_INT_SAMPLER_1D_ARRAY_EXT = ((int)0x8DD6);
        public const int UNSIGNED_INT_SAMPLER_1D_EXT = ((int)0x8DD1);
        public const int UNSIGNED_INT_SAMPLER_2D = ((int)0x8DD2);
        public const int UNSIGNED_INT_SAMPLER_2D_ARRAY = ((int)0x8DD7);
        public const int UNSIGNED_INT_SAMPLER_2D_ARRAY_EXT = ((int)0x8DD7);
        public const int UNSIGNED_INT_SAMPLER_2D_EXT = ((int)0x8DD2);
        public const int UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = ((int)0x910A);
        public const int UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910D);
        public const int UNSIGNED_INT_SAMPLER_2D_RECT = ((int)0x8DD5);
        public const int UNSIGNED_INT_SAMPLER_2D_RECT_EXT = ((int)0x8DD5);
        public const int UNSIGNED_INT_SAMPLER_3D = ((int)0x8DD3);
        public const int UNSIGNED_INT_SAMPLER_3D_EXT = ((int)0x8DD3);
        public const int UNSIGNED_INT_SAMPLER_BUFFER = ((int)0x8DD8);
        public const int UNSIGNED_INT_SAMPLER_BUFFER_AMD = ((int)0x9003);
        public const int UNSIGNED_INT_SAMPLER_BUFFER_EXT = ((int)0x8DD8);
        public const int UNSIGNED_INT_SAMPLER_CUBE = ((int)0x8DD4);
        public const int UNSIGNED_INT_SAMPLER_CUBE_EXT = ((int)0x8DD4);
        public const int UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = ((int)0x900F);
        public const int UNSIGNED_INT_SAMPLER_RENDERBUFFER_NV = ((int)0x8E58);
        public const int UNSIGNED_INT_VEC2 = ((int)0x8DC6);
        public const int UNSIGNED_INT_VEC2_EXT = ((int)0x8DC6);
        public const int UNSIGNED_INT_VEC3 = ((int)0x8DC7);
        public const int UNSIGNED_INT_VEC3_EXT = ((int)0x8DC7);
        public const int UNSIGNED_INT_VEC4 = ((int)0x8DC8);
        public const int UNSIGNED_INT_VEC4_EXT = ((int)0x8DC8);
        public const int UNSIGNED_INT64_AMD = ((int)0x8BC2);
        public const int UNSIGNED_NORMALIZED = ((int)0x8C17);
        public const int UNSIGNED_NORMALIZED_ARB = ((int)0x8C17);
        public const int UNSIGNED_SHORT = ((int)0x1403);
        public const int UNSIGNED_SHORT_1_5_5_5_REV = ((int)0x8366);
        public const int UNSIGNED_SHORT_1_5_5_5_REV_EXT = ((int)0x8366);
        public const int UNSIGNED_SHORT_1_5_5_5_REVERSED = ((int)0x8366);
        public const int UNSIGNED_SHORT_4_4_4_4 = ((int)0x8033);
        public const int UNSIGNED_SHORT_4_4_4_4_EXT = ((int)0x8033);
        public const int UNSIGNED_SHORT_4_4_4_4_REV = ((int)0x8365);
        public const int UNSIGNED_SHORT_4_4_4_4_REV_EXT = ((int)0x8365);
        public const int UNSIGNED_SHORT_4_4_4_4_REVERSED = ((int)0x8365);
        public const int UNSIGNED_SHORT_5_5_5_1 = ((int)0x8034);
        public const int UNSIGNED_SHORT_5_5_5_1_EXT = ((int)0x8034);
        public const int UNSIGNED_SHORT_5_6_5 = ((int)0x8363);
        public const int UNSIGNED_SHORT_5_6_5_EXT = ((int)0x8363);
        public const int UNSIGNED_SHORT_5_6_5_REV = ((int)0x8364);
        public const int UNSIGNED_SHORT_5_6_5_REV_EXT = ((int)0x8364);
        public const int UNSIGNED_SHORT_5_6_5_REVERSED = ((int)0x8364);
        public const int UPPER_LEFT = ((int)0x8CA2);
        public const int V2F = ((int)0x2A20);
        public const int V3F = ((int)0x2A21);
        public const int VALIDATE_STATUS = ((int)0x8B83);
        public const int VARIANT_ARRAY_EXT = ((int)0x87E8);
        public const int VARIANT_ARRAY_POINTER_EXT = ((int)0x87E9);
        public const int VARIANT_ARRAY_STRIDE_EXT = ((int)0x87E6);
        public const int VARIANT_ARRAY_TYPE_EXT = ((int)0x87E7);
        public const int VARIANT_DATATYPE_EXT = ((int)0x87E5);
        public const int VARIANT_EXT = ((int)0x87C1);
        public const int VARIANT_VALUE_EXT = ((int)0x87E4);
        public const int VBO_FREE_MEMORY_ATI = ((int)0x87FB);
        public const int VECTOR_EXT = ((int)0x87BF);
        public const int VENDOR = ((int)0x1F00);
        public const int VERSION = ((int)0x1F02);
        public const int VERTEX_ARRAY = ((int)0x8074);
        public const int VERTEX_ARRAY_BINDING = ((int)0x85B5);
        public const int VERTEX_ARRAY_BUFFER_BINDING = ((int)0x8896);
        public const int VERTEX_ARRAY_BUFFER_BINDING_ARB = ((int)0x8896);
        public const int VERTEX_ARRAY_COUNT_EXT = ((int)0x807D);
        public const int VERTEX_ARRAY_EXT = ((int)0x8074);
        public const int VERTEX_ARRAY_POINTER = ((int)0x808E);
        public const int VERTEX_ARRAY_POINTER_EXT = ((int)0x808E);
        public const int VERTEX_ARRAY_SIZE = ((int)0x807A);
        public const int VERTEX_ARRAY_SIZE_EXT = ((int)0x807A);
        public const int VERTEX_ARRAY_STRIDE = ((int)0x807C);
        public const int VERTEX_ARRAY_STRIDE_EXT = ((int)0x807C);
        public const int VERTEX_ARRAY_TYPE = ((int)0x807B);
        public const int VERTEX_ARRAY_TYPE_EXT = ((int)0x807B);
        public const int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = ((int)0x889F);
        public const int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = ((int)0x889F);
        public const int VERTEX_ATTRIB_ARRAY_DIVISOR_ARB = ((int)0x88FE);
        public const int VERTEX_ATTRIB_ARRAY_ENABLED = ((int)0x8622);
        public const int VERTEX_ATTRIB_ARRAY_ENABLED_ARB = ((int)0x8622);
        public const int VERTEX_ATTRIB_ARRAY_INTEGER = ((int)0x88FD);
        public const int VERTEX_ATTRIB_ARRAY_INTEGER_NV = ((int)0x88FD);
        public const int VERTEX_ATTRIB_ARRAY_NORMALIZED = ((int)0x886A);
        public const int VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = ((int)0x886A);
        public const int VERTEX_ATTRIB_ARRAY_POINTER = ((int)0x8645);
        public const int VERTEX_ATTRIB_ARRAY_POINTER_ARB = ((int)0x8645);
        public const int VERTEX_ATTRIB_ARRAY_SIZE = ((int)0x8623);
        public const int VERTEX_ATTRIB_ARRAY_SIZE_ARB = ((int)0x8623);
        public const int VERTEX_ATTRIB_ARRAY_STRIDE = ((int)0x8624);
        public const int VERTEX_ATTRIB_ARRAY_STRIDE_ARB = ((int)0x8624);
        public const int VERTEX_ATTRIB_ARRAY_TYPE = ((int)0x8625);
        public const int VERTEX_ATTRIB_ARRAY_TYPE_ARB = ((int)0x8625);
        public const int VERTEX_BLEND_ARB = ((int)0x86A7);
        public const int VERTEX_ID_NV = ((int)0x8C7B);
        public const int VERTEX_PROGRAM = ((int)0x8620);
        public const int VERTEX_PROGRAM_ARB = ((int)0x8620);
        public const int VERTEX_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA2);
        public const int VERTEX_PROGRAM_POINT_SIZE = ((int)0x8642);
        public const int VERTEX_PROGRAM_POINT_SIZE_ARB = ((int)0x8642);
        public const int VERTEX_PROGRAM_TWO_SIDE = ((int)0x8643);
        public const int VERTEX_PROGRAM_TWO_SIDE_ARB = ((int)0x8643);
        public const int VERTEX_SHADER = ((int)0x8B31);
        public const int VERTEX_SHADER_ARB = ((int)0x8B31);
        public const int VERTEX_SHADER_BINDING_EXT = ((int)0x8781);
        public const int VERTEX_SHADER_EXT = ((int)0x8780);
        public const int VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87CF);
        public const int VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87D1);
        public const int VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87D2);
        public const int VERTEX_SHADER_LOCALS_EXT = ((int)0x87D3);
        public const int VERTEX_SHADER_OPTIMIZED_EXT = ((int)0x87D4);
        public const int VERTEX_SHADER_VARIANTS_EXT = ((int)0x87D0);
        public const int VERTEX_WEIGHT_ARRAY_EXT = ((int)0x850C);
        public const int VERTEX_WEIGHT_ARRAY_POINTER_EXT = ((int)0x8510);
        public const int VERTEX_WEIGHT_ARRAY_SIZE_EXT = ((int)0x850D);
        public const int VERTEX_WEIGHT_ARRAY_STRIDE_EXT = ((int)0x850F);
        public const int VERTEX_WEIGHT_ARRAY_TYPE_EXT = ((int)0x850E);
        public const int VERTEX_WEIGHTING_EXT = ((int)0x8509);
        public const int VIEWPORT = ((int)0x0BA2);
        public const int VIEWPORT_BIT = ((int)0x00000800);
        public const int W_EXT = ((int)0x87D8);
        public const int WAIT_FAILED = ((int)0x911D);
        public const int WEIGHT_ARRAY_ARB = ((int)0x86AD);
        public const int WEIGHT_ARRAY_BUFFER_BINDING = ((int)0x889E);
        public const int WEIGHT_ARRAY_BUFFER_BINDING_ARB = ((int)0x889E);
        public const int WEIGHT_ARRAY_POINTER_ARB = ((int)0x86AC);
        public const int WEIGHT_ARRAY_SIZE_ARB = ((int)0x86AB);
        public const int WEIGHT_ARRAY_STRIDE_ARB = ((int)0x86AA);
        public const int WEIGHT_ARRAY_TYPE_ARB = ((int)0x86A9);
        public const int WEIGHT_SUM_UNITY_ARB = ((int)0x86A6);
        public const int WRITE_ONLY = ((int)0x88B9);
        public const int WRITE_ONLY_ARB = ((int)0x88B9);
        public const int X_EXT = ((int)0x87D5);
        public const int XOR = ((int)0x1506);
        public const int Y_EXT = ((int)0x87D6);
        public const int Z_EXT = ((int)0x87D7);
        public const int ZERO = ((int)0);
        public const int ZERO_EXT = ((int)0x87DD);
        public const int ZOOM_X = ((int)0x0D16);
        public const int ZOOM_Y = ((int)0x0D17);
    }

    public enum AlphaFunction : int
    {
        NEVER = ((int)0x0200),
        LESS = ((int)0x0201),
        EQUAL = ((int)0x0202),
        LEQUAL = ((int)0x0203),
        GREATER = ((int)0x0204),
        NOTEQUAL = ((int)0x0205),
        GEQUAL = ((int)0x0206),
        ALWAYS = ((int)0x0207),
    }

    public enum AMD_performance_monitor : int
    {
        COUNTER_TYPE_AMD = ((int)0x8BC0),
        COUNTER_RANGE_AMD = ((int)0x8BC1),
        UNSIGNED_INT64_AMD = ((int)0x8BC2),
        PERCENTAGE_AMD = ((int)0x8BC3),
        PERFMON_RESULT_AVAILABLE_AMD = ((int)0x8BC4),
        PERFMON_RESULT_SIZE_AMD = ((int)0x8BC5),
        PERFMON_RESULT_AMD = ((int)0x8BC6),
    }

    public enum AMD_texture_texture4 : int
    {
    }

    public enum AMD_vertex_shader_tesselator : int
    {
        SAMPLER_BUFFER_AMD = ((int)0x9001),
        INT_SAMPLER_BUFFER_AMD = ((int)0x9002),
        UNSIGNED_INT_SAMPLER_BUFFER_AMD = ((int)0x9003),
        TESSELLATION_MODE_AMD = ((int)0x9004),
        TESSELLATION_FACTOR_AMD = ((int)0x9005),
        DISCRETE_AMD = ((int)0x9006),
        CONTINUOUS_AMD = ((int)0x9007),
    }

    public enum ARB_color_buffer_float : int
    {
        RGBA_FLOAT_MODE_ARB = ((int)0x8820),
        CLAMP_VERTEX_COLOR_ARB = ((int)0x891A),
        CLAMP_FRAGMENT_COLOR_ARB = ((int)0x891B),
        CLAMP_READ_COLOR_ARB = ((int)0x891C),
        FIXED_ONLY_ARB = ((int)0x891D),
    }

    public enum ARB_compatibility : int
    {
    }

    public enum ARB_copy_buffer : int
    {
        COPY_READ_BUFFER = ((int)0x8F36),
        COPY_WRITE_BUFFER = ((int)0x8F37),
    }

    public enum ARB_depth_buffer_float : int
    {
        DEPTH_COMPONENT32F = ((int)0x8CAC),
        DEPTH32F_STENCIL8 = ((int)0x8CAD),
        FLOAT_32_UNSIGNED_INT_24_8_REV = ((int)0x8DAD),
    }

    public enum ARB_depth_clamp : int
    {
        DEPTH_CLAMP = ((int)0x864F),
    }

    public enum ARB_depth_texture : int
    {
        DEPTH_COMPONENT16_ARB = ((int)0x81A5),
        DEPTH_COMPONENT24_ARB = ((int)0x81A6),
        DEPTH_COMPONENT32_ARB = ((int)0x81A7),
        TEXTURE_DEPTH_SIZE_ARB = ((int)0x884A),
        DEPTH_TEXTURE_MODE_ARB = ((int)0x884B),
    }

    public enum ARB_draw_buffers : int
    {
        MAX_DRAW_BUFFERS_ARB = ((int)0x8824),
        DRAW_BUFFER0_ARB = ((int)0x8825),
        DRAW_BUFFER1_ARB = ((int)0x8826),
        DRAW_BUFFER2_ARB = ((int)0x8827),
        DRAW_BUFFER3_ARB = ((int)0x8828),
        DRAW_BUFFER4_ARB = ((int)0x8829),
        DRAW_BUFFER5_ARB = ((int)0x882A),
        DRAW_BUFFER6_ARB = ((int)0x882B),
        DRAW_BUFFER7_ARB = ((int)0x882C),
        DRAW_BUFFER8_ARB = ((int)0x882D),
        DRAW_BUFFER9_ARB = ((int)0x882E),
        DRAW_BUFFER10_ARB = ((int)0x882F),
        DRAW_BUFFER11_ARB = ((int)0x8830),
        DRAW_BUFFER12_ARB = ((int)0x8831),
        DRAW_BUFFER13_ARB = ((int)0x8832),
        DRAW_BUFFER14_ARB = ((int)0x8833),
        DRAW_BUFFER15_ARB = ((int)0x8834),
    }

    public enum ARB_draw_buffers_blend : int
    {
    }

    public enum ARB_draw_elements_base_vertex : int
    {
    }

    public enum ARB_draw_instanced : int
    {
    }

    public enum ARB_fragment_coord_conventions : int
    {
    }

    public enum ARB_fragment_program : int
    {
        FRAGMENT_PROGRAM_ARB = ((int)0x8804),
        PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x8805),
        PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x8806),
        PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x8807),
        PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x8808),
        PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x8809),
        PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x880A),
        MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x880B),
        MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x880C),
        MAX_PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x880D),
        MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x880E),
        MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x880F),
        MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x8810),
        MAX_TEXTURE_COORDS_ARB = ((int)0x8871),
        MAX_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8872),
    }

    public enum ARB_fragment_program_shadow : int
    {
    }

    public enum ARB_fragment_shader : int
    {
        FRAGMENT_SHADER_ARB = ((int)0x8B30),
        MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = ((int)0x8B49),
        FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = ((int)0x8B8B),
    }

    public enum ARB_framebuffer_object : int
    {
        INVALID_FRAMEBUFFER_OPERATION = ((int)0x0506),
        FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = ((int)0x8210),
        FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = ((int)0x8211),
        FRAMEBUFFER_ATTACHMENT_RED_SIZE = ((int)0x8212),
        FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = ((int)0x8213),
        FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = ((int)0x8214),
        FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = ((int)0x8215),
        FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = ((int)0x8216),
        FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = ((int)0x8217),
        FRAMEBUFFER_DEFAULT = ((int)0x8218),
        FRAMEBUFFER_UNDEFINED = ((int)0x8219),
        DEPTH_STENCIL_ATTACHMENT = ((int)0x821A),
        INDEX = ((int)0x8222),
        MAX_RENDERBUFFER_SIZE = ((int)0x84E8),
        DEPTH_STENCIL = ((int)0x84F9),
        UNSIGNED_INT_24_8 = ((int)0x84FA),
        DEPTH24_STENCIL8 = ((int)0x88F0),
        TEXTURE_STENCIL_SIZE = ((int)0x88F1),
        TEXTURE_RED_TYPE = ((int)0x8C10),
        TEXTURE_GREEN_TYPE = ((int)0x8C11),
        TEXTURE_BLUE_TYPE = ((int)0x8C12),
        TEXTURE_ALPHA_TYPE = ((int)0x8C13),
        TEXTURE_LUMINANCE_TYPE = ((int)0x8C14),
        TEXTURE_INTENSITY_TYPE = ((int)0x8C15),
        TEXTURE_DEPTH_TYPE = ((int)0x8C16),
        UNSIGNED_NORMALIZED = ((int)0x8C17),
        DRAW_FRAMEBUFFER_BINDING = ((int)0x8CA6),
        FRAMEBUFFER_BINDING = ((int)0x8CA6),
        RENDERBUFFER_BINDING = ((int)0x8CA7),
        READ_FRAMEBUFFER = ((int)0x8CA8),
        DRAW_FRAMEBUFFER = ((int)0x8CA9),
        READ_FRAMEBUFFER_BINDING = ((int)0x8CAA),
        RENDERBUFFER_SAMPLES = ((int)0x8CAB),
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = ((int)0x8CD0),
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = ((int)0x8CD1),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = ((int)0x8CD2),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = ((int)0x8CD3),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4),
        FRAMEBUFFER_COMPLETE = ((int)0x8CD5),
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT = ((int)0x8CD6),
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = ((int)0x8CD7),
        FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = ((int)0x8CDB),
        FRAMEBUFFER_INCOMPLETE_READ_BUFFER = ((int)0x8CDC),
        FRAMEBUFFER_UNSUPPORTED = ((int)0x8CDD),
        MAX_COLOR_ATTACHMENTS = ((int)0x8CDF),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
        DEPTH_ATTACHMENT = ((int)0x8D00),
        STENCIL_ATTACHMENT = ((int)0x8D20),
        FRAMEBUFFER = ((int)0x8D40),
        RENDERBUFFER = ((int)0x8D41),
        RENDERBUFFER_WIDTH = ((int)0x8D42),
        RENDERBUFFER_HEIGHT = ((int)0x8D43),
        RENDERBUFFER_INTERNAL_FORMAT = ((int)0x8D44),
        STENCIL_INDEX1 = ((int)0x8D46),
        STENCIL_INDEX4 = ((int)0x8D47),
        STENCIL_INDEX8 = ((int)0x8D48),
        STENCIL_INDEX16 = ((int)0x8D49),
        RENDERBUFFER_RED_SIZE = ((int)0x8D50),
        RENDERBUFFER_GREEN_SIZE = ((int)0x8D51),
        RENDERBUFFER_BLUE_SIZE = ((int)0x8D52),
        RENDERBUFFER_ALPHA_SIZE = ((int)0x8D53),
        RENDERBUFFER_DEPTH_SIZE = ((int)0x8D54),
        RENDERBUFFER_STENCIL_SIZE = ((int)0x8D55),
        FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = ((int)0x8D56),
        MAX_SAMPLES = ((int)0x8D57),
    }

    public enum ARB_framebuffer_sRGB : int
    {
        FRAMEBUFFER_SRGB = ((int)0x8DB9),
    }

    public enum ARB_geometry_shader4 : int
    {
        LINES_ADJACENCY_ARB = ((int)0x000A),
        LINE_STRIP_ADJACENCY_ARB = ((int)0x000B),
        TRIANGLES_ADJACENCY_ARB = ((int)0x000C),
        TRIANGLE_STRIP_ADJACENCY_ARB = ((int)0x000D),
        PROGRAM_POINT_SIZE_ARB = ((int)0x8642),
        MAX_VARYING_COMPONENTS = ((int)0x8B4B),
        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8C29),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_LAYERED_ARB = ((int)0x8DA7),
        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_ARB = ((int)0x8DA8),
        FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_ARB = ((int)0x8DA9),
        GEOMETRY_SHADER_ARB = ((int)0x8DD9),
        GEOMETRY_VERTICES_OUT_ARB = ((int)0x8DDA),
        GEOMETRY_INPUT_TYPE_ARB = ((int)0x8DDB),
        GEOMETRY_OUTPUT_TYPE_ARB = ((int)0x8DDC),
        MAX_GEOMETRY_VARYING_COMPONENTS_ARB = ((int)0x8DDD),
        MAX_VERTEX_VARYING_COMPONENTS_ARB = ((int)0x8DDE),
        MAX_GEOMETRY_UNIFORM_COMPONENTS_ARB = ((int)0x8DDF),
        MAX_GEOMETRY_OUTPUT_VERTICES_ARB = ((int)0x8DE0),
        MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_ARB = ((int)0x8DE1),
    }

    public enum ARB_half_float_pixel : int
    {
        HALF_FLOAT_ARB = ((int)0x140B),
    }

    public enum ARB_half_float_vertex : int
    {
        HALF_FLOAT = ((int)0x140B),
    }

    public enum ARB_imaging : int
    {
        CONSTANT_COLOR = ((int)0x8001),
        ONE_MINUS_CONSTANT_COLOR = ((int)0x8002),
        CONSTANT_ALPHA = ((int)0x8003),
        ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004),
        BLEND_COLOR = ((int)0x8005),
        FUNC_ADD = ((int)0x8006),
        MIN = ((int)0x8007),
        MAX = ((int)0x8008),
        BLEND_EQUATION = ((int)0x8009),
        FUNC_SUBTRACT = ((int)0x800A),
        FUNC_REVERSE_SUBTRACT = ((int)0x800B),
    }

    public enum ARB_imaging_DEPRECATED : int
    {
        CONVOLUTION_1D = ((int)0x8010),
        CONVOLUTION_2D = ((int)0x8011),
        SEPARABLE_2D = ((int)0x8012),
        CONVOLUTION_BORDER_MODE = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS = ((int)0x8015),
        REDUCE = ((int)0x8016),
        CONVOLUTION_FORMAT = ((int)0x8017),
        CONVOLUTION_WIDTH = ((int)0x8018),
        CONVOLUTION_HEIGHT = ((int)0x8019),
        MAX_CONVOLUTION_WIDTH = ((int)0x801A),
        MAX_CONVOLUTION_HEIGHT = ((int)0x801B),
        POST_CONVOLUTION_RED_SCALE = ((int)0x801C),
        POST_CONVOLUTION_GREEN_SCALE = ((int)0x801D),
        POST_CONVOLUTION_BLUE_SCALE = ((int)0x801E),
        POST_CONVOLUTION_ALPHA_SCALE = ((int)0x801F),
        POST_CONVOLUTION_RED_BIAS = ((int)0x8020),
        POST_CONVOLUTION_GREEN_BIAS = ((int)0x8021),
        POST_CONVOLUTION_BLUE_BIAS = ((int)0x8022),
        POST_CONVOLUTION_ALPHA_BIAS = ((int)0x8023),
        HISTOGRAM = ((int)0x8024),
        PROXY_HISTOGRAM = ((int)0x8025),
        HISTOGRAM_WIDTH = ((int)0x8026),
        HISTOGRAM_FORMAT = ((int)0x8027),
        HISTOGRAM_RED_SIZE = ((int)0x8028),
        HISTOGRAM_GREEN_SIZE = ((int)0x8029),
        HISTOGRAM_BLUE_SIZE = ((int)0x802A),
        HISTOGRAM_ALPHA_SIZE = ((int)0x802B),
        HISTOGRAM_LUMINANCE_SIZE = ((int)0x802C),
        HISTOGRAM_SINK = ((int)0x802D),
        MINMAX = ((int)0x802E),
        MINMAX_FORMAT = ((int)0x802F),
        MINMAX_SINK = ((int)0x8030),
        TABLE_TOO_LARGE = ((int)0x8031),
        COLOR_MATRIX = ((int)0x80B1),
        COLOR_MATRIX_STACK_DEPTH = ((int)0x80B2),
        MAX_COLOR_MATRIX_STACK_DEPTH = ((int)0x80B3),
        POST_COLOR_MATRIX_RED_SCALE = ((int)0x80B4),
        POST_COLOR_MATRIX_GREEN_SCALE = ((int)0x80B5),
        POST_COLOR_MATRIX_BLUE_SCALE = ((int)0x80B6),
        POST_COLOR_MATRIX_ALPHA_SCALE = ((int)0x80B7),
        POST_COLOR_MATRIX_RED_BIAS = ((int)0x80B8),
        POST_COLOR_MATRIX_GREEN_BIAS = ((int)0x80B9),
        POST_COLOR_MATRIX_BLUE_BIAS = ((int)0x80BA),
        POST_COLOR_MATRIX_ALPHA_BIAS = ((int)0x80BB),
        COLOR_TABLE = ((int)0x80D0),
        POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D1),
        POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D2),
        PROXY_COLOR_TABLE = ((int)0x80D3),
        PROXY_POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D4),
        PROXY_POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D5),
        COLOR_TABLE_SCALE = ((int)0x80D6),
        COLOR_TABLE_BIAS = ((int)0x80D7),
        COLOR_TABLE_FORMAT = ((int)0x80D8),
        COLOR_TABLE_WIDTH = ((int)0x80D9),
        COLOR_TABLE_RED_SIZE = ((int)0x80DA),
        COLOR_TABLE_GREEN_SIZE = ((int)0x80DB),
        COLOR_TABLE_BLUE_SIZE = ((int)0x80DC),
        COLOR_TABLE_ALPHA_SIZE = ((int)0x80DD),
        COLOR_TABLE_LUMINANCE_SIZE = ((int)0x80DE),
        COLOR_TABLE_INTENSITY_SIZE = ((int)0x80DF),
        CONSTANT_BORDER = ((int)0x8151),
        REPLICATE_BORDER = ((int)0x8153),
        CONVOLUTION_BORDER_COLOR = ((int)0x8154),
    }

    public enum ARB_instanced_arrays : int
    {
        VERTEX_ATTRIB_ARRAY_DIVISOR_ARB = ((int)0x88FE),
    }

    public enum ARB_map_buffer_range : int
    {
        MAP_READ_BIT = ((int)0x0001),
        MAP_WRITE_BIT = ((int)0x0002),
        MAP_INVALIDATE_RANGE_BIT = ((int)0x0004),
        MAP_INVALIDATE_BUFFER_BIT = ((int)0x0008),
        MAP_FLUSH_EXPLICIT_BIT = ((int)0x0010),
        MAP_UNSYNCHRONIZED_BIT = ((int)0x0020),
    }

    public enum ARB_matrix_palette : int
    {
        MATRIX_PALETTE_ARB = ((int)0x8840),
        MAX_MATRIX_PALETTE_STACK_DEPTH_ARB = ((int)0x8841),
        MAX_PALETTE_MATRICES_ARB = ((int)0x8842),
        CURRENT_PALETTE_MATRIX_ARB = ((int)0x8843),
        MATRIX_INDEX_ARRAY_ARB = ((int)0x8844),
        CURRENT_MATRIX_INDEX_ARB = ((int)0x8845),
        MATRIX_INDEX_ARRAY_SIZE_ARB = ((int)0x8846),
        MATRIX_INDEX_ARRAY_TYPE_ARB = ((int)0x8847),
        MATRIX_INDEX_ARRAY_STRIDE_ARB = ((int)0x8848),
        MATRIX_INDEX_ARRAY_POINTER_ARB = ((int)0x8849),
    }

    public enum ARB_multisample : int
    {
        MULTISAMPLE_BIT_ARB = ((int)0x20000000),
        MULTISAMPLE_ARB = ((int)0x809D),
        SAMPLE_ALPHA_TO_COVERAGE_ARB = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE_ARB = ((int)0x809F),
        SAMPLE_COVERAGE_ARB = ((int)0x80A0),
        SAMPLE_BUFFERS_ARB = ((int)0x80A8),
        SAMPLES_ARB = ((int)0x80A9),
        SAMPLE_COVERAGE_VALUE_ARB = ((int)0x80AA),
        SAMPLE_COVERAGE_INVERT_ARB = ((int)0x80AB),
    }

    public enum ARB_multitexture : int
    {
        TEXTURE0_ARB = ((int)0x84C0),
        TEXTURE1_ARB = ((int)0x84C1),
        TEXTURE2_ARB = ((int)0x84C2),
        TEXTURE3_ARB = ((int)0x84C3),
        TEXTURE4_ARB = ((int)0x84C4),
        TEXTURE5_ARB = ((int)0x84C5),
        TEXTURE6_ARB = ((int)0x84C6),
        TEXTURE7_ARB = ((int)0x84C7),
        TEXTURE8_ARB = ((int)0x84C8),
        TEXTURE9_ARB = ((int)0x84C9),
        TEXTURE10_ARB = ((int)0x84CA),
        TEXTURE11_ARB = ((int)0x84CB),
        TEXTURE12_ARB = ((int)0x84CC),
        TEXTURE13_ARB = ((int)0x84CD),
        TEXTURE14_ARB = ((int)0x84CE),
        TEXTURE15_ARB = ((int)0x84CF),
        TEXTURE16_ARB = ((int)0x84D0),
        TEXTURE17_ARB = ((int)0x84D1),
        TEXTURE18_ARB = ((int)0x84D2),
        TEXTURE19_ARB = ((int)0x84D3),
        TEXTURE20_ARB = ((int)0x84D4),
        TEXTURE21_ARB = ((int)0x84D5),
        TEXTURE22_ARB = ((int)0x84D6),
        TEXTURE23_ARB = ((int)0x84D7),
        TEXTURE24_ARB = ((int)0x84D8),
        TEXTURE25_ARB = ((int)0x84D9),
        TEXTURE26_ARB = ((int)0x84DA),
        TEXTURE27_ARB = ((int)0x84DB),
        TEXTURE28_ARB = ((int)0x84DC),
        TEXTURE29_ARB = ((int)0x84DD),
        TEXTURE30_ARB = ((int)0x84DE),
        TEXTURE31_ARB = ((int)0x84DF),
        ACTIVE_TEXTURE_ARB = ((int)0x84E0),
        CLIENT_ACTIVE_TEXTURE_ARB = ((int)0x84E1),
        MAX_TEXTURE_UNITS_ARB = ((int)0x84E2),
    }

    public enum ARB_occlusion_query : int
    {
        QUERY_COUNTER_BITS_ARB = ((int)0x8864),
        CURRENT_QUERY_ARB = ((int)0x8865),
        QUERY_RESULT_ARB = ((int)0x8866),
        QUERY_RESULT_AVAILABLE_ARB = ((int)0x8867),
        SAMPLES_PASSED_ARB = ((int)0x8914),
    }

    public enum ARB_pixel_buffer_object : int
    {
        PIXEL_PACK_BUFFER_ARB = ((int)0x88EB),
        PIXEL_UNPACK_BUFFER_ARB = ((int)0x88EC),
        PIXEL_PACK_BUFFER_BINDING_ARB = ((int)0x88ED),
        PIXEL_UNPACK_BUFFER_BINDING_ARB = ((int)0x88EF),
    }

    public enum ARB_point_parameters : int
    {
        POINT_SIZE_MIN_ARB = ((int)0x8126),
        POINT_SIZE_MAX_ARB = ((int)0x8127),
        POINT_FADE_THRESHOLD_SIZE_ARB = ((int)0x8128),
        POINT_DISTANCE_ATTENUATION_ARB = ((int)0x8129),
    }

    public enum ARB_point_sprite : int
    {
        POINT_SPRITE_ARB = ((int)0x8861),
        COORD_REPLACE_ARB = ((int)0x8862),
    }

    public enum ARB_provoking_vertex : int
    {
        QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = ((int)0x8E4C),
        FIRST_VERTEX_CONVENTION = ((int)0x8E4D),
        LAST_VERTEX_CONVENTION = ((int)0x8E4E),
        PROVOKING_VERTEX = ((int)0x8E4F),
    }

    public enum ARB_sample_shading : int
    {
        SAMPLE_SHADING = ((int)0x8C36),
        MIN_SAMPLE_SHADING_VALUE = ((int)0x8C37),
    }

    public enum ARB_seamless_cube_map : int
    {
        TEXTURE_CUBE_MAP_SEAMLESS = ((int)0x884F),
    }

    public enum ARB_shader_objects : int
    {
        PROGRAM_OBJECT_ARB = ((int)0x8B40),
        SHADER_OBJECT_ARB = ((int)0x8B48),
        OBJECT_TYPE_ARB = ((int)0x8B4E),
        OBJECT_SUBTYPE_ARB = ((int)0x8B4F),
        FLOAT_VEC2_ARB = ((int)0x8B50),
        FLOAT_VEC3_ARB = ((int)0x8B51),
        FLOAT_VEC4_ARB = ((int)0x8B52),
        INT_VEC2_ARB = ((int)0x8B53),
        INT_VEC3_ARB = ((int)0x8B54),
        INT_VEC4_ARB = ((int)0x8B55),
        BOOL_ARB = ((int)0x8B56),
        BOOL_VEC2_ARB = ((int)0x8B57),
        BOOL_VEC3_ARB = ((int)0x8B58),
        BOOL_VEC4_ARB = ((int)0x8B59),
        FLOAT_MAT2_ARB = ((int)0x8B5A),
        FLOAT_MAT3_ARB = ((int)0x8B5B),
        FLOAT_MAT4_ARB = ((int)0x8B5C),
        SAMPLER_1D_ARB = ((int)0x8B5D),
        SAMPLER_2D_ARB = ((int)0x8B5E),
        SAMPLER_3D_ARB = ((int)0x8B5F),
        SAMPLER_CUBE_ARB = ((int)0x8B60),
        SAMPLER_1D_SHADOW_ARB = ((int)0x8B61),
        SAMPLER_2D_SHADOW_ARB = ((int)0x8B62),
        SAMPLER_2D_RECT_ARB = ((int)0x8B63),
        SAMPLER_2D_RECT_SHADOW_ARB = ((int)0x8B64),
        OBJECT_DELETE_STATUS_ARB = ((int)0x8B80),
        OBJECT_COMPILE_STATUS_ARB = ((int)0x8B81),
        OBJECT_LINK_STATUS_ARB = ((int)0x8B82),
        OBJECT_VALIDATE_STATUS_ARB = ((int)0x8B83),
        OBJECT_INFO_LOG_LENGTH_ARB = ((int)0x8B84),
        OBJECT_ATTACHED_OBJECTS_ARB = ((int)0x8B85),
        OBJECT_ACTIVE_UNIFORMS_ARB = ((int)0x8B86),
        OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = ((int)0x8B87),
        OBJECT_SHADER_SOURCE_LENGTH_ARB = ((int)0x8B88),
    }

    public enum ARB_shader_texture_lod : int
    {
    }

    public enum ARB_shading_language_100 : int
    {
        SHADING_LANGUAGE_VERSION_ARB = ((int)0x8B8C),
    }

    public enum ARB_shadow : int
    {
        TEXTURE_COMPARE_MODE_ARB = ((int)0x884C),
        TEXTURE_COMPARE_FUNC_ARB = ((int)0x884D),
        COMPARE_R_TO_TEXTURE_ARB = ((int)0x884E),
    }

    public enum ARB_shadow_ambient : int
    {
        TEXTURE_COMPARE_FAIL_VALUE_ARB = ((int)0x80BF),
    }

    public enum ARB_sync : int
    {
        SYNC_FLUSH_COMMANDS_BIT = ((int)0x00000001),
        MAX_SERVER_WAIT_TIMEOUT = ((int)0x9111),
        OBJECT_TYPE = ((int)0x9112),
        SYNC_CONDITION = ((int)0x9113),
        SYNC_STATUS = ((int)0x9114),
        SYNC_FLAGS = ((int)0x9115),
        SYNC_FENCE = ((int)0x9116),
        SYNC_GPU_COMMANDS_COMPLETE = ((int)0x9117),
        UNSIGNALED = ((int)0x9118),
        SIGNALED = ((int)0x9119),
        ALREADY_SIGNALED = ((int)0x911A),
        TIMEOUT_EXPIRED = ((int)0x911B),
        CONDITION_SATISFIED = ((int)0x911C),
        WAIT_FAILED = ((int)0x911D),
        TIMEOUT_IGNORED = unchecked((int)0xFFFFFFFFFFFFFFFF),
    }

    public enum ARB_texture_border_clamp : int
    {
        CLAMP_TO_BORDER_ARB = ((int)0x812D),
    }

    public enum ARB_texture_buffer_object : int
    {
        TEXTURE_BUFFER_ARB = ((int)0x8C2A),
        MAX_TEXTURE_BUFFER_SIZE_ARB = ((int)0x8C2B),
        TEXTURE_BINDING_BUFFER_ARB = ((int)0x8C2C),
        TEXTURE_BUFFER_DATA_STORE_BINDING_ARB = ((int)0x8C2D),
        TEXTURE_BUFFER_FORMAT_ARB = ((int)0x8C2E),
    }

    public enum ARB_texture_compression : int
    {
        COMPRESSED_ALPHA_ARB = ((int)0x84E9),
        COMPRESSED_LUMINANCE_ARB = ((int)0x84EA),
        COMPRESSED_LUMINANCE_ALPHA_ARB = ((int)0x84EB),
        COMPRESSED_INTENSITY_ARB = ((int)0x84EC),
        COMPRESSED_RGB_ARB = ((int)0x84ED),
        COMPRESSED_RGBA_ARB = ((int)0x84EE),
        TEXTURE_COMPRESSION_HINT_ARB = ((int)0x84EF),
        TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = ((int)0x86A0),
        TEXTURE_COMPRESSED_ARB = ((int)0x86A1),
        NUM_COMPRESSED_TEXTURE_FORMATS_ARB = ((int)0x86A2),
        COMPRESSED_TEXTURE_FORMATS_ARB = ((int)0x86A3),
    }

    public enum ARB_texture_compression_rgtc : int
    {
        COMPRESSED_RED_RGTC1 = ((int)0x8DBB),
        COMPRESSED_SIGNED_RED_RGTC1 = ((int)0x8DBC),
        COMPRESSED_RG_RGTC2 = ((int)0x8DBD),
        COMPRESSED_SIGNED_RG_RGTC2 = ((int)0x8DBE),
    }

    public enum ARB_texture_cube_map : int
    {
        NORMAL_MAP_ARB = ((int)0x8511),
        REFLECTION_MAP_ARB = ((int)0x8512),
        TEXTURE_CUBE_MAP_ARB = ((int)0x8513),
        TEXTURE_BINDING_CUBE_MAP_ARB = ((int)0x8514),
        TEXTURE_CUBE_MAP_POSITIVE_X_ARB = ((int)0x8515),
        TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = ((int)0x8516),
        TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = ((int)0x8517),
        TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = ((int)0x8518),
        TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = ((int)0x8519),
        TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = ((int)0x851A),
        PROXY_TEXTURE_CUBE_MAP_ARB = ((int)0x851B),
        MAX_CUBE_MAP_TEXTURE_SIZE_ARB = ((int)0x851C),
    }

    public enum ARB_texture_cube_map_array : int
    {
        TEXTURE_CUBE_MAP_ARRAY = ((int)0x9009),
        TEXTURE_BINDING_CUBE_MAP_ARRAY = ((int)0x900A),
        PROXY_TEXTURE_CUBE_MAP_ARRAY = ((int)0x900B),
        SAMPLER_CUBE_MAP_ARRAY = ((int)0x900C),
        SAMPLER_CUBE_MAP_ARRAY_SHADOW = ((int)0x900D),
        INT_SAMPLER_CUBE_MAP_ARRAY = ((int)0x900E),
        UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = ((int)0x900F),
    }

    public enum ARB_texture_env_add : int
    {
    }

    public enum ARB_texture_env_combine : int
    {
        SUBTRACT_ARB = ((int)0x84E7),
        COMBINE_ARB = ((int)0x8570),
        COMBINE_RGB_ARB = ((int)0x8571),
        COMBINE_ALPHA_ARB = ((int)0x8572),
        RGB_SCALE_ARB = ((int)0x8573),
        ADD_SIGNED_ARB = ((int)0x8574),
        INTERPOLATE_ARB = ((int)0x8575),
        CONSTANT_ARB = ((int)0x8576),
        PRIMARY_COLOR_ARB = ((int)0x8577),
        PREVIOUS_ARB = ((int)0x8578),
        SOURCE0_RGB_ARB = ((int)0x8580),
        SOURCE1_RGB_ARB = ((int)0x8581),
        SOURCE2_RGB_ARB = ((int)0x8582),
        SOURCE0_ALPHA_ARB = ((int)0x8588),
        SOURCE1_ALPHA_ARB = ((int)0x8589),
        SOURCE2_ALPHA_ARB = ((int)0x858A),
        OPERAND0_RGB_ARB = ((int)0x8590),
        OPERAND1_RGB_ARB = ((int)0x8591),
        OPERAND2_RGB_ARB = ((int)0x8592),
        OPERAND0_ALPHA_ARB = ((int)0x8598),
        OPERAND1_ALPHA_ARB = ((int)0x8599),
        OPERAND2_ALPHA_ARB = ((int)0x859A),
    }

    public enum ARB_texture_env_crossbar : int
    {
    }

    public enum ARB_texture_env_dot3 : int
    {
        DOT3_RGB_ARB = ((int)0x86AE),
        DOT3_RGBA_ARB = ((int)0x86AF),
    }

    public enum ARB_texture_float : int
    {
        RGBA32F_ARB = ((int)0x8814),
        RGB32F_ARB = ((int)0x8815),
        ALPHA32F_ARB = ((int)0x8816),
        INTENSITY32F_ARB = ((int)0x8817),
        LUMINANCE32F_ARB = ((int)0x8818),
        LUMINANCE_ALPHA32F_ARB = ((int)0x8819),
        RGBA16F_ARB = ((int)0x881A),
        RGB16F_ARB = ((int)0x881B),
        ALPHA16F_ARB = ((int)0x881C),
        INTENSITY16F_ARB = ((int)0x881D),
        LUMINANCE16F_ARB = ((int)0x881E),
        LUMINANCE_ALPHA16F_ARB = ((int)0x881F),
        TEXTURE_RED_TYPE_ARB = ((int)0x8C10),
        TEXTURE_GREEN_TYPE_ARB = ((int)0x8C11),
        TEXTURE_BLUE_TYPE_ARB = ((int)0x8C12),
        TEXTURE_ALPHA_TYPE_ARB = ((int)0x8C13),
        TEXTURE_LUMINANCE_TYPE_ARB = ((int)0x8C14),
        TEXTURE_INTENSITY_TYPE_ARB = ((int)0x8C15),
        TEXTURE_DEPTH_TYPE_ARB = ((int)0x8C16),
        UNSIGNED_NORMALIZED_ARB = ((int)0x8C17),
    }

    public enum ARB_texture_gather : int
    {
        MIN_PROGRAM_TEXTURE_GATHER_OFFSET = ((int)0x8E5E),
        MAX_PROGRAM_TEXTURE_GATHER_OFFSET = ((int)0x8E5F),
        MAX_PROGRAM_TEXTURE_GATHER_COMPONENTS = ((int)0x8F9F),
    }

    public enum ARB_texture_mirrored_repeat : int
    {
        MIRRORED_REPEAT_ARB = ((int)0x8370),
    }

    public enum ARB_texture_multisample : int
    {
        SAMPLE_POSITION = ((int)0x8E50),
        SAMPLE_MASK = ((int)0x8E51),
        SAMPLE_MASK_VALUE = ((int)0x8E52),
        MAX_SAMPLE_MASK_WORDS = ((int)0x8E59),
        TEXTURE_2D_MULTISAMPLE = ((int)0x9100),
        PROXY_TEXTURE_2D_MULTISAMPLE = ((int)0x9101),
        TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102),
        PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9103),
        TEXTURE_BINDING_2D_MULTISAMPLE = ((int)0x9104),
        TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = ((int)0x9105),
        TEXTURE_SAMPLES = ((int)0x9106),
        TEXTURE_FIXED_SAMPLE_LOCATIONS = ((int)0x9107),
        SAMPLER_2D_MULTISAMPLE = ((int)0x9108),
        INT_SAMPLER_2D_MULTISAMPLE = ((int)0x9109),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = ((int)0x910A),
        SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910B),
        INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910C),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910D),
        MAX_COLOR_TEXTURE_SAMPLES = ((int)0x910E),
        MAX_DEPTH_TEXTURE_SAMPLES = ((int)0x910F),
        MAX_INTEGER_SAMPLES = ((int)0x9110),
    }

    public enum ARB_texture_non_power_of_two : int
    {
    }

    public enum ARB_texture_query_lod : int
    {
    }

    public enum ARB_texture_rectangle : int
    {
        TEXTURE_RECTANGLE_ARB = ((int)0x84F5),
        TEXTURE_BINDING_RECTANGLE_ARB = ((int)0x84F6),
        PROXY_TEXTURE_RECTANGLE_ARB = ((int)0x84F7),
        MAX_RECTANGLE_TEXTURE_SIZE_ARB = ((int)0x84F8),
    }

    public enum ARB_texture_rg : int
    {
        RG = ((int)0x8227),
        RG_INTEGER = ((int)0x8228),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        RG8 = ((int)0x822B),
        RG16 = ((int)0x822C),
        R16F = ((int)0x822D),
        R32F = ((int)0x822E),
        RG16F = ((int)0x822F),
        RG32F = ((int)0x8230),
        R8I = ((int)0x8231),
        R8UI = ((int)0x8232),
        R16I = ((int)0x8233),
        R16UI = ((int)0x8234),
        R32I = ((int)0x8235),
        R32UI = ((int)0x8236),
        RG8I = ((int)0x8237),
        RG8UI = ((int)0x8238),
        RG16I = ((int)0x8239),
        RG16UI = ((int)0x823A),
        RG32I = ((int)0x823B),
        RG32UI = ((int)0x823C),
    }

    public enum ARB_transpose_matrix : int
    {
        TRANSPOSE_MODELVIEW_MATRIX_ARB = ((int)0x84E3),
        TRANSPOSE_PROJECTION_MATRIX_ARB = ((int)0x84E4),
        TRANSPOSE_TEXTURE_MATRIX_ARB = ((int)0x84E5),
        TRANSPOSE_COLOR_MATRIX_ARB = ((int)0x84E6),
    }

    public enum ARB_uniform_buffer_object : int
    {
        UNIFORM_BUFFER = ((int)0x8A11),
        UNIFORM_BUFFER_BINDING = ((int)0x8A28),
        UNIFORM_BUFFER_START = ((int)0x8A29),
        UNIFORM_BUFFER_SIZE = ((int)0x8A2A),
        MAX_VERTEX_UNIFORM_BLOCKS = ((int)0x8A2B),
        MAX_GEOMETRY_UNIFORM_BLOCKS = ((int)0x8A2C),
        MAX_FRAGMENT_UNIFORM_BLOCKS = ((int)0x8A2D),
        MAX_COMBINED_UNIFORM_BLOCKS = ((int)0x8A2E),
        MAX_UNIFORM_BUFFER_BINDINGS = ((int)0x8A2F),
        MAX_UNIFORM_BLOCK_SIZE = ((int)0x8A30),
        MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = ((int)0x8A31),
        MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8A32),
        MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8A33),
        UNIFORM_BUFFER_OFFSET_ALIGNMENT = ((int)0x8A34),
        ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = ((int)0x8A35),
        ACTIVE_UNIFORM_BLOCKS = ((int)0x8A36),
        UNIFORM_TYPE = ((int)0x8A37),
        UNIFORM_SIZE = ((int)0x8A38),
        UNIFORM_NAME_LENGTH = ((int)0x8A39),
        UNIFORM_BLOCK_INDEX = ((int)0x8A3A),
        UNIFORM_OFFSET = ((int)0x8A3B),
        UNIFORM_ARRAY_STRIDE = ((int)0x8A3C),
        UNIFORM_MATRIX_STRIDE = ((int)0x8A3D),
        UNIFORM_IS_ROW_MAJOR = ((int)0x8A3E),
        UNIFORM_BLOCK_BINDING = ((int)0x8A3F),
        UNIFORM_BLOCK_DATA_SIZE = ((int)0x8A40),
        UNIFORM_BLOCK_NAME_LENGTH = ((int)0x8A41),
        UNIFORM_BLOCK_ACTIVE_UNIFORMS = ((int)0x8A42),
        UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = ((int)0x8A43),
        UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = ((int)0x8A44),
        UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = ((int)0x8A45),
        UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = ((int)0x8A46),
        INVALID_INDEX = unchecked((int)0xFFFFFFFF),
    }

    public enum ARB_vertex_array_bgra : int
    {
        BGRA = ((int)0x80E1),
    }

    public enum ARB_vertex_array_object : int
    {
        VERTEX_ARRAY_BINDING = ((int)0x85B5),
    }

    public enum ARB_vertex_blend : int
    {
        MODELVIEW0_ARB = ((int)0x1700),
        MODELVIEW1_ARB = ((int)0x850A),
        MAX_VERTEX_UNITS_ARB = ((int)0x86A4),
        ACTIVE_VERTEX_UNITS_ARB = ((int)0x86A5),
        WEIGHT_SUM_UNITY_ARB = ((int)0x86A6),
        VERTEX_BLEND_ARB = ((int)0x86A7),
        CURRENT_WEIGHT_ARB = ((int)0x86A8),
        WEIGHT_ARRAY_TYPE_ARB = ((int)0x86A9),
        WEIGHT_ARRAY_STRIDE_ARB = ((int)0x86AA),
        WEIGHT_ARRAY_SIZE_ARB = ((int)0x86AB),
        WEIGHT_ARRAY_POINTER_ARB = ((int)0x86AC),
        WEIGHT_ARRAY_ARB = ((int)0x86AD),
        MODELVIEW2_ARB = ((int)0x8722),
        MODELVIEW3_ARB = ((int)0x8723),
        MODELVIEW4_ARB = ((int)0x8724),
        MODELVIEW5_ARB = ((int)0x8725),
        MODELVIEW6_ARB = ((int)0x8726),
        MODELVIEW7_ARB = ((int)0x8727),
        MODELVIEW8_ARB = ((int)0x8728),
        MODELVIEW9_ARB = ((int)0x8729),
        MODELVIEW10_ARB = ((int)0x872A),
        MODELVIEW11_ARB = ((int)0x872B),
        MODELVIEW12_ARB = ((int)0x872C),
        MODELVIEW13_ARB = ((int)0x872D),
        MODELVIEW14_ARB = ((int)0x872E),
        MODELVIEW15_ARB = ((int)0x872F),
        MODELVIEW16_ARB = ((int)0x8730),
        MODELVIEW17_ARB = ((int)0x8731),
        MODELVIEW18_ARB = ((int)0x8732),
        MODELVIEW19_ARB = ((int)0x8733),
        MODELVIEW20_ARB = ((int)0x8734),
        MODELVIEW21_ARB = ((int)0x8735),
        MODELVIEW22_ARB = ((int)0x8736),
        MODELVIEW23_ARB = ((int)0x8737),
        MODELVIEW24_ARB = ((int)0x8738),
        MODELVIEW25_ARB = ((int)0x8739),
        MODELVIEW26_ARB = ((int)0x873A),
        MODELVIEW27_ARB = ((int)0x873B),
        MODELVIEW28_ARB = ((int)0x873C),
        MODELVIEW29_ARB = ((int)0x873D),
        MODELVIEW30_ARB = ((int)0x873E),
        MODELVIEW31_ARB = ((int)0x873F),
    }

    public enum ARB_vertex_buffer_object : int
    {
        BUFFER_SIZE_ARB = ((int)0x8764),
        BUFFER_USAGE_ARB = ((int)0x8765),
        ARRAY_BUFFER_ARB = ((int)0x8892),
        ELEMENT_ARRAY_BUFFER_ARB = ((int)0x8893),
        ARRAY_BUFFER_BINDING_ARB = ((int)0x8894),
        ELEMENT_ARRAY_BUFFER_BINDING_ARB = ((int)0x8895),
        VERTEX_ARRAY_BUFFER_BINDING_ARB = ((int)0x8896),
        NORMAL_ARRAY_BUFFER_BINDING_ARB = ((int)0x8897),
        COLOR_ARRAY_BUFFER_BINDING_ARB = ((int)0x8898),
        INDEX_ARRAY_BUFFER_BINDING_ARB = ((int)0x8899),
        TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = ((int)0x889A),
        EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = ((int)0x889B),
        SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = ((int)0x889C),
        FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = ((int)0x889D),
        WEIGHT_ARRAY_BUFFER_BINDING_ARB = ((int)0x889E),
        VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = ((int)0x889F),
        READ_ONLY_ARB = ((int)0x88B8),
        WRITE_ONLY_ARB = ((int)0x88B9),
        READ_WRITE_ARB = ((int)0x88BA),
        BUFFER_ACCESS_ARB = ((int)0x88BB),
        BUFFER_MAPPED_ARB = ((int)0x88BC),
        BUFFER_MAP_POINTER_ARB = ((int)0x88BD),
        STREAM_DRAW_ARB = ((int)0x88E0),
        STREAM_READ_ARB = ((int)0x88E1),
        STREAM_COPY_ARB = ((int)0x88E2),
        STATIC_DRAW_ARB = ((int)0x88E4),
        STATIC_READ_ARB = ((int)0x88E5),
        STATIC_COPY_ARB = ((int)0x88E6),
        DYNAMIC_DRAW_ARB = ((int)0x88E8),
        DYNAMIC_READ_ARB = ((int)0x88E9),
        DYNAMIC_COPY_ARB = ((int)0x88EA),
    }

    public enum ARB_vertex_program : int
    {
        COLOR_SUM_ARB = ((int)0x8458),
        VERTEX_PROGRAM_ARB = ((int)0x8620),
        VERTEX_ATTRIB_ARRAY_ENABLED_ARB = ((int)0x8622),
        VERTEX_ATTRIB_ARRAY_SIZE_ARB = ((int)0x8623),
        VERTEX_ATTRIB_ARRAY_STRIDE_ARB = ((int)0x8624),
        VERTEX_ATTRIB_ARRAY_TYPE_ARB = ((int)0x8625),
        CURRENT_VERTEX_ATTRIB_ARB = ((int)0x8626),
        PROGRAM_LENGTH_ARB = ((int)0x8627),
        PROGRAM_STRING_ARB = ((int)0x8628),
        MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = ((int)0x862E),
        MAX_PROGRAM_MATRICES_ARB = ((int)0x862F),
        CURRENT_MATRIX_STACK_DEPTH_ARB = ((int)0x8640),
        CURRENT_MATRIX_ARB = ((int)0x8641),
        VERTEX_PROGRAM_POINT_SIZE_ARB = ((int)0x8642),
        VERTEX_PROGRAM_TWO_SIDE_ARB = ((int)0x8643),
        VERTEX_ATTRIB_ARRAY_POINTER_ARB = ((int)0x8645),
        PROGRAM_ERROR_POSITION_ARB = ((int)0x864B),
        PROGRAM_BINDING_ARB = ((int)0x8677),
        MAX_VERTEX_ATTRIBS_ARB = ((int)0x8869),
        VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = ((int)0x886A),
        PROGRAM_ERROR_STRING_ARB = ((int)0x8874),
        PROGRAM_FORMAT_ASCII_ARB = ((int)0x8875),
        PROGRAM_FORMAT_ARB = ((int)0x8876),
        PROGRAM_INSTRUCTIONS_ARB = ((int)0x88A0),
        MAX_PROGRAM_INSTRUCTIONS_ARB = ((int)0x88A1),
        PROGRAM_NATIVE_INSTRUCTIONS_ARB = ((int)0x88A2),
        MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = ((int)0x88A3),
        PROGRAM_TEMPORARIES_ARB = ((int)0x88A4),
        MAX_PROGRAM_TEMPORARIES_ARB = ((int)0x88A5),
        PROGRAM_NATIVE_TEMPORARIES_ARB = ((int)0x88A6),
        MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = ((int)0x88A7),
        PROGRAM_PARAMETERS_ARB = ((int)0x88A8),
        MAX_PROGRAM_PARAMETERS_ARB = ((int)0x88A9),
        PROGRAM_NATIVE_PARAMETERS_ARB = ((int)0x88AA),
        MAX_PROGRAM_NATIVE_PARAMETERS_ARB = ((int)0x88AB),
        PROGRAM_ATTRIBS_ARB = ((int)0x88AC),
        MAX_PROGRAM_ATTRIBS_ARB = ((int)0x88AD),
        PROGRAM_NATIVE_ATTRIBS_ARB = ((int)0x88AE),
        MAX_PROGRAM_NATIVE_ATTRIBS_ARB = ((int)0x88AF),
        PROGRAM_ADDRESS_REGISTERS_ARB = ((int)0x88B0),
        MAX_PROGRAM_ADDRESS_REGISTERS_ARB = ((int)0x88B1),
        PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = ((int)0x88B2),
        MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = ((int)0x88B3),
        MAX_PROGRAM_LOCAL_PARAMETERS_ARB = ((int)0x88B4),
        MAX_PROGRAM_ENV_PARAMETERS_ARB = ((int)0x88B5),
        PROGRAM_UNDER_NATIVE_LIMITS_ARB = ((int)0x88B6),
        TRANSPOSE_CURRENT_MATRIX_ARB = ((int)0x88B7),
        MATRIX0_ARB = ((int)0x88C0),
        MATRIX1_ARB = ((int)0x88C1),
        MATRIX2_ARB = ((int)0x88C2),
        MATRIX3_ARB = ((int)0x88C3),
        MATRIX4_ARB = ((int)0x88C4),
        MATRIX5_ARB = ((int)0x88C5),
        MATRIX6_ARB = ((int)0x88C6),
        MATRIX7_ARB = ((int)0x88C7),
        MATRIX8_ARB = ((int)0x88C8),
        MATRIX9_ARB = ((int)0x88C9),
        MATRIX10_ARB = ((int)0x88CA),
        MATRIX11_ARB = ((int)0x88CB),
        MATRIX12_ARB = ((int)0x88CC),
        MATRIX13_ARB = ((int)0x88CD),
        MATRIX14_ARB = ((int)0x88CE),
        MATRIX15_ARB = ((int)0x88CF),
        MATRIX16_ARB = ((int)0x88D0),
        MATRIX17_ARB = ((int)0x88D1),
        MATRIX18_ARB = ((int)0x88D2),
        MATRIX19_ARB = ((int)0x88D3),
        MATRIX20_ARB = ((int)0x88D4),
        MATRIX21_ARB = ((int)0x88D5),
        MATRIX22_ARB = ((int)0x88D6),
        MATRIX23_ARB = ((int)0x88D7),
        MATRIX24_ARB = ((int)0x88D8),
        MATRIX25_ARB = ((int)0x88D9),
        MATRIX26_ARB = ((int)0x88DA),
        MATRIX27_ARB = ((int)0x88DB),
        MATRIX28_ARB = ((int)0x88DC),
        MATRIX29_ARB = ((int)0x88DD),
        MATRIX30_ARB = ((int)0x88DE),
        MATRIX31_ARB = ((int)0x88DF),
    }

    public enum ARB_vertex_shader : int
    {
        VERTEX_SHADER_ARB = ((int)0x8B31),
        MAX_VERTEX_UNIFORM_COMPONENTS_ARB = ((int)0x8B4A),
        MAX_VARYING_FLOATS_ARB = ((int)0x8B4B),
        MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8B4C),
        MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = ((int)0x8B4D),
        OBJECT_ACTIVE_ATTRIBUTES_ARB = ((int)0x8B89),
        OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = ((int)0x8B8A),
    }

    public enum ARB_window_pos : int
    {
    }

    public enum ArrayCap : int
    {
        VERTEX_ARRAY = ((int)0x8074),
        NORMAL_ARRAY = ((int)0x8075),
        COLOR_ARRAY = ((int)0x8076),
        INDEX_ARRAY = ((int)0x8077),
        TEXTURE_COORD_ARRAY = ((int)0x8078),
        EDGE_FLAG_ARRAY = ((int)0x8079),
        FOG_COORD_ARRAY = ((int)0x8457),
        SECONDARY_COLOR_ARRAY = ((int)0x845E),
    }

    public enum AssemblyProgramFormatARB : int
    {
        PROGRAM_FORMAT_ASCII_ARB = ((int)0x8875),
    }

    public enum AssemblyProgramParameterARB : int
    {
        PROGRAM_LENGTH = ((int)0x8627),
        PROGRAM_BINDING = ((int)0x8677),
        PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x8805),
        PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x8806),
        PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x8807),
        PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x8808),
        PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x8809),
        PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x880A),
        MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = ((int)0x880B),
        MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = ((int)0x880C),
        MAX_PROGRAM_TEX_INDIRECTIONS_ARB = ((int)0x880D),
        MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = ((int)0x880E),
        MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = ((int)0x880F),
        MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = ((int)0x8810),
        PROGRAM_FORMAT = ((int)0x8876),
        PROGRAM_INSTRUCTION = ((int)0x88A0),
        MAX_PROGRAM_INSTRUCTIONS = ((int)0x88A1),
        PROGRAM_NATIVE_INSTRUCTIONS = ((int)0x88A2),
        MAX_PROGRAM_NATIVE_INSTRUCTIONS = ((int)0x88A3),
        PROGRAM_TEMPORARIES = ((int)0x88A4),
        MAX_PROGRAM_TEMPORARIES = ((int)0x88A5),
        PROGRAM_NATIVE_TEMPORARIES = ((int)0x88A6),
        MAX_PROGRAM_NATIVE_TEMPORARIES = ((int)0x88A7),
        PROGRAM_PARAMETERS = ((int)0x88A8),
        MAX_PROGRAM_PARAMETERS = ((int)0x88A9),
        PROGRAM_NATIVE_PARAMETERS = ((int)0x88AA),
        MAX_PROGRAM_NATIVE_PARAMETERS = ((int)0x88AB),
        PROGRAM_ATTRIBS = ((int)0x88AC),
        MAX_PROGRAM_ATTRIBS = ((int)0x88AD),
        PROGRAM_NATIVE_ATTRIBS = ((int)0x88AE),
        MAX_PROGRAM_NATIVE_ATTRIBS = ((int)0x88AF),
        PROGRAM_ADDRESS_REGISTERS = ((int)0x88B0),
        MAX_PROGRAM_ADDRESS_REGISTERS = ((int)0x88B1),
        PROGRAM_NATIVE_ADDRESS_REGISTERS = ((int)0x88B2),
        MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS = ((int)0x88B3),
        MAX_PROGRAM_LOCAL_PARAMETERS = ((int)0x88B4),
        MAX_PROGRAM_ENV_PARAMETERS = ((int)0x88B5),
        PROGRAM_UNDER_NATIVE_LIMITS = ((int)0x88B6),
    }

    public enum AssemblyProgramStringParameterARB : int
    {
        PROGRAM_STRING = ((int)0x8628),
    }

    public enum AssemblyProgramTargetARB : int
    {
        VERTEX_PROGRAM = ((int)0x8620),
        FRAGMENT_PROGRAM = ((int)0x8804),
    }

    public enum ATI_meminfo : int
    {
        VBO_FREE_MEMORY_ATI = ((int)0x87FB),
        TEXTURE_FREE_MEMORY_ATI = ((int)0x87FC),
        RENDERBUFFER_FREE_MEMORY_ATI = ((int)0x87FD),
    }

    [Flags]
    public enum AttribMask : int
    {
        CURRENT_BIT = ((int)0x00000001),
        POINT_BIT = ((int)0x00000002),
        LINE_BIT = ((int)0x00000004),
        POLYGON_BIT = ((int)0x00000008),
        POLYGON_STIPPLE_BIT = ((int)0x00000010),
        PIXEL_MODE_BIT = ((int)0x00000020),
        LIGHTING_BIT = ((int)0x00000040),
        FOG_BIT = ((int)0x00000080),
        DEPTH_BUFFER_BIT = ((int)0x00000100),
        ACCUM_BUFFER_BIT = ((int)0x00000200),
        STENCIL_BUFFER_BIT = ((int)0x00000400),
        VIEWPORT_BIT = ((int)0x00000800),
        TRANSFORM_BIT = ((int)0x00001000),
        ENABLE_BIT = ((int)0x00002000),
        COLOR_BUFFER_BIT = ((int)0x00004000),
        HINT_BIT = ((int)0x00008000),
        EVAL_BIT = ((int)0x00010000),
        LIST_BIT = ((int)0x00020000),
        TEXTURE_BIT = ((int)0x00040000),
        SCISSOR_BIT = ((int)0x00080000),
        MULTISAMPLE_BIT = ((int)0x20000000),
        ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF),
    }

    public enum BeginFeedbackMode : int
    {
        POINTS = ((int)0x0000),
        LINES = ((int)0x0001),
        TRIANGLES = ((int)0x0004),
    }

    public enum BeginMode : int
    {
        POINTS = ((int)0x0000),
        LINES = ((int)0x0001),
        LINE_LOOP = ((int)0x0002),
        LINE_STRIP = ((int)0x0003),
        TRIANGLES = ((int)0x0004),
        TRIANGLE_STRIP = ((int)0x0005),
        TRIANGLE_FAN = ((int)0x0006),
        QUADS = ((int)0x0007),
        QUAD_STRIP = ((int)0x0008),
        POLYGON = ((int)0x0009),
        LINES_ADJACENCY = ((int)0xA),
        LINE_STRIP_ADJACENCY = ((int)0xB),
        TRIANGLES_ADJACENCY = ((int)0xC),
        TRIANGLE_STRIP_ADJACENCY = ((int)0xD),
    }

    public enum BlendEquationMode : int
    {
        FUNC_ADD = ((int)0x8006),
        MIN = ((int)0x8007),
        MAX = ((int)0x8008),
        FUNC_SUBTRACT = ((int)0x800A),
        FUNC_REVERSE_SUBTRACT = ((int)0x800B),
    }

    public enum BlendEquationModeEXT : int
    {
        LOGIC_OP = ((int)0x0BF1),
        FUNC_ADD_EXT = ((int)0x8006),
        MIN_EXT = ((int)0x8007),
        MAX_EXT = ((int)0x8008),
        FUNC_SUBTRACT_EXT = ((int)0x800A),
        FUNC_REVERSE_SUBTRACT_EXT = ((int)0x800B),
    }

    public enum BlendingFactorDest : int
    {
        ZERO = ((int)0),
        SRC_COLOR = ((int)0x0300),
        ONE_MINUS_SRC_COLOR = ((int)0x0301),
        SRC_ALPHA = ((int)0x0302),
        ONE_MINUS_SRC_ALPHA = ((int)0x0303),
        DST_ALPHA = ((int)0x0304),
        ONE_MINUS_DST_ALPHA = ((int)0x0305),
        DST_COLOR = ((int)0x0306),
        ONE_MINUS_DST_COLOR = ((int)0x0307),
        CONSTANT_COLOR = ((int)0x8001),
        CONSTANT_COLOR_EXT = ((int)0x8001),
        ONE_MINUS_CONSTANT_COLOR = ((int)0x8002),
        ONE_MINUS_CONSTANT_COLOR_EXT = ((int)0x8002),
        CONSTANT_ALPHA = ((int)0x8003),
        CONSTANT_ALPHA_EXT = ((int)0x8003),
        ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004),
        ONE_MINUS_CONSTANT_ALPHA_EXT = ((int)0x8004),
        ONE = ((int)1),
    }

    public enum BlendingFactorSrc : int
    {
        ZERO = ((int)0),
        SRC_ALPHA = ((int)0x0302),
        ONE_MINUS_SRC_ALPHA = ((int)0x0303),
        DST_ALPHA = ((int)0x0304),
        ONE_MINUS_DST_ALPHA = ((int)0x0305),
        DST_COLOR = ((int)0x0306),
        ONE_MINUS_DST_COLOR = ((int)0x0307),
        SRC_ALPHA_SATURATE = ((int)0x0308),
        CONSTANT_COLOR = ((int)0x8001),
        CONSTANT_COLOR_EXT = ((int)0x8001),
        ONE_MINUS_CONSTANT_COLOR = ((int)0x8002),
        ONE_MINUS_CONSTANT_COLOR_EXT = ((int)0x8002),
        CONSTANT_ALPHA = ((int)0x8003),
        CONSTANT_ALPHA_EXT = ((int)0x8003),
        ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004),
        ONE_MINUS_CONSTANT_ALPHA_EXT = ((int)0x8004),
        ONE = ((int)1),
    }

    public enum BlitFramebufferFilter : int
    {
        NEAREST = ((int)0x2600),
        LINEAR = ((int)0x2601),
    }

    public enum Boolean : int
    {
        FALSE = ((int)0),
        TRUE = ((int)1),
    }

    public enum BufferAccess : int
    {
        READ_ONLY = ((int)0x88B8),
        WRITE_ONLY = ((int)0x88B9),
        READ_WRITE = ((int)0x88BA),
    }

    public enum BufferAccessARB : int
    {
        READ_ONLY = ((int)0x88B8),
        WRITE_ONLY = ((int)0x88B9),
        READ_WRITE = ((int)0x88BA),
    }

    [Flags]
    public enum BufferAccessMask : int
    {
        MAP_READ_BIT = ((int)0x0001),
        MAP_WRITE_BIT = ((int)0x0002),
        MAP_INVALIDATE_RANGE_BIT = ((int)0x0004),
        MAP_INVALIDATE_BUFFER_BIT = ((int)0x0008),
        MAP_FLUSH_EXPLICIT_BIT = ((int)0x0010),
        MAP_UNSYNCHRONIZED_BIT = ((int)0x0020),
    }

    public enum BufferParameterName : int
    {
        BUFFER_SIZE = ((int)0x8764),
        BUFFER_USAGE = ((int)0x8765),
        BUFFER_ACCESS = ((int)0x88BB),
        BUFFER_MAPPED = ((int)0x88BC),
    }

    public enum BufferParameterNameARB : int
    {
        BUFFER_SIZE = ((int)0x8764),
        BUFFER_USAGE = ((int)0x8765),
        BUFFER_ACCESS = ((int)0x88BB),
        BUFFER_MAPPED = ((int)0x88BC),
    }

    public enum BufferPointer : int
    {
        BUFFER_MAP_POINTER = ((int)0x88BD),
    }

    public enum BufferPointerNameARB : int
    {
        BUFFER_MAP_POINTER = ((int)0x88BD),
    }

    public enum BufferTarget : int
    {
        ARRAY_BUFFER = ((int)0x8892),
        ELEMENT_ARRAY_BUFFER = ((int)0x8893),
        PIXEL_PACK_BUFFER = ((int)0x88EB),
        PIXEL_UNPACK_BUFFER = ((int)0x88EC),
        UNIFORM_BUFFER = ((int)0x8A11),
        TEXTURE_BUFFER = ((int)0x8C2A),
        TRANSFORM_FEEDBACK_BUFFER = ((int)0x8C8E),
        COPY_READ_BUFFER = ((int)0x8F36),
        COPY_WRITE_BUFFER = ((int)0x8F37),
    }

    public enum BufferTargetARB : int
    {
        ARRAY_BUFFER = ((int)0x8892),
        ELEMENT_ARRAY_BUFFER = ((int)0x8893),
    }

    public enum BufferUsageARB : int
    {
        STREAM_DRAW = ((int)0x88E0),
        STREAM_READ = ((int)0x88E1),
        STREAM_COPY = ((int)0x88E2),
        STATIC_DRAW = ((int)0x88E4),
        STATIC_READ = ((int)0x88E5),
        STATIC_COPY = ((int)0x88E6),
        DYNAMIC_DRAW = ((int)0x88E8),
        DYNAMIC_READ = ((int)0x88E9),
        DYNAMIC_COPY = ((int)0x88EA),
    }

    public enum BufferUsageHint : int
    {
        STREAM_DRAW = ((int)0x88E0),
        STREAM_READ = ((int)0x88E1),
        STREAM_COPY = ((int)0x88E2),
        STATIC_DRAW = ((int)0x88E4),
        STATIC_READ = ((int)0x88E5),
        STATIC_COPY = ((int)0x88E6),
        DYNAMIC_DRAW = ((int)0x88E8),
        DYNAMIC_READ = ((int)0x88E9),
        DYNAMIC_COPY = ((int)0x88EA),
    }

    public enum ClampColorMode : int
    {
        FALSE = ((int)0),
        FIXED_ONLY = ((int)0x891D),
        TRUE = ((int)1),
    }

    public enum ClampColorTarget : int
    {
        CLAMP_VERTEX_COLOR = ((int)0x891A),
        CLAMP_FRAGMENT_COLOR = ((int)0x891B),
        CLAMP_READ_COLOR = ((int)0x891C),
    }

    public enum ClearBuffer : int
    {
        COLOR = ((int)0x1800),
        DEPTH = ((int)0x1801),
        STENCIL = ((int)0x1802),
        DEPTH_STENCIL = ((int)0x84F9),
    }

    [Flags]
    public enum ClearBufferMask : int
    {
        DEPTH_BUFFER_BIT = ((int)0x00000100),
        ACCUM_BUFFER_BIT = ((int)0x00000200),
        STENCIL_BUFFER_BIT = ((int)0x00000400),
        COLOR_BUFFER_BIT = ((int)0x00004000),
    }

    [Flags]
    public enum ClientAttribMask : int
    {
        CLIENT_PIXEL_STORE_BIT = ((int)0x00000001),
        CLIENT_VERTEX_ARRAY_BIT = ((int)0x00000002),
        CLIENT_ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF),
    }

    public enum ClipPlaneName : int
    {
        CLIP_PLANE0 = ((int)0x3000),
        CLIP_PLANE1 = ((int)0x3001),
        CLIP_PLANE2 = ((int)0x3002),
        CLIP_PLANE3 = ((int)0x3003),
        CLIP_PLANE4 = ((int)0x3004),
        CLIP_PLANE5 = ((int)0x3005),
    }

    public enum ColorMaterialFace : int
    {
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        FRONT_AND_BACK = ((int)0x0408),
    }

    public enum ColorMaterialParameter : int
    {
        AMBIENT = ((int)0x1200),
        DIFFUSE = ((int)0x1201),
        SPECULAR = ((int)0x1202),
        EMISSION = ((int)0x1600),
        AMBIENT_AND_DIFFUSE = ((int)0x1602),
    }

    public enum ColorPointerType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

    public enum ColorTableParameterPName : int
    {
        COLOR_TABLE_SCALE = ((int)0x80D6),
        COLOR_TABLE_BIAS = ((int)0x80D7),
    }

    public enum ColorTableTarget : int
    {
        COLOR_TABLE = ((int)0x80D0),
        POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D1),
        POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D2),
        PROXY_COLOR_TABLE = ((int)0x80D3),
        PROXY_POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D4),
        PROXY_POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D5),
    }

    public enum ConditionalRenderType : int
    {
        QUERY_WAIT = ((int)0x8E13),
        QUERY_NO_WAIT = ((int)0x8E14),
        QUERY_BY_REGION_WAIT = ((int)0x8E15),
        QUERY_BY_REGION_NO_WAIT = ((int)0x8E16),
    }

    public enum ConvolutionBorderModeEXT : int
    {
        REDUCE_EXT = ((int)0x8016),
    }

    public enum ConvolutionParameter : int
    {
        CONVOLUTION_BORDER_MODE = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS = ((int)0x8015),
    }

    public enum ConvolutionParameterEXT : int
    {
        CONVOLUTION_BORDER_MODE_EXT = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE_EXT = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS_EXT = ((int)0x8015),
    }

    public enum ConvolutionParameterValue : int
    {
        REDUCE = ((int)0x8016),
        CONSTANT_BORDER = ((int)0x8151),
        REPLICATE_BORDER = ((int)0x8153),
    }

    public enum ConvolutionTarget : int
    {
        CONVOLUTION_1D = ((int)0x8010),
        CONVOLUTION_2D = ((int)0x8011),
        SEPARABLE_2D = ((int)0x8012),
    }

    public enum ConvolutionTargetEXT : int
    {
        CONVOLUTION_1D_EXT = ((int)0x8010),
        CONVOLUTION_2D_EXT = ((int)0x8011),
    }

    public enum CullFaceMode : int
    {
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        FRONT_AND_BACK = ((int)0x0408),
    }

    public enum DataType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        GL_2_BYTES = ((int)0x1407),
        GL_3_BYTES = ((int)0x1408),
        GL_4_BYTES = ((int)0x1409),
        DOUBLE = ((int)0x140A),
        DOUBLE_EXT = ((int)0x140A),
    }

    public enum DepthFunction : int
    {
        NEVER = ((int)0x0200),
        LESS = ((int)0x0201),
        EQUAL = ((int)0x0202),
        LEQUAL = ((int)0x0203),
        GREATER = ((int)0x0204),
        NOTEQUAL = ((int)0x0205),
        GEQUAL = ((int)0x0206),
        ALWAYS = ((int)0x0207),
    }

    public enum DrawBufferMode : int
    {
        NONE = ((int)0),
        FRONT_LEFT = ((int)0x0400),
        FRONT_RIGHT = ((int)0x0401),
        BACK_LEFT = ((int)0x0402),
        BACK_RIGHT = ((int)0x0403),
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        LEFT = ((int)0x0406),
        RIGHT = ((int)0x0407),
        FRONT_AND_BACK = ((int)0x0408),
        AUX0 = ((int)0x0409),
        AUX1 = ((int)0x040A),
        AUX2 = ((int)0x040B),
        AUX3 = ((int)0x040C),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
    }

    public enum DrawBuffersEnum : int
    {
        NONE = ((int)0),
        FRONT_LEFT = ((int)0x0400),
        FRONT_RIGHT = ((int)0x0401),
        BACK_LEFT = ((int)0x0402),
        BACK_RIGHT = ((int)0x0403),
        AUX0 = ((int)0x0409),
        AUX1 = ((int)0x040A),
        AUX2 = ((int)0x040B),
        AUX3 = ((int)0x040C),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
    }

    public enum DrawElementsType : int
    {
        UNSIGNED_BYTE = ((int)0x1401),
        UNSIGNED_SHORT = ((int)0x1403),
        UNSIGNED_INT = ((int)0x1405),
    }

    public enum EnableCap : int
    {
        POINT_SMOOTH = ((int)0x0B10),
        LINE_SMOOTH = ((int)0x0B20),
        LINE_STIPPLE = ((int)0x0B24),
        POLYGON_SMOOTH = ((int)0x0B41),
        POLYGON_STIPPLE = ((int)0x0B42),
        CULL_FACE = ((int)0x0B44),
        LIGHTING = ((int)0x0B50),
        COLOR_MATERIAL = ((int)0x0B57),
        FOG = ((int)0x0B60),
        DEPTH_TEST = ((int)0x0B71),
        STENCIL_TEST = ((int)0x0B90),
        NORMALIZE = ((int)0x0BA1),
        ALPHA_TEST = ((int)0x0BC0),
        DITHER = ((int)0x0BD0),
        BLEND = ((int)0x0BE2),
        INDEX_LOGIC_OP = ((int)0x0BF1),
        COLOR_LOGIC_OP = ((int)0x0BF2),
        SCISSOR_TEST = ((int)0x0C11),
        TEXTURE_GEN_S = ((int)0x0C60),
        TEXTURE_GEN_T = ((int)0x0C61),
        TEXTURE_GEN_R = ((int)0x0C62),
        TEXTURE_GEN_Q = ((int)0x0C63),
        AUTO_NORMAL = ((int)0x0D80),
        MAP1_COLOR_4 = ((int)0x0D90),
        MAP1_INDEX = ((int)0x0D91),
        MAP1_NORMAL = ((int)0x0D92),
        MAP1_TEXTURE_COORD_1 = ((int)0x0D93),
        MAP1_TEXTURE_COORD_2 = ((int)0x0D94),
        MAP1_TEXTURE_COORD_3 = ((int)0x0D95),
        MAP1_TEXTURE_COORD_4 = ((int)0x0D96),
        MAP1_VERTEX_3 = ((int)0x0D97),
        MAP1_VERTEX_4 = ((int)0x0D98),
        MAP2_COLOR_4 = ((int)0x0DB0),
        MAP2_INDEX = ((int)0x0DB1),
        MAP2_NORMAL = ((int)0x0DB2),
        MAP2_TEXTURE_COORD_1 = ((int)0x0DB3),
        MAP2_TEXTURE_COORD_2 = ((int)0x0DB4),
        MAP2_TEXTURE_COORD_3 = ((int)0x0DB5),
        MAP2_TEXTURE_COORD_4 = ((int)0x0DB6),
        MAP2_VERTEX_3 = ((int)0x0DB7),
        MAP2_VERTEX_4 = ((int)0x0DB8),
        TEXTURE_1D = ((int)0x0DE0),
        TEXTURE_2D = ((int)0x0DE1),
        POLYGON_OFFSET_POINT = ((int)0x2A01),
        POLYGON_OFFSET_LINE = ((int)0x2A02),
        CLIP_PLANE0 = ((int)0x3000),
        CLIP_PLANE1 = ((int)0x3001),
        CLIP_PLANE2 = ((int)0x3002),
        CLIP_PLANE3 = ((int)0x3003),
        CLIP_PLANE4 = ((int)0x3004),
        CLIP_PLANE5 = ((int)0x3005),
        LIGHT0 = ((int)0x4000),
        LIGHT1 = ((int)0x4001),
        LIGHT2 = ((int)0x4002),
        LIGHT3 = ((int)0x4003),
        LIGHT4 = ((int)0x4004),
        LIGHT5 = ((int)0x4005),
        LIGHT6 = ((int)0x4006),
        LIGHT7 = ((int)0x4007),
        CONVOLUTION_1D = ((int)0x8010),
        CONVOLUTION_1D_EXT = ((int)0x8010),
        CONVOLUTION_2D = ((int)0x8011),
        CONVOLUTION_2D_EXT = ((int)0x8011),
        SEPARABLE_2D = ((int)0x8012),
        SEPARABLE_2D_EXT = ((int)0x8012),
        HISTOGRAM = ((int)0x8024),
        HISTOGRAM_EXT = ((int)0x8024),
        MINMAX_EXT = ((int)0x802E),
        POLYGON_OFFSET_FILL = ((int)0x8037),
        RESCALE_NORMAL = ((int)0x803A),
        RESCALE_NORMAL_EXT = ((int)0x803A),
        TEXTURE_3D_EXT = ((int)0x806F),
        VERTEX_ARRAY = ((int)0x8074),
        NORMAL_ARRAY = ((int)0x8075),
        COLOR_ARRAY = ((int)0x8076),
        INDEX_ARRAY = ((int)0x8077),
        TEXTURE_COORD_ARRAY = ((int)0x8078),
        EDGE_FLAG_ARRAY = ((int)0x8079),
        MULTISAMPLE = ((int)0x809D),
        SAMPLE_ALPHA_TO_COVERAGE = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE = ((int)0x809F),
        SAMPLE_COVERAGE = ((int)0x80A0),
        COLOR_TABLE = ((int)0x80D0),
        POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D1),
        POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D2),
        SHARED_TEXTURE_PALETTE_EXT = ((int)0x81FB),
        FOG_COORD_ARRAY = ((int)0x8457),
        COLOR_SUM = ((int)0x8458),
        SECONDARY_COLOR_ARRAY = ((int)0x845E),
        TEXTURE_CUBE_MAP = ((int)0x8513),
        PROGRAM_POINT_SIZE = ((int)0x8642),
        VERTEX_PROGRAM_POINT_SIZE = ((int)0x8642),
        VERTEX_PROGRAM_TWO_SIDE = ((int)0x8643),
        DEPTH_CLAMP = ((int)0x864F),
        TEXTURE_CUBE_MAP_SEAMLESS = ((int)0x884F),
        POINT_SPRITE = ((int)0x8861),
        RASTERIZER_DISCARD = ((int)0x8C89),
        FRAMEBUFFER_SRGB = ((int)0x8DB9),
        SAMPLE_MASK = ((int)0x8E51),
        PRIMITIVE_RESTART = ((int)0x8F9D),
    }

    public enum ErrorCode : int
    {
        NO_ERROR = ((int)0),
        INVALID_ENUM = ((int)0x0500),
        INVALID_VALUE = ((int)0x0501),
        INVALID_OPERATION = ((int)0x0502),
        STACK_OVERFLOW = ((int)0x0503),
        STACK_UNDERFLOW = ((int)0x0504),
        OUT_OF_MEMORY = ((int)0x0505),
        INVALID_FRAMEBUFFER_OPERATION = ((int)0x0506),
        INVALID_FRAMEBUFFER_OPERATION_EXT = ((int)0x0506),
        TABLE_TOO_LARGE_EXT = ((int)0x8031),
        TEXTURE_TOO_LARGE_EXT = ((int)0x8065),
    }

    public enum EXT_422_pixels : int
    {
        GL_422_EXT = ((int)0x80CC),
        GL_422_REV_EXT = ((int)0x80CD),
        GL_422_AVERAGE_EXT = ((int)0x80CE),
        GL_422_REV_AVERAGE_EXT = ((int)0x80CF),
    }

    public enum EXT_abgr : int
    {
        ABGR_EXT = ((int)0x8000),
    }

    public enum EXT_bgra : int
    {
        BGR_EXT = ((int)0x80E0),
        BGRA_EXT = ((int)0x80E1),
    }

    public enum EXT_bindable_uniform : int
    {
        MAX_VERTEX_BINDABLE_UNIFORMS_EXT = ((int)0x8DE2),
        MAX_FRAGMENT_BINDABLE_UNIFORMS_EXT = ((int)0x8DE3),
        MAX_GEOMETRY_BINDABLE_UNIFORMS_EXT = ((int)0x8DE4),
        MAX_BINDABLE_UNIFORM_SIZE_EXT = ((int)0x8DED),
        UNIFORM_BUFFER_EXT = ((int)0x8DEE),
        UNIFORM_BUFFER_BINDING_EXT = ((int)0x8DEF),
    }

    public enum EXT_blend_color : int
    {
        CONSTANT_COLOR = ((int)0x8001),
        CONSTANT_COLOR_EXT = ((int)0x8001),
        ONE_MINUS_CONSTANT_COLOR = ((int)0x8002),
        ONE_MINUS_CONSTANT_COLOR_EXT = ((int)0x8002),
        CONSTANT_ALPHA = ((int)0x8003),
        CONSTANT_ALPHA_EXT = ((int)0x8003),
        ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004),
        ONE_MINUS_CONSTANT_ALPHA_EXT = ((int)0x8004),
        BLEND_COLOR = ((int)0x8005),
        BLEND_COLOR_EXT = ((int)0x8005),
    }

    public enum EXT_blend_equation_separate : int
    {
        BLEND_EQUATION_RGB_EXT = ((int)0x8009),
        BLEND_EQUATION_ALPHA_EXT = ((int)0x883D),
    }

    public enum EXT_blend_func_separate : int
    {
        BLEND_DST_RGB_EXT = ((int)0x80C8),
        BLEND_SRC_RGB_EXT = ((int)0x80C9),
        BLEND_DST_ALPHA_EXT = ((int)0x80CA),
        BLEND_SRC_ALPHA_EXT = ((int)0x80CB),
    }

    public enum EXT_blend_logic_op : int
    {
    }

    public enum EXT_blend_minmax : int
    {
        FUNC_ADD = ((int)0x8006),
        FUNC_ADD_EXT = ((int)0x8006),
        MIN = ((int)0x8007),
        MIN_EXT = ((int)0x8007),
        MAX = ((int)0x8008),
        MAX_EXT = ((int)0x8008),
        BLEND_EQUATION = ((int)0x8009),
        BLEND_EQUATION_EXT = ((int)0x8009),
    }

    public enum EXT_blend_subtract : int
    {
        FUNC_SUBTRACT = ((int)0x800A),
        FUNC_SUBTRACT_EXT = ((int)0x800A),
        FUNC_REVERSE_SUBTRACT = ((int)0x800B),
        FUNC_REVERSE_SUBTRACT_EXT = ((int)0x800B),
    }

    public enum EXT_clip_volume_hint : int
    {
        CLIP_VOLUME_CLIPPING_HINT_EXT = ((int)0x80F0),
    }

    public enum EXT_cmyka : int
    {
        CMYK_EXT = ((int)0x800C),
        CMYKA_EXT = ((int)0x800D),
        PACK_CMYK_HINT_EXT = ((int)0x800E),
        UNPACK_CMYK_HINT_EXT = ((int)0x800F),
    }

    public enum EXT_color_subtable : int
    {
    }

    public enum EXT_compiled_vertex_array : int
    {
        ARRAY_ELEMENT_LOCK_FIRST_EXT = ((int)0x81A8),
        ARRAY_ELEMENT_LOCK_COUNT_EXT = ((int)0x81A9),
    }

    public enum EXT_convolution : int
    {
        CONVOLUTION_1D_EXT = ((int)0x8010),
        CONVOLUTION_2D_EXT = ((int)0x8011),
        SEPARABLE_2D_EXT = ((int)0x8012),
        CONVOLUTION_BORDER_MODE_EXT = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE_EXT = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS_EXT = ((int)0x8015),
        REDUCE_EXT = ((int)0x8016),
        CONVOLUTION_FORMAT_EXT = ((int)0x8017),
        CONVOLUTION_WIDTH_EXT = ((int)0x8018),
        CONVOLUTION_HEIGHT_EXT = ((int)0x8019),
        MAX_CONVOLUTION_WIDTH_EXT = ((int)0x801A),
        MAX_CONVOLUTION_HEIGHT_EXT = ((int)0x801B),
        POST_CONVOLUTION_RED_SCALE_EXT = ((int)0x801C),
        POST_CONVOLUTION_GREEN_SCALE_EXT = ((int)0x801D),
        POST_CONVOLUTION_BLUE_SCALE_EXT = ((int)0x801E),
        POST_CONVOLUTION_ALPHA_SCALE_EXT = ((int)0x801F),
        POST_CONVOLUTION_RED_BIAS_EXT = ((int)0x8020),
        POST_CONVOLUTION_GREEN_BIAS_EXT = ((int)0x8021),
        POST_CONVOLUTION_BLUE_BIAS_EXT = ((int)0x8022),
        POST_CONVOLUTION_ALPHA_BIAS_EXT = ((int)0x8023),
    }

    public enum EXT_coordinate_frame : int
    {
        TANGENT_ARRAY_EXT = ((int)0x8439),
        BINORMAL_ARRAY_EXT = ((int)0x843A),
        CURRENT_TANGENT_EXT = ((int)0x843B),
        CURRENT_BINORMAL_EXT = ((int)0x843C),
        TANGENT_ARRAY_TYPE_EXT = ((int)0x843E),
        TANGENT_ARRAY_STRIDE_EXT = ((int)0x843F),
        BINORMAL_ARRAY_TYPE_EXT = ((int)0x8440),
        BINORMAL_ARRAY_STRIDE_EXT = ((int)0x8441),
        TANGENT_ARRAY_POINTER_EXT = ((int)0x8442),
        BINORMAL_ARRAY_POINTER_EXT = ((int)0x8443),
        MAP1_TANGENT_EXT = ((int)0x8444),
        MAP2_TANGENT_EXT = ((int)0x8445),
        MAP1_BINORMAL_EXT = ((int)0x8446),
        MAP2_BINORMAL_EXT = ((int)0x8447),
    }

    public enum EXT_copy_texture : int
    {
    }

    public enum EXT_cull_vertex : int
    {
        CULL_VERTEX_EXT = ((int)0x81AA),
        CULL_VERTEX_EYE_POSITION_EXT = ((int)0x81AB),
        CULL_VERTEX_OBJECT_POSITION_EXT = ((int)0x81AC),
    }

    public enum EXT_depth_bounds_test : int
    {
        DEPTH_BOUNDS_TEST_EXT = ((int)0x8890),
        DEPTH_BOUNDS_EXT = ((int)0x8891),
    }

    public enum EXT_direct_state_access : int
    {
        PROGRAM_MATRIX_EXT = ((int)0x8E2D),
        TRANSPOSE_PROGRAM_MATRIX_EXT = ((int)0x8E2E),
        PROGRAM_MATRIX_STACK_DEPTH_EXT = ((int)0x8E2F),
    }

    public enum EXT_draw_buffers2 : int
    {
    }

    public enum EXT_draw_instanced : int
    {
    }

    public enum EXT_draw_range_elements : int
    {
        MAX_ELEMENTS_VERTICES_EXT = ((int)0x80E8),
        MAX_ELEMENTS_INDICES_EXT = ((int)0x80E9),
    }

    public enum EXT_fog_coord : int
    {
        FOG_COORDINATE_SOURCE_EXT = ((int)0x8450),
        FOG_COORDINATE_EXT = ((int)0x8451),
        FRAGMENT_DEPTH_EXT = ((int)0x8452),
        CURRENT_FOG_COORDINATE_EXT = ((int)0x8453),
        FOG_COORDINATE_ARRAY_TYPE_EXT = ((int)0x8454),
        FOG_COORDINATE_ARRAY_STRIDE_EXT = ((int)0x8455),
        FOG_COORDINATE_ARRAY_POINTER_EXT = ((int)0x8456),
        FOG_COORDINATE_ARRAY_EXT = ((int)0x8457),
    }

    public enum EXT_framebuffer_blit : int
    {
        DRAW_FRAMEBUFFER_BINDING_EXT = ((int)0x8CA6),
        READ_FRAMEBUFFER_EXT = ((int)0x8CA8),
        DRAW_FRAMEBUFFER_EXT = ((int)0x8CA9),
        READ_FRAMEBUFFER_BINDING_EXT = ((int)0x8CAA),
    }

    public enum EXT_framebuffer_multisample : int
    {
        RENDERBUFFER_SAMPLES_EXT = ((int)0x8CAB),
        FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_EXT = ((int)0x8D56),
        MAX_SAMPLES_EXT = ((int)0x8D57),
    }

    public enum EXT_framebuffer_object : int
    {
        INVALID_FRAMEBUFFER_OPERATION_EXT = ((int)0x0506),
        MAX_RENDERBUFFER_SIZE_EXT = ((int)0x84E8),
        FRAMEBUFFER_BINDING_EXT = ((int)0x8CA6),
        RENDERBUFFER_BINDING_EXT = ((int)0x8CA7),
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = ((int)0x8CD0),
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = ((int)0x8CD1),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = ((int)0x8CD2),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = ((int)0x8CD3),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = ((int)0x8CD4),
        FRAMEBUFFER_COMPLETE_EXT = ((int)0x8CD5),
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = ((int)0x8CD6),
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = ((int)0x8CD7),
        FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = ((int)0x8CD9),
        FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = ((int)0x8CDA),
        FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = ((int)0x8CDB),
        FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = ((int)0x8CDC),
        FRAMEBUFFER_UNSUPPORTED_EXT = ((int)0x8CDD),
        MAX_COLOR_ATTACHMENTS_EXT = ((int)0x8CDF),
        COLOR_ATTACHMENT0_EXT = ((int)0x8CE0),
        COLOR_ATTACHMENT1_EXT = ((int)0x8CE1),
        COLOR_ATTACHMENT2_EXT = ((int)0x8CE2),
        COLOR_ATTACHMENT3_EXT = ((int)0x8CE3),
        COLOR_ATTACHMENT4_EXT = ((int)0x8CE4),
        COLOR_ATTACHMENT5_EXT = ((int)0x8CE5),
        COLOR_ATTACHMENT6_EXT = ((int)0x8CE6),
        COLOR_ATTACHMENT7_EXT = ((int)0x8CE7),
        COLOR_ATTACHMENT8_EXT = ((int)0x8CE8),
        COLOR_ATTACHMENT9_EXT = ((int)0x8CE9),
        COLOR_ATTACHMENT10_EXT = ((int)0x8CEA),
        COLOR_ATTACHMENT11_EXT = ((int)0x8CEB),
        COLOR_ATTACHMENT12_EXT = ((int)0x8CEC),
        COLOR_ATTACHMENT13_EXT = ((int)0x8CED),
        COLOR_ATTACHMENT14_EXT = ((int)0x8CEE),
        COLOR_ATTACHMENT15_EXT = ((int)0x8CEF),
        DEPTH_ATTACHMENT_EXT = ((int)0x8D00),
        STENCIL_ATTACHMENT_EXT = ((int)0x8D20),
        FRAMEBUFFER_EXT = ((int)0x8D40),
        RENDERBUFFER_EXT = ((int)0x8D41),
        RENDERBUFFER_WIDTH_EXT = ((int)0x8D42),
        RENDERBUFFER_HEIGHT_EXT = ((int)0x8D43),
        RENDERBUFFER_INTERNAL_FORMAT_EXT = ((int)0x8D44),
        STENCIL_INDEX1_EXT = ((int)0x8D46),
        STENCIL_INDEX4_EXT = ((int)0x8D47),
        STENCIL_INDEX8_EXT = ((int)0x8D48),
        STENCIL_INDEX16_EXT = ((int)0x8D49),
        RENDERBUFFER_RED_SIZE_EXT = ((int)0x8D50),
        RENDERBUFFER_GREEN_SIZE_EXT = ((int)0x8D51),
        RENDERBUFFER_BLUE_SIZE_EXT = ((int)0x8D52),
        RENDERBUFFER_ALPHA_SIZE_EXT = ((int)0x8D53),
        RENDERBUFFER_DEPTH_SIZE_EXT = ((int)0x8D54),
        RENDERBUFFER_STENCIL_SIZE_EXT = ((int)0x8D55),
    }

    public enum EXT_framebuffer_sRGB : int
    {
        FRAMEBUFFER_SRGB_EXT = ((int)0x8DB9),
        FRAMEBUFFER_SRGB_CAPABLE_EXT = ((int)0x8DBA),
    }

    public enum EXT_geometry_shader4 : int
    {
        LINES_ADJACENCY_EXT = ((int)0x000A),
        LINE_STRIP_ADJACENCY_EXT = ((int)0x000B),
        TRIANGLES_ADJACENCY_EXT = ((int)0x000C),
        TRIANGLE_STRIP_ADJACENCY_EXT = ((int)0x000D),
        PROGRAM_POINT_SIZE_EXT = ((int)0x8642),
        MAX_VARYING_COMPONENTS_EXT = ((int)0x8B4B),
        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT = ((int)0x8C29),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_LAYERED_EXT = ((int)0x8DA7),
        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT = ((int)0x8DA8),
        FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT = ((int)0x8DA9),
        GEOMETRY_SHADER_EXT = ((int)0x8DD9),
        GEOMETRY_VERTICES_OUT_EXT = ((int)0x8DDA),
        GEOMETRY_INPUT_TYPE_EXT = ((int)0x8DDB),
        GEOMETRY_OUTPUT_TYPE_EXT = ((int)0x8DDC),
        MAX_GEOMETRY_VARYING_COMPONENTS_EXT = ((int)0x8DDD),
        MAX_VERTEX_VARYING_COMPONENTS_EXT = ((int)0x8DDE),
        MAX_GEOMETRY_UNIFORM_COMPONENTS_EXT = ((int)0x8DDF),
        MAX_GEOMETRY_OUTPUT_VERTICES_EXT = ((int)0x8DE0),
        MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_EXT = ((int)0x8DE1),
    }

    public enum EXT_gpu_program_parameters : int
    {
    }

    public enum EXT_gpu_shader4 : int
    {
        SAMPLER_1D_ARRAY_EXT = ((int)0x8DC0),
        SAMPLER_2D_ARRAY_EXT = ((int)0x8DC1),
        SAMPLER_BUFFER_EXT = ((int)0x8DC2),
        SAMPLER_1D_ARRAY_SHADOW_EXT = ((int)0x8DC3),
        SAMPLER_2D_ARRAY_SHADOW_EXT = ((int)0x8DC4),
        SAMPLER_CUBE_SHADOW_EXT = ((int)0x8DC5),
        UNSIGNED_INT_VEC2_EXT = ((int)0x8DC6),
        UNSIGNED_INT_VEC3_EXT = ((int)0x8DC7),
        UNSIGNED_INT_VEC4_EXT = ((int)0x8DC8),
        INT_SAMPLER_1D_EXT = ((int)0x8DC9),
        INT_SAMPLER_2D_EXT = ((int)0x8DCA),
        INT_SAMPLER_3D_EXT = ((int)0x8DCB),
        INT_SAMPLER_CUBE_EXT = ((int)0x8DCC),
        INT_SAMPLER_2D_RECT_EXT = ((int)0x8DCD),
        INT_SAMPLER_1D_ARRAY_EXT = ((int)0x8DCE),
        INT_SAMPLER_2D_ARRAY_EXT = ((int)0x8DCF),
        INT_SAMPLER_BUFFER_EXT = ((int)0x8DD0),
        UNSIGNED_INT_SAMPLER_1D_EXT = ((int)0x8DD1),
        UNSIGNED_INT_SAMPLER_2D_EXT = ((int)0x8DD2),
        UNSIGNED_INT_SAMPLER_3D_EXT = ((int)0x8DD3),
        UNSIGNED_INT_SAMPLER_CUBE_EXT = ((int)0x8DD4),
        UNSIGNED_INT_SAMPLER_2D_RECT_EXT = ((int)0x8DD5),
        UNSIGNED_INT_SAMPLER_1D_ARRAY_EXT = ((int)0x8DD6),
        UNSIGNED_INT_SAMPLER_2D_ARRAY_EXT = ((int)0x8DD7),
        UNSIGNED_INT_SAMPLER_BUFFER_EXT = ((int)0x8DD8),
    }

    public enum EXT_histogram : int
    {
        HISTOGRAM_EXT = ((int)0x8024),
        PROXY_HISTOGRAM_EXT = ((int)0x8025),
        HISTOGRAM_WIDTH_EXT = ((int)0x8026),
        HISTOGRAM_FORMAT_EXT = ((int)0x8027),
        HISTOGRAM_RED_SIZE_EXT = ((int)0x8028),
        HISTOGRAM_GREEN_SIZE_EXT = ((int)0x8029),
        HISTOGRAM_BLUE_SIZE_EXT = ((int)0x802A),
        HISTOGRAM_ALPHA_SIZE_EXT = ((int)0x802B),
        HISTOGRAM_LUMINANCE_SIZE = ((int)0x802C),
        HISTOGRAM_LUMINANCE_SIZE_EXT = ((int)0x802C),
        HISTOGRAM_SINK_EXT = ((int)0x802D),
        MINMAX_EXT = ((int)0x802E),
        MINMAX_FORMAT_EXT = ((int)0x802F),
        MINMAX_SINK_EXT = ((int)0x8030),
        TABLE_TOO_LARGE_EXT = ((int)0x8031),
    }

    public enum EXT_index_array_formats : int
    {
        IUI_V2F_EXT = ((int)0x81AD),
        IUI_V3F_EXT = ((int)0x81AE),
        IUI_N3F_V2F_EXT = ((int)0x81AF),
        IUI_N3F_V3F_EXT = ((int)0x81B0),
        T2F_IUI_V2F_EXT = ((int)0x81B1),
        T2F_IUI_V3F_EXT = ((int)0x81B2),
        T2F_IUI_N3F_V2F_EXT = ((int)0x81B3),
        T2F_IUI_N3F_V3F_EXT = ((int)0x81B4),
    }

    public enum EXT_index_func : int
    {
        INDEX_TEST_EXT = ((int)0x81B5),
        INDEX_TEST_FUNC_EXT = ((int)0x81B6),
        INDEX_TEST_REF_EXT = ((int)0x81B7),
    }

    public enum EXT_index_material : int
    {
        INDEX_MATERIAL_EXT = ((int)0x81B8),
        INDEX_MATERIAL_PARAMETER_EXT = ((int)0x81B9),
        INDEX_MATERIAL_FACE_EXT = ((int)0x81BA),
    }

    public enum EXT_index_texture : int
    {
    }

    public enum EXT_light_texture : int
    {
        FRAGMENT_MATERIAL_EXT = ((int)0x8349),
        FRAGMENT_NORMAL_EXT = ((int)0x834A),
        FRAGMENT_COLOR_EXT = ((int)0x834C),
        ATTENUATION_EXT = ((int)0x834D),
        SHADOW_ATTENUATION_EXT = ((int)0x834E),
        TEXTURE_APPLICATION_MODE_EXT = ((int)0x834F),
        TEXTURE_LIGHT_EXT = ((int)0x8350),
        TEXTURE_MATERIAL_FACE_EXT = ((int)0x8351),
        TEXTURE_MATERIAL_PARAMETER_EXT = ((int)0x8352),
        FRAGMENT_DEPTH_EXT = ((int)0x8452),
    }

    public enum EXT_multi_draw_arrays : int
    {
    }

    public enum EXT_multisample : int
    {
        MULTISAMPLE_BIT_EXT = ((int)0x20000000),
        MULTISAMPLE_EXT = ((int)0x809D),
        SAMPLE_ALPHA_TO_MASK_EXT = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE_EXT = ((int)0x809F),
        SAMPLE_MASK_EXT = ((int)0x80A0),
        GL_1PASS_EXT = ((int)0x80A1),
        GL_2PASS_0_EXT = ((int)0x80A2),
        GL_2PASS_1_EXT = ((int)0x80A3),
        GL_4PASS_0_EXT = ((int)0x80A4),
        GL_4PASS_1_EXT = ((int)0x80A5),
        GL_4PASS_2_EXT = ((int)0x80A6),
        GL_4PASS_3_EXT = ((int)0x80A7),
        SAMPLE_BUFFERS_EXT = ((int)0x80A8),
        SAMPLES_EXT = ((int)0x80A9),
        SAMPLE_MASK_VALUE_EXT = ((int)0x80AA),
        SAMPLE_MASK_INVERT_EXT = ((int)0x80AB),
        SAMPLE_PATTERN_EXT = ((int)0x80AC),
    }

    public enum EXT_packed_depth_stencil : int
    {
        DEPTH_STENCIL_EXT = ((int)0x84F9),
        UNSIGNED_INT_24_8_EXT = ((int)0x84FA),
        DEPTH24_STENCIL8_EXT = ((int)0x88F0),
        TEXTURE_STENCIL_SIZE_EXT = ((int)0x88F1),
    }

    public enum EXT_packed_float : int
    {
        R11F_G11F_B10F_EXT = ((int)0x8C3A),
        UNSIGNED_INT_10F_11F_11F_REV_EXT = ((int)0x8C3B),
        RGBA_SIGNED_COMPONENTS_EXT = ((int)0x8C3C),
    }

    public enum EXT_packed_pixels : int
    {
        UNSIGNED_BYTE_3_3_2_EXT = ((int)0x8032),
        UNSIGNED_SHORT_4_4_4_4_EXT = ((int)0x8033),
        UNSIGNED_SHORT_5_5_5_1_EXT = ((int)0x8034),
        UNSIGNED_INT_8_8_8_8_EXT = ((int)0x8035),
        UNSIGNED_INT_10_10_10_2_EXT = ((int)0x8036),
        UNSIGNED_BYTE_2_3_3_REV_EXT = ((int)0x8362),
        UNSIGNED_SHORT_5_6_5_EXT = ((int)0x8363),
        UNSIGNED_SHORT_5_6_5_REV_EXT = ((int)0x8364),
        UNSIGNED_SHORT_4_4_4_4_REV_EXT = ((int)0x8365),
        UNSIGNED_SHORT_1_5_5_5_REV_EXT = ((int)0x8366),
        UNSIGNED_INT_8_8_8_8_REV_EXT = ((int)0x8367),
        UNSIGNED_INT_2_10_10_10_REV_EXT = ((int)0x8368),
    }

    public enum EXT_paletted_texture : int
    {
        COLOR_INDEX1_EXT = ((int)0x80E2),
        COLOR_INDEX2_EXT = ((int)0x80E3),
        COLOR_INDEX4_EXT = ((int)0x80E4),
        COLOR_INDEX8_EXT = ((int)0x80E5),
        COLOR_INDEX12_EXT = ((int)0x80E6),
        COLOR_INDEX16_EXT = ((int)0x80E7),
        TEXTURE_INDEX_SIZE_EXT = ((int)0x80ED),
    }

    public enum EXT_pixel_buffer_object : int
    {
        PIXEL_PACK_BUFFER_EXT = ((int)0x88EB),
        PIXEL_UNPACK_BUFFER_EXT = ((int)0x88EC),
        PIXEL_PACK_BUFFER_BINDING_EXT = ((int)0x88ED),
        PIXEL_UNPACK_BUFFER_BINDING_EXT = ((int)0x88EF),
    }

    public enum EXT_pixel_transform : int
    {
        PIXEL_TRANSFORM_2D_EXT = ((int)0x8330),
        PIXEL_MAG_FILTER_EXT = ((int)0x8331),
        PIXEL_MIN_FILTER_EXT = ((int)0x8332),
        PIXEL_CUBIC_WEIGHT_EXT = ((int)0x8333),
        CUBIC_EXT = ((int)0x8334),
        AVERAGE_EXT = ((int)0x8335),
        PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = ((int)0x8336),
        MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = ((int)0x8337),
        PIXEL_TRANSFORM_2D_MATRIX_EXT = ((int)0x8338),
    }

    public enum EXT_pixel_transform_color_table : int
    {
    }

    public enum EXT_point_parameters : int
    {
        POINT_SIZE_MIN_EXT = ((int)0x8126),
        POINT_SIZE_MAX_EXT = ((int)0x8127),
        POINT_FADE_THRESHOLD_SIZE_EXT = ((int)0x8128),
        DISTANCE_ATTENUATION_EXT = ((int)0x8129),
    }

    public enum EXT_polygon_offset : int
    {
        POLYGON_OFFSET_EXT = ((int)0x8037),
        POLYGON_OFFSET_FACTOR_EXT = ((int)0x8038),
        POLYGON_OFFSET_BIAS_EXT = ((int)0x8039),
    }

    public enum EXT_provoking_vertex : int
    {
        QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION_EXT = ((int)0x8E4C),
        FIRST_VERTEX_CONVENTION_EXT = ((int)0x8E4D),
        LAST_VERTEX_CONVENTION_EXT = ((int)0x8E4E),
        PROVOKING_VERTEX_EXT = ((int)0x8E4F),
    }

    public enum EXT_rescale_normal : int
    {
        RESCALE_NORMAL_EXT = ((int)0x803A),
    }

    public enum EXT_secondary_color : int
    {
        COLOR_SUM_EXT = ((int)0x8458),
        CURRENT_SECONDARY_COLOR_EXT = ((int)0x8459),
        SECONDARY_COLOR_ARRAY_SIZE_EXT = ((int)0x845A),
        SECONDARY_COLOR_ARRAY_TYPE_EXT = ((int)0x845B),
        SECONDARY_COLOR_ARRAY_STRIDE_EXT = ((int)0x845C),
        SECONDARY_COLOR_ARRAY_POINTER_EXT = ((int)0x845D),
        SECONDARY_COLOR_ARRAY_EXT = ((int)0x845E),
    }

    public enum EXT_separate_specular_color : int
    {
        LIGHT_MODEL_COLOR_CONTROL_EXT = ((int)0x81F8),
        SINGLE_COLOR_EXT = ((int)0x81F9),
        SEPARATE_SPECULAR_COLOR_EXT = ((int)0x81FA),
    }

    public enum EXT_shadow_funcs : int
    {
    }

    public enum EXT_shared_texture_palette : int
    {
        SHARED_TEXTURE_PALETTE_EXT = ((int)0x81FB),
    }

    public enum EXT_stencil_clear_tag : int
    {
        STENCIL_TAG_BITS_EXT = ((int)0x88F2),
        STENCIL_CLEAR_TAG_VALUE_EXT = ((int)0x88F3),
    }

    public enum EXT_stencil_two_side : int
    {
        STENCIL_TEST_TWO_SIDE_EXT = ((int)0x8910),
        ACTIVE_STENCIL_FACE_EXT = ((int)0x8911),
    }

    public enum EXT_stencil_wrap : int
    {
        INCR_WRAP_EXT = ((int)0x8507),
        DECR_WRAP_EXT = ((int)0x8508),
    }

    public enum EXT_subtexture : int
    {
    }

    public enum EXT_texture : int
    {
        ALPHA4_EXT = ((int)0x803B),
        ALPHA8_EXT = ((int)0x803C),
        ALPHA12_EXT = ((int)0x803D),
        ALPHA16_EXT = ((int)0x803E),
        LUMINANCE4_EXT = ((int)0x803F),
        LUMINANCE8_EXT = ((int)0x8040),
        LUMINANCE12_EXT = ((int)0x8041),
        LUMINANCE16_EXT = ((int)0x8042),
        LUMINANCE4_ALPHA4_EXT = ((int)0x8043),
        LUMINANCE6_ALPHA2_EXT = ((int)0x8044),
        LUMINANCE8_ALPHA8_EXT = ((int)0x8045),
        LUMINANCE12_ALPHA4_EXT = ((int)0x8046),
        LUMINANCE12_ALPHA12_EXT = ((int)0x8047),
        LUMINANCE16_ALPHA16_EXT = ((int)0x8048),
        INTENSITY_EXT = ((int)0x8049),
        INTENSITY4_EXT = ((int)0x804A),
        INTENSITY8_EXT = ((int)0x804B),
        INTENSITY12_EXT = ((int)0x804C),
        INTENSITY16_EXT = ((int)0x804D),
        RGB2_EXT = ((int)0x804E),
        RGB4_EXT = ((int)0x804F),
        RGB5_EXT = ((int)0x8050),
        RGB8_EXT = ((int)0x8051),
        RGB10_EXT = ((int)0x8052),
        RGB12_EXT = ((int)0x8053),
        RGB16_EXT = ((int)0x8054),
        RGBA2_EXT = ((int)0x8055),
        RGBA4_EXT = ((int)0x8056),
        RGB5_A1_EXT = ((int)0x8057),
        RGBA8_EXT = ((int)0x8058),
        RGB10_A2_EXT = ((int)0x8059),
        RGBA12_EXT = ((int)0x805A),
        RGBA16_EXT = ((int)0x805B),
        TEXTURE_RED_SIZE_EXT = ((int)0x805C),
        TEXTURE_GREEN_SIZE_EXT = ((int)0x805D),
        TEXTURE_BLUE_SIZE_EXT = ((int)0x805E),
        TEXTURE_ALPHA_SIZE_EXT = ((int)0x805F),
        TEXTURE_LUMINANCE_SIZE_EXT = ((int)0x8060),
        TEXTURE_INTENSITY_SIZE_EXT = ((int)0x8061),
        REPLACE_EXT = ((int)0x8062),
        PROXY_TEXTURE_1D_EXT = ((int)0x8063),
        PROXY_TEXTURE_2D_EXT = ((int)0x8064),
        TEXTURE_TOO_LARGE_EXT = ((int)0x8065),
    }

    public enum EXT_texture_array : int
    {
        COMPARE_REF_DEPTH_TO_TEXTURE_EXT = ((int)0x884E),
        MAX_ARRAY_TEXTURE_LAYERS_EXT = ((int)0x88FF),
        TEXTURE_1D_ARRAY_EXT = ((int)0x8C18),
        PROXY_TEXTURE_1D_ARRAY_EXT = ((int)0x8C19),
        TEXTURE_2D_ARRAY_EXT = ((int)0x8C1A),
        PROXY_TEXTURE_2D_ARRAY_EXT = ((int)0x8C1B),
        TEXTURE_BINDING_1D_ARRAY_EXT = ((int)0x8C1C),
        TEXTURE_BINDING_2D_ARRAY_EXT = ((int)0x8C1D),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = ((int)0x8CD4),
    }

    public enum EXT_texture_buffer_object : int
    {
        TEXTURE_BUFFER_EXT = ((int)0x8C2A),
        MAX_TEXTURE_BUFFER_SIZE_EXT = ((int)0x8C2B),
        TEXTURE_BINDING_BUFFER_EXT = ((int)0x8C2C),
        TEXTURE_BUFFER_DATA_STORE_BINDING_EXT = ((int)0x8C2D),
        TEXTURE_BUFFER_FORMAT_EXT = ((int)0x8C2E),
    }

    public enum EXT_texture_compression_latc : int
    {
        COMPRESSED_LUMINANCE_LATC1_EXT = ((int)0x8C70),
        COMPRESSED_SIGNED_LUMINANCE_LATC1_EXT = ((int)0x8C71),
        COMPRESSED_LUMINANCE_ALPHA_LATC2_EXT = ((int)0x8C72),
        COMPRESSED_SIGNED_LUMINANCE_ALPHA_LATC2_EXT = ((int)0x8C73),
    }

    public enum EXT_texture_compression_rgtc : int
    {
        COMPRESSED_RED_RGTC1_EXT = ((int)0x8DBB),
        COMPRESSED_SIGNED_RED_RGTC1_EXT = ((int)0x8DBC),
        COMPRESSED_RED_GREEN_RGTC2_EXT = ((int)0x8DBD),
        COMPRESSED_SIGNED_RED_GREEN_RGTC2_EXT = ((int)0x8DBE),
    }

    public enum EXT_texture_compression_s3tc : int
    {
        COMPRESSED_RGB_S3TC_DXT1_EXT = ((int)0x83F0),
        COMPRESSED_RGBA_S3TC_DXT1_EXT = ((int)0x83F1),
        COMPRESSED_RGBA_S3TC_DXT3_EXT = ((int)0x83F2),
        COMPRESSED_RGBA_S3TC_DXT5_EXT = ((int)0x83F3),
    }

    public enum EXT_texture_cube_map : int
    {
        NORMAL_MAP_EXT = ((int)0x8511),
        REFLECTION_MAP_EXT = ((int)0x8512),
        TEXTURE_CUBE_MAP_EXT = ((int)0x8513),
        TEXTURE_BINDING_CUBE_MAP_EXT = ((int)0x8514),
        TEXTURE_CUBE_MAP_POSITIVE_X_EXT = ((int)0x8515),
        TEXTURE_CUBE_MAP_NEGATIVE_X_EXT = ((int)0x8516),
        TEXTURE_CUBE_MAP_POSITIVE_Y_EXT = ((int)0x8517),
        TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT = ((int)0x8518),
        TEXTURE_CUBE_MAP_POSITIVE_Z_EXT = ((int)0x8519),
        TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT = ((int)0x851A),
        PROXY_TEXTURE_CUBE_MAP_EXT = ((int)0x851B),
        MAX_CUBE_MAP_TEXTURE_SIZE_EXT = ((int)0x851C),
    }

    public enum EXT_texture_env_add : int
    {
    }

    public enum EXT_texture_env_combine : int
    {
        COMBINE_EXT = ((int)0x8570),
        COMBINE_RGB_EXT = ((int)0x8571),
        COMBINE_ALPHA_EXT = ((int)0x8572),
        RGB_SCALE_EXT = ((int)0x8573),
        ADD_SIGNED_EXT = ((int)0x8574),
        INTERPOLATE_EXT = ((int)0x8575),
        CONSTANT_EXT = ((int)0x8576),
        PRIMARY_COLOR_EXT = ((int)0x8577),
        PREVIOUS_EXT = ((int)0x8578),
        SOURCE0_RGB_EXT = ((int)0x8580),
        SOURCE1_RGB_EXT = ((int)0x8581),
        SOURCE2_RGB_EXT = ((int)0x8582),
        SOURCE0_ALPHA_EXT = ((int)0x8588),
        SOURCE1_ALPHA_EXT = ((int)0x8589),
        SOURCE2_ALPHA_EXT = ((int)0x858A),
        OPERAND0_RGB_EXT = ((int)0x8590),
        OPERAND1_RGB_EXT = ((int)0x8591),
        OPERAND2_RGB_EXT = ((int)0x8592),
        OPERAND0_ALPHA_EXT = ((int)0x8598),
        OPERAND1_ALPHA_EXT = ((int)0x8599),
        OPERAND2_ALPHA_EXT = ((int)0x859A),
    }

    public enum EXT_texture_env_dot3 : int
    {
        DOT3_RGB_EXT = ((int)0x8740),
        DOT3_RGBA_EXT = ((int)0x8741),
    }

    public enum EXT_texture_filter_anisotropic : int
    {
        TEXTURE_MAX_ANISOTROPY_EXT = ((int)0x84FE),
        MAX_TEXTURE_MAX_ANISOTROPY_EXT = ((int)0x84FF),
    }

    public enum EXT_texture_integer : int
    {
        RGBA32UI_EXT = ((int)0x8D70),
        RGB32UI_EXT = ((int)0x8D71),
        ALPHA32UI_EXT = ((int)0x8D72),
        INTENSITY32UI_EXT = ((int)0x8D73),
        LUMINANCE32UI_EXT = ((int)0x8D74),
        LUMINANCE_ALPHA32UI_EXT = ((int)0x8D75),
        RGBA16UI_EXT = ((int)0x8D76),
        RGB16UI_EXT = ((int)0x8D77),
        ALPHA16UI_EXT = ((int)0x8D78),
        INTENSITY16UI_EXT = ((int)0x8D79),
        LUMINANCE16UI_EXT = ((int)0x8D7A),
        LUMINANCE_ALPHA16UI_EXT = ((int)0x8D7B),
        RGBA8UI_EXT = ((int)0x8D7C),
        RGB8UI_EXT = ((int)0x8D7D),
        ALPHA8UI_EXT = ((int)0x8D7E),
        INTENSITY8UI_EXT = ((int)0x8D7F),
        LUMINANCE8UI_EXT = ((int)0x8D80),
        LUMINANCE_ALPHA8UI_EXT = ((int)0x8D81),
        RGBA32I_EXT = ((int)0x8D82),
        RGB32I_EXT = ((int)0x8D83),
        ALPHA32I_EXT = ((int)0x8D84),
        INTENSITY32I_EXT = ((int)0x8D85),
        LUMINANCE32I_EXT = ((int)0x8D86),
        LUMINANCE_ALPHA32I_EXT = ((int)0x8D87),
        RGBA16I_EXT = ((int)0x8D88),
        RGB16I_EXT = ((int)0x8D89),
        ALPHA16I_EXT = ((int)0x8D8A),
        INTENSITY16I_EXT = ((int)0x8D8B),
        LUMINANCE16I_EXT = ((int)0x8D8C),
        LUMINANCE_ALPHA16I_EXT = ((int)0x8D8D),
        RGBA8I_EXT = ((int)0x8D8E),
        RGB8I_EXT = ((int)0x8D8F),
        ALPHA8I_EXT = ((int)0x8D90),
        INTENSITY8I_EXT = ((int)0x8D91),
        LUMINANCE8I_EXT = ((int)0x8D92),
        LUMINANCE_ALPHA8I_EXT = ((int)0x8D93),
        RED_INTEGER_EXT = ((int)0x8D94),
        GREEN_INTEGER_EXT = ((int)0x8D95),
        BLUE_INTEGER_EXT = ((int)0x8D96),
        ALPHA_INTEGER_EXT = ((int)0x8D97),
        RGB_INTEGER_EXT = ((int)0x8D98),
        RGBA_INTEGER_EXT = ((int)0x8D99),
        BGR_INTEGER_EXT = ((int)0x8D9A),
        BGRA_INTEGER_EXT = ((int)0x8D9B),
        LUMINANCE_INTEGER_EXT = ((int)0x8D9C),
        LUMINANCE_ALPHA_INTEGER_EXT = ((int)0x8D9D),
        RGBA_INTEGER_MODE_EXT = ((int)0x8D9E),
    }

    public enum EXT_texture_lod_bias : int
    {
        MAX_TEXTURE_LOD_BIAS_EXT = ((int)0x84FD),
        TEXTURE_FILTER_CONTROL_EXT = ((int)0x8500),
        TEXTURE_LOD_BIAS_EXT = ((int)0x8501),
    }

    public enum EXT_texture_mirror_clamp : int
    {
        MIRROR_CLAMP_EXT = ((int)0x8742),
        MIRROR_CLAMP_TO_EDGE_EXT = ((int)0x8743),
        MIRROR_CLAMP_TO_BORDER_EXT = ((int)0x8912),
    }

    public enum EXT_texture_object : int
    {
        TEXTURE_PRIORITY_EXT = ((int)0x8066),
        TEXTURE_RESIDENT_EXT = ((int)0x8067),
        TEXTURE_1D_BINDING_EXT = ((int)0x8068),
        TEXTURE_2D_BINDING_EXT = ((int)0x8069),
        TEXTURE_3D_BINDING_EXT = ((int)0x806A),
    }

    public enum EXT_texture_perturb_normal : int
    {
        PERTURB_EXT = ((int)0x85AE),
        TEXTURE_NORMAL_EXT = ((int)0x85AF),
    }

    public enum EXT_texture_shared_exponent : int
    {
        RGB9_E5_EXT = ((int)0x8C3D),
        UNSIGNED_INT_5_9_9_9_REV_EXT = ((int)0x8C3E),
        TEXTURE_SHARED_SIZE_EXT = ((int)0x8C3F),
    }

    public enum EXT_texture_snorm : int
    {
        RED_SNORM = ((int)0x8F90),
        RG_SNORM = ((int)0x8F91),
        RGB_SNORM = ((int)0x8F92),
        RGBA_SNORM = ((int)0x8F93),
        R8_SNORM = ((int)0x8F94),
        RG8_SNORM = ((int)0x8F95),
        RGB8_SNORM = ((int)0x8F96),
        RGBA8_SNORM = ((int)0x8F97),
        R16_SNORM = ((int)0x8F98),
        RG16_SNORM = ((int)0x8F99),
        RGB16_SNORM = ((int)0x8F9A),
        RGBA16_SNORM = ((int)0x8F9B),
        SIGNED_NORMALIZED = ((int)0x8F9C),
        ALPHA_SNORM = ((int)0x9010),
        LUMINANCE_SNORM = ((int)0x9011),
        LUMINANCE_ALPHA_SNORM = ((int)0x9012),
        INTENSITY_SNORM = ((int)0x9013),
        ALPHA8_SNORM = ((int)0x9014),
        LUMINANCE8_SNORM = ((int)0x9015),
        LUMINANCE8_ALPHA8_SNORM = ((int)0x9016),
        INTENSITY8_SNORM = ((int)0x9017),
        ALPHA16_SNORM = ((int)0x9018),
        LUMINANCE16_SNORM = ((int)0x9019),
        LUMINANCE16_ALPHA16_SNORM = ((int)0x901A),
        INTENSITY16_SNORM = ((int)0x901B),
    }

    public enum EXT_texture_sRGB : int
    {
        SRGB_EXT = ((int)0x8C40),
        SRGB8_EXT = ((int)0x8C41),
        SRGB_ALPHA_EXT = ((int)0x8C42),
        SRGB8_ALPHA8_EXT = ((int)0x8C43),
        SLUMINANCE_ALPHA_EXT = ((int)0x8C44),
        SLUMINANCE8_ALPHA8_EXT = ((int)0x8C45),
        SLUMINANCE_EXT = ((int)0x8C46),
        SLUMINANCE8_EXT = ((int)0x8C47),
        COMPRESSED_SRGB_EXT = ((int)0x8C48),
        COMPRESSED_SRGB_ALPHA_EXT = ((int)0x8C49),
        COMPRESSED_SLUMINANCE_EXT = ((int)0x8C4A),
        COMPRESSED_SLUMINANCE_ALPHA_EXT = ((int)0x8C4B),
        COMPRESSED_SRGB_S3TC_DXT1_EXT = ((int)0x8C4C),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = ((int)0x8C4D),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = ((int)0x8C4E),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = ((int)0x8C4F),
    }

    public enum EXT_texture_swizzle : int
    {
        TEXTURE_SWIZZLE_R_EXT = ((int)0x8E42),
        TEXTURE_SWIZZLE_G_EXT = ((int)0x8E43),
        TEXTURE_SWIZZLE_B_EXT = ((int)0x8E44),
        TEXTURE_SWIZZLE_A_EXT = ((int)0x8E45),
        TEXTURE_SWIZZLE_RGBA_EXT = ((int)0x8E46),
    }

    public enum EXT_texture3D : int
    {
        PACK_SKIP_IMAGES_EXT = ((int)0x806B),
        PACK_IMAGE_HEIGHT_EXT = ((int)0x806C),
        UNPACK_SKIP_IMAGES_EXT = ((int)0x806D),
        UNPACK_IMAGE_HEIGHT_EXT = ((int)0x806E),
        TEXTURE_3D_EXT = ((int)0x806F),
        PROXY_TEXTURE_3D_EXT = ((int)0x8070),
        TEXTURE_DEPTH_EXT = ((int)0x8071),
        TEXTURE_WRAP_R_EXT = ((int)0x8072),
        MAX_3D_TEXTURE_SIZE_EXT = ((int)0x8073),
    }

    public enum EXT_timer_query : int
    {
        TIME_ELAPSED_EXT = ((int)0x88BF),
    }

    public enum EXT_transform_feedback : int
    {
        TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH_EXT = ((int)0x8C76),
        TRANSFORM_FEEDBACK_BUFFER_MODE_EXT = ((int)0x8C7F),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_EXT = ((int)0x8C80),
        TRANSFORM_FEEDBACK_VARYINGS_EXT = ((int)0x8C83),
        TRANSFORM_FEEDBACK_BUFFER_START_EXT = ((int)0x8C84),
        TRANSFORM_FEEDBACK_BUFFER_SIZE_EXT = ((int)0x8C85),
        PRIMITIVES_GENERATED_EXT = ((int)0x8C87),
        TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_EXT = ((int)0x8C88),
        RASTERIZER_DISCARD_EXT = ((int)0x8C89),
        MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_EXT = ((int)0x8C8A),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_EXT = ((int)0x8C8B),
        INTERLEAVED_ATTRIBS_EXT = ((int)0x8C8C),
        SEPARATE_ATTRIBS_EXT = ((int)0x8C8D),
        TRANSFORM_FEEDBACK_BUFFER_EXT = ((int)0x8C8E),
        TRANSFORM_FEEDBACK_BUFFER_BINDING_EXT = ((int)0x8C8F),
    }

    public enum EXT_vertex_array : int
    {
        VERTEX_ARRAY_EXT = ((int)0x8074),
        NORMAL_ARRAY_EXT = ((int)0x8075),
        COLOR_ARRAY_EXT = ((int)0x8076),
        INDEX_ARRAY_EXT = ((int)0x8077),
        TEXTURE_COORD_ARRAY_EXT = ((int)0x8078),
        EDGE_FLAG_ARRAY_EXT = ((int)0x8079),
        VERTEX_ARRAY_SIZE_EXT = ((int)0x807A),
        VERTEX_ARRAY_TYPE_EXT = ((int)0x807B),
        VERTEX_ARRAY_STRIDE_EXT = ((int)0x807C),
        VERTEX_ARRAY_COUNT_EXT = ((int)0x807D),
        NORMAL_ARRAY_TYPE_EXT = ((int)0x807E),
        NORMAL_ARRAY_STRIDE_EXT = ((int)0x807F),
        NORMAL_ARRAY_COUNT_EXT = ((int)0x8080),
        COLOR_ARRAY_SIZE_EXT = ((int)0x8081),
        COLOR_ARRAY_TYPE_EXT = ((int)0x8082),
        COLOR_ARRAY_STRIDE_EXT = ((int)0x8083),
        COLOR_ARRAY_COUNT_EXT = ((int)0x8084),
        INDEX_ARRAY_TYPE_EXT = ((int)0x8085),
        INDEX_ARRAY_STRIDE_EXT = ((int)0x8086),
        INDEX_ARRAY_COUNT_EXT = ((int)0x8087),
        TEXTURE_COORD_ARRAY_SIZE_EXT = ((int)0x8088),
        TEXTURE_COORD_ARRAY_TYPE_EXT = ((int)0x8089),
        TEXTURE_COORD_ARRAY_STRIDE_EXT = ((int)0x808A),
        TEXTURE_COORD_ARRAY_COUNT_EXT = ((int)0x808B),
        EDGE_FLAG_ARRAY_STRIDE_EXT = ((int)0x808C),
        EDGE_FLAG_ARRAY_COUNT_EXT = ((int)0x808D),
        VERTEX_ARRAY_POINTER_EXT = ((int)0x808E),
        NORMAL_ARRAY_POINTER_EXT = ((int)0x808F),
        COLOR_ARRAY_POINTER_EXT = ((int)0x8090),
        INDEX_ARRAY_POINTER_EXT = ((int)0x8091),
        TEXTURE_COORD_ARRAY_POINTER_EXT = ((int)0x8092),
        EDGE_FLAG_ARRAY_POINTER_EXT = ((int)0x8093),
    }

    public enum EXT_vertex_array_bgra : int
    {
        BGRA = ((int)0x80E1),
    }

    public enum EXT_vertex_shader : int
    {
        VERTEX_SHADER_EXT = ((int)0x8780),
        VERTEX_SHADER_BINDING_EXT = ((int)0x8781),
        OP_INDEX_EXT = ((int)0x8782),
        OP_NEGATE_EXT = ((int)0x8783),
        OP_DOT3_EXT = ((int)0x8784),
        OP_DOT4_EXT = ((int)0x8785),
        OP_MUL_EXT = ((int)0x8786),
        OP_ADD_EXT = ((int)0x8787),
        OP_MADD_EXT = ((int)0x8788),
        OP_FRAC_EXT = ((int)0x8789),
        OP_MAX_EXT = ((int)0x878A),
        OP_MIN_EXT = ((int)0x878B),
        OP_SET_GE_EXT = ((int)0x878C),
        OP_SET_LT_EXT = ((int)0x878D),
        OP_CLAMP_EXT = ((int)0x878E),
        OP_FLOOR_EXT = ((int)0x878F),
        OP_ROUND_EXT = ((int)0x8790),
        OP_EXP_BASE_2_EXT = ((int)0x8791),
        OP_LOG_BASE_2_EXT = ((int)0x8792),
        OP_POWER_EXT = ((int)0x8793),
        OP_RECIP_EXT = ((int)0x8794),
        OP_RECIP_SQRT_EXT = ((int)0x8795),
        OP_SUB_EXT = ((int)0x8796),
        OP_CROSS_PRODUCT_EXT = ((int)0x8797),
        OP_MULTIPLY_MATRIX_EXT = ((int)0x8798),
        OP_MOV_EXT = ((int)0x8799),
        OUTPUT_VERTEX_EXT = ((int)0x879A),
        OUTPUT_COLOR0_EXT = ((int)0x879B),
        OUTPUT_COLOR1_EXT = ((int)0x879C),
        OUTPUT_TEXTURE_COORD0_EXT = ((int)0x879D),
        OUTPUT_TEXTURE_COORD1_EXT = ((int)0x879E),
        OUTPUT_TEXTURE_COORD2_EXT = ((int)0x879F),
        OUTPUT_TEXTURE_COORD3_EXT = ((int)0x87A0),
        OUTPUT_TEXTURE_COORD4_EXT = ((int)0x87A1),
        OUTPUT_TEXTURE_COORD5_EXT = ((int)0x87A2),
        OUTPUT_TEXTURE_COORD6_EXT = ((int)0x87A3),
        OUTPUT_TEXTURE_COORD7_EXT = ((int)0x87A4),
        OUTPUT_TEXTURE_COORD8_EXT = ((int)0x87A5),
        OUTPUT_TEXTURE_COORD9_EXT = ((int)0x87A6),
        OUTPUT_TEXTURE_COORD10_EXT = ((int)0x87A7),
        OUTPUT_TEXTURE_COORD11_EXT = ((int)0x87A8),
        OUTPUT_TEXTURE_COORD12_EXT = ((int)0x87A9),
        OUTPUT_TEXTURE_COORD13_EXT = ((int)0x87AA),
        OUTPUT_TEXTURE_COORD14_EXT = ((int)0x87AB),
        OUTPUT_TEXTURE_COORD15_EXT = ((int)0x87AC),
        OUTPUT_TEXTURE_COORD16_EXT = ((int)0x87AD),
        OUTPUT_TEXTURE_COORD17_EXT = ((int)0x87AE),
        OUTPUT_TEXTURE_COORD18_EXT = ((int)0x87AF),
        OUTPUT_TEXTURE_COORD19_EXT = ((int)0x87B0),
        OUTPUT_TEXTURE_COORD20_EXT = ((int)0x87B1),
        OUTPUT_TEXTURE_COORD21_EXT = ((int)0x87B2),
        OUTPUT_TEXTURE_COORD22_EXT = ((int)0x87B3),
        OUTPUT_TEXTURE_COORD23_EXT = ((int)0x87B4),
        OUTPUT_TEXTURE_COORD24_EXT = ((int)0x87B5),
        OUTPUT_TEXTURE_COORD25_EXT = ((int)0x87B6),
        OUTPUT_TEXTURE_COORD26_EXT = ((int)0x87B7),
        OUTPUT_TEXTURE_COORD27_EXT = ((int)0x87B8),
        OUTPUT_TEXTURE_COORD28_EXT = ((int)0x87B9),
        OUTPUT_TEXTURE_COORD29_EXT = ((int)0x87BA),
        OUTPUT_TEXTURE_COORD30_EXT = ((int)0x87BB),
        OUTPUT_TEXTURE_COORD31_EXT = ((int)0x87BC),
        OUTPUT_FOG_EXT = ((int)0x87BD),
        SCALAR_EXT = ((int)0x87BE),
        VECTOR_EXT = ((int)0x87BF),
        MATRIX_EXT = ((int)0x87C0),
        VARIANT_EXT = ((int)0x87C1),
        INVARIANT_EXT = ((int)0x87C2),
        LOCAL_CONSTANT_EXT = ((int)0x87C3),
        LOCAL_EXT = ((int)0x87C4),
        MAX_VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87C5),
        MAX_VERTEX_SHADER_VARIANTS_EXT = ((int)0x87C6),
        MAX_VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87C7),
        MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87C8),
        MAX_VERTEX_SHADER_LOCALS_EXT = ((int)0x87C9),
        MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87CA),
        MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT = ((int)0x87CB),
        MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87CC),
        MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87CD),
        MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT = ((int)0x87CE),
        VERTEX_SHADER_INSTRUCTIONS_EXT = ((int)0x87CF),
        VERTEX_SHADER_VARIANTS_EXT = ((int)0x87D0),
        VERTEX_SHADER_INVARIANTS_EXT = ((int)0x87D1),
        VERTEX_SHADER_LOCAL_CONSTANTS_EXT = ((int)0x87D2),
        VERTEX_SHADER_LOCALS_EXT = ((int)0x87D3),
        VERTEX_SHADER_OPTIMIZED_EXT = ((int)0x87D4),
        X_EXT = ((int)0x87D5),
        Y_EXT = ((int)0x87D6),
        Z_EXT = ((int)0x87D7),
        W_EXT = ((int)0x87D8),
        NEGATIVE_X_EXT = ((int)0x87D9),
        NEGATIVE_Y_EXT = ((int)0x87DA),
        NEGATIVE_Z_EXT = ((int)0x87DB),
        NEGATIVE_W_EXT = ((int)0x87DC),
        ZERO_EXT = ((int)0x87DD),
        ONE_EXT = ((int)0x87DE),
        NEGATIVE_ONE_EXT = ((int)0x87DF),
        NORMALIZED_RANGE_EXT = ((int)0x87E0),
        FULL_RANGE_EXT = ((int)0x87E1),
        CURRENT_VERTEX_EXT = ((int)0x87E2),
        MVP_MATRIX_EXT = ((int)0x87E3),
        VARIANT_VALUE_EXT = ((int)0x87E4),
        VARIANT_DATATYPE_EXT = ((int)0x87E5),
        VARIANT_ARRAY_STRIDE_EXT = ((int)0x87E6),
        VARIANT_ARRAY_TYPE_EXT = ((int)0x87E7),
        VARIANT_ARRAY_EXT = ((int)0x87E8),
        VARIANT_ARRAY_POINTER_EXT = ((int)0x87E9),
        INVARIANT_VALUE_EXT = ((int)0x87EA),
        INVARIANT_DATATYPE_EXT = ((int)0x87EB),
        LOCAL_CONSTANT_VALUE_EXT = ((int)0x87EC),
        LOCAL_CONSTANT_DATATYPE_EXT = ((int)0x87ED),
    }

    public enum EXT_vertex_weighting : int
    {
        MODELVIEW0_STACK_DEPTH_EXT = ((int)0x0BA3),
        MODELVIEW0_MATRIX_EXT = ((int)0x0BA6),
        MODELVIEW0_EXT = ((int)0x1700),
        MODELVIEW1_STACK_DEPTH_EXT = ((int)0x8502),
        MODELVIEW1_MATRIX_EXT = ((int)0x8506),
        VERTEX_WEIGHTING_EXT = ((int)0x8509),
        MODELVIEW1_EXT = ((int)0x850A),
        CURRENT_VERTEX_WEIGHT_EXT = ((int)0x850B),
        VERTEX_WEIGHT_ARRAY_EXT = ((int)0x850C),
        VERTEX_WEIGHT_ARRAY_SIZE_EXT = ((int)0x850D),
        VERTEX_WEIGHT_ARRAY_TYPE_EXT = ((int)0x850E),
        VERTEX_WEIGHT_ARRAY_STRIDE_EXT = ((int)0x850F),
        VERTEX_WEIGHT_ARRAY_POINTER_EXT = ((int)0x8510),
    }

    public enum FeedBackToken : int
    {
        PASS_THROUGH_TOKEN = ((int)0x0700),
        POINT_TOKEN = ((int)0x0701),
        LINE_TOKEN = ((int)0x0702),
        POLYGON_TOKEN = ((int)0x0703),
        BITMAP_TOKEN = ((int)0x0704),
        DRAW_PIXEL_TOKEN = ((int)0x0705),
        COPY_PIXEL_TOKEN = ((int)0x0706),
        LINE_RESET_TOKEN = ((int)0x0707),
    }

    public enum FeedbackType : int
    {
        GL_2D = ((int)0x0600),
        GL_3D = ((int)0x0601),
        GL_3D_COLOR = ((int)0x0602),
        GL_3D_COLOR_TEXTURE = ((int)0x0603),
        GL_4D_COLOR_TEXTURE = ((int)0x0604),
    }

    public enum FogMode : int
    {
        EXP = ((int)0x0800),
        EXP2 = ((int)0x0801),
        LINEAR = ((int)0x2601),
        FOG_COORD = ((int)0x8451),
        FRAGMENT_DEPTH = ((int)0x8452),
    }

    public enum FogParameter : int
    {
        FOG_INDEX = ((int)0x0B61),
        FOG_DENSITY = ((int)0x0B62),
        FOG_START = ((int)0x0B63),
        FOG_END = ((int)0x0B64),
        FOG_MODE = ((int)0x0B65),
        FOG_COLOR = ((int)0x0B66),
        FOG_COORD_SRC = ((int)0x8450),
    }

    public enum FogPointerType : int
    {
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

    public enum FramebufferAttachment : int
    {
        DEPTH_STENCIL_ATTACHMENT = ((int)0x821A),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT0_EXT = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT1_EXT = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT2_EXT = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT3_EXT = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT4_EXT = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT5_EXT = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT6_EXT = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT7_EXT = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT8_EXT = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT9_EXT = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT10_EXT = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT11_EXT = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT12_EXT = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT13_EXT = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT14_EXT = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
        COLOR_ATTACHMENT15_EXT = ((int)0x8CEF),
        DEPTH_ATTACHMENT = ((int)0x8D00),
        DEPTH_ATTACHMENT_EXT = ((int)0x8D00),
        STENCIL_ATTACHMENT = ((int)0x8D20),
        STENCIL_ATTACHMENT_EXT = ((int)0x8D20),
    }

    public enum FramebufferAttachmentComponentType : int
    {
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        INDEX = ((int)0x8222),
        UNSIGNED_NORMALIZED = ((int)0x8C17),
    }

    public enum FramebufferAttachmentObjectType : int
    {
        NONE = ((int)0),
        TEXTURE = ((int)0x1702),
        FRAMEBUFFER_DEFAULT = ((int)0x8218),
        RENDERBUFFER = ((int)0x8D41),
    }

    public enum FramebufferErrorCode : int
    {
        FRAMEBUFFER_UNDEFINED = ((int)0x8219),
        FRAMEBUFFER_COMPLETE = ((int)0x8CD5),
        FRAMEBUFFER_COMPLETE_EXT = ((int)0x8CD5),
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT = ((int)0x8CD6),
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = ((int)0x8CD6),
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = ((int)0x8CD7),
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = ((int)0x8CD7),
        FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = ((int)0x8CD9),
        FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = ((int)0x8CDA),
        FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = ((int)0x8CDB),
        FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = ((int)0x8CDB),
        FRAMEBUFFER_INCOMPLETE_READ_BUFFER = ((int)0x8CDC),
        FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = ((int)0x8CDC),
        FRAMEBUFFER_UNSUPPORTED = ((int)0x8CDD),
        FRAMEBUFFER_UNSUPPORTED_EXT = ((int)0x8CDD),
        FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = ((int)0x8D56),
        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = ((int)0x8DA8),
        FRAMEBUFFER_INCOMPLETE_LAYER_COUNT = ((int)0x8DA9),
    }

    public enum FramebufferParameterName : int
    {
        FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = ((int)0x8210),
        FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = ((int)0x8211),
        FRAMEBUFFER_ATTACHMENT_RED_SIZE = ((int)0x8212),
        FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = ((int)0x8213),
        FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = ((int)0x8214),
        FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = ((int)0x8215),
        FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = ((int)0x8216),
        FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = ((int)0x8217),
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = ((int)0x8CD0),
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = ((int)0x8CD0),
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = ((int)0x8CD1),
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = ((int)0x8CD1),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = ((int)0x8CD2),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = ((int)0x8CD2),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = ((int)0x8CD3),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = ((int)0x8CD3),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_LAYERED = ((int)0x8DA7),
    }

    public enum FramebufferTarget : int
    {
        READ_FRAMEBUFFER = ((int)0x8CA8),
        DRAW_FRAMEBUFFER = ((int)0x8CA9),
        FRAMEBUFFER = ((int)0x8D40),
        FRAMEBUFFER_EXT = ((int)0x8D40),
    }

    public enum FrontFaceDirection : int
    {
        CW = ((int)0x0900),
        CCW = ((int)0x0901),
    }

    public enum GenerateMipmapTarget : int
    {
        TEXTURE_1D = ((int)0x0DE0),
        TEXTURE_2D = ((int)0x0DE1),
        TEXTURE_3D = ((int)0x806F),
        TEXTURE_CUBE_MAP = ((int)0x8513),
        TEXTURE_1D_ARRAY = ((int)0x8C18),
        TEXTURE_2D_ARRAY = ((int)0x8C1A),
        TEXTURE_2D_MULTISAMPLE = ((int)0x9100),
        TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102),
    }

    public enum GetColorTableParameterPName : int
    {
        COLOR_TABLE_SCALE = ((int)0x80D6),
        COLOR_TABLE_BIAS = ((int)0x80D7),
        COLOR_TABLE_FORMAT = ((int)0x80D8),
        COLOR_TABLE_WIDTH = ((int)0x80D9),
        COLOR_TABLE_RED_SIZE = ((int)0x80DA),
        COLOR_TABLE_GREEN_SIZE = ((int)0x80DB),
        COLOR_TABLE_BLUE_SIZE = ((int)0x80DC),
        COLOR_TABLE_ALPHA_SIZE = ((int)0x80DD),
        COLOR_TABLE_LUMINANCE_SIZE = ((int)0x80DE),
        COLOR_TABLE_INTENSITY_SIZE = ((int)0x80DF),
    }

    public enum GetColorTableParameterPNameSGI : int
    {
        COLOR_TABLE_SCALE_SGI = ((int)0x80D6),
        COLOR_TABLE_BIAS_SGI = ((int)0x80D7),
        COLOR_TABLE_FORMAT_SGI = ((int)0x80D8),
        COLOR_TABLE_WIDTH_SGI = ((int)0x80D9),
        COLOR_TABLE_RED_SIZE_SGI = ((int)0x80DA),
        COLOR_TABLE_GREEN_SIZE_SGI = ((int)0x80DB),
        COLOR_TABLE_BLUE_SIZE_SGI = ((int)0x80DC),
        COLOR_TABLE_ALPHA_SIZE_SGI = ((int)0x80DD),
        COLOR_TABLE_LUMINANCE_SIZE_SGI = ((int)0x80DE),
        COLOR_TABLE_INTENSITY_SIZE_SGI = ((int)0x80DF),
    }

    public enum GetConvolutionParameter : int
    {
        CONVOLUTION_BORDER_MODE_EXT = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE_EXT = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS_EXT = ((int)0x8015),
        CONVOLUTION_FORMAT_EXT = ((int)0x8017),
        CONVOLUTION_WIDTH_EXT = ((int)0x8018),
        CONVOLUTION_HEIGHT_EXT = ((int)0x8019),
        MAX_CONVOLUTION_WIDTH_EXT = ((int)0x801A),
        MAX_CONVOLUTION_HEIGHT_EXT = ((int)0x801B),
    }

    public enum GetConvolutionParameterPName : int
    {
        CONVOLUTION_BORDER_MODE = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS = ((int)0x8015),
        CONVOLUTION_FORMAT = ((int)0x8017),
        CONVOLUTION_WIDTH = ((int)0x8018),
        CONVOLUTION_HEIGHT = ((int)0x8019),
        MAX_CONVOLUTION_WIDTH = ((int)0x801A),
        MAX_CONVOLUTION_HEIGHT = ((int)0x801B),
        CONVOLUTION_BORDER_COLOR = ((int)0x8154),
    }

    public enum GetHistogramParameterPName : int
    {
        HISTOGRAM_WIDTH = ((int)0x8026),
        HISTOGRAM_FORMAT = ((int)0x8027),
        HISTOGRAM_RED_SIZE = ((int)0x8028),
        HISTOGRAM_GREEN_SIZE = ((int)0x8029),
        HISTOGRAM_BLUE_SIZE = ((int)0x802A),
        HISTOGRAM_ALPHA_SIZE = ((int)0x802B),
        HISTOGRAM_LUMINANCE_SIZE = ((int)0x802C),
        HISTOGRAM_SINK = ((int)0x802D),
    }

    public enum GetHistogramParameterPNameEXT : int
    {
        HISTOGRAM_WIDTH_EXT = ((int)0x8026),
        HISTOGRAM_FORMAT_EXT = ((int)0x8027),
        HISTOGRAM_RED_SIZE_EXT = ((int)0x8028),
        HISTOGRAM_GREEN_SIZE_EXT = ((int)0x8029),
        HISTOGRAM_BLUE_SIZE_EXT = ((int)0x802A),
        HISTOGRAM_ALPHA_SIZE_EXT = ((int)0x802B),
        HISTOGRAM_LUMINANCE_SIZE_EXT = ((int)0x802C),
        HISTOGRAM_SINK_EXT = ((int)0x802D),
    }

    public enum GetIndexedPName : int
    {
        UNIFORM_BUFFER_BINDING = ((int)0x8A28),
        UNIFORM_BUFFER_START = ((int)0x8A29),
        UNIFORM_BUFFER_SIZE = ((int)0x8A2A),
        TRANSFORM_FEEDBACK_BUFFER_START = ((int)0x8C84),
        TRANSFORM_FEEDBACK_BUFFER_SIZE = ((int)0x8C85),
        TRANSFORM_FEEDBACK_BUFFER_BINDING = ((int)0x8C8F),
        SAMPLE_MASK_VALUE = ((int)0x8E52),
    }

    public enum GetMapQuery : int
    {
        COEFF = ((int)0x0A00),
        ORDER = ((int)0x0A01),
        DOMAIN = ((int)0x0A02),
    }

    public enum GetMinmaxParameterPName : int
    {
        MINMAX_FORMAT = ((int)0x802F),
        MINMAX_SINK = ((int)0x8030),
    }

    public enum GetMinmaxParameterPNameEXT : int
    {
        MINMAX_FORMAT_EXT = ((int)0x802F),
        MINMAX_SINK_EXT = ((int)0x8030),
    }

    public enum GetMultisamplePName : int
    {
        SAMPLE_POSITION = ((int)0x8E50),
    }

    public enum GetPixelMap : int
    {
        PIXEL_MAP_I_TO_I = ((int)0x0C70),
        PIXEL_MAP_S_TO_S = ((int)0x0C71),
        PIXEL_MAP_I_TO_R = ((int)0x0C72),
        PIXEL_MAP_I_TO_G = ((int)0x0C73),
        PIXEL_MAP_I_TO_B = ((int)0x0C74),
        PIXEL_MAP_I_TO_A = ((int)0x0C75),
        PIXEL_MAP_R_TO_R = ((int)0x0C76),
        PIXEL_MAP_G_TO_G = ((int)0x0C77),
        PIXEL_MAP_B_TO_B = ((int)0x0C78),
        PIXEL_MAP_A_TO_A = ((int)0x0C79),
    }

    public enum GetPName : int
    {
        CURRENT_COLOR = ((int)0x0B00),
        CURRENT_INDEX = ((int)0x0B01),
        CURRENT_NORMAL = ((int)0x0B02),
        CURRENT_TEXTURE_COORDS = ((int)0x0B03),
        CURRENT_RASTER_COLOR = ((int)0x0B04),
        CURRENT_RASTER_INDEX = ((int)0x0B05),
        CURRENT_RASTER_TEXTURE_COORDS = ((int)0x0B06),
        CURRENT_RASTER_POSITION = ((int)0x0B07),
        CURRENT_RASTER_POSITION_VALID = ((int)0x0B08),
        CURRENT_RASTER_DISTANCE = ((int)0x0B09),
        POINT_SMOOTH = ((int)0x0B10),
        POINT_SIZE = ((int)0x0B11),
        POINT_SIZE_RANGE = ((int)0x0B12),
        SMOOTH_POINT_SIZE_RANGE = ((int)0x0B12),
        POINT_SIZE_GRANULARITY = ((int)0x0B13),
        SMOOTH_POINT_SIZE_GRANULARITY = ((int)0x0B13),
        LINE_SMOOTH = ((int)0x0B20),
        LINE_WIDTH = ((int)0x0B21),
        LINE_WIDTH_RANGE = ((int)0x0B22),
        SMOOTH_LINE_WIDTH_RANGE = ((int)0x0B22),
        LINE_WIDTH_GRANULARITY = ((int)0x0B23),
        SMOOTH_LINE_WIDTH_GRANULARITY = ((int)0x0B23),
        LINE_STIPPLE = ((int)0x0B24),
        LINE_STIPPLE_PATTERN = ((int)0x0B25),
        LINE_STIPPLE_REPEAT = ((int)0x0B26),
        LIST_MODE = ((int)0x0B30),
        MAX_LIST_NESTING = ((int)0x0B31),
        LIST_BASE = ((int)0x0B32),
        LIST_INDEX = ((int)0x0B33),
        POLYGON_MODE = ((int)0x0B40),
        POLYGON_SMOOTH = ((int)0x0B41),
        POLYGON_STIPPLE = ((int)0x0B42),
        EDGE_FLAG = ((int)0x0B43),
        CULL_FACE = ((int)0x0B44),
        CULL_FACE_MODE = ((int)0x0B45),
        FRONT_FACE = ((int)0x0B46),
        LIGHTING = ((int)0x0B50),
        LIGHT_MODEL_LOCAL_VIEWER = ((int)0x0B51),
        LIGHT_MODEL_TWO_SIDE = ((int)0x0B52),
        LIGHT_MODEL_AMBIENT = ((int)0x0B53),
        SHADE_MODEL = ((int)0x0B54),
        COLOR_MATERIAL_FACE = ((int)0x0B55),
        COLOR_MATERIAL_PARAMETER = ((int)0x0B56),
        COLOR_MATERIAL = ((int)0x0B57),
        FOG = ((int)0x0B60),
        FOG_INDEX = ((int)0x0B61),
        FOG_DENSITY = ((int)0x0B62),
        FOG_START = ((int)0x0B63),
        FOG_END = ((int)0x0B64),
        FOG_MODE = ((int)0x0B65),
        FOG_COLOR = ((int)0x0B66),
        DEPTH_RANGE = ((int)0x0B70),
        DEPTH_TEST = ((int)0x0B71),
        DEPTH_WRITEMASK = ((int)0x0B72),
        DEPTH_CLEAR_VALUE = ((int)0x0B73),
        DEPTH_FUNC = ((int)0x0B74),
        ACCUM_CLEAR_VALUE = ((int)0x0B80),
        STENCIL_TEST = ((int)0x0B90),
        STENCIL_CLEAR_VALUE = ((int)0x0B91),
        STENCIL_FUNC = ((int)0x0B92),
        STENCIL_VALUE_MASK = ((int)0x0B93),
        STENCIL_FAIL = ((int)0x0B94),
        STENCIL_PASS_DEPTH_FAIL = ((int)0x0B95),
        STENCIL_PASS_DEPTH_PASS = ((int)0x0B96),
        STENCIL_REF = ((int)0x0B97),
        STENCIL_WRITEMASK = ((int)0x0B98),
        MATRIX_MODE = ((int)0x0BA0),
        NORMALIZE = ((int)0x0BA1),
        VIEWPORT = ((int)0x0BA2),
        MODELVIEW_STACK_DEPTH = ((int)0x0BA3),
        PROJECTION_STACK_DEPTH = ((int)0x0BA4),
        TEXTURE_STACK_DEPTH = ((int)0x0BA5),
        MODELVIEW_MATRIX = ((int)0x0BA6),
        PROJECTION_MATRIX = ((int)0x0BA7),
        TEXTURE_MATRIX = ((int)0x0BA8),
        ATTRIB_STACK_DEPTH = ((int)0x0BB0),
        CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0BB1),
        ALPHA_TEST = ((int)0x0BC0),
        ALPHA_TEST_FUNC = ((int)0x0BC1),
        ALPHA_TEST_REF = ((int)0x0BC2),
        DITHER = ((int)0x0BD0),
        BLEND_DST = ((int)0x0BE0),
        BLEND_SRC = ((int)0x0BE1),
        BLEND = ((int)0x0BE2),
        LOGIC_OP_MODE = ((int)0x0BF0),
        INDEX_LOGIC_OP = ((int)0x0BF1),
        LOGIC_OP = ((int)0x0BF1),
        COLOR_LOGIC_OP = ((int)0x0BF2),
        AUX_BUFFERS = ((int)0x0C00),
        DRAW_BUFFER = ((int)0x0C01),
        READ_BUFFER = ((int)0x0C02),
        SCISSOR_BOX = ((int)0x0C10),
        SCISSOR_TEST = ((int)0x0C11),
        INDEX_CLEAR_VALUE = ((int)0x0C20),
        INDEX_WRITEMASK = ((int)0x0C21),
        COLOR_CLEAR_VALUE = ((int)0x0C22),
        COLOR_WRITEMASK = ((int)0x0C23),
        INDEX_MODE = ((int)0x0C30),
        RGBA_MODE = ((int)0x0C31),
        DOUBLEBUFFER = ((int)0x0C32),
        STEREO = ((int)0x0C33),
        RENDER_MODE = ((int)0x0C40),
        PERSPECTIVE_CORRECTION_HINT = ((int)0x0C50),
        POINT_SMOOTH_HINT = ((int)0x0C51),
        LINE_SMOOTH_HINT = ((int)0x0C52),
        POLYGON_SMOOTH_HINT = ((int)0x0C53),
        FOG_HINT = ((int)0x0C54),
        TEXTURE_GEN_S = ((int)0x0C60),
        TEXTURE_GEN_T = ((int)0x0C61),
        TEXTURE_GEN_R = ((int)0x0C62),
        TEXTURE_GEN_Q = ((int)0x0C63),
        PIXEL_MAP_I_TO_I_SIZE = ((int)0x0CB0),
        PIXEL_MAP_S_TO_S_SIZE = ((int)0x0CB1),
        PIXEL_MAP_I_TO_R_SIZE = ((int)0x0CB2),
        PIXEL_MAP_I_TO_G_SIZE = ((int)0x0CB3),
        PIXEL_MAP_I_TO_B_SIZE = ((int)0x0CB4),
        PIXEL_MAP_I_TO_A_SIZE = ((int)0x0CB5),
        PIXEL_MAP_R_TO_R_SIZE = ((int)0x0CB6),
        PIXEL_MAP_G_TO_G_SIZE = ((int)0x0CB7),
        PIXEL_MAP_B_TO_B_SIZE = ((int)0x0CB8),
        PIXEL_MAP_A_TO_A_SIZE = ((int)0x0CB9),
        UNPACK_SWAP_BYTES = ((int)0x0CF0),
        UNPACK_LSB_FIRST = ((int)0x0CF1),
        UNPACK_ROW_LENGTH = ((int)0x0CF2),
        UNPACK_SKIP_ROWS = ((int)0x0CF3),
        UNPACK_SKIP_PIXELS = ((int)0x0CF4),
        UNPACK_ALIGNMENT = ((int)0x0CF5),
        PACK_SWAP_BYTES = ((int)0x0D00),
        PACK_LSB_FIRST = ((int)0x0D01),
        PACK_ROW_LENGTH = ((int)0x0D02),
        PACK_SKIP_ROWS = ((int)0x0D03),
        PACK_SKIP_PIXELS = ((int)0x0D04),
        PACK_ALIGNMENT = ((int)0x0D05),
        MAP_COLOR = ((int)0x0D10),
        MAP_STENCIL = ((int)0x0D11),
        INDEX_SHIFT = ((int)0x0D12),
        INDEX_OFFSET = ((int)0x0D13),
        RED_SCALE = ((int)0x0D14),
        RED_BIAS = ((int)0x0D15),
        ZOOM_X = ((int)0x0D16),
        ZOOM_Y = ((int)0x0D17),
        GREEN_SCALE = ((int)0x0D18),
        GREEN_BIAS = ((int)0x0D19),
        BLUE_SCALE = ((int)0x0D1A),
        BLUE_BIAS = ((int)0x0D1B),
        ALPHA_SCALE = ((int)0x0D1C),
        ALPHA_BIAS = ((int)0x0D1D),
        DEPTH_SCALE = ((int)0x0D1E),
        DEPTH_BIAS = ((int)0x0D1F),
        MAX_EVAL_ORDER = ((int)0x0D30),
        MAX_LIGHTS = ((int)0x0D31),
        MAX_CLIP_PLANES = ((int)0x0D32),
        MAX_TEXTURE_SIZE = ((int)0x0D33),
        MAX_PIXEL_MAP_TABLE = ((int)0x0D34),
        MAX_ATTRIB_STACK_DEPTH = ((int)0x0D35),
        MAX_MODELVIEW_STACK_DEPTH = ((int)0x0D36),
        MAX_NAME_STACK_DEPTH = ((int)0x0D37),
        MAX_PROJECTION_STACK_DEPTH = ((int)0x0D38),
        MAX_TEXTURE_STACK_DEPTH = ((int)0x0D39),
        MAX_VIEWPORT_DIMS = ((int)0x0D3A),
        MAX_CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0D3B),
        SUBPIXEL_BITS = ((int)0x0D50),
        INDEX_BITS = ((int)0x0D51),
        RED_BITS = ((int)0x0D52),
        GREEN_BITS = ((int)0x0D53),
        BLUE_BITS = ((int)0x0D54),
        ALPHA_BITS = ((int)0x0D55),
        DEPTH_BITS = ((int)0x0D56),
        STENCIL_BITS = ((int)0x0D57),
        ACCUM_RED_BITS = ((int)0x0D58),
        ACCUM_GREEN_BITS = ((int)0x0D59),
        ACCUM_BLUE_BITS = ((int)0x0D5A),
        ACCUM_ALPHA_BITS = ((int)0x0D5B),
        NAME_STACK_DEPTH = ((int)0x0D70),
        AUTO_NORMAL = ((int)0x0D80),
        MAP1_COLOR_4 = ((int)0x0D90),
        MAP1_INDEX = ((int)0x0D91),
        MAP1_NORMAL = ((int)0x0D92),
        MAP1_TEXTURE_COORD_1 = ((int)0x0D93),
        MAP1_TEXTURE_COORD_2 = ((int)0x0D94),
        MAP1_TEXTURE_COORD_3 = ((int)0x0D95),
        MAP1_TEXTURE_COORD_4 = ((int)0x0D96),
        MAP1_VERTEX_3 = ((int)0x0D97),
        MAP1_VERTEX_4 = ((int)0x0D98),
        MAP2_COLOR_4 = ((int)0x0DB0),
        MAP2_INDEX = ((int)0x0DB1),
        MAP2_NORMAL = ((int)0x0DB2),
        MAP2_TEXTURE_COORD_1 = ((int)0x0DB3),
        MAP2_TEXTURE_COORD_2 = ((int)0x0DB4),
        MAP2_TEXTURE_COORD_3 = ((int)0x0DB5),
        MAP2_TEXTURE_COORD_4 = ((int)0x0DB6),
        MAP2_VERTEX_3 = ((int)0x0DB7),
        MAP2_VERTEX_4 = ((int)0x0DB8),
        MAP1_GRID_DOMAIN = ((int)0x0DD0),
        MAP1_GRID_SEGMENTS = ((int)0x0DD1),
        MAP2_GRID_DOMAIN = ((int)0x0DD2),
        MAP2_GRID_SEGMENTS = ((int)0x0DD3),
        TEXTURE_1D = ((int)0x0DE0),
        TEXTURE_2D = ((int)0x0DE1),
        FEEDBACK_BUFFER_SIZE = ((int)0x0DF1),
        FEEDBACK_BUFFER_TYPE = ((int)0x0DF2),
        SELECTION_BUFFER_SIZE = ((int)0x0DF4),
        POLYGON_OFFSET_UNITS = ((int)0x2A00),
        POLYGON_OFFSET_POINT = ((int)0x2A01),
        POLYGON_OFFSET_LINE = ((int)0x2A02),
        CLIP_PLANE0 = ((int)0x3000),
        CLIP_PLANE1 = ((int)0x3001),
        CLIP_PLANE2 = ((int)0x3002),
        CLIP_PLANE3 = ((int)0x3003),
        CLIP_PLANE4 = ((int)0x3004),
        CLIP_PLANE5 = ((int)0x3005),
        LIGHT0 = ((int)0x4000),
        LIGHT1 = ((int)0x4001),
        LIGHT2 = ((int)0x4002),
        LIGHT3 = ((int)0x4003),
        LIGHT4 = ((int)0x4004),
        LIGHT5 = ((int)0x4005),
        LIGHT6 = ((int)0x4006),
        LIGHT7 = ((int)0x4007),
        BLEND_COLOR_EXT = ((int)0x8005),
        BLEND_EQUATION_EXT = ((int)0x8009),
        BLEND_EQUATION_RGB = ((int)0x8009),
        PACK_CMYK_HINT_EXT = ((int)0x800E),
        UNPACK_CMYK_HINT_EXT = ((int)0x800F),
        CONVOLUTION_1D_EXT = ((int)0x8010),
        CONVOLUTION_2D_EXT = ((int)0x8011),
        SEPARABLE_2D_EXT = ((int)0x8012),
        POST_CONVOLUTION_RED_SCALE_EXT = ((int)0x801C),
        POST_CONVOLUTION_GREEN_SCALE_EXT = ((int)0x801D),
        POST_CONVOLUTION_BLUE_SCALE_EXT = ((int)0x801E),
        POST_CONVOLUTION_ALPHA_SCALE_EXT = ((int)0x801F),
        POST_CONVOLUTION_RED_BIAS_EXT = ((int)0x8020),
        POST_CONVOLUTION_GREEN_BIAS_EXT = ((int)0x8021),
        POST_CONVOLUTION_BLUE_BIAS_EXT = ((int)0x8022),
        POST_CONVOLUTION_ALPHA_BIAS_EXT = ((int)0x8023),
        HISTOGRAM_EXT = ((int)0x8024),
        MINMAX_EXT = ((int)0x802E),
        POLYGON_OFFSET_FILL = ((int)0x8037),
        POLYGON_OFFSET_FACTOR = ((int)0x8038),
        POLYGON_OFFSET_BIAS_EXT = ((int)0x8039),
        RESCALE_NORMAL_EXT = ((int)0x803A),
        TEXTURE_BINDING_1D = ((int)0x8068),
        TEXTURE_BINDING_2D = ((int)0x8069),
        TEXTURE_3D_BINDING_EXT = ((int)0x806A),
        TEXTURE_BINDING_3D = ((int)0x806A),
        PACK_SKIP_IMAGES_EXT = ((int)0x806B),
        PACK_IMAGE_HEIGHT_EXT = ((int)0x806C),
        UNPACK_SKIP_IMAGES_EXT = ((int)0x806D),
        UNPACK_IMAGE_HEIGHT_EXT = ((int)0x806E),
        TEXTURE_3D_EXT = ((int)0x806F),
        MAX_3D_TEXTURE_SIZE = ((int)0x8073),
        MAX_3D_TEXTURE_SIZE_EXT = ((int)0x8073),
        VERTEX_ARRAY = ((int)0x8074),
        NORMAL_ARRAY = ((int)0x8075),
        COLOR_ARRAY = ((int)0x8076),
        INDEX_ARRAY = ((int)0x8077),
        TEXTURE_COORD_ARRAY = ((int)0x8078),
        EDGE_FLAG_ARRAY = ((int)0x8079),
        VERTEX_ARRAY_SIZE = ((int)0x807A),
        VERTEX_ARRAY_TYPE = ((int)0x807B),
        VERTEX_ARRAY_STRIDE = ((int)0x807C),
        VERTEX_ARRAY_COUNT_EXT = ((int)0x807D),
        NORMAL_ARRAY_TYPE = ((int)0x807E),
        NORMAL_ARRAY_STRIDE = ((int)0x807F),
        NORMAL_ARRAY_COUNT_EXT = ((int)0x8080),
        COLOR_ARRAY_SIZE = ((int)0x8081),
        COLOR_ARRAY_TYPE = ((int)0x8082),
        COLOR_ARRAY_STRIDE = ((int)0x8083),
        COLOR_ARRAY_COUNT_EXT = ((int)0x8084),
        INDEX_ARRAY_TYPE = ((int)0x8085),
        INDEX_ARRAY_STRIDE = ((int)0x8086),
        INDEX_ARRAY_COUNT_EXT = ((int)0x8087),
        TEXTURE_COORD_ARRAY_SIZE = ((int)0x8088),
        TEXTURE_COORD_ARRAY_TYPE = ((int)0x8089),
        TEXTURE_COORD_ARRAY_STRIDE = ((int)0x808A),
        TEXTURE_COORD_ARRAY_COUNT_EXT = ((int)0x808B),
        EDGE_FLAG_ARRAY_STRIDE = ((int)0x808C),
        EDGE_FLAG_ARRAY_COUNT_EXT = ((int)0x808D),
        MULTISAMPLE = ((int)0x809D),
        SAMPLE_ALPHA_TO_COVERAGE = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE = ((int)0x809F),
        SAMPLE_COVERAGE = ((int)0x80A0),
        SAMPLE_BUFFERS = ((int)0x80A8),
        SAMPLES = ((int)0x80A9),
        SAMPLE_COVERAGE_VALUE = ((int)0x80AA),
        SAMPLE_COVERAGE_INVERT = ((int)0x80AB),
        BLEND_DST_RGB = ((int)0x80C8),
        BLEND_SRC_RGB = ((int)0x80C9),
        BLEND_DST_ALPHA = ((int)0x80CA),
        BLEND_SRC_ALPHA = ((int)0x80CB),
        MAX_ELEMENTS_VERTICES = ((int)0x80E8),
        MAX_ELEMENTS_INDICES = ((int)0x80E9),
        POINT_SIZE_MIN = ((int)0x8126),
        POINT_SIZE_MAX = ((int)0x8127),
        POINT_FADE_THRESHOLD_SIZE = ((int)0x8128),
        POINT_DISTANCE_ATTENUATION = ((int)0x8129),
        GENERATE_MIPMAP_HINT = ((int)0x8192),
        LIGHT_MODEL_COLOR_CONTROL = ((int)0x81F8),
        SHARED_TEXTURE_PALETTE_EXT = ((int)0x81FB),
        MAJOR_VERSION = ((int)0x821B),
        MINOR_VERSION = ((int)0x821C),
        NUM_EXTENSIONS = ((int)0x821D),
        CONTEXT_FLAGS = ((int)0x821E),
        CURRENT_FOG_COORD = ((int)0x8453),
        FOG_COORD_ARRAY_TYPE = ((int)0x8454),
        FOG_COORD_ARRAY_STRIDE = ((int)0x8455),
        COLOR_SUM = ((int)0x8458),
        CURRENT_SECONDARY_COLOR = ((int)0x8459),
        SECONDARY_COLOR_ARRAY_SIZE = ((int)0x845A),
        SECONDARY_COLOR_ARRAY_TYPE = ((int)0x845B),
        SECONDARY_COLOR_ARRAY_STRIDE = ((int)0x845C),
        CURRENT_RASTER_SECONDARY_COLOR = ((int)0x845F),
        ALIASED_POINT_SIZE_RANGE = ((int)0x846D),
        ALIASED_LINE_WIDTH_RANGE = ((int)0x846E),
        ACTIVE_TEXTURE = ((int)0x84E0),
        CLIENT_ACTIVE_TEXTURE = ((int)0x84E1),
        MAX_TEXTURE_UNITS = ((int)0x84E2),
        TRANSPOSE_MODELVIEW_MATRIX = ((int)0x84E3),
        TRANSPOSE_PROJECTION_MATRIX = ((int)0x84E4),
        TRANSPOSE_TEXTURE_MATRIX = ((int)0x84E5),
        TRANSPOSE_COLOR_MATRIX = ((int)0x84E6),
        MAX_RENDERBUFFER_SIZE = ((int)0x84E8),
        MAX_RENDERBUFFER_SIZE_EXT = ((int)0x84E8),
        TEXTURE_COMPRESSION_HINT = ((int)0x84EF),
        TEXTURE_BINDING_RECTANGLE = ((int)0x84F6),
        MAX_RECTANGLE_TEXTURE_SIZE = ((int)0x84F8),
        MAX_TEXTURE_LOD_BIAS = ((int)0x84FD),
        TEXTURE_CUBE_MAP = ((int)0x8513),
        TEXTURE_BINDING_CUBE_MAP = ((int)0x8514),
        MAX_CUBE_MAP_TEXTURE_SIZE = ((int)0x851C),
        VERTEX_ARRAY_BINDING = ((int)0x85B5),
        PROGRAM_POINT_SIZE = ((int)0x8642),
        DEPTH_CLAMP = ((int)0x864F),
        NUM_COMPRESSED_TEXTURE_FORMATS = ((int)0x86A2),
        COMPRESSED_TEXTURE_FORMATS = ((int)0x86A3),
        STENCIL_BACK_FUNC = ((int)0x8800),
        STENCIL_BACK_FAIL = ((int)0x8801),
        STENCIL_BACK_PASS_DEPTH_FAIL = ((int)0x8802),
        STENCIL_BACK_PASS_DEPTH_PASS = ((int)0x8803),
        RGBA_FLOAT_MODE = ((int)0x8820),
        MAX_DRAW_BUFFERS = ((int)0x8824),
        DRAW_BUFFER0 = ((int)0x8825),
        DRAW_BUFFER1 = ((int)0x8826),
        DRAW_BUFFER2 = ((int)0x8827),
        DRAW_BUFFER3 = ((int)0x8828),
        DRAW_BUFFER4 = ((int)0x8829),
        DRAW_BUFFER5 = ((int)0x882A),
        DRAW_BUFFER6 = ((int)0x882B),
        DRAW_BUFFER7 = ((int)0x882C),
        DRAW_BUFFER8 = ((int)0x882D),
        DRAW_BUFFER9 = ((int)0x882E),
        DRAW_BUFFER10 = ((int)0x882F),
        DRAW_BUFFER11 = ((int)0x8830),
        DRAW_BUFFER12 = ((int)0x8831),
        DRAW_BUFFER13 = ((int)0x8832),
        DRAW_BUFFER14 = ((int)0x8833),
        DRAW_BUFFER15 = ((int)0x8834),
        BLEND_EQUATION_ALPHA = ((int)0x883D),
        TEXTURE_CUBE_MAP_SEAMLESS = ((int)0x884F),
        POINT_SPRITE = ((int)0x8861),
        MAX_VERTEX_ATTRIBS = ((int)0x8869),
        MAX_TEXTURE_COORDS = ((int)0x8871),
        MAX_TEXTURE_IMAGE_UNITS = ((int)0x8872),
        ARRAY_BUFFER_BINDING = ((int)0x8894),
        ELEMENT_ARRAY_BUFFER_BINDING = ((int)0x8895),
        VERTEX_ARRAY_BUFFER_BINDING = ((int)0x8896),
        NORMAL_ARRAY_BUFFER_BINDING = ((int)0x8897),
        COLOR_ARRAY_BUFFER_BINDING = ((int)0x8898),
        INDEX_ARRAY_BUFFER_BINDING = ((int)0x8899),
        TEXTURE_COORD_ARRAY_BUFFER_BINDING = ((int)0x889A),
        EDGE_FLAG_ARRAY_BUFFER_BINDING = ((int)0x889B),
        SECONDARY_COLOR_ARRAY_BUFFER_BINDING = ((int)0x889C),
        FOG_COORD_ARRAY_BUFFER_BINDING = ((int)0x889D),
        WEIGHT_ARRAY_BUFFER_BINDING = ((int)0x889E),
        VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = ((int)0x889F),
        PIXEL_PACK_BUFFER_BINDING = ((int)0x88ED),
        PIXEL_UNPACK_BUFFER_BINDING = ((int)0x88EF),
        MAX_ARRAY_TEXTURE_LAYERS = ((int)0x88FF),
        MIN_PROGRAM_TEXEL_OFFSET = ((int)0x8904),
        MAX_PROGRAM_TEXEL_OFFSET = ((int)0x8905),
        CLAMP_VERTEX_COLOR = ((int)0x891A),
        CLAMP_FRAGMENT_COLOR = ((int)0x891B),
        CLAMP_READ_COLOR = ((int)0x891C),
        MAX_VERTEX_UNIFORM_BLOCKS = ((int)0x8A2B),
        MAX_GEOMETRY_UNIFORM_BLOCKS = ((int)0x8A2C),
        MAX_FRAGMENT_UNIFORM_BLOCKS = ((int)0x8A2D),
        MAX_COMBINED_UNIFORM_BLOCKS = ((int)0x8A2E),
        MAX_UNIFORM_BUFFER_BINDINGS = ((int)0x8A2F),
        MAX_UNIFORM_BLOCK_SIZE = ((int)0x8A30),
        MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = ((int)0x8A31),
        MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8A32),
        MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8A33),
        UNIFORM_BUFFER_OFFSET_ALIGNMENT = ((int)0x8A34),
        MAX_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8B49),
        MAX_VERTEX_UNIFORM_COMPONENTS = ((int)0x8B4A),
        MAX_VARYING_COMPONENTS = ((int)0x8B4B),
        MAX_VARYING_FLOATS = ((int)0x8B4B),
        MAX_VERTEX_TEXTURE_IMAGE_UNITS = ((int)0x8B4C),
        MAX_COMBINED_TEXTURE_IMAGE_UNITS = ((int)0x8B4D),
        FRAGMENT_SHADER_DERIVATIVE_HINT = ((int)0x8B8B),
        CURRENT_PROGRAM = ((int)0x8B8D),
        TEXTURE_BINDING_1D_ARRAY = ((int)0x8C1C),
        TEXTURE_BINDING_2D_ARRAY = ((int)0x8C1D),
        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = ((int)0x8C29),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = ((int)0x8C80),
        MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = ((int)0x8C8A),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = ((int)0x8C8B),
        STENCIL_BACK_REF = ((int)0x8CA3),
        STENCIL_BACK_VALUE_MASK = ((int)0x8CA4),
        STENCIL_BACK_WRITEMASK = ((int)0x8CA5),
        DRAW_FRAMEBUFFER_BINDING = ((int)0x8CA6),
        FRAMEBUFFER_BINDING = ((int)0x8CA6),
        FRAMEBUFFER_BINDING_EXT = ((int)0x8CA6),
        RENDERBUFFER_BINDING = ((int)0x8CA7),
        RENDERBUFFER_BINDING_EXT = ((int)0x8CA7),
        READ_FRAMEBUFFER_BINDING = ((int)0x8CAA),
        MAX_COLOR_ATTACHMENTS = ((int)0x8CDF),
        MAX_COLOR_ATTACHMENTS_EXT = ((int)0x8CDF),
        MAX_SAMPLES = ((int)0x8D57),
        FRAMEBUFFER_SRGB = ((int)0x8DB9),
        MAX_GEOMETRY_VARYING_COMPONENTS = ((int)0x8DDD),
        MAX_VERTEX_VARYING_COMPONENTS = ((int)0x8DDE),
        MAX_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8DDF),
        MAX_GEOMETRY_OUTPUT_VERTICES = ((int)0x8DE0),
        MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = ((int)0x8DE1),
        QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = ((int)0x8E4C),
        PROVOKING_VERTEX = ((int)0x8E4F),
        SAMPLE_MASK = ((int)0x8E51),
        MAX_SAMPLE_MASK_WORDS = ((int)0x8E59),
        TEXTURE_BINDING_2D_MULTISAMPLE = ((int)0x9104),
        TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = ((int)0x9105),
        MAX_COLOR_TEXTURE_SAMPLES = ((int)0x910E),
        MAX_DEPTH_TEXTURE_SAMPLES = ((int)0x910F),
        MAX_INTEGER_SAMPLES = ((int)0x9110),
    }

    public enum GetPointervPName : int
    {
        FEEDBACK_BUFFER_POINTER = ((int)0x0DF0),
        SELECTION_BUFFER_POINTER = ((int)0x0DF3),
        VERTEX_ARRAY_POINTER = ((int)0x808E),
        NORMAL_ARRAY_POINTER = ((int)0x808F),
        COLOR_ARRAY_POINTER = ((int)0x8090),
        INDEX_ARRAY_POINTER = ((int)0x8091),
        TEXTURE_COORD_ARRAY_POINTER = ((int)0x8092),
        EDGE_FLAG_ARRAY_POINTER = ((int)0x8093),
        FOG_COORD_ARRAY_POINTER = ((int)0x8456),
        SECONDARY_COLOR_ARRAY_POINTER = ((int)0x845D),
    }

    public enum GetQueryObjectParam : int
    {
        QUERY_RESULT = ((int)0x8866),
        QUERY_RESULT_AVAILABLE = ((int)0x8867),
    }

    public enum GetQueryParam : int
    {
        QUERY_COUNTER_BITS = ((int)0x8864),
        CURRENT_QUERY = ((int)0x8865),
    }

    public enum GetTextureParameter : int
    {
        TEXTURE_WIDTH = ((int)0x1000),
        TEXTURE_HEIGHT = ((int)0x1001),
        TEXTURE_COMPONENTS = ((int)0x1003),
        TEXTURE_INTERNAL_FORMAT = ((int)0x1003),
        TEXTURE_BORDER_COLOR = ((int)0x1004),
        TEXTURE_BORDER = ((int)0x1005),
        TEXTURE_MAG_FILTER = ((int)0x2800),
        TEXTURE_MIN_FILTER = ((int)0x2801),
        TEXTURE_WRAP_S = ((int)0x2802),
        TEXTURE_WRAP_T = ((int)0x2803),
        TEXTURE_RED_SIZE = ((int)0x805C),
        TEXTURE_GREEN_SIZE = ((int)0x805D),
        TEXTURE_BLUE_SIZE = ((int)0x805E),
        TEXTURE_ALPHA_SIZE = ((int)0x805F),
        TEXTURE_LUMINANCE_SIZE = ((int)0x8060),
        TEXTURE_INTENSITY_SIZE = ((int)0x8061),
        TEXTURE_PRIORITY = ((int)0x8066),
        TEXTURE_RESIDENT = ((int)0x8067),
        TEXTURE_DEPTH = ((int)0x8071),
        TEXTURE_DEPTH_EXT = ((int)0x8071),
        TEXTURE_WRAP_R = ((int)0x8072),
        TEXTURE_WRAP_R_EXT = ((int)0x8072),
        TEXTURE_MIN_LOD = ((int)0x813A),
        TEXTURE_MAX_LOD = ((int)0x813B),
        TEXTURE_BASE_LEVEL = ((int)0x813C),
        TEXTURE_MAX_LEVEL = ((int)0x813D),
        GENERATE_MIPMAP = ((int)0x8191),
        TEXTURE_COMPRESSED_IMAGE_SIZE = ((int)0x86A0),
        TEXTURE_COMPRESSED = ((int)0x86A1),
        TEXTURE_DEPTH_SIZE = ((int)0x884A),
        DEPTH_TEXTURE_MODE = ((int)0x884B),
        TEXTURE_COMPARE_MODE = ((int)0x884C),
        TEXTURE_COMPARE_FUNC = ((int)0x884D),
        TEXTURE_STENCIL_SIZE = ((int)0x88F1),
        TEXTURE_RED_TYPE = ((int)0x8C10),
        TEXTURE_GREEN_TYPE = ((int)0x8C11),
        TEXTURE_BLUE_TYPE = ((int)0x8C12),
        TEXTURE_ALPHA_TYPE = ((int)0x8C13),
        TEXTURE_LUMINANCE_TYPE = ((int)0x8C14),
        TEXTURE_INTENSITY_TYPE = ((int)0x8C15),
        TEXTURE_DEPTH_TYPE = ((int)0x8C16),
        TEXTURE_SHARED_SIZE = ((int)0x8C3F),
        TEXTURE_SAMPLES = ((int)0x9106),
        TEXTURE_FIXED_SAMPLE_LOCATIONS = ((int)0x9107),
    }

    public enum GREMEDY_frame_terminator : int
    {
    }

    public enum GREMEDY_string_marker : int
    {
    }

    public enum HintMode : int
    {
        DONT_CARE = ((int)0x1100),
        FASTEST = ((int)0x1101),
        NICEST = ((int)0x1102),
    }

    public enum HintTarget : int
    {
        PERSPECTIVE_CORRECTION_HINT = ((int)0x0C50),
        POINT_SMOOTH_HINT = ((int)0x0C51),
        LINE_SMOOTH_HINT = ((int)0x0C52),
        POLYGON_SMOOTH_HINT = ((int)0x0C53),
        FOG_HINT = ((int)0x0C54),
        PACK_CMYK_HINT_EXT = ((int)0x800E),
        UNPACK_CMYK_HINT_EXT = ((int)0x800F),
        GENERATE_MIPMAP_HINT = ((int)0x8192),
        TEXTURE_COMPRESSION_HINT = ((int)0x84EF),
        FRAGMENT_SHADER_DERIVATIVE_HINT = ((int)0x8B8B),
    }

    public enum HistogramTarget : int
    {
        HISTOGRAM = ((int)0x8024),
        PROXY_HISTOGRAM = ((int)0x8025),
    }

    public enum HistogramTargetEXT : int
    {
        HISTOGRAM_EXT = ((int)0x8024),
        PROXY_HISTOGRAM_EXT = ((int)0x8025),
    }

    public enum IndexedEnableCap : int
    {
        BLEND = ((int)0x0BE2),
    }

    public enum IndexPointerType : int
    {
        SHORT = ((int)0x1402),
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
    }

    public enum InterleavedArrayFormat : int
    {
        V2F = ((int)0x2A20),
        V3F = ((int)0x2A21),
        C4UB_V2F = ((int)0x2A22),
        C4UB_V3F = ((int)0x2A23),
        C3F_V3F = ((int)0x2A24),
        N3F_V3F = ((int)0x2A25),
        C4F_N3F_V3F = ((int)0x2A26),
        T2F_V3F = ((int)0x2A27),
        T4F_V4F = ((int)0x2A28),
        T2F_C4UB_V3F = ((int)0x2A29),
        T2F_C3F_V3F = ((int)0x2A2A),
        T2F_N3F_V3F = ((int)0x2A2B),
        T2F_C4F_N3F_V3F = ((int)0x2A2C),
        T4F_C4F_N3F_V4F = ((int)0x2A2D),
    }

    public enum LightModelColorControl : int
    {
        SINGLE_COLOR = ((int)0x81F9),
        SEPARATE_SPECULAR_COLOR = ((int)0x81FA),
    }

    public enum LightModelParameter : int
    {
        LIGHT_MODEL_LOCAL_VIEWER = ((int)0x0B51),
        LIGHT_MODEL_TWO_SIDE = ((int)0x0B52),
        LIGHT_MODEL_AMBIENT = ((int)0x0B53),
        LIGHT_MODEL_COLOR_CONTROL = ((int)0x81F8),
    }

    public enum LightName : int
    {
        LIGHT0 = ((int)0x4000),
        LIGHT1 = ((int)0x4001),
        LIGHT2 = ((int)0x4002),
        LIGHT3 = ((int)0x4003),
        LIGHT4 = ((int)0x4004),
        LIGHT5 = ((int)0x4005),
        LIGHT6 = ((int)0x4006),
        LIGHT7 = ((int)0x4007),
    }

    public enum LightParameter : int
    {
        AMBIENT = ((int)0x1200),
        DIFFUSE = ((int)0x1201),
        SPECULAR = ((int)0x1202),
        POSITION = ((int)0x1203),
        SPOT_DIRECTION = ((int)0x1204),
        SPOT_EXPONENT = ((int)0x1205),
        SPOT_CUTOFF = ((int)0x1206),
        CONSTANT_ATTENUATION = ((int)0x1207),
        LINEAR_ATTENUATION = ((int)0x1208),
        QUADRATIC_ATTENUATION = ((int)0x1209),
    }

    public enum ListMode : int
    {
        COMPILE = ((int)0x1300),
        COMPILE_AND_EXECUTE = ((int)0x1301),
    }

    public enum ListNameType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        GL_2_BYTES = ((int)0x1407),
        GL_3_BYTES = ((int)0x1408),
        GL_4_BYTES = ((int)0x1409),
    }

    public enum LogicOp : int
    {
        CLEAR = ((int)0x1500),
        AND = ((int)0x1501),
        AND_REVERSE = ((int)0x1502),
        COPY = ((int)0x1503),
        AND_INVERTED = ((int)0x1504),
        NOOP = ((int)0x1505),
        XOR = ((int)0x1506),
        OR = ((int)0x1507),
        NOR = ((int)0x1508),
        EQUIV = ((int)0x1509),
        INVERT = ((int)0x150A),
        OR_REVERSE = ((int)0x150B),
        COPY_INVERTED = ((int)0x150C),
        OR_INVERTED = ((int)0x150D),
        NAND = ((int)0x150E),
        SET = ((int)0x150F),
    }

    public enum MapTarget : int
    {
        MAP1_COLOR_4 = ((int)0x0D90),
        MAP1_INDEX = ((int)0x0D91),
        MAP1_NORMAL = ((int)0x0D92),
        MAP1_TEXTURE_COORD_1 = ((int)0x0D93),
        MAP1_TEXTURE_COORD_2 = ((int)0x0D94),
        MAP1_TEXTURE_COORD_3 = ((int)0x0D95),
        MAP1_TEXTURE_COORD_4 = ((int)0x0D96),
        MAP1_VERTEX_3 = ((int)0x0D97),
        MAP1_VERTEX_4 = ((int)0x0D98),
        MAP2_COLOR_4 = ((int)0x0DB0),
        MAP2_INDEX = ((int)0x0DB1),
        MAP2_NORMAL = ((int)0x0DB2),
        MAP2_TEXTURE_COORD_1 = ((int)0x0DB3),
        MAP2_TEXTURE_COORD_2 = ((int)0x0DB4),
        MAP2_TEXTURE_COORD_3 = ((int)0x0DB5),
        MAP2_TEXTURE_COORD_4 = ((int)0x0DB6),
        MAP2_VERTEX_3 = ((int)0x0DB7),
        MAP2_VERTEX_4 = ((int)0x0DB8),
    }

    public enum MaterialFace : int
    {
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        FRONT_AND_BACK = ((int)0x0408),
    }

    public enum MaterialParameter : int
    {
        AMBIENT = ((int)0x1200),
        DIFFUSE = ((int)0x1201),
        SPECULAR = ((int)0x1202),
        EMISSION = ((int)0x1600),
        SHININESS = ((int)0x1601),
        AMBIENT_AND_DIFFUSE = ((int)0x1602),
        COLOR_INDEXES = ((int)0x1603),
    }

    public enum MatrixMode : int
    {
        MODELVIEW = ((int)0x1700),
        PROJECTION = ((int)0x1701),
        TEXTURE = ((int)0x1702),
        COLOR = ((int)0x1800),
    }

    public enum MatrixModeARB : int
    {
        MODELVIEW = ((int)0x1700),
        PROJECTION = ((int)0x1701),
        TEXTURE = ((int)0x1702),
        COLOR = ((int)0x1800),
        MATRIX0 = ((int)0x88C0),
        MATRIX1 = ((int)0x88C1),
        MATRIX2 = ((int)0x88C2),
        MATRIX3 = ((int)0x88C3),
        MATRIX4 = ((int)0x88C4),
        MATRIX5 = ((int)0x88C5),
        MATRIX6 = ((int)0x88C6),
        MATRIX7 = ((int)0x88C7),
        MATRIX8 = ((int)0x88C8),
        MATRIX9 = ((int)0x88C9),
        MATRIX10 = ((int)0x88CA),
        MATRIX11 = ((int)0x88CB),
        MATRIX12 = ((int)0x88CC),
        MATRIX13 = ((int)0x88CD),
        MATRIX14 = ((int)0x88CE),
        MATRIX15 = ((int)0x88CF),
        MATRIX16 = ((int)0x88D0),
        MATRIX17 = ((int)0x88D1),
        MATRIX18 = ((int)0x88D2),
        MATRIX19 = ((int)0x88D3),
        MATRIX20 = ((int)0x88D4),
        MATRIX21 = ((int)0x88D5),
        MATRIX22 = ((int)0x88D6),
        MATRIX23 = ((int)0x88D7),
        MATRIX24 = ((int)0x88D8),
        MATRIX25 = ((int)0x88D9),
        MATRIX26 = ((int)0x88DA),
        MATRIX27 = ((int)0x88DB),
        MATRIX28 = ((int)0x88DC),
        MATRIX29 = ((int)0x88DD),
        MATRIX30 = ((int)0x88DE),
        MATRIX31 = ((int)0x88DF),
    }

    public enum MESA_resize_buffers : int
    {
    }

    public enum MESA_window_pos : int
    {
    }

    public enum MESAX_texture_stack : int
    {
        TEXTURE_1D_STACK_MESAX = ((int)0x8759),
        TEXTURE_2D_STACK_MESAX = ((int)0x875A),
        PROXY_TEXTURE_1D_STACK_MESAX = ((int)0x875B),
        PROXY_TEXTURE_2D_STACK_MESAX = ((int)0x875C),
        TEXTURE_1D_STACK_BINDING_MESAX = ((int)0x875D),
        TEXTURE_2D_STACK_BINDING_MESAX = ((int)0x875E),
    }

    public enum MeshMode1 : int
    {
        POINT = ((int)0x1B00),
        LINE = ((int)0x1B01),
    }

    public enum MeshMode2 : int
    {
        POINT = ((int)0x1B00),
        LINE = ((int)0x1B01),
        FILL = ((int)0x1B02),
    }

    public enum MinmaxTarget : int
    {
        MINMAX = ((int)0x802E),
    }

    public enum MinmaxTargetEXT : int
    {
        MINMAX_EXT = ((int)0x802E),
    }

    public enum NormalPointerType : int
    {
        BYTE = ((int)0x1400),
        SHORT = ((int)0x1402),
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

    public enum NV_blend_square : int
    {
    }

    public enum NV_conditional_render : int
    {
        QUERY_WAIT_NV = ((int)0x8E13),
        QUERY_NO_WAIT_NV = ((int)0x8E14),
        QUERY_BY_REGION_WAIT_NV = ((int)0x8E15),
        QUERY_BY_REGION_NO_WAIT_NV = ((int)0x8E16),
    }

    public enum NV_explicit_multisample : int
    {
        SAMPLE_POSITION_NV = ((int)0x8E50),
        SAMPLE_MASK_NV = ((int)0x8E51),
        SAMPLE_MASK_VALUE_NV = ((int)0x8E52),
        TEXTURE_BINDING_RENDERBUFFER_NV = ((int)0x8E53),
        TEXTURE_RENDERBUFFER_DATA_STORE_BINDING_NV = ((int)0x8E54),
        TEXTURE_RENDERBUFFER_NV = ((int)0x8E55),
        SAMPLER_RENDERBUFFER_NV = ((int)0x8E56),
        INT_SAMPLER_RENDERBUFFER_NV = ((int)0x8E57),
        UNSIGNED_INT_SAMPLER_RENDERBUFFER_NV = ((int)0x8E58),
        MAX_SAMPLE_MASK_WORDS_NV = ((int)0x8E59),
    }

    public enum NV_fog_distance : int
    {
        EYE_PLANE = ((int)0x2502),
        FOG_DISTANCE_MODE_NV = ((int)0x855A),
        EYE_RADIAL_NV = ((int)0x855B),
        EYE_PLANE_ABSOLUTE_NV = ((int)0x855C),
    }

    public enum NV_geometry_program4 : int
    {
        LINES_ADJACENCY_EXT = ((int)0x000A),
        LINE_STRIP_ADJACENCY_EXT = ((int)0x000B),
        TRIANGLES_ADJACENCY_EXT = ((int)0x000C),
        TRIANGLE_STRIP_ADJACENCY_EXT = ((int)0x000D),
        PROGRAM_POINT_SIZE_EXT = ((int)0x8642),
        GEOMETRY_PROGRAM_NV = ((int)0x8C26),
        MAX_PROGRAM_OUTPUT_VERTICES_NV = ((int)0x8C27),
        MAX_PROGRAM_TOTAL_OUTPUT_COMPONENTS_NV = ((int)0x8C28),
        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT = ((int)0x8C29),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_LAYERED_EXT = ((int)0x8DA7),
        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT = ((int)0x8DA8),
        FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT = ((int)0x8DA9),
        GEOMETRY_VERTICES_OUT_EXT = ((int)0x8DDA),
        GEOMETRY_INPUT_TYPE_EXT = ((int)0x8DDB),
        GEOMETRY_OUTPUT_TYPE_EXT = ((int)0x8DDC),
    }

    public enum NV_gpu_program4 : int
    {
        MIN_PROGRAM_TEXEL_OFFSET_NV = ((int)0x8904),
        MAX_PROGRAM_TEXEL_OFFSET_NV = ((int)0x8905),
        PROGRAM_ATTRIB_COMPONENTS_NV = ((int)0x8906),
        PROGRAM_RESULT_COMPONENTS_NV = ((int)0x8907),
        MAX_PROGRAM_ATTRIB_COMPONENTS_NV = ((int)0x8908),
        MAX_PROGRAM_RESULT_COMPONENTS_NV = ((int)0x8909),
        MAX_PROGRAM_GENERIC_ATTRIBS_NV = ((int)0x8DA5),
        MAX_PROGRAM_GENERIC_RESULTS_NV = ((int)0x8DA6),
    }

    public enum NV_parameter_buffer_object : int
    {
        MAX_PROGRAM_PARAMETER_BUFFER_BINDINGS_NV = ((int)0x8DA0),
        MAX_PROGRAM_PARAMETER_BUFFER_SIZE_NV = ((int)0x8DA1),
        VERTEX_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA2),
        GEOMETRY_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA3),
        FRAGMENT_PROGRAM_PARAMETER_BUFFER_NV = ((int)0x8DA4),
    }

    public enum NV_present_video : int
    {
        FRAME_NV = ((int)0x8E26),
        FIELDS_NV = ((int)0x8E27),
        CURRENT_TIME_NV = ((int)0x8E28),
        NUM_FILL_STREAMS_NV = ((int)0x8E29),
        PRESENT_TIME_NV = ((int)0x8E2A),
        PRESENT_DURATION_NV = ((int)0x8E2B),
    }

    public enum NV_texgen_emboss : int
    {
        EMBOSS_LIGHT_NV = ((int)0x855D),
        EMBOSS_CONSTANT_NV = ((int)0x855E),
        EMBOSS_MAP_NV = ((int)0x855F),
    }

    public enum NV_texture_env_combine4 : int
    {
        COMBINE4_NV = ((int)0x8503),
        SOURCE3_RGB_NV = ((int)0x8583),
        SOURCE3_ALPHA_NV = ((int)0x858B),
        OPERAND3_RGB_NV = ((int)0x8593),
        OPERAND3_ALPHA_NV = ((int)0x859B),
    }

    public enum NV_transform_feedback : int
    {
        BACK_PRIMARY_COLOR_NV = ((int)0x8C77),
        BACK_SECONDARY_COLOR_NV = ((int)0x8C78),
        TEXTURE_COORD_NV = ((int)0x8C79),
        CLIP_DISTANCE_NV = ((int)0x8C7A),
        VERTEX_ID_NV = ((int)0x8C7B),
        PRIMITIVE_ID_NV = ((int)0x8C7C),
        GENERIC_ATTRIB_NV = ((int)0x8C7D),
        TRANSFORM_FEEDBACK_ATTRIBS_NV = ((int)0x8C7E),
        TRANSFORM_FEEDBACK_BUFFER_MODE_NV = ((int)0x8C7F),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_NV = ((int)0x8C80),
        ACTIVE_VARYINGS_NV = ((int)0x8C81),
        ACTIVE_VARYING_MAX_LENGTH_NV = ((int)0x8C82),
        TRANSFORM_FEEDBACK_VARYINGS_NV = ((int)0x8C83),
        TRANSFORM_FEEDBACK_BUFFER_START_NV = ((int)0x8C84),
        TRANSFORM_FEEDBACK_BUFFER_SIZE_NV = ((int)0x8C85),
        TRANSFORM_FEEDBACK_RECORD_NV = ((int)0x8C86),
        PRIMITIVES_GENERATED_NV = ((int)0x8C87),
        TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV = ((int)0x8C88),
        RASTERIZER_DISCARD_NV = ((int)0x8C89),
        MAX_TRANSFORM_FEEDBACK_INTERLEAVED_ATTRIBS_NV = ((int)0x8C8A),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_NV = ((int)0x8C8B),
        INTERLEAVED_ATTRIBS_NV = ((int)0x8C8C),
        SEPARATE_ATTRIBS_NV = ((int)0x8C8D),
        TRANSFORM_FEEDBACK_BUFFER_NV = ((int)0x8C8E),
        TRANSFORM_FEEDBACK_BUFFER_BINDING_NV = ((int)0x8C8F),
    }

    public enum NV_transform_feedback2 : int
    {
        TRANSFORM_FEEDBACK_NV = ((int)0x8E22),
        TRANSFORM_FEEDBACK_BUFFER_PAUSED_NV = ((int)0x8E23),
        TRANSFORM_FEEDBACK_BUFFER_ACTIVE_NV = ((int)0x8E24),
        TRANSFORM_FEEDBACK_BINDING_NV = ((int)0x8E25),
    }

    public enum NV_vertex_program4 : int
    {
        VERTEX_ATTRIB_ARRAY_INTEGER_NV = ((int)0x88FD),
    }

    public enum OES_read_format : int
    {
        IMPLEMENTATION_COLOR_READ_TYPE_OES = ((int)0x8B9A),
        IMPLEMENTATION_COLOR_READ_FORMAT_OES = ((int)0x8B9B),
    }

    public enum PixelCopyType : int
    {
        COLOR = ((int)0x1800),
        DEPTH = ((int)0x1801),
        STENCIL = ((int)0x1802),
    }

    public enum PixelFormat : int
    {
        COLOR_INDEX = ((int)0x1900),
        STENCIL_INDEX = ((int)0x1901),
        DEPTH_COMPONENT = ((int)0x1902),
        RED = ((int)0x1903),
        GREEN = ((int)0x1904),
        BLUE = ((int)0x1905),
        ALPHA = ((int)0x1906),
        RGB = ((int)0x1907),
        RGBA = ((int)0x1908),
        LUMINANCE = ((int)0x1909),
        LUMINANCE_ALPHA = ((int)0x190A),
        ABGR_EXT = ((int)0x8000),
        CMYK_EXT = ((int)0x800C),
        CMYKA_EXT = ((int)0x800D),
        BGR = ((int)0x80E0),
        BGRA = ((int)0x80E1),
        RG = ((int)0x8227),
        RG_INTEGER = ((int)0x8228),
        DEPTH_STENCIL = ((int)0x84F9),
        RED_INTEGER = ((int)0x8D94),
        GREEN_INTEGER = ((int)0x8D95),
        BLUE_INTEGER = ((int)0x8D96),
        ALPHA_INTEGER = ((int)0x8D97),
        RGB_INTEGER = ((int)0x8D98),
        RGBA_INTEGER = ((int)0x8D99),
        BGR_INTEGER = ((int)0x8D9A),
        BGRA_INTEGER = ((int)0x8D9B),
    }

    public enum PixelInternalFormat : int
    {
        DEPTH_COMPONENT = ((int)0x1902),
        ALPHA = ((int)0x1906),
        RGB = ((int)0x1907),
        RGBA = ((int)0x1908),
        LUMINANCE = ((int)0x1909),
        LUMINANCE_ALPHA = ((int)0x190A),
        R3_G3_B2 = ((int)0x2A10),
        ALPHA4 = ((int)0x803B),
        ALPHA8 = ((int)0x803C),
        ALPHA12 = ((int)0x803D),
        ALPHA16 = ((int)0x803E),
        LUMINANCE4 = ((int)0x803F),
        LUMINANCE8 = ((int)0x8040),
        LUMINANCE12 = ((int)0x8041),
        LUMINANCE16 = ((int)0x8042),
        LUMINANCE4_ALPHA4 = ((int)0x8043),
        LUMINANCE6_ALPHA2 = ((int)0x8044),
        LUMINANCE8_ALPHA8 = ((int)0x8045),
        LUMINANCE12_ALPHA4 = ((int)0x8046),
        LUMINANCE12_ALPHA12 = ((int)0x8047),
        LUMINANCE16_ALPHA16 = ((int)0x8048),
        INTENSITY = ((int)0x8049),
        INTENSITY4 = ((int)0x804A),
        INTENSITY8 = ((int)0x804B),
        INTENSITY12 = ((int)0x804C),
        INTENSITY16 = ((int)0x804D),
        RGB2_EXT = ((int)0x804E),
        RGB4 = ((int)0x804F),
        RGB5 = ((int)0x8050),
        RGB8 = ((int)0x8051),
        RGB10 = ((int)0x8052),
        RGB12 = ((int)0x8053),
        RGB16 = ((int)0x8054),
        RGBA2 = ((int)0x8055),
        RGBA4 = ((int)0x8056),
        RGB5_A1 = ((int)0x8057),
        RGBA8 = ((int)0x8058),
        RGB10_A2 = ((int)0x8059),
        RGBA12 = ((int)0x805A),
        RGBA16 = ((int)0x805B),
        DEPTH_COMPONENT16 = ((int)0x81a5),
        DEPTH_COMPONENT24 = ((int)0x81a6),
        DEPTH_COMPONENT32 = ((int)0x81a7),
        COMPRESSED_RED = ((int)0x8225),
        COMPRESSED_RG = ((int)0x8226),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        RG8 = ((int)0x822B),
        RG16 = ((int)0x822C),
        R16F = ((int)0x822D),
        R32F = ((int)0x822E),
        RG16F = ((int)0x822F),
        RG32F = ((int)0x8230),
        R8I = ((int)0x8231),
        R8UI = ((int)0x8232),
        R16I = ((int)0x8233),
        R16UI = ((int)0x8234),
        R32I = ((int)0x8235),
        R32UI = ((int)0x8236),
        RG8I = ((int)0x8237),
        RG8UI = ((int)0x8238),
        RG16I = ((int)0x8239),
        RG16UI = ((int)0x823A),
        RG32I = ((int)0x823B),
        RG32UI = ((int)0x823C),
        COMPRESSED_RGB_S3TC_DXT1_EXT = ((int)0x83F0),
        COMPRESSED_RGBA_S3TC_DXT1_EXT = ((int)0x83F1),
        COMPRESSED_RGBA_S3TC_DXT3_EXT = ((int)0x83F2),
        COMPRESSED_RGBA_S3TC_DXT5_EXT = ((int)0x83F3),
        COMPRESSED_ALPHA = ((int)0x84E9),
        COMPRESSED_LUMINANCE = ((int)0x84EA),
        COMPRESSED_LUMINANCE_ALPHA = ((int)0x84EB),
        COMPRESSED_INTENSITY = ((int)0x84EC),
        COMPRESSED_RGB = ((int)0x84ED),
        COMPRESSED_RGBA = ((int)0x84EE),
        DEPTH_STENCIL = ((int)0x84F9),
        RGBA32F = ((int)0x8814),
        RGB32F = ((int)0x8815),
        RGBA16F = ((int)0x881A),
        RGB16F = ((int)0x881B),
        DEPTH24_STENCIL8 = ((int)0x88F0),
        R11F_G11F_B10F = ((int)0x8C3A),
        RGB9_E5 = ((int)0x8C3D),
        SRGB = ((int)0x8C40),
        SRGB8 = ((int)0x8C41),
        SRGB_ALPHA = ((int)0x8C42),
        SRGB8_ALPHA8 = ((int)0x8C43),
        SLUMINANCE_ALPHA = ((int)0x8C44),
        SLUMINANCE8_ALPHA8 = ((int)0x8C45),
        SLUMINANCE = ((int)0x8C46),
        SLUMINANCE8 = ((int)0x8C47),
        COMPRESSED_SRGB = ((int)0x8C48),
        COMPRESSED_SRGB_ALPHA = ((int)0x8C49),
        COMPRESSED_SLUMINANCE = ((int)0x8C4A),
        COMPRESSED_SLUMINANCE_ALPHA = ((int)0x8C4B),
        COMPRESSED_SRGB_S3TC_DXT1_EXT = ((int)0x8C4C),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = ((int)0x8C4D),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = ((int)0x8C4E),
        COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = ((int)0x8C4F),
        DEPTH_COMPONENT32F = ((int)0x8CAC),
        DEPTH32F_STENCIL8 = ((int)0x8CAD),
        RGBA32UI = ((int)0x8D70),
        RGB32UI = ((int)0x8D71),
        RGBA16UI = ((int)0x8D76),
        RGB16UI = ((int)0x8D77),
        RGBA8UI = ((int)0x8D7C),
        RGB8UI = ((int)0x8D7D),
        RGBA32I = ((int)0x8D82),
        RGB32I = ((int)0x8D83),
        RGBA16I = ((int)0x8D88),
        RGB16I = ((int)0x8D89),
        RGBA8I = ((int)0x8D8E),
        RGB8I = ((int)0x8D8F),
        FLOAT_32_UNSIGNED_INT_24_8_REV = ((int)0x8DAD),
        COMPRESSED_RED_RGTC1 = ((int)0x8DBB),
        COMPRESSED_SIGNED_RED_RGTC1 = ((int)0x8DBC),
        COMPRESSED_RG_RGTC2 = ((int)0x8DBD),
        COMPRESSED_SIGNED_RG_RGTC2 = ((int)0x8DBE),
        ONE = ((int)1),
        TWO = ((int)2),
        THREE = ((int)3),
        FOUR = ((int)4),
    }

    public enum PixelMap : int
    {
        PIXEL_MAP_I_TO_I = ((int)0x0C70),
        PIXEL_MAP_S_TO_S = ((int)0x0C71),
        PIXEL_MAP_I_TO_R = ((int)0x0C72),
        PIXEL_MAP_I_TO_G = ((int)0x0C73),
        PIXEL_MAP_I_TO_B = ((int)0x0C74),
        PIXEL_MAP_I_TO_A = ((int)0x0C75),
        PIXEL_MAP_R_TO_R = ((int)0x0C76),
        PIXEL_MAP_G_TO_G = ((int)0x0C77),
        PIXEL_MAP_B_TO_B = ((int)0x0C78),
        PIXEL_MAP_A_TO_A = ((int)0x0C79),
    }

    public enum PixelStoreParameter : int
    {
        UNPACK_SWAP_BYTES = ((int)0x0CF0),
        UNPACK_LSB_FIRST = ((int)0x0CF1),
        UNPACK_ROW_LENGTH = ((int)0x0CF2),
        UNPACK_SKIP_ROWS = ((int)0x0CF3),
        UNPACK_SKIP_PIXELS = ((int)0x0CF4),
        UNPACK_ALIGNMENT = ((int)0x0CF5),
        PACK_SWAP_BYTES = ((int)0x0D00),
        PACK_LSB_FIRST = ((int)0x0D01),
        PACK_ROW_LENGTH = ((int)0x0D02),
        PACK_SKIP_ROWS = ((int)0x0D03),
        PACK_SKIP_PIXELS = ((int)0x0D04),
        PACK_ALIGNMENT = ((int)0x0D05),
        PACK_SKIP_IMAGES = ((int)0x806B),
        PACK_SKIP_IMAGES_EXT = ((int)0x806B),
        PACK_IMAGE_HEIGHT = ((int)0x806C),
        PACK_IMAGE_HEIGHT_EXT = ((int)0x806C),
        UNPACK_SKIP_IMAGES = ((int)0x806D),
        UNPACK_SKIP_IMAGES_EXT = ((int)0x806D),
        UNPACK_IMAGE_HEIGHT = ((int)0x806E),
        UNPACK_IMAGE_HEIGHT_EXT = ((int)0x806E),
    }

    public enum PixelTexGenMode : int
    {
        NONE = ((int)0),
        RGB = ((int)0x1907),
        RGBA = ((int)0x1908),
        LUMINANCE = ((int)0x1909),
        LUMINANCE_ALPHA = ((int)0x190A),
    }

    public enum PixelTransferParameter : int
    {
        MAP_COLOR = ((int)0x0D10),
        MAP_STENCIL = ((int)0x0D11),
        INDEX_SHIFT = ((int)0x0D12),
        INDEX_OFFSET = ((int)0x0D13),
        RED_SCALE = ((int)0x0D14),
        RED_BIAS = ((int)0x0D15),
        GREEN_SCALE = ((int)0x0D18),
        GREEN_BIAS = ((int)0x0D19),
        BLUE_SCALE = ((int)0x0D1A),
        BLUE_BIAS = ((int)0x0D1B),
        ALPHA_SCALE = ((int)0x0D1C),
        ALPHA_BIAS = ((int)0x0D1D),
        DEPTH_SCALE = ((int)0x0D1E),
        DEPTH_BIAS = ((int)0x0D1F),
        POST_CONVOLUTION_RED_SCALE_EXT = ((int)0x801C),
        POST_CONVOLUTION_GREEN_SCALE_EXT = ((int)0x801D),
        POST_CONVOLUTION_BLUE_SCALE_EXT = ((int)0x801E),
        POST_CONVOLUTION_ALPHA_SCALE_EXT = ((int)0x801F),
        POST_CONVOLUTION_RED_BIAS_EXT = ((int)0x8020),
        POST_CONVOLUTION_GREEN_BIAS_EXT = ((int)0x8021),
        POST_CONVOLUTION_BLUE_BIAS_EXT = ((int)0x8022),
        POST_CONVOLUTION_ALPHA_BIAS_EXT = ((int)0x8023),
        POST_COLOR_MATRIX_RED_SCALE_SGI = ((int)0x80B4),
        POST_COLOR_MATRIX_GREEN_SCALE_SGI = ((int)0x80B5),
        POST_COLOR_MATRIX_BLUE_SCALE_SGI = ((int)0x80B6),
        POST_COLOR_MATRIX_ALPHA_SCALE_SGI = ((int)0x80B7),
        POST_COLOR_MATRIX_RED_BIAS_SGI = ((int)0x80B8),
        POST_COLOR_MATRIX_GREEN_BIAS_SGI = ((int)0x80B9),
        POST_COLOR_MATRIX_BLUE_BIAS_SGI = ((int)0x80BA),
        POST_COLOR_MATRIX_ALPHA_BIAS_SGI = ((int)0x80BB),
    }

    public enum PixelType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        HALF_FLOAT = ((int)0x140B),
        BITMAP = ((int)0x1A00),
        UNSIGNED_BYTE_3_3_2 = ((int)0x8032),
        UNSIGNED_BYTE_3_3_2_EXT = ((int)0x8032),
        UNSIGNED_SHORT_4_4_4_4 = ((int)0x8033),
        UNSIGNED_SHORT_4_4_4_4_EXT = ((int)0x8033),
        UNSIGNED_SHORT_5_5_5_1 = ((int)0x8034),
        UNSIGNED_SHORT_5_5_5_1_EXT = ((int)0x8034),
        UNSIGNED_INT_8_8_8_8 = ((int)0x8035),
        UNSIGNED_INT_8_8_8_8_EXT = ((int)0x8035),
        UNSIGNED_INT_10_10_10_2 = ((int)0x8036),
        UNSIGNED_INT_10_10_10_2_EXT = ((int)0x8036),
        UNSIGNED_BYTE_2_3_3_REVERSED = ((int)0x8362),
        UNSIGNED_SHORT_5_6_5 = ((int)0x8363),
        UNSIGNED_SHORT_5_6_5_REVERSED = ((int)0x8364),
        UNSIGNED_SHORT_4_4_4_4_REVERSED = ((int)0x8365),
        UNSIGNED_SHORT_1_5_5_5_REVERSED = ((int)0x8366),
        UNSIGNED_INT_8_8_8_8_REVERSED = ((int)0x8367),
        UNSIGNED_INT_2_10_10_10_REVERSED = ((int)0x8368),
        UNSIGNED_INT_24_8 = ((int)0x84FA),
        UNSIGNED_INT_10F_11F_11F_REV = ((int)0x8C3B),
        UNSIGNED_INT_5_9_9_9_REV = ((int)0x8C3E),
        FLOAT_32_UNSIGNED_INT_24_8_REV = ((int)0x8DAD),
    }

    public enum PointParameterName : int
    {
        POINT_SIZE_MIN = ((int)0x8126),
        POINT_SIZE_MAX = ((int)0x8127),
        POINT_FADE_THRESHOLD_SIZE = ((int)0x8128),
        POINT_DISTANCE_ATTENUATION = ((int)0x8129),
        POINT_SPRITE_COORD_ORIGIN = ((int)0x8CA0),
    }

    public enum PointSpriteCoordOriginParameter : int
    {
        LOWER_LEFT = ((int)0x8CA1),
        UPPER_LEFT = ((int)0x8CA2),
    }

    public enum PolygonMode : int
    {
        POINT = ((int)0x1B00),
        LINE = ((int)0x1B01),
        FILL = ((int)0x1B02),
    }

    public enum ProgramParameter : int
    {
        ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = ((int)0x8A35),
        ACTIVE_UNIFORM_BLOCKS = ((int)0x8A36),
        DELETE_STATUS = ((int)0x8B80),
        LINK_STATUS = ((int)0x8B82),
        VALIDATE_STATUS = ((int)0x8B83),
        INFO_LOG_LENGTH = ((int)0x8B84),
        ATTACHED_SHADERS = ((int)0x8B85),
        ACTIVE_UNIFORMS = ((int)0x8B86),
        ACTIVE_UNIFORM_MAX_LENGTH = ((int)0x8B87),
        ACTIVE_ATTRIBUTES = ((int)0x8B89),
        ACTIVE_ATTRIBUTE_MAX_LENGTH = ((int)0x8B8A),
        TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = ((int)0x8C76),
        TRANSFORM_FEEDBACK_BUFFER_MODE = ((int)0x8C7F),
        TRANSFORM_FEEDBACK_VARYINGS = ((int)0x8C83),
        GEOMETRY_VERTICES_OUT = ((int)0x8DDA),
        GEOMETRY_INPUT_TYPE = ((int)0x8DDB),
        GEOMETRY_OUTPUT_TYPE = ((int)0x8DDC),
    }

    public enum ProvokingVertexMode : int
    {
        FIRST_VERTEX_CONVENTION = ((int)0x8E4D),
        LAST_VERTEX_CONVENTION = ((int)0x8E4E),
    }

    public enum QueryTarget : int
    {
        SAMPLES_PASSED = ((int)0x8914),
        PRIMITIVES_GENERATED = ((int)0x8C87),
        TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = ((int)0x8C88),
    }

    public enum ReadBufferMode : int
    {
        FRONT_LEFT = ((int)0x0400),
        FRONT_RIGHT = ((int)0x0401),
        BACK_LEFT = ((int)0x0402),
        BACK_RIGHT = ((int)0x0403),
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        LEFT = ((int)0x0406),
        RIGHT = ((int)0x0407),
        AUX0 = ((int)0x0409),
        AUX1 = ((int)0x040A),
        AUX2 = ((int)0x040B),
        AUX3 = ((int)0x040C),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
    }

    public enum REND_screen_coordinates : int
    {
        SCREEN_COORDINATES_REND = ((int)0x8490),
        INVERTED_SCREEN_W_REND = ((int)0x8491),
    }

    public enum RenderbufferParameterName : int
    {
        RENDERBUFFER_SAMPLES = ((int)0x8CAB),
        RENDERBUFFER_WIDTH = ((int)0x8D42),
        RENDERBUFFER_WIDTH_EXT = ((int)0x8D42),
        RENDERBUFFER_HEIGHT = ((int)0x8D43),
        RENDERBUFFER_HEIGHT_EXT = ((int)0x8D43),
        RENDERBUFFER_INTERNAL_FORMAT = ((int)0x8D44),
        RENDERBUFFER_INTERNAL_FORMAT_EXT = ((int)0x8D44),
        RENDERBUFFER_RED_SIZE = ((int)0x8D50),
        RENDERBUFFER_RED_SIZE_EXT = ((int)0x8D50),
        RENDERBUFFER_GREEN_SIZE = ((int)0x8D51),
        RENDERBUFFER_GREEN_SIZE_EXT = ((int)0x8D51),
        RENDERBUFFER_BLUE_SIZE = ((int)0x8D52),
        RENDERBUFFER_BLUE_SIZE_EXT = ((int)0x8D52),
        RENDERBUFFER_ALPHA_SIZE = ((int)0x8D53),
        RENDERBUFFER_ALPHA_SIZE_EXT = ((int)0x8D53),
        RENDERBUFFER_DEPTH_SIZE = ((int)0x8D54),
        RENDERBUFFER_DEPTH_SIZE_EXT = ((int)0x8D54),
        RENDERBUFFER_STENCIL_SIZE = ((int)0x8D55),
        RENDERBUFFER_STENCIL_SIZE_EXT = ((int)0x8D55),
    }

    public enum RenderbufferStorage : int
    {
        R3_G3_B2 = ((int)0x2A10),
        ALPHA4 = ((int)0x803B),
        ALPHA8 = ((int)0x803C),
        ALPHA12 = ((int)0x803D),
        ALPHA16 = ((int)0x803E),
        RGB4 = ((int)0x804F),
        RGB5 = ((int)0x8050),
        RGB8 = ((int)0x8051),
        RGB10 = ((int)0x8052),
        RGB12 = ((int)0x8053),
        RGB16 = ((int)0x8054),
        RGBA2 = ((int)0x8055),
        RGBA4 = ((int)0x8056),
        RGB5_A1 = ((int)0x8057),
        RGBA8 = ((int)0x8058),
        RGB10_A2 = ((int)0x8059),
        RGBA12 = ((int)0x805A),
        RGBA16 = ((int)0x805B),
        DEPTH_COMPONENT16 = ((int)0x81a5),
        DEPTH_COMPONENT24 = ((int)0x81a6),
        DEPTH_COMPONENT32 = ((int)0x81a7),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        RG8 = ((int)0x822B),
        RG16 = ((int)0x822C),
        R16F = ((int)0x822D),
        R32F = ((int)0x822E),
        RG16F = ((int)0x822F),
        RG32F = ((int)0x8230),
        R8I = ((int)0x8231),
        R8UI = ((int)0x8232),
        R16I = ((int)0x8233),
        R16UI = ((int)0x8234),
        R32I = ((int)0x8235),
        R32UI = ((int)0x8236),
        RG8I = ((int)0x8237),
        RG8UI = ((int)0x8238),
        RG16I = ((int)0x8239),
        RG16UI = ((int)0x823A),
        RG32I = ((int)0x823B),
        RG32UI = ((int)0x823C),
        RGBA32F = ((int)0x8814),
        RGB32F = ((int)0x8815),
        RGBA16F = ((int)0x881A),
        RGB16F = ((int)0x881B),
        DEPTH24_STENCIL8 = ((int)0x88F0),
        R11F_G11F_B10F = ((int)0x8C3A),
        RGB9_E5 = ((int)0x8C3D),
        SRGB8 = ((int)0x8C41),
        SRGB8_ALPHA8 = ((int)0x8C43),
        DEPTH_COMPONENT32F = ((int)0x8CAC),
        DEPTH32F_STENCIL8 = ((int)0x8CAD),
        STENCIL_INDEX1 = ((int)0x8D46),
        STENCIL_INDEX1_EXT = ((int)0x8D46),
        STENCIL_INDEX4 = ((int)0x8D47),
        STENCIL_INDEX4_EXT = ((int)0x8D47),
        STENCIL_INDEX8 = ((int)0x8D48),
        STENCIL_INDEX8_EXT = ((int)0x8D48),
        STENCIL_INDEX16 = ((int)0x8D49),
        STENCIL_INDEX16_EXT = ((int)0x8D49),
        RGBA32UI = ((int)0x8D70),
        RGB32UI = ((int)0x8D71),
        RGBA16UI = ((int)0x8D76),
        RGB16UI = ((int)0x8D77),
        RGBA8UI = ((int)0x8D7C),
        RGB8UI = ((int)0x8D7D),
        RGBA32I = ((int)0x8D82),
        RGB32I = ((int)0x8D83),
        RGBA16I = ((int)0x8D88),
        RGB16I = ((int)0x8D89),
        RGBA8I = ((int)0x8D8E),
        RGB8I = ((int)0x8D8F),
    }

    public enum RenderbufferTarget : int
    {
        RENDERBUFFER = ((int)0x8D41),
        RENDERBUFFER_EXT = ((int)0x8D41),
    }

    public enum RenderingMode : int
    {
        RENDER = ((int)0x1C00),
        FEEDBACK = ((int)0x1C01),
        SELECT = ((int)0x1C02),
    }

    public enum SamplePatternSGIS : int
    {
        GL_1PASS_SGIS = ((int)0x80A1),
        GL_2PASS_0_SGIS = ((int)0x80A2),
        GL_2PASS_1_SGIS = ((int)0x80A3),
        GL_4PASS_0_SGIS = ((int)0x80A4),
        GL_4PASS_1_SGIS = ((int)0x80A5),
        GL_4PASS_2_SGIS = ((int)0x80A6),
        GL_4PASS_3_SGIS = ((int)0x80A7),
    }

    public enum SeparableTarget : int
    {
        SEPARABLE_2D = ((int)0x8012),
    }

    public enum SeparableTargetEXT : int
    {
        SEPARABLE_2D_EXT = ((int)0x8012),
    }

    public enum SGI_color_matrix : int
    {
        COLOR_MATRIX_SGI = ((int)0x80B1),
        COLOR_MATRIX_STACK_DEPTH_SGI = ((int)0x80B2),
        MAX_COLOR_MATRIX_STACK_DEPTH_SGI = ((int)0x80B3),
        POST_COLOR_MATRIX_RED_SCALE_SGI = ((int)0x80B4),
        POST_COLOR_MATRIX_GREEN_SCALE_SGI = ((int)0x80B5),
        POST_COLOR_MATRIX_BLUE_SCALE_SGI = ((int)0x80B6),
        POST_COLOR_MATRIX_ALPHA_SCALE_SGI = ((int)0x80B7),
        POST_COLOR_MATRIX_RED_BIAS_SGI = ((int)0x80B8),
        POST_COLOR_MATRIX_GREEN_BIAS_SGI = ((int)0x80B9),
        POST_COLOR_MATRIX_BLUE_BIAS_SGI = ((int)0x80BA),
        POST_COLOR_MATRIX_ALPHA_BIAS_SGI = ((int)0x80BB),
    }

    public enum SGI_color_table : int
    {
        COLOR_TABLE_SGI = ((int)0x80D0),
        POST_CONVOLUTION_COLOR_TABLE_SGI = ((int)0x80D1),
        POST_COLOR_MATRIX_COLOR_TABLE_SGI = ((int)0x80D2),
        PROXY_COLOR_TABLE_SGI = ((int)0x80D3),
        PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = ((int)0x80D4),
        PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = ((int)0x80D5),
        COLOR_TABLE_SCALE_SGI = ((int)0x80D6),
        COLOR_TABLE_BIAS_SGI = ((int)0x80D7),
        COLOR_TABLE_FORMAT_SGI = ((int)0x80D8),
        COLOR_TABLE_WIDTH_SGI = ((int)0x80D9),
        COLOR_TABLE_RED_SIZE_SGI = ((int)0x80DA),
        COLOR_TABLE_GREEN_SIZE_SGI = ((int)0x80DB),
        COLOR_TABLE_BLUE_SIZE_SGI = ((int)0x80DC),
        COLOR_TABLE_ALPHA_SIZE_SGI = ((int)0x80DD),
        COLOR_TABLE_LUMINANCE_SIZE_SGI = ((int)0x80DE),
        COLOR_TABLE_INTENSITY_SIZE_SGI = ((int)0x80DF),
    }

    public enum SGIS_multisample : int
    {
        MULTISAMPLE_SGIS = ((int)0x809D),
        SAMPLE_ALPHA_TO_MASK_SGIS = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE_SGIS = ((int)0x809F),
        SAMPLE_MASK_SGIS = ((int)0x80A0),
        GL_1PASS_SGIS = ((int)0x80A1),
        GL_2PASS_0_SGIS = ((int)0x80A2),
        GL_2PASS_1_SGIS = ((int)0x80A3),
        GL_4PASS_0_SGIS = ((int)0x80A4),
        GL_4PASS_1_SGIS = ((int)0x80A5),
        GL_4PASS_2_SGIS = ((int)0x80A6),
        GL_4PASS_3_SGIS = ((int)0x80A7),
        SAMPLE_BUFFERS_SGIS = ((int)0x80A8),
        SAMPLES_SGIS = ((int)0x80A9),
        SAMPLE_MASK_VALUE_SGIS = ((int)0x80AA),
        SAMPLE_MASK_INVERT_SGIS = ((int)0x80AB),
        SAMPLE_PATTERN_SGIS = ((int)0x80AC),
    }

    public enum SGIS_texture_border_clamp : int
    {
        CLAMP_TO_BORDER_SGIS = ((int)0x812D),
    }

    public enum SGIS_texture_edge_clamp : int
    {
        CLAMP_TO_EDGE_SGIS = ((int)0x812F),
    }

    public enum SGIS_texture_filter4 : int
    {
        FILTER4_SGIS = ((int)0x8146),
        TEXTURE_FILTER4_SIZE_SGIS = ((int)0x8147),
    }

    public enum SGIS_texture_lod : int
    {
        TEXTURE_MIN_LOD_SGIS = ((int)0x813A),
        TEXTURE_MAX_LOD_SGIS = ((int)0x813B),
        TEXTURE_BASE_LEVEL_SGIS = ((int)0x813C),
        TEXTURE_MAX_LEVEL_SGIS = ((int)0x813D),
    }

    public enum SGIS_texture4D : int
    {
        PACK_SKIP_VOLUMES_SGIS = ((int)0x8130),
        PACK_IMAGE_DEPTH_SGIS = ((int)0x8131),
        UNPACK_SKIP_VOLUMES_SGIS = ((int)0x8132),
        UNPACK_IMAGE_DEPTH_SGIS = ((int)0x8133),
        TEXTURE_4D_SGIS = ((int)0x8134),
        PROXY_TEXTURE_4D_SGIS = ((int)0x8135),
        TEXTURE_4DSIZE_SGIS = ((int)0x8136),
        TEXTURE_WRAP_Q_SGIS = ((int)0x8137),
        MAX_4D_TEXTURE_SIZE_SGIS = ((int)0x8138),
        TEXTURE_4D_BINDING_SGIS = ((int)0x814F),
    }

    public enum ShaderParameter : int
    {
        SHADER_TYPE = ((int)0x8B4F),
        DELETE_STATUS = ((int)0x8B80),
        COMPILE_STATUS = ((int)0x8B81),
        INFO_LOG_LENGTH = ((int)0x8B84),
        SHADER_SOURCE_LENGTH = ((int)0x8B88),
    }

    public enum ShaderType : int
    {
        FRAGMENT_SHADER = ((int)0x8B30),
        VERTEX_SHADER = ((int)0x8B31),
        GEOMETRY_SHADER = ((int)0x8DD9),
        GEOMETRY_SHADER_EXT = ((int)0x8DD9),
    }

    public enum ShadingModel : int
    {
        FLAT = ((int)0x1D00),
        SMOOTH = ((int)0x1D01),
    }

    public enum SizedInternalFormat : int
    {
        RGBA8 = ((int)0x8058),
        RGBA16 = ((int)0x805B),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        RG8 = ((int)0x822B),
        RG16 = ((int)0x822C),
        R16F = ((int)0x822D),
        R32F = ((int)0x822E),
        RG16F = ((int)0x822F),
        RG32F = ((int)0x8230),
        R8I = ((int)0x8231),
        R8UI = ((int)0x8232),
        R16I = ((int)0x8233),
        R16UI = ((int)0x8234),
        R32I = ((int)0x8235),
        R32UI = ((int)0x8236),
        RG8I = ((int)0x8237),
        RG8UI = ((int)0x8238),
        RG16I = ((int)0x8239),
        RG16UI = ((int)0x823A),
        RG32I = ((int)0x823B),
        RG32UI = ((int)0x823C),
        RGBA32F = ((int)0x8814),
        RGBA16F = ((int)0x881A),
        RGBA32UI = ((int)0x8D70),
        RGBA16UI = ((int)0x8D76),
        RGBA8UI = ((int)0x8D7C),
        RGBA32I = ((int)0x8D82),
        RGBA16I = ((int)0x8D88),
        RGBA8I = ((int)0x8D8E),
    }

    public enum StencilFace : int
    {
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        FRONT_AND_BACK = ((int)0x0408),
    }

    public enum StencilFunction : int
    {
        NEVER = ((int)0x0200),
        LESS = ((int)0x0201),
        EQUAL = ((int)0x0202),
        LEQUAL = ((int)0x0203),
        GREATER = ((int)0x0204),
        NOTEQUAL = ((int)0x0205),
        GEQUAL = ((int)0x0206),
        ALWAYS = ((int)0x0207),
    }

    public enum StencilOp : int
    {
        ZERO = ((int)0),
        INVERT = ((int)0x150A),
        KEEP = ((int)0x1E00),
        REPLACE = ((int)0x1E01),
        INCR = ((int)0x1E02),
        DECR = ((int)0x1E03),
        INCR_WRAP = ((int)0x8507),
        DECR_WRAP = ((int)0x8508),
    }

    public enum StringName : int
    {
        VENDOR = ((int)0x1F00),
        RENDERER = ((int)0x1F01),
        VERSION = ((int)0x1F02),
        EXTENSIONS = ((int)0x1F03),
        SHADING_LANGUAGE_VERSION = ((int)0x8B8C),
    }

    public enum TexCoordPointerType : int
    {
        SHORT = ((int)0x1402),
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

    public enum TextureBufferTarget : int
    {
        TEXTURE_BUFFER = ((int)0x8C2A),
    }

    public enum TextureCompareMode : int
    {
        COMPARE_R_TO_TEXTURE = ((int)0x884E),
        COMPARE_REF_TO_TEXTURE = ((int)0x884E),
    }

    public enum TextureCoordName : int
    {
        S = ((int)0x2000),
        T = ((int)0x2001),
        R = ((int)0x2002),
        Q = ((int)0x2003),
    }

    public enum TextureEnvMode : int
    {
        ADD = ((int)0x0104),
        BLEND = ((int)0x0BE2),
        REPLACE = ((int)0x1e01),
        MODULATE = ((int)0x2100),
        DECAL = ((int)0x2101),
        REPLACE_EXT = ((int)0x8062),
        COMBINE = ((int)0x8570),
    }

    public enum TextureEnvModeCombine : int
    {
        ADD = ((int)0x0104),
        REPLACE = ((int)0x1E01),
        MODULATE = ((int)0x2100),
        SUBTRACT = ((int)0x84E7),
        ADD_SIGNED = ((int)0x8574),
        INTERPOLATE = ((int)0x8575),
        DOT3_RGB = ((int)0x86AE),
        DOT3_RGBA = ((int)0x86AF),
    }

    public enum TextureEnvModeOperandAlpha : int
    {
        SRC_ALPHA = ((int)0x0302),
        ONE_MINUS_SRC_ALPHA = ((int)0x0303),
    }

    public enum TextureEnvModeOperandRgb : int
    {
        SRC_COLOR = ((int)0x0300),
        ONE_MINUS_SRC_COLOR = ((int)0x0301),
        SRC_ALPHA = ((int)0x0302),
        ONE_MINUS_SRC_ALPHA = ((int)0x0303),
    }

    public enum TextureEnvModePointSprite : int
    {
        FALSE = ((int)0),
        TRUE = ((int)1),
    }

    public enum TextureEnvModeScale : int
    {
        ONE = ((int)1),
        TWO = ((int)2),
        FOUR = ((int)4),
    }

    public enum TextureEnvModeSource : int
    {
        TEXTURE = ((int)0x1702),
        TEXTURE0 = ((int)0x84C0),
        TEXTURE1 = ((int)0x84C1),
        TEXTURE2 = ((int)0x84C2),
        TEXTURE3 = ((int)0x84C3),
        TEXTURE4 = ((int)0x84C4),
        TEXTURE5 = ((int)0x84C5),
        TEXTURE6 = ((int)0x84C6),
        TEXTURE7 = ((int)0x84C7),
        TEXTURE8 = ((int)0x84C8),
        TEXTURE9 = ((int)0x84C9),
        TEXTURE10 = ((int)0x84CA),
        TEXTURE11 = ((int)0x84CB),
        TEXTURE12 = ((int)0x84CC),
        TEXTURE13 = ((int)0x84CD),
        TEXTURE14 = ((int)0x84CE),
        TEXTURE15 = ((int)0x84CF),
        TEXTURE16 = ((int)0x84D0),
        TEXTURE17 = ((int)0x84D1),
        TEXTURE18 = ((int)0x84D2),
        TEXTURE19 = ((int)0x84D3),
        TEXTURE20 = ((int)0x84D4),
        TEXTURE21 = ((int)0x84D5),
        TEXTURE22 = ((int)0x84D6),
        TEXTURE23 = ((int)0x84D7),
        TEXTURE24 = ((int)0x84D8),
        TEXTURE25 = ((int)0x84D9),
        TEXTURE26 = ((int)0x84DA),
        TEXTURE27 = ((int)0x84DB),
        TEXTURE28 = ((int)0x84DC),
        TEXTURE29 = ((int)0x84DD),
        TEXTURE30 = ((int)0x84DE),
        TEXTURE31 = ((int)0x84DF),
        CONSTANT = ((int)0x8576),
        PRIMARY_COLOR = ((int)0x8577),
        PREVIOUS = ((int)0x8578),
    }

    public enum TextureEnvParameter : int
    {
        ALPHA_SCALE = ((int)0x0D1C),
        TEXTURE_ENV_MODE = ((int)0x2200),
        TEXTURE_ENV_COLOR = ((int)0x2201),
        TEXTURE_LOD_BIAS = ((int)0x8501),
        COMBINE_RGB = ((int)0x8571),
        COMBINE_ALPHA = ((int)0x8572),
        RGB_SCALE = ((int)0x8573),
        SOURCE0_RGB = ((int)0x8580),
        SRC1_RGB = ((int)0x8581),
        SRC2_RGB = ((int)0x8582),
        SRC0_ALPHA = ((int)0x8588),
        SRC1_ALPHA = ((int)0x8589),
        SRC2_ALPHA = ((int)0x858A),
        OPERAND0_RGB = ((int)0x8590),
        OPERAND1_RGB = ((int)0x8591),
        OPERAND2_RGB = ((int)0x8592),
        OPERAND0_ALPHA = ((int)0x8598),
        OPERAND1_ALPHA = ((int)0x8599),
        OPERAND2_ALPHA = ((int)0x859A),
        COORD_REPLACE = ((int)0x8862),
    }

    public enum TextureEnvTarget : int
    {
        TEXTURE_ENV = ((int)0x2300),
        TEXTURE_FILTER_CONTROL = ((int)0x8500),
        POINT_SPRITE = ((int)0x8861),
    }

    public enum TextureFilterFuncSGIS : int
    {
        FILTER4_SGIS = ((int)0x8146),
    }

    public enum TextureGenMode : int
    {
        EYE_LINEAR = ((int)0x2400),
        OBJECT_LINEAR = ((int)0x2401),
        SPHERE_MAP = ((int)0x2402),
        NORMAL_MAP = ((int)0x8511),
        REFLECTION_MAP = ((int)0x8512),
    }

    public enum TextureGenParameter : int
    {
        TEXTURE_GEN_MODE = ((int)0x2500),
        OBJECT_PLANE = ((int)0x2501),
        EYE_PLANE = ((int)0x2502),
    }

    public enum TextureMagFilter : int
    {
        NEAREST = ((int)0x2600),
        LINEAR = ((int)0x2601),
    }

    public enum TextureMinFilter : int
    {
        NEAREST = ((int)0x2600),
        LINEAR = ((int)0x2601),
        NEAREST_MIPMAP_NEAREST = ((int)0x2700),
        LINEAR_MIPMAP_NEAREST = ((int)0x2701),
        NEAREST_MIPMAP_LINEAR = ((int)0x2702),
        LINEAR_MIPMAP_LINEAR = ((int)0x2703),
    }

    public enum TextureParameterName : int
    {
        TEXTURE_BORDER_COLOR = ((int)0x1004),
        RED = ((int)0x1903),
        TEXTURE_MAG_FILTER = ((int)0x2800),
        TEXTURE_MIN_FILTER = ((int)0x2801),
        TEXTURE_WRAP_S = ((int)0x2802),
        TEXTURE_WRAP_T = ((int)0x2803),
        TEXTURE_PRIORITY = ((int)0x8066),
        TEXTURE_DEPTH = ((int)0x8071),
        TEXTURE_WRAP_R = ((int)0x8072),
        TEXTURE_WRAP_R_EXT = ((int)0x8072),
        TEXTURE_COMPARE_FAIL_VALUE = ((int)0x80BF),
        CLAMP_TO_BORDER = ((int)0x812D),
        CLAMP_TO_EDGE = ((int)0x812F),
        TEXTURE_MIN_LOD = ((int)0x813A),
        TEXTURE_MAX_LOD = ((int)0x813B),
        TEXTURE_BASE_LEVEL = ((int)0x813C),
        TEXTURE_MAX_LEVEL = ((int)0x813D),
        GENERATE_MIPMAP = ((int)0x8191),
        TEXTURE_LOD_BIAS = ((int)0x8501),
        DEPTH_TEXTURE_MODE = ((int)0x884B),
        TEXTURE_COMPARE_MODE = ((int)0x884C),
        TEXTURE_COMPARE_FUNC = ((int)0x884D),
    }

    public enum TextureTarget : int
    {
        TEXTURE_1D = ((int)0x0DE0),
        TEXTURE_2D = ((int)0x0DE1),
        PROXY_TEXTURE_1D = ((int)0x8063),
        PROXY_TEXTURE_2D = ((int)0x8064),
        TEXTURE_3D = ((int)0x806F),
        PROXY_TEXTURE_3D = ((int)0x8070),
        TEXTURE_MIN_LOD = ((int)0x813A),
        TEXTURE_MAX_LOD = ((int)0x813B),
        TEXTURE_BASE_LEVEL = ((int)0x813C),
        TEXTURE_MAX_LEVEL = ((int)0x813D),
        TEXTURE_RECTANGLE = ((int)0x84F5),
        TEXTURE_RECTANGLE_ARB = ((int)0x84F5),
        PROXY_TEXTURE_RECTANGLE = ((int)0x84F7),
        TEXTURE_CUBE_MAP = ((int)0x8513),
        TEXTURE_BINDING_CUBE_MAP = ((int)0x8514),
        TEXTURE_CUBE_MAP_POSITIVE_X = ((int)0x8515),
        TEXTURE_CUBE_MAP_NEGATIVE_X = ((int)0x8516),
        TEXTURE_CUBE_MAP_POSITIVE_Y = ((int)0x8517),
        TEXTURE_CUBE_MAP_NEGATIVE_Y = ((int)0x8518),
        TEXTURE_CUBE_MAP_POSITIVE_Z = ((int)0x8519),
        TEXTURE_CUBE_MAP_NEGATIVE_Z = ((int)0x851A),
        PROXY_TEXTURE_CUBE_MAP = ((int)0x851B),
        TEXTURE_1D_ARRAY = ((int)0x8C18),
        PROXY_TEXTURE_1D_ARRAY = ((int)0x8C19),
        TEXTURE_2D_ARRAY = ((int)0x8C1A),
        PROXY_TEXTURE_2D_ARRAY = ((int)0x8C1B),
        TEXTURE_BUFFER = ((int)0x8C2A),
        TEXTURE_2D_MULTISAMPLE = ((int)0x9100),
        PROXY_TEXTURE_2D_MULTISAMPLE = ((int)0x9101),
        TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102),
        PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9103),
    }

    public enum TextureTargetMultisample : int
    {
        TEXTURE_2D_MULTISAMPLE = ((int)0x9100),
        PROXY_TEXTURE_2D_MULTISAMPLE = ((int)0x9101),
        TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102),
        PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9103),
    }

    public enum TextureUnit : int
    {
        TEXTURE0 = ((int)0x84C0),
        TEXTURE1 = ((int)0x84C1),
        TEXTURE2 = ((int)0x84C2),
        TEXTURE3 = ((int)0x84C3),
        TEXTURE4 = ((int)0x84C4),
        TEXTURE5 = ((int)0x84C5),
        TEXTURE6 = ((int)0x84C6),
        TEXTURE7 = ((int)0x84C7),
        TEXTURE8 = ((int)0x84C8),
        TEXTURE9 = ((int)0x84C9),
        TEXTURE10 = ((int)0x84CA),
        TEXTURE11 = ((int)0x84CB),
        TEXTURE12 = ((int)0x84CC),
        TEXTURE13 = ((int)0x84CD),
        TEXTURE14 = ((int)0x84CE),
        TEXTURE15 = ((int)0x84CF),
        TEXTURE16 = ((int)0x84D0),
        TEXTURE17 = ((int)0x84D1),
        TEXTURE18 = ((int)0x84D2),
        TEXTURE19 = ((int)0x84D3),
        TEXTURE20 = ((int)0x84D4),
        TEXTURE21 = ((int)0x84D5),
        TEXTURE22 = ((int)0x84D6),
        TEXTURE23 = ((int)0x84D7),
        TEXTURE24 = ((int)0x84D8),
        TEXTURE25 = ((int)0x84D9),
        TEXTURE26 = ((int)0x84DA),
        TEXTURE27 = ((int)0x84DB),
        TEXTURE28 = ((int)0x84DC),
        TEXTURE29 = ((int)0x84DD),
        TEXTURE30 = ((int)0x84DE),
        TEXTURE31 = ((int)0x84DF),
    }

    public enum TextureWrapMode : int
    {
        CLAMP = ((int)0x2900),
        REPEAT = ((int)0x2901),
        CLAMP_TO_BORDER = ((int)0x812D),
        CLAMP_TO_EDGE = ((int)0x812F),
        MIRRORED_REPEAT = ((int)0x8370),
    }

    public enum TransformFeedbackMode : int
    {
        INTERLEAVED_ATTRIBS = ((int)0x8C8C),
        SEPARATE_ATTRIBS = ((int)0x8C8D),
    }

    public enum VERSION_1_1 : int
    {
        FALSE = ((int)0),
        NO_ERROR = ((int)0),
        NONE = ((int)0),
        ZERO = ((int)0),
        POINTS = ((int)0x0000),
        DEPTH_BUFFER_BIT = ((int)0x00000100),
        STENCIL_BUFFER_BIT = ((int)0x00000400),
        COLOR_BUFFER_BIT = ((int)0x00004000),
        LINES = ((int)0x0001),
        LINE_LOOP = ((int)0x0002),
        LINE_STRIP = ((int)0x0003),
        TRIANGLES = ((int)0x0004),
        TRIANGLE_STRIP = ((int)0x0005),
        TRIANGLE_FAN = ((int)0x0006),
        NEVER = ((int)0x0200),
        LESS = ((int)0x0201),
        EQUAL = ((int)0x0202),
        LEQUAL = ((int)0x0203),
        GREATER = ((int)0x0204),
        NOTEQUAL = ((int)0x0205),
        GEQUAL = ((int)0x0206),
        ALWAYS = ((int)0x0207),
        SRC_COLOR = ((int)0x0300),
        ONE_MINUS_SRC_COLOR = ((int)0x0301),
        SRC_ALPHA = ((int)0x0302),
        ONE_MINUS_SRC_ALPHA = ((int)0x0303),
        DST_ALPHA = ((int)0x0304),
        ONE_MINUS_DST_ALPHA = ((int)0x0305),
        DST_COLOR = ((int)0x0306),
        ONE_MINUS_DST_COLOR = ((int)0x0307),
        SRC_ALPHA_SATURATE = ((int)0x0308),
        FRONT_LEFT = ((int)0x0400),
        FRONT_RIGHT = ((int)0x0401),
        BACK_LEFT = ((int)0x0402),
        BACK_RIGHT = ((int)0x0403),
        FRONT = ((int)0x0404),
        BACK = ((int)0x0405),
        LEFT = ((int)0x0406),
        RIGHT = ((int)0x0407),
        FRONT_AND_BACK = ((int)0x0408),
        INVALID_ENUM = ((int)0x0500),
        INVALID_VALUE = ((int)0x0501),
        INVALID_OPERATION = ((int)0x0502),
        OUT_OF_MEMORY = ((int)0x0505),
        CW = ((int)0x0900),
        CCW = ((int)0x0901),
        POINT_SIZE = ((int)0x0B11),
        POINT_SIZE_RANGE = ((int)0x0B12),
        POINT_SIZE_GRANULARITY = ((int)0x0B13),
        LINE_SMOOTH = ((int)0x0B20),
        LINE_WIDTH = ((int)0x0B21),
        LINE_WIDTH_RANGE = ((int)0x0B22),
        LINE_WIDTH_GRANULARITY = ((int)0x0B23),
        POLYGON_SMOOTH = ((int)0x0B41),
        CULL_FACE = ((int)0x0B44),
        CULL_FACE_MODE = ((int)0x0B45),
        FRONT_FACE = ((int)0x0B46),
        DEPTH_RANGE = ((int)0x0B70),
        DEPTH_TEST = ((int)0x0B71),
        DEPTH_WRITEMASK = ((int)0x0B72),
        DEPTH_CLEAR_VALUE = ((int)0x0B73),
        DEPTH_FUNC = ((int)0x0B74),
        STENCIL_TEST = ((int)0x0B90),
        STENCIL_CLEAR_VALUE = ((int)0x0B91),
        STENCIL_FUNC = ((int)0x0B92),
        STENCIL_VALUE_MASK = ((int)0x0B93),
        STENCIL_FAIL = ((int)0x0B94),
        STENCIL_PASS_DEPTH_FAIL = ((int)0x0B95),
        STENCIL_PASS_DEPTH_PASS = ((int)0x0B96),
        STENCIL_REF = ((int)0x0B97),
        STENCIL_WRITEMASK = ((int)0x0B98),
        VIEWPORT = ((int)0x0BA2),
        DITHER = ((int)0x0BD0),
        BLEND_DST = ((int)0x0BE0),
        BLEND_SRC = ((int)0x0BE1),
        BLEND = ((int)0x0BE2),
        LOGIC_OP_MODE = ((int)0x0BF0),
        COLOR_LOGIC_OP = ((int)0x0BF2),
        DRAW_BUFFER = ((int)0x0C01),
        READ_BUFFER = ((int)0x0C02),
        SCISSOR_BOX = ((int)0x0C10),
        SCISSOR_TEST = ((int)0x0C11),
        COLOR_CLEAR_VALUE = ((int)0x0C22),
        COLOR_WRITEMASK = ((int)0x0C23),
        DOUBLEBUFFER = ((int)0x0C32),
        STEREO = ((int)0x0C33),
        LINE_SMOOTH_HINT = ((int)0x0C52),
        POLYGON_SMOOTH_HINT = ((int)0x0C53),
        UNPACK_SWAP_BYTES = ((int)0x0CF0),
        UNPACK_LSB_FIRST = ((int)0x0CF1),
        UNPACK_ROW_LENGTH = ((int)0x0CF2),
        UNPACK_SKIP_ROWS = ((int)0x0CF3),
        UNPACK_SKIP_PIXELS = ((int)0x0CF4),
        UNPACK_ALIGNMENT = ((int)0x0CF5),
        PACK_SWAP_BYTES = ((int)0x0D00),
        PACK_LSB_FIRST = ((int)0x0D01),
        PACK_ROW_LENGTH = ((int)0x0D02),
        PACK_SKIP_ROWS = ((int)0x0D03),
        PACK_SKIP_PIXELS = ((int)0x0D04),
        PACK_ALIGNMENT = ((int)0x0D05),
        MAX_TEXTURE_SIZE = ((int)0x0D33),
        MAX_VIEWPORT_DIMS = ((int)0x0D3A),
        SUBPIXEL_BITS = ((int)0x0D50),
        TEXTURE_1D = ((int)0x0DE0),
        TEXTURE_2D = ((int)0x0DE1),
        TEXTURE_WIDTH = ((int)0x1000),
        TEXTURE_HEIGHT = ((int)0x1001),
        TEXTURE_INTERNAL_FORMAT = ((int)0x1003),
        TEXTURE_BORDER_COLOR = ((int)0x1004),
        TEXTURE_BORDER = ((int)0x1005),
        DONT_CARE = ((int)0x1100),
        FASTEST = ((int)0x1101),
        NICEST = ((int)0x1102),
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        CLEAR = ((int)0x1500),
        AND = ((int)0x1501),
        AND_REVERSE = ((int)0x1502),
        COPY = ((int)0x1503),
        AND_INVERTED = ((int)0x1504),
        NOOP = ((int)0x1505),
        XOR = ((int)0x1506),
        OR = ((int)0x1507),
        NOR = ((int)0x1508),
        EQUIV = ((int)0x1509),
        INVERT = ((int)0x150A),
        OR_REVERSE = ((int)0x150B),
        COPY_INVERTED = ((int)0x150C),
        OR_INVERTED = ((int)0x150D),
        NAND = ((int)0x150E),
        SET = ((int)0x150F),
        TEXTURE = ((int)0x1702),
        COLOR = ((int)0x1800),
        DEPTH = ((int)0x1801),
        STENCIL = ((int)0x1802),
        STENCIL_INDEX = ((int)0x1901),
        DEPTH_COMPONENT = ((int)0x1902),
        RED = ((int)0x1903),
        GREEN = ((int)0x1904),
        BLUE = ((int)0x1905),
        ALPHA = ((int)0x1906),
        RGB = ((int)0x1907),
        RGBA = ((int)0x1908),
        POINT = ((int)0x1B00),
        LINE = ((int)0x1B01),
        FILL = ((int)0x1B02),
        KEEP = ((int)0x1E00),
        REPLACE = ((int)0x1E01),
        INCR = ((int)0x1E02),
        DECR = ((int)0x1E03),
        VENDOR = ((int)0x1F00),
        RENDERER = ((int)0x1F01),
        VERSION = ((int)0x1F02),
        EXTENSIONS = ((int)0x1F03),
        NEAREST = ((int)0x2600),
        LINEAR = ((int)0x2601),
        NEAREST_MIPMAP_NEAREST = ((int)0x2700),
        LINEAR_MIPMAP_NEAREST = ((int)0x2701),
        NEAREST_MIPMAP_LINEAR = ((int)0x2702),
        LINEAR_MIPMAP_LINEAR = ((int)0x2703),
        TEXTURE_MAG_FILTER = ((int)0x2800),
        TEXTURE_MIN_FILTER = ((int)0x2801),
        TEXTURE_WRAP_S = ((int)0x2802),
        TEXTURE_WRAP_T = ((int)0x2803),
        REPEAT = ((int)0x2901),
        POLYGON_OFFSET_UNITS = ((int)0x2A00),
        POLYGON_OFFSET_POINT = ((int)0x2A01),
        POLYGON_OFFSET_LINE = ((int)0x2A02),
        R3_G3_B2 = ((int)0x2A10),
        POLYGON_OFFSET_FILL = ((int)0x8037),
        POLYGON_OFFSET_FACTOR = ((int)0x8038),
        RGB4 = ((int)0x804F),
        RGB5 = ((int)0x8050),
        RGB8 = ((int)0x8051),
        RGB10 = ((int)0x8052),
        RGB12 = ((int)0x8053),
        RGB16 = ((int)0x8054),
        RGBA2 = ((int)0x8055),
        RGBA4 = ((int)0x8056),
        RGB5_A1 = ((int)0x8057),
        RGBA8 = ((int)0x8058),
        RGB10_A2 = ((int)0x8059),
        RGBA12 = ((int)0x805A),
        RGBA16 = ((int)0x805B),
        TEXTURE_RED_SIZE = ((int)0x805C),
        TEXTURE_GREEN_SIZE = ((int)0x805D),
        TEXTURE_BLUE_SIZE = ((int)0x805E),
        TEXTURE_ALPHA_SIZE = ((int)0x805F),
        PROXY_TEXTURE_1D = ((int)0x8063),
        PROXY_TEXTURE_2D = ((int)0x8064),
        TEXTURE_BINDING_1D = ((int)0x8068),
        TEXTURE_BINDING_2D = ((int)0x8069),
        ONE = ((int)1),
        TRUE = ((int)1),
    }

    public enum VERSION_1_1_DEPRECATED : int
    {
        CLIENT_PIXEL_STORE_BIT = ((int)0x00000001),
        CURRENT_BIT = ((int)0x00000001),
        CLIENT_VERTEX_ARRAY_BIT = ((int)0x00000002),
        POINT_BIT = ((int)0x00000002),
        LINE_BIT = ((int)0x00000004),
        POLYGON_BIT = ((int)0x00000008),
        POLYGON_STIPPLE_BIT = ((int)0x00000010),
        PIXEL_MODE_BIT = ((int)0x00000020),
        LIGHTING_BIT = ((int)0x00000040),
        FOG_BIT = ((int)0x00000080),
        ACCUM_BUFFER_BIT = ((int)0x00000200),
        VIEWPORT_BIT = ((int)0x00000800),
        TRANSFORM_BIT = ((int)0x00001000),
        ENABLE_BIT = ((int)0x00002000),
        HINT_BIT = ((int)0x00008000),
        EVAL_BIT = ((int)0x00010000),
        LIST_BIT = ((int)0x00020000),
        TEXTURE_BIT = ((int)0x00040000),
        QUADS = ((int)0x0007),
        QUAD_STRIP = ((int)0x0008),
        SCISSOR_BIT = ((int)0x00080000),
        POLYGON = ((int)0x0009),
        ACCUM = ((int)0x0100),
        LOAD = ((int)0x0101),
        RETURN = ((int)0x0102),
        MULT = ((int)0x0103),
        ADD = ((int)0x0104),
        AUX0 = ((int)0x0409),
        AUX1 = ((int)0x040A),
        AUX2 = ((int)0x040B),
        AUX3 = ((int)0x040C),
        STACK_OVERFLOW = ((int)0x0503),
        STACK_UNDERFLOW = ((int)0x0504),
        GL_2D = ((int)0x0600),
        GL_3D = ((int)0x0601),
        GL_3D_COLOR = ((int)0x0602),
        GL_3D_COLOR_TEXTURE = ((int)0x0603),
        GL_4D_COLOR_TEXTURE = ((int)0x0604),
        PASS_THROUGH_TOKEN = ((int)0x0700),
        POINT_TOKEN = ((int)0x0701),
        LINE_TOKEN = ((int)0x0702),
        POLYGON_TOKEN = ((int)0x0703),
        BITMAP_TOKEN = ((int)0x0704),
        DRAW_PIXEL_TOKEN = ((int)0x0705),
        COPY_PIXEL_TOKEN = ((int)0x0706),
        LINE_RESET_TOKEN = ((int)0x0707),
        EXP = ((int)0x0800),
        EXP2 = ((int)0x0801),
        COEFF = ((int)0x0A00),
        ORDER = ((int)0x0A01),
        DOMAIN = ((int)0x0A02),
        CURRENT_COLOR = ((int)0x0B00),
        CURRENT_INDEX = ((int)0x0B01),
        CURRENT_NORMAL = ((int)0x0B02),
        CURRENT_TEXTURE_COORDS = ((int)0x0B03),
        CURRENT_RASTER_COLOR = ((int)0x0B04),
        CURRENT_RASTER_INDEX = ((int)0x0B05),
        CURRENT_RASTER_TEXTURE_COORDS = ((int)0x0B06),
        CURRENT_RASTER_POSITION = ((int)0x0B07),
        CURRENT_RASTER_POSITION_VALID = ((int)0x0B08),
        CURRENT_RASTER_DISTANCE = ((int)0x0B09),
        POINT_SMOOTH = ((int)0x0B10),
        LINE_STIPPLE = ((int)0x0B24),
        LINE_STIPPLE_PATTERN = ((int)0x0B25),
        LINE_STIPPLE_REPEAT = ((int)0x0B26),
        LIST_MODE = ((int)0x0B30),
        MAX_LIST_NESTING = ((int)0x0B31),
        LIST_BASE = ((int)0x0B32),
        LIST_INDEX = ((int)0x0B33),
        POLYGON_MODE = ((int)0x0B40),
        POLYGON_STIPPLE = ((int)0x0B42),
        EDGE_FLAG = ((int)0x0B43),
        LIGHTING = ((int)0x0B50),
        LIGHT_MODEL_LOCAL_VIEWER = ((int)0x0B51),
        LIGHT_MODEL_TWO_SIDE = ((int)0x0B52),
        LIGHT_MODEL_AMBIENT = ((int)0x0B53),
        SHADE_MODEL = ((int)0x0B54),
        COLOR_MATERIAL_FACE = ((int)0x0B55),
        COLOR_MATERIAL_PARAMETER = ((int)0x0B56),
        COLOR_MATERIAL = ((int)0x0B57),
        FOG = ((int)0x0B60),
        FOG_INDEX = ((int)0x0B61),
        FOG_DENSITY = ((int)0x0B62),
        FOG_START = ((int)0x0B63),
        FOG_END = ((int)0x0B64),
        FOG_MODE = ((int)0x0B65),
        FOG_COLOR = ((int)0x0B66),
        ACCUM_CLEAR_VALUE = ((int)0x0B80),
        MATRIX_MODE = ((int)0x0BA0),
        NORMALIZE = ((int)0x0BA1),
        MODELVIEW_STACK_DEPTH = ((int)0x0BA3),
        PROJECTION_STACK_DEPTH = ((int)0x0BA4),
        TEXTURE_STACK_DEPTH = ((int)0x0BA5),
        MODELVIEW_MATRIX = ((int)0x0BA6),
        PROJECTION_MATRIX = ((int)0x0BA7),
        TEXTURE_MATRIX = ((int)0x0BA8),
        ATTRIB_STACK_DEPTH = ((int)0x0BB0),
        CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0BB1),
        ALPHA_TEST = ((int)0x0BC0),
        ALPHA_TEST_FUNC = ((int)0x0BC1),
        ALPHA_TEST_REF = ((int)0x0BC2),
        INDEX_LOGIC_OP = ((int)0x0BF1),
        LOGIC_OP = ((int)0x0BF1),
        AUX_BUFFERS = ((int)0x0C00),
        INDEX_CLEAR_VALUE = ((int)0x0C20),
        INDEX_WRITEMASK = ((int)0x0C21),
        INDEX_MODE = ((int)0x0C30),
        RGBA_MODE = ((int)0x0C31),
        RENDER_MODE = ((int)0x0C40),
        PERSPECTIVE_CORRECTION_HINT = ((int)0x0C50),
        POINT_SMOOTH_HINT = ((int)0x0C51),
        FOG_HINT = ((int)0x0C54),
        TEXTURE_GEN_S = ((int)0x0C60),
        TEXTURE_GEN_T = ((int)0x0C61),
        TEXTURE_GEN_R = ((int)0x0C62),
        TEXTURE_GEN_Q = ((int)0x0C63),
        PIXEL_MAP_I_TO_I = ((int)0x0C70),
        PIXEL_MAP_S_TO_S = ((int)0x0C71),
        PIXEL_MAP_I_TO_R = ((int)0x0C72),
        PIXEL_MAP_I_TO_G = ((int)0x0C73),
        PIXEL_MAP_I_TO_B = ((int)0x0C74),
        PIXEL_MAP_I_TO_A = ((int)0x0C75),
        PIXEL_MAP_R_TO_R = ((int)0x0C76),
        PIXEL_MAP_G_TO_G = ((int)0x0C77),
        PIXEL_MAP_B_TO_B = ((int)0x0C78),
        PIXEL_MAP_A_TO_A = ((int)0x0C79),
        PIXEL_MAP_I_TO_I_SIZE = ((int)0x0CB0),
        PIXEL_MAP_S_TO_S_SIZE = ((int)0x0CB1),
        PIXEL_MAP_I_TO_R_SIZE = ((int)0x0CB2),
        PIXEL_MAP_I_TO_G_SIZE = ((int)0x0CB3),
        PIXEL_MAP_I_TO_B_SIZE = ((int)0x0CB4),
        PIXEL_MAP_I_TO_A_SIZE = ((int)0x0CB5),
        PIXEL_MAP_R_TO_R_SIZE = ((int)0x0CB6),
        PIXEL_MAP_G_TO_G_SIZE = ((int)0x0CB7),
        PIXEL_MAP_B_TO_B_SIZE = ((int)0x0CB8),
        PIXEL_MAP_A_TO_A_SIZE = ((int)0x0CB9),
        MAP_COLOR = ((int)0x0D10),
        MAP_STENCIL = ((int)0x0D11),
        INDEX_SHIFT = ((int)0x0D12),
        INDEX_OFFSET = ((int)0x0D13),
        RED_SCALE = ((int)0x0D14),
        RED_BIAS = ((int)0x0D15),
        ZOOM_X = ((int)0x0D16),
        ZOOM_Y = ((int)0x0D17),
        GREEN_SCALE = ((int)0x0D18),
        GREEN_BIAS = ((int)0x0D19),
        BLUE_SCALE = ((int)0x0D1A),
        BLUE_BIAS = ((int)0x0D1B),
        ALPHA_SCALE = ((int)0x0D1C),
        ALPHA_BIAS = ((int)0x0D1D),
        DEPTH_SCALE = ((int)0x0D1E),
        DEPTH_BIAS = ((int)0x0D1F),
        MAX_EVAL_ORDER = ((int)0x0D30),
        MAX_LIGHTS = ((int)0x0D31),
        MAX_CLIP_PLANES = ((int)0x0D32),
        MAX_PIXEL_MAP_TABLE = ((int)0x0D34),
        MAX_ATTRIB_STACK_DEPTH = ((int)0x0D35),
        MAX_MODELVIEW_STACK_DEPTH = ((int)0x0D36),
        MAX_NAME_STACK_DEPTH = ((int)0x0D37),
        MAX_PROJECTION_STACK_DEPTH = ((int)0x0D38),
        MAX_TEXTURE_STACK_DEPTH = ((int)0x0D39),
        MAX_CLIENT_ATTRIB_STACK_DEPTH = ((int)0x0D3B),
        INDEX_BITS = ((int)0x0D51),
        RED_BITS = ((int)0x0D52),
        GREEN_BITS = ((int)0x0D53),
        BLUE_BITS = ((int)0x0D54),
        ALPHA_BITS = ((int)0x0D55),
        DEPTH_BITS = ((int)0x0D56),
        STENCIL_BITS = ((int)0x0D57),
        ACCUM_RED_BITS = ((int)0x0D58),
        ACCUM_GREEN_BITS = ((int)0x0D59),
        ACCUM_BLUE_BITS = ((int)0x0D5A),
        ACCUM_ALPHA_BITS = ((int)0x0D5B),
        NAME_STACK_DEPTH = ((int)0x0D70),
        AUTO_NORMAL = ((int)0x0D80),
        MAP1_COLOR_4 = ((int)0x0D90),
        MAP1_INDEX = ((int)0x0D91),
        MAP1_NORMAL = ((int)0x0D92),
        MAP1_TEXTURE_COORD_1 = ((int)0x0D93),
        MAP1_TEXTURE_COORD_2 = ((int)0x0D94),
        MAP1_TEXTURE_COORD_3 = ((int)0x0D95),
        MAP1_TEXTURE_COORD_4 = ((int)0x0D96),
        MAP1_VERTEX_3 = ((int)0x0D97),
        MAP1_VERTEX_4 = ((int)0x0D98),
        MAP2_COLOR_4 = ((int)0x0DB0),
        MAP2_INDEX = ((int)0x0DB1),
        MAP2_NORMAL = ((int)0x0DB2),
        MAP2_TEXTURE_COORD_1 = ((int)0x0DB3),
        MAP2_TEXTURE_COORD_2 = ((int)0x0DB4),
        MAP2_TEXTURE_COORD_3 = ((int)0x0DB5),
        MAP2_TEXTURE_COORD_4 = ((int)0x0DB6),
        MAP2_VERTEX_3 = ((int)0x0DB7),
        MAP2_VERTEX_4 = ((int)0x0DB8),
        MAP1_GRID_DOMAIN = ((int)0x0DD0),
        MAP1_GRID_SEGMENTS = ((int)0x0DD1),
        MAP2_GRID_DOMAIN = ((int)0x0DD2),
        MAP2_GRID_SEGMENTS = ((int)0x0DD3),
        FEEDBACK_BUFFER_POINTER = ((int)0x0DF0),
        FEEDBACK_BUFFER_SIZE = ((int)0x0DF1),
        FEEDBACK_BUFFER_TYPE = ((int)0x0DF2),
        SELECTION_BUFFER_POINTER = ((int)0x0DF3),
        SELECTION_BUFFER_SIZE = ((int)0x0DF4),
        TEXTURE_COMPONENTS = ((int)0x1003),
        AMBIENT = ((int)0x1200),
        DIFFUSE = ((int)0x1201),
        SPECULAR = ((int)0x1202),
        POSITION = ((int)0x1203),
        SPOT_DIRECTION = ((int)0x1204),
        SPOT_EXPONENT = ((int)0x1205),
        SPOT_CUTOFF = ((int)0x1206),
        CONSTANT_ATTENUATION = ((int)0x1207),
        LINEAR_ATTENUATION = ((int)0x1208),
        QUADRATIC_ATTENUATION = ((int)0x1209),
        COMPILE = ((int)0x1300),
        COMPILE_AND_EXECUTE = ((int)0x1301),
        GL_2_BYTES = ((int)0x1407),
        GL_3_BYTES = ((int)0x1408),
        GL_4_BYTES = ((int)0x1409),
        EMISSION = ((int)0x1600),
        SHININESS = ((int)0x1601),
        AMBIENT_AND_DIFFUSE = ((int)0x1602),
        COLOR_INDEXES = ((int)0x1603),
        MODELVIEW = ((int)0x1700),
        PROJECTION = ((int)0x1701),
        COLOR_INDEX = ((int)0x1900),
        LUMINANCE = ((int)0x1909),
        LUMINANCE_ALPHA = ((int)0x190A),
        BITMAP = ((int)0x1A00),
        RENDER = ((int)0x1C00),
        FEEDBACK = ((int)0x1C01),
        SELECT = ((int)0x1C02),
        FLAT = ((int)0x1D00),
        SMOOTH = ((int)0x1D01),
        S = ((int)0x2000),
        T = ((int)0x2001),
        R = ((int)0x2002),
        Q = ((int)0x2003),
        MODULATE = ((int)0x2100),
        DECAL = ((int)0x2101),
        TEXTURE_ENV_MODE = ((int)0x2200),
        TEXTURE_ENV_COLOR = ((int)0x2201),
        TEXTURE_ENV = ((int)0x2300),
        EYE_LINEAR = ((int)0x2400),
        OBJECT_LINEAR = ((int)0x2401),
        SPHERE_MAP = ((int)0x2402),
        TEXTURE_GEN_MODE = ((int)0x2500),
        OBJECT_PLANE = ((int)0x2501),
        EYE_PLANE = ((int)0x2502),
        CLAMP = ((int)0x2900),
        V2F = ((int)0x2A20),
        V3F = ((int)0x2A21),
        C4UB_V2F = ((int)0x2A22),
        C4UB_V3F = ((int)0x2A23),
        C3F_V3F = ((int)0x2A24),
        N3F_V3F = ((int)0x2A25),
        C4F_N3F_V3F = ((int)0x2A26),
        T2F_V3F = ((int)0x2A27),
        T4F_V4F = ((int)0x2A28),
        T2F_C4UB_V3F = ((int)0x2A29),
        T2F_C3F_V3F = ((int)0x2A2A),
        T2F_N3F_V3F = ((int)0x2A2B),
        T2F_C4F_N3F_V3F = ((int)0x2A2C),
        T4F_C4F_N3F_V4F = ((int)0x2A2D),
        CLIP_PLANE0 = ((int)0x3000),
        CLIP_PLANE1 = ((int)0x3001),
        CLIP_PLANE2 = ((int)0x3002),
        CLIP_PLANE3 = ((int)0x3003),
        CLIP_PLANE4 = ((int)0x3004),
        CLIP_PLANE5 = ((int)0x3005),
        LIGHT0 = ((int)0x4000),
        LIGHT1 = ((int)0x4001),
        LIGHT2 = ((int)0x4002),
        LIGHT3 = ((int)0x4003),
        LIGHT4 = ((int)0x4004),
        LIGHT5 = ((int)0x4005),
        LIGHT6 = ((int)0x4006),
        LIGHT7 = ((int)0x4007),
        ALPHA4 = ((int)0x803B),
        ALPHA8 = ((int)0x803C),
        ALPHA12 = ((int)0x803D),
        ALPHA16 = ((int)0x803E),
        LUMINANCE4 = ((int)0x803F),
        LUMINANCE8 = ((int)0x8040),
        LUMINANCE12 = ((int)0x8041),
        LUMINANCE16 = ((int)0x8042),
        LUMINANCE4_ALPHA4 = ((int)0x8043),
        LUMINANCE6_ALPHA2 = ((int)0x8044),
        LUMINANCE8_ALPHA8 = ((int)0x8045),
        LUMINANCE12_ALPHA4 = ((int)0x8046),
        LUMINANCE12_ALPHA12 = ((int)0x8047),
        LUMINANCE16_ALPHA16 = ((int)0x8048),
        INTENSITY = ((int)0x8049),
        INTENSITY4 = ((int)0x804A),
        INTENSITY8 = ((int)0x804B),
        INTENSITY12 = ((int)0x804C),
        INTENSITY16 = ((int)0x804D),
        TEXTURE_LUMINANCE_SIZE = ((int)0x8060),
        TEXTURE_INTENSITY_SIZE = ((int)0x8061),
        TEXTURE_PRIORITY = ((int)0x8066),
        TEXTURE_RESIDENT = ((int)0x8067),
        VERTEX_ARRAY = ((int)0x8074),
        NORMAL_ARRAY = ((int)0x8075),
        COLOR_ARRAY = ((int)0x8076),
        INDEX_ARRAY = ((int)0x8077),
        TEXTURE_COORD_ARRAY = ((int)0x8078),
        EDGE_FLAG_ARRAY = ((int)0x8079),
        VERTEX_ARRAY_SIZE = ((int)0x807A),
        VERTEX_ARRAY_TYPE = ((int)0x807B),
        VERTEX_ARRAY_STRIDE = ((int)0x807C),
        NORMAL_ARRAY_TYPE = ((int)0x807E),
        NORMAL_ARRAY_STRIDE = ((int)0x807F),
        COLOR_ARRAY_SIZE = ((int)0x8081),
        COLOR_ARRAY_TYPE = ((int)0x8082),
        COLOR_ARRAY_STRIDE = ((int)0x8083),
        INDEX_ARRAY_TYPE = ((int)0x8085),
        INDEX_ARRAY_STRIDE = ((int)0x8086),
        TEXTURE_COORD_ARRAY_SIZE = ((int)0x8088),
        TEXTURE_COORD_ARRAY_TYPE = ((int)0x8089),
        TEXTURE_COORD_ARRAY_STRIDE = ((int)0x808A),
        EDGE_FLAG_ARRAY_STRIDE = ((int)0x808C),
        VERTEX_ARRAY_POINTER = ((int)0x808E),
        NORMAL_ARRAY_POINTER = ((int)0x808F),
        COLOR_ARRAY_POINTER = ((int)0x8090),
        INDEX_ARRAY_POINTER = ((int)0x8091),
        TEXTURE_COORD_ARRAY_POINTER = ((int)0x8092),
        EDGE_FLAG_ARRAY_POINTER = ((int)0x8093),
        ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF),
        CLIENT_ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF),
    }

    public enum VERSION_1_2 : int
    {
        SMOOTH_POINT_SIZE_RANGE = ((int)0x0B12),
        SMOOTH_POINT_SIZE_GRANULARITY = ((int)0x0B13),
        SMOOTH_LINE_WIDTH_RANGE = ((int)0x0B22),
        SMOOTH_LINE_WIDTH_GRANULARITY = ((int)0x0B23),
        CONSTANT_COLOR = ((int)0x8001),
        ONE_MINUS_CONSTANT_COLOR = ((int)0x8002),
        CONSTANT_ALPHA = ((int)0x8003),
        ONE_MINUS_CONSTANT_ALPHA = ((int)0x8004),
        BLEND_COLOR = ((int)0x8005),
        CONVOLUTION_1D = ((int)0x8010),
        CONVOLUTION_2D = ((int)0x8011),
        SEPARABLE_2D = ((int)0x8012),
        CONVOLUTION_BORDER_MODE = ((int)0x8013),
        CONVOLUTION_FILTER_SCALE = ((int)0x8014),
        CONVOLUTION_FILTER_BIAS = ((int)0x8015),
        REDUCE = ((int)0x8016),
        CONVOLUTION_FORMAT = ((int)0x8017),
        CONVOLUTION_WIDTH = ((int)0x8018),
        CONVOLUTION_HEIGHT = ((int)0x8019),
        MAX_CONVOLUTION_WIDTH = ((int)0x801A),
        MAX_CONVOLUTION_HEIGHT = ((int)0x801B),
        POST_CONVOLUTION_RED_SCALE = ((int)0x801C),
        POST_CONVOLUTION_GREEN_SCALE = ((int)0x801D),
        POST_CONVOLUTION_BLUE_SCALE = ((int)0x801E),
        POST_CONVOLUTION_ALPHA_SCALE = ((int)0x801F),
        POST_CONVOLUTION_RED_BIAS = ((int)0x8020),
        POST_CONVOLUTION_GREEN_BIAS = ((int)0x8021),
        POST_CONVOLUTION_BLUE_BIAS = ((int)0x8022),
        POST_CONVOLUTION_ALPHA_BIAS = ((int)0x8023),
        HISTOGRAM = ((int)0x8024),
        PROXY_HISTOGRAM = ((int)0x8025),
        HISTOGRAM_WIDTH = ((int)0x8026),
        HISTOGRAM_FORMAT = ((int)0x8027),
        HISTOGRAM_RED_SIZE = ((int)0x8028),
        HISTOGRAM_GREEN_SIZE = ((int)0x8029),
        HISTOGRAM_BLUE_SIZE = ((int)0x802A),
        HISTOGRAM_ALPHA_SIZE = ((int)0x802B),
        HISTOGRAM_SINK = ((int)0x802D),
        MINMAX = ((int)0x802E),
        MINMAX_FORMAT = ((int)0x802F),
        MINMAX_SINK = ((int)0x8030),
        TABLE_TOO_LARGE = ((int)0x8031),
        UNSIGNED_BYTE_3_3_2 = ((int)0x8032),
        UNSIGNED_SHORT_4_4_4_4 = ((int)0x8033),
        UNSIGNED_SHORT_5_5_5_1 = ((int)0x8034),
        UNSIGNED_INT_8_8_8_8 = ((int)0x8035),
        UNSIGNED_INT_10_10_10_2 = ((int)0x8036),
        RESCALE_NORMAL = ((int)0x803A),
        TEXTURE_BINDING_3D = ((int)0x806A),
        PACK_SKIP_IMAGES = ((int)0x806B),
        PACK_IMAGE_HEIGHT = ((int)0x806C),
        UNPACK_SKIP_IMAGES = ((int)0x806D),
        UNPACK_IMAGE_HEIGHT = ((int)0x806E),
        TEXTURE_3D = ((int)0x806F),
        PROXY_TEXTURE_3D = ((int)0x8070),
        TEXTURE_DEPTH = ((int)0x8071),
        TEXTURE_WRAP_R = ((int)0x8072),
        MAX_3D_TEXTURE_SIZE = ((int)0x8073),
        COLOR_MATRIX = ((int)0x80B1),
        COLOR_MATRIX_STACK_DEPTH = ((int)0x80B2),
        MAX_COLOR_MATRIX_STACK_DEPTH = ((int)0x80B3),
        POST_COLOR_MATRIX_RED_SCALE = ((int)0x80B4),
        POST_COLOR_MATRIX_GREEN_SCALE = ((int)0x80B5),
        POST_COLOR_MATRIX_BLUE_SCALE = ((int)0x80B6),
        POST_COLOR_MATRIX_ALPHA_SCALE = ((int)0x80B7),
        POST_COLOR_MATRIX_RED_BIAS = ((int)0x80B8),
        POST_COLOR_MATRIX_GREEN_BIAS = ((int)0x80B9),
        POST_COLOR_MATRIX_BLUE_BIAS = ((int)0x80BA),
        POST_COLOR_MATRIX_ALPHA_BIAS = ((int)0x80BB),
        COLOR_TABLE = ((int)0x80D0),
        POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D1),
        POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D2),
        PROXY_COLOR_TABLE = ((int)0x80D3),
        PROXY_POST_CONVOLUTION_COLOR_TABLE = ((int)0x80D4),
        PROXY_POST_COLOR_MATRIX_COLOR_TABLE = ((int)0x80D5),
        COLOR_TABLE_SCALE = ((int)0x80D6),
        COLOR_TABLE_BIAS = ((int)0x80D7),
        COLOR_TABLE_FORMAT = ((int)0x80D8),
        COLOR_TABLE_WIDTH = ((int)0x80D9),
        COLOR_TABLE_RED_SIZE = ((int)0x80DA),
        COLOR_TABLE_GREEN_SIZE = ((int)0x80DB),
        COLOR_TABLE_BLUE_SIZE = ((int)0x80DC),
        COLOR_TABLE_ALPHA_SIZE = ((int)0x80DD),
        COLOR_TABLE_LUMINANCE_SIZE = ((int)0x80DE),
        COLOR_TABLE_INTENSITY_SIZE = ((int)0x80DF),
        BGR = ((int)0x80E0),
        BGRA = ((int)0x80E1),
        MAX_ELEMENTS_VERTICES = ((int)0x80E8),
        MAX_ELEMENTS_INDICES = ((int)0x80E9),
        CLAMP_TO_EDGE = ((int)0x812F),
        TEXTURE_MIN_LOD = ((int)0x813A),
        TEXTURE_MAX_LOD = ((int)0x813B),
        TEXTURE_BASE_LEVEL = ((int)0x813C),
        TEXTURE_MAX_LEVEL = ((int)0x813D),
        CONSTANT_BORDER = ((int)0x8151),
        REPLICATE_BORDER = ((int)0x8153),
        CONVOLUTION_BORDER_COLOR = ((int)0x8154),
        LIGHT_MODEL_COLOR_CONTROL = ((int)0x81F8),
        SINGLE_COLOR = ((int)0x81F9),
        SEPARATE_SPECULAR_COLOR = ((int)0x81FA),
        UNSIGNED_BYTE_2_3_3_REV = ((int)0x8362),
        UNSIGNED_SHORT_5_6_5 = ((int)0x8363),
        UNSIGNED_SHORT_5_6_5_REV = ((int)0x8364),
        UNSIGNED_SHORT_4_4_4_4_REV = ((int)0x8365),
        UNSIGNED_SHORT_1_5_5_5_REV = ((int)0x8366),
        UNSIGNED_INT_8_8_8_8_REV = ((int)0x8367),
        UNSIGNED_INT_2_10_10_10_REV = ((int)0x8368),
        ALIASED_POINT_SIZE_RANGE = ((int)0x846D),
        ALIASED_LINE_WIDTH_RANGE = ((int)0x846E),
    }

    public enum VERSION_1_2_DEPRECATED : int
    {
        RESCALE_NORMAL = ((int)0x803A),
        LIGHT_MODEL_COLOR_CONTROL = ((int)0x81F8),
        SINGLE_COLOR = ((int)0x81F9),
        SEPARATE_SPECULAR_COLOR = ((int)0x81FA),
        ALIASED_POINT_SIZE_RANGE = ((int)0x846D),
    }

    public enum VERSION_1_3 : int
    {
        MULTISAMPLE = ((int)0x809D),
        SAMPLE_ALPHA_TO_COVERAGE = ((int)0x809E),
        SAMPLE_ALPHA_TO_ONE = ((int)0x809F),
        SAMPLE_COVERAGE = ((int)0x80A0),
        SAMPLE_BUFFERS = ((int)0x80A8),
        SAMPLES = ((int)0x80A9),
        SAMPLE_COVERAGE_VALUE = ((int)0x80AA),
        SAMPLE_COVERAGE_INVERT = ((int)0x80AB),
        CLAMP_TO_BORDER = ((int)0x812D),
        TEXTURE0 = ((int)0x84C0),
        TEXTURE1 = ((int)0x84C1),
        TEXTURE2 = ((int)0x84C2),
        TEXTURE3 = ((int)0x84C3),
        TEXTURE4 = ((int)0x84C4),
        TEXTURE5 = ((int)0x84C5),
        TEXTURE6 = ((int)0x84C6),
        TEXTURE7 = ((int)0x84C7),
        TEXTURE8 = ((int)0x84C8),
        TEXTURE9 = ((int)0x84C9),
        TEXTURE10 = ((int)0x84CA),
        TEXTURE11 = ((int)0x84CB),
        TEXTURE12 = ((int)0x84CC),
        TEXTURE13 = ((int)0x84CD),
        TEXTURE14 = ((int)0x84CE),
        TEXTURE15 = ((int)0x84CF),
        TEXTURE16 = ((int)0x84D0),
        TEXTURE17 = ((int)0x84D1),
        TEXTURE18 = ((int)0x84D2),
        TEXTURE19 = ((int)0x84D3),
        TEXTURE20 = ((int)0x84D4),
        TEXTURE21 = ((int)0x84D5),
        TEXTURE22 = ((int)0x84D6),
        TEXTURE23 = ((int)0x84D7),
        TEXTURE24 = ((int)0x84D8),
        TEXTURE25 = ((int)0x84D9),
        TEXTURE26 = ((int)0x84DA),
        TEXTURE27 = ((int)0x84DB),
        TEXTURE28 = ((int)0x84DC),
        TEXTURE29 = ((int)0x84DD),
        TEXTURE30 = ((int)0x84DE),
        TEXTURE31 = ((int)0x84DF),
        ACTIVE_TEXTURE = ((int)0x84E0),
        COMPRESSED_RGB = ((int)0x84ED),
        COMPRESSED_RGBA = ((int)0x84EE),
        TEXTURE_COMPRESSION_HINT = ((int)0x84EF),
        TEXTURE_CUBE_MAP = ((int)0x8513),
        TEXTURE_BINDING_CUBE_MAP = ((int)0x8514),
        TEXTURE_CUBE_MAP_POSITIVE_X = ((int)0x8515),
        TEXTURE_CUBE_MAP_NEGATIVE_X = ((int)0x8516),
        TEXTURE_CUBE_MAP_POSITIVE_Y = ((int)0x8517),
        TEXTURE_CUBE_MAP_NEGATIVE_Y = ((int)0x8518),
        TEXTURE_CUBE_MAP_POSITIVE_Z = ((int)0x8519),
        TEXTURE_CUBE_MAP_NEGATIVE_Z = ((int)0x851A),
        PROXY_TEXTURE_CUBE_MAP = ((int)0x851B),
        MAX_CUBE_MAP_TEXTURE_SIZE = ((int)0x851C),
        TEXTURE_COMPRESSED_IMAGE_SIZE = ((int)0x86A0),
        TEXTURE_COMPRESSED = ((int)0x86A1),
        NUM_COMPRESSED_TEXTURE_FORMATS = ((int)0x86A2),
        COMPRESSED_TEXTURE_FORMATS = ((int)0x86A3),
    }

    public enum VERSION_1_3_DEPRECATED : int
    {
        MULTISAMPLE_BIT = ((int)0x20000000),
        CLIENT_ACTIVE_TEXTURE = ((int)0x84E1),
        MAX_TEXTURE_UNITS = ((int)0x84E2),
        TRANSPOSE_MODELVIEW_MATRIX = ((int)0x84E3),
        TRANSPOSE_PROJECTION_MATRIX = ((int)0x84E4),
        TRANSPOSE_TEXTURE_MATRIX = ((int)0x84E5),
        TRANSPOSE_COLOR_MATRIX = ((int)0x84E6),
        SUBTRACT = ((int)0x84E7),
        COMPRESSED_ALPHA = ((int)0x84E9),
        COMPRESSED_LUMINANCE = ((int)0x84EA),
        COMPRESSED_LUMINANCE_ALPHA = ((int)0x84EB),
        COMPRESSED_INTENSITY = ((int)0x84EC),
        NORMAL_MAP = ((int)0x8511),
        REFLECTION_MAP = ((int)0x8512),
        COMBINE = ((int)0x8570),
        COMBINE_RGB = ((int)0x8571),
        COMBINE_ALPHA = ((int)0x8572),
        RGB_SCALE = ((int)0x8573),
        ADD_SIGNED = ((int)0x8574),
        INTERPOLATE = ((int)0x8575),
        CONSTANT = ((int)0x8576),
        PRIMARY_COLOR = ((int)0x8577),
        PREVIOUS = ((int)0x8578),
        SOURCE0_RGB = ((int)0x8580),
        SOURCE1_RGB = ((int)0x8581),
        SOURCE2_RGB = ((int)0x8582),
        SOURCE0_ALPHA = ((int)0x8588),
        SOURCE1_ALPHA = ((int)0x8589),
        SOURCE2_ALPHA = ((int)0x858A),
        OPERAND0_RGB = ((int)0x8590),
        OPERAND1_RGB = ((int)0x8591),
        OPERAND2_RGB = ((int)0x8592),
        OPERAND0_ALPHA = ((int)0x8598),
        OPERAND1_ALPHA = ((int)0x8599),
        OPERAND2_ALPHA = ((int)0x859A),
        DOT3_RGB = ((int)0x86AE),
        DOT3_RGBA = ((int)0x86AF),
    }

    public enum VERSION_1_4 : int
    {
        BLEND_DST_RGB = ((int)0x80C8),
        BLEND_SRC_RGB = ((int)0x80C9),
        BLEND_DST_ALPHA = ((int)0x80CA),
        BLEND_SRC_ALPHA = ((int)0x80CB),
        POINT_SIZE_MIN = ((int)0x8126),
        POINT_SIZE_MAX = ((int)0x8127),
        POINT_FADE_THRESHOLD_SIZE = ((int)0x8128),
        POINT_DISTANCE_ATTENUATION = ((int)0x8129),
        DEPTH_COMPONENT16 = ((int)0x81A5),
        DEPTH_COMPONENT24 = ((int)0x81A6),
        DEPTH_COMPONENT32 = ((int)0x81A7),
        MIRRORED_REPEAT = ((int)0x8370),
        MAX_TEXTURE_LOD_BIAS = ((int)0x84FD),
        TEXTURE_LOD_BIAS = ((int)0x8501),
        INCR_WRAP = ((int)0x8507),
        DECR_WRAP = ((int)0x8508),
        TEXTURE_DEPTH_SIZE = ((int)0x884A),
        TEXTURE_COMPARE_MODE = ((int)0x884C),
        TEXTURE_COMPARE_FUNC = ((int)0x884D),
    }

    public enum VERSION_1_4_DEPRECATED : int
    {
        POINT_SIZE_MIN = ((int)0x8126),
        POINT_SIZE_MAX = ((int)0x8127),
        POINT_DISTANCE_ATTENUATION = ((int)0x8129),
        GENERATE_MIPMAP = ((int)0x8191),
        GENERATE_MIPMAP_HINT = ((int)0x8192),
        FOG_COORDINATE_SOURCE = ((int)0x8450),
        FOG_COORDINATE = ((int)0x8451),
        FRAGMENT_DEPTH = ((int)0x8452),
        CURRENT_FOG_COORDINATE = ((int)0x8453),
        FOG_COORDINATE_ARRAY_TYPE = ((int)0x8454),
        FOG_COORDINATE_ARRAY_STRIDE = ((int)0x8455),
        FOG_COORDINATE_ARRAY_POINTER = ((int)0x8456),
        FOG_COORDINATE_ARRAY = ((int)0x8457),
        COLOR_SUM = ((int)0x8458),
        CURRENT_SECONDARY_COLOR = ((int)0x8459),
        SECONDARY_COLOR_ARRAY_SIZE = ((int)0x845A),
        SECONDARY_COLOR_ARRAY_TYPE = ((int)0x845B),
        SECONDARY_COLOR_ARRAY_STRIDE = ((int)0x845C),
        SECONDARY_COLOR_ARRAY_POINTER = ((int)0x845D),
        SECONDARY_COLOR_ARRAY = ((int)0x845E),
        TEXTURE_FILTER_CONTROL = ((int)0x8500),
        DEPTH_TEXTURE_MODE = ((int)0x884B),
        COMPARE_R_TO_TEXTURE = ((int)0x884E),
    }

    public enum VERSION_1_5 : int
    {
        BUFFER_SIZE = ((int)0x8764),
        BUFFER_USAGE = ((int)0x8765),
        QUERY_COUNTER_BITS = ((int)0x8864),
        CURRENT_QUERY = ((int)0x8865),
        QUERY_RESULT = ((int)0x8866),
        QUERY_RESULT_AVAILABLE = ((int)0x8867),
        ARRAY_BUFFER = ((int)0x8892),
        ELEMENT_ARRAY_BUFFER = ((int)0x8893),
        ARRAY_BUFFER_BINDING = ((int)0x8894),
        ELEMENT_ARRAY_BUFFER_BINDING = ((int)0x8895),
        VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = ((int)0x889F),
        READ_ONLY = ((int)0x88B8),
        WRITE_ONLY = ((int)0x88B9),
        READ_WRITE = ((int)0x88BA),
        BUFFER_ACCESS = ((int)0x88BB),
        BUFFER_MAPPED = ((int)0x88BC),
        BUFFER_MAP_POINTER = ((int)0x88BD),
        STREAM_DRAW = ((int)0x88E0),
        STREAM_READ = ((int)0x88E1),
        STREAM_COPY = ((int)0x88E2),
        STATIC_DRAW = ((int)0x88E4),
        STATIC_READ = ((int)0x88E5),
        STATIC_COPY = ((int)0x88E6),
        DYNAMIC_DRAW = ((int)0x88E8),
        DYNAMIC_READ = ((int)0x88E9),
        DYNAMIC_COPY = ((int)0x88EA),
        SAMPLES_PASSED = ((int)0x8914),
    }

    public enum VERSION_1_5_DEPRECATED : int
    {
        FOG_COORD_SRC = ((int)0x8450),
        FOG_COORD = ((int)0x8451),
        CURRENT_FOG_COORD = ((int)0x8453),
        FOG_COORD_ARRAY_TYPE = ((int)0x8454),
        FOG_COORD_ARRAY_STRIDE = ((int)0x8455),
        FOG_COORD_ARRAY_POINTER = ((int)0x8456),
        FOG_COORD_ARRAY = ((int)0x8457),
        SRC0_RGB = ((int)0x8580),
        SRC1_RGB = ((int)0x8581),
        SRC2_RGB = ((int)0x8582),
        SRC0_ALPHA = ((int)0x8588),
        SRC1_ALPHA = ((int)0x8589),
        SRC2_ALPHA = ((int)0x858A),
        VERTEX_ARRAY_BUFFER_BINDING = ((int)0x8896),
        NORMAL_ARRAY_BUFFER_BINDING = ((int)0x8897),
        COLOR_ARRAY_BUFFER_BINDING = ((int)0x8898),
        INDEX_ARRAY_BUFFER_BINDING = ((int)0x8899),
        TEXTURE_COORD_ARRAY_BUFFER_BINDING = ((int)0x889A),
        EDGE_FLAG_ARRAY_BUFFER_BINDING = ((int)0x889B),
        SECONDARY_COLOR_ARRAY_BUFFER_BINDING = ((int)0x889C),
        FOG_COORD_ARRAY_BUFFER_BINDING = ((int)0x889D),
        FOG_COORDINATE_ARRAY_BUFFER_BINDING = ((int)0x889D),
        WEIGHT_ARRAY_BUFFER_BINDING = ((int)0x889E),
    }

    public enum VERSION_2_0 : int
    {
        BLEND_EQUATION_RGB = ((int)0x8009),
        VERTEX_ATTRIB_ARRAY_ENABLED = ((int)0x8622),
        VERTEX_ATTRIB_ARRAY_SIZE = ((int)0x8623),
        VERTEX_ATTRIB_ARRAY_STRIDE = ((int)0x8624),
        VERTEX_ATTRIB_ARRAY_TYPE = ((int)0x8625),
        CURRENT_VERTEX_ATTRIB = ((int)0x8626),
        VERTEX_PROGRAM_POINT_SIZE = ((int)0x8642),
        VERTEX_ATTRIB_ARRAY_POINTER = ((int)0x8645),
        STENCIL_BACK_FUNC = ((int)0x8800),
        STENCIL_BACK_FAIL = ((int)0x8801),
        STENCIL_BACK_PASS_DEPTH_FAIL = ((int)0x8802),
        STENCIL_BACK_PASS_DEPTH_PASS = ((int)0x8803),
        MAX_DRAW_BUFFERS = ((int)0x8824),
        DRAW_BUFFER0 = ((int)0x8825),
        DRAW_BUFFER1 = ((int)0x8826),
        DRAW_BUFFER2 = ((int)0x8827),
        DRAW_BUFFER3 = ((int)0x8828),
        DRAW_BUFFER4 = ((int)0x8829),
        DRAW_BUFFER5 = ((int)0x882A),
        DRAW_BUFFER6 = ((int)0x882B),
        DRAW_BUFFER7 = ((int)0x882C),
        DRAW_BUFFER8 = ((int)0x882D),
        DRAW_BUFFER9 = ((int)0x882E),
        DRAW_BUFFER10 = ((int)0x882F),
        DRAW_BUFFER11 = ((int)0x8830),
        DRAW_BUFFER12 = ((int)0x8831),
        DRAW_BUFFER13 = ((int)0x8832),
        DRAW_BUFFER14 = ((int)0x8833),
        DRAW_BUFFER15 = ((int)0x8834),
        BLEND_EQUATION_ALPHA = ((int)0x883D),
        MAX_VERTEX_ATTRIBS = ((int)0x8869),
        VERTEX_ATTRIB_ARRAY_NORMALIZED = ((int)0x886A),
        MAX_TEXTURE_IMAGE_UNITS = ((int)0x8872),
        FRAGMENT_SHADER = ((int)0x8B30),
        VERTEX_SHADER = ((int)0x8B31),
        MAX_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8B49),
        MAX_VERTEX_UNIFORM_COMPONENTS = ((int)0x8B4A),
        MAX_VARYING_FLOATS = ((int)0x8B4B),
        MAX_VERTEX_TEXTURE_IMAGE_UNITS = ((int)0x8B4C),
        MAX_COMBINED_TEXTURE_IMAGE_UNITS = ((int)0x8B4D),
        SHADER_TYPE = ((int)0x8B4F),
        FLOAT_VEC2 = ((int)0x8B50),
        FLOAT_VEC3 = ((int)0x8B51),
        FLOAT_VEC4 = ((int)0x8B52),
        INT_VEC2 = ((int)0x8B53),
        INT_VEC3 = ((int)0x8B54),
        INT_VEC4 = ((int)0x8B55),
        BOOL = ((int)0x8B56),
        BOOL_VEC2 = ((int)0x8B57),
        BOOL_VEC3 = ((int)0x8B58),
        BOOL_VEC4 = ((int)0x8B59),
        FLOAT_MAT2 = ((int)0x8B5A),
        FLOAT_MAT3 = ((int)0x8B5B),
        FLOAT_MAT4 = ((int)0x8B5C),
        SAMPLER_1D = ((int)0x8B5D),
        SAMPLER_2D = ((int)0x8B5E),
        SAMPLER_3D = ((int)0x8B5F),
        SAMPLER_CUBE = ((int)0x8B60),
        SAMPLER_1D_SHADOW = ((int)0x8B61),
        SAMPLER_2D_SHADOW = ((int)0x8B62),
        DELETE_STATUS = ((int)0x8B80),
        COMPILE_STATUS = ((int)0x8B81),
        LINK_STATUS = ((int)0x8B82),
        VALIDATE_STATUS = ((int)0x8B83),
        INFO_LOG_LENGTH = ((int)0x8B84),
        ATTACHED_SHADERS = ((int)0x8B85),
        ACTIVE_UNIFORMS = ((int)0x8B86),
        ACTIVE_UNIFORM_MAX_LENGTH = ((int)0x8B87),
        SHADER_SOURCE_LENGTH = ((int)0x8B88),
        ACTIVE_ATTRIBUTES = ((int)0x8B89),
        ACTIVE_ATTRIBUTE_MAX_LENGTH = ((int)0x8B8A),
        FRAGMENT_SHADER_DERIVATIVE_HINT = ((int)0x8B8B),
        SHADING_LANGUAGE_VERSION = ((int)0x8B8C),
        CURRENT_PROGRAM = ((int)0x8B8D),
        POINT_SPRITE_COORD_ORIGIN = ((int)0x8CA0),
        LOWER_LEFT = ((int)0x8CA1),
        UPPER_LEFT = ((int)0x8CA2),
        STENCIL_BACK_REF = ((int)0x8CA3),
        STENCIL_BACK_VALUE_MASK = ((int)0x8CA4),
        STENCIL_BACK_WRITEMASK = ((int)0x8CA5),
    }

    public enum VERSION_2_0_DEPRECATED : int
    {
        VERTEX_PROGRAM_TWO_SIDE = ((int)0x8643),
        POINT_SPRITE = ((int)0x8861),
        COORD_REPLACE = ((int)0x8862),
        MAX_TEXTURE_COORDS = ((int)0x8871),
    }

    public enum VERSION_2_1 : int
    {
        PIXEL_PACK_BUFFER = ((int)0x88EB),
        PIXEL_UNPACK_BUFFER = ((int)0x88EC),
        PIXEL_PACK_BUFFER_BINDING = ((int)0x88ED),
        PIXEL_UNPACK_BUFFER_BINDING = ((int)0x88EF),
        FLOAT_MAT2x3 = ((int)0x8B65),
        FLOAT_MAT2x4 = ((int)0x8B66),
        FLOAT_MAT3x2 = ((int)0x8B67),
        FLOAT_MAT3x4 = ((int)0x8B68),
        FLOAT_MAT4x2 = ((int)0x8B69),
        FLOAT_MAT4x3 = ((int)0x8B6A),
        SRGB = ((int)0x8C40),
        SRGB8 = ((int)0x8C41),
        SRGB_ALPHA = ((int)0x8C42),
        SRGB8_ALPHA8 = ((int)0x8C43),
        COMPRESSED_SRGB = ((int)0x8C48),
        COMPRESSED_SRGB_ALPHA = ((int)0x8C49),
    }

    public enum VERSION_2_1_DEPRECATED : int
    {
        CURRENT_RASTER_SECONDARY_COLOR = ((int)0x845F),
        SLUMINANCE_ALPHA = ((int)0x8C44),
        SLUMINANCE8_ALPHA8 = ((int)0x8C45),
        SLUMINANCE = ((int)0x8C46),
        SLUMINANCE8 = ((int)0x8C47),
        COMPRESSED_SLUMINANCE = ((int)0x8C4A),
        COMPRESSED_SLUMINANCE_ALPHA = ((int)0x8C4B),
    }

    public enum VERSION_3_0 : int
    {
        CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = ((int)0x0001),
        MAP_READ_BIT = ((int)0x0001),
        MAP_WRITE_BIT = ((int)0x0002),
        MAP_INVALIDATE_RANGE_BIT = ((int)0x0004),
        MAP_INVALIDATE_BUFFER_BIT = ((int)0x0008),
        MAP_FLUSH_EXPLICIT_BIT = ((int)0x0010),
        MAP_UNSYNCHRONIZED_BIT = ((int)0x0020),
        INVALID_FRAMEBUFFER_OPERATION = ((int)0x0506),
        MAX_CLIP_DISTANCES = ((int)0x0D32),
        HALF_FLOAT = ((int)0x140B),
        CLIP_DISTANCE0 = ((int)0x3000),
        CLIP_DISTANCE1 = ((int)0x3001),
        CLIP_DISTANCE2 = ((int)0x3002),
        CLIP_DISTANCE3 = ((int)0x3003),
        CLIP_DISTANCE4 = ((int)0x3004),
        CLIP_DISTANCE5 = ((int)0x3005),
        CLIP_DISTANCE6 = ((int)0x3006),
        CLIP_DISTANCE7 = ((int)0x3007),
        FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = ((int)0x8210),
        FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = ((int)0x8211),
        FRAMEBUFFER_ATTACHMENT_RED_SIZE = ((int)0x8212),
        FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = ((int)0x8213),
        FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = ((int)0x8214),
        FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = ((int)0x8215),
        FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = ((int)0x8216),
        FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = ((int)0x8217),
        FRAMEBUFFER_DEFAULT = ((int)0x8218),
        FRAMEBUFFER_UNDEFINED = ((int)0x8219),
        DEPTH_STENCIL_ATTACHMENT = ((int)0x821A),
        MAJOR_VERSION = ((int)0x821B),
        MINOR_VERSION = ((int)0x821C),
        NUM_EXTENSIONS = ((int)0x821D),
        CONTEXT_FLAGS = ((int)0x821E),
        INDEX = ((int)0x8222),
        DEPTH_BUFFER = ((int)0x8223),
        STENCIL_BUFFER = ((int)0x8224),
        COMPRESSED_RED = ((int)0x8225),
        COMPRESSED_RG = ((int)0x8226),
        RG = ((int)0x8227),
        RG_INTEGER = ((int)0x8228),
        R8 = ((int)0x8229),
        R16 = ((int)0x822A),
        RG8 = ((int)0x822B),
        RG16 = ((int)0x822C),
        R16F = ((int)0x822D),
        R32F = ((int)0x822E),
        RG16F = ((int)0x822F),
        RG32F = ((int)0x8230),
        R8I = ((int)0x8231),
        R8UI = ((int)0x8232),
        R16I = ((int)0x8233),
        R16UI = ((int)0x8234),
        R32I = ((int)0x8235),
        R32UI = ((int)0x8236),
        RG8I = ((int)0x8237),
        RG8UI = ((int)0x8238),
        RG16I = ((int)0x8239),
        RG16UI = ((int)0x823A),
        RG32I = ((int)0x823B),
        RG32UI = ((int)0x823C),
        MAX_RENDERBUFFER_SIZE = ((int)0x84E8),
        DEPTH_STENCIL = ((int)0x84F9),
        UNSIGNED_INT_24_8 = ((int)0x84FA),
        VERTEX_ARRAY_BINDING = ((int)0x85B5),
        RGBA32F = ((int)0x8814),
        RGB32F = ((int)0x8815),
        RGBA16F = ((int)0x881A),
        RGB16F = ((int)0x881B),
        COMPARE_REF_TO_TEXTURE = ((int)0x884E),
        DEPTH24_STENCIL8 = ((int)0x88F0),
        TEXTURE_STENCIL_SIZE = ((int)0x88F1),
        VERTEX_ATTRIB_ARRAY_INTEGER = ((int)0x88FD),
        MAX_ARRAY_TEXTURE_LAYERS = ((int)0x88FF),
        MIN_PROGRAM_TEXEL_OFFSET = ((int)0x8904),
        MAX_PROGRAM_TEXEL_OFFSET = ((int)0x8905),
        CLAMP_READ_COLOR = ((int)0x891C),
        FIXED_ONLY = ((int)0x891D),
        MAX_VARYING_COMPONENTS = ((int)0x8B4B),
        TEXTURE_RED_TYPE = ((int)0x8C10),
        TEXTURE_GREEN_TYPE = ((int)0x8C11),
        TEXTURE_BLUE_TYPE = ((int)0x8C12),
        TEXTURE_ALPHA_TYPE = ((int)0x8C13),
        TEXTURE_LUMINANCE_TYPE = ((int)0x8C14),
        TEXTURE_INTENSITY_TYPE = ((int)0x8C15),
        TEXTURE_DEPTH_TYPE = ((int)0x8C16),
        UNSIGNED_NORMALIZED = ((int)0x8C17),
        TEXTURE_1D_ARRAY = ((int)0x8C18),
        PROXY_TEXTURE_1D_ARRAY = ((int)0x8C19),
        TEXTURE_2D_ARRAY = ((int)0x8C1A),
        PROXY_TEXTURE_2D_ARRAY = ((int)0x8C1B),
        TEXTURE_BINDING_1D_ARRAY = ((int)0x8C1C),
        TEXTURE_BINDING_2D_ARRAY = ((int)0x8C1D),
        R11F_G11F_B10F = ((int)0x8C3A),
        UNSIGNED_INT_10F_11F_11F_REV = ((int)0x8C3B),
        RGB9_E5 = ((int)0x8C3D),
        UNSIGNED_INT_5_9_9_9_REV = ((int)0x8C3E),
        TEXTURE_SHARED_SIZE = ((int)0x8C3F),
        TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = ((int)0x8C76),
        TRANSFORM_FEEDBACK_BUFFER_MODE = ((int)0x8C7F),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = ((int)0x8C80),
        TRANSFORM_FEEDBACK_VARYINGS = ((int)0x8C83),
        TRANSFORM_FEEDBACK_BUFFER_START = ((int)0x8C84),
        TRANSFORM_FEEDBACK_BUFFER_SIZE = ((int)0x8C85),
        PRIMITIVES_GENERATED = ((int)0x8C87),
        TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = ((int)0x8C88),
        RASTERIZER_DISCARD = ((int)0x8C89),
        MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = ((int)0x8C8A),
        MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = ((int)0x8C8B),
        INTERLEAVED_ATTRIBS = ((int)0x8C8C),
        SEPARATE_ATTRIBS = ((int)0x8C8D),
        TRANSFORM_FEEDBACK_BUFFER = ((int)0x8C8E),
        TRANSFORM_FEEDBACK_BUFFER_BINDING = ((int)0x8C8F),
        DRAW_FRAMEBUFFER_BINDING = ((int)0x8CA6),
        FRAMEBUFFER_BINDING = ((int)0x8CA6),
        RENDERBUFFER_BINDING = ((int)0x8CA7),
        READ_FRAMEBUFFER = ((int)0x8CA8),
        DRAW_FRAMEBUFFER = ((int)0x8CA9),
        READ_FRAMEBUFFER_BINDING = ((int)0x8CAA),
        RENDERBUFFER_SAMPLES = ((int)0x8CAB),
        DEPTH_COMPONENT32F = ((int)0x8CAC),
        DEPTH32F_STENCIL8 = ((int)0x8CAD),
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = ((int)0x8CD0),
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = ((int)0x8CD1),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = ((int)0x8CD2),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = ((int)0x8CD3),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4),
        FRAMEBUFFER_COMPLETE = ((int)0x8CD5),
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT = ((int)0x8CD6),
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = ((int)0x8CD7),
        FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = ((int)0x8CDB),
        FRAMEBUFFER_INCOMPLETE_READ_BUFFER = ((int)0x8CDC),
        FRAMEBUFFER_UNSUPPORTED = ((int)0x8CDD),
        MAX_COLOR_ATTACHMENTS = ((int)0x8CDF),
        COLOR_ATTACHMENT0 = ((int)0x8CE0),
        COLOR_ATTACHMENT1 = ((int)0x8CE1),
        COLOR_ATTACHMENT2 = ((int)0x8CE2),
        COLOR_ATTACHMENT3 = ((int)0x8CE3),
        COLOR_ATTACHMENT4 = ((int)0x8CE4),
        COLOR_ATTACHMENT5 = ((int)0x8CE5),
        COLOR_ATTACHMENT6 = ((int)0x8CE6),
        COLOR_ATTACHMENT7 = ((int)0x8CE7),
        COLOR_ATTACHMENT8 = ((int)0x8CE8),
        COLOR_ATTACHMENT9 = ((int)0x8CE9),
        COLOR_ATTACHMENT10 = ((int)0x8CEA),
        COLOR_ATTACHMENT11 = ((int)0x8CEB),
        COLOR_ATTACHMENT12 = ((int)0x8CEC),
        COLOR_ATTACHMENT13 = ((int)0x8CED),
        COLOR_ATTACHMENT14 = ((int)0x8CEE),
        COLOR_ATTACHMENT15 = ((int)0x8CEF),
        DEPTH_ATTACHMENT = ((int)0x8D00),
        STENCIL_ATTACHMENT = ((int)0x8D20),
        FRAMEBUFFER = ((int)0x8D40),
        RENDERBUFFER = ((int)0x8D41),
        RENDERBUFFER_WIDTH = ((int)0x8D42),
        RENDERBUFFER_HEIGHT = ((int)0x8D43),
        RENDERBUFFER_INTERNAL_FORMAT = ((int)0x8D44),
        STENCIL_INDEX1 = ((int)0x8D46),
        STENCIL_INDEX4 = ((int)0x8D47),
        STENCIL_INDEX8 = ((int)0x8D48),
        STENCIL_INDEX16 = ((int)0x8D49),
        RENDERBUFFER_RED_SIZE = ((int)0x8D50),
        RENDERBUFFER_GREEN_SIZE = ((int)0x8D51),
        RENDERBUFFER_BLUE_SIZE = ((int)0x8D52),
        RENDERBUFFER_ALPHA_SIZE = ((int)0x8D53),
        RENDERBUFFER_DEPTH_SIZE = ((int)0x8D54),
        RENDERBUFFER_STENCIL_SIZE = ((int)0x8D55),
        FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = ((int)0x8D56),
        MAX_SAMPLES = ((int)0x8D57),
        RGBA32UI = ((int)0x8D70),
        RGB32UI = ((int)0x8D71),
        RGBA16UI = ((int)0x8D76),
        RGB16UI = ((int)0x8D77),
        RGBA8UI = ((int)0x8D7C),
        RGB8UI = ((int)0x8D7D),
        RGBA32I = ((int)0x8D82),
        RGB32I = ((int)0x8D83),
        RGBA16I = ((int)0x8D88),
        RGB16I = ((int)0x8D89),
        RGBA8I = ((int)0x8D8E),
        RGB8I = ((int)0x8D8F),
        RED_INTEGER = ((int)0x8D94),
        GREEN_INTEGER = ((int)0x8D95),
        BLUE_INTEGER = ((int)0x8D96),
        RGB_INTEGER = ((int)0x8D98),
        RGBA_INTEGER = ((int)0x8D99),
        BGR_INTEGER = ((int)0x8D9A),
        BGRA_INTEGER = ((int)0x8D9B),
        FLOAT_32_UNSIGNED_INT_24_8_REV = ((int)0x8DAD),
        FRAMEBUFFER_SRGB = ((int)0x8DB9),
        COMPRESSED_RED_RGTC1 = ((int)0x8DBB),
        COMPRESSED_SIGNED_RED_RGTC1 = ((int)0x8DBC),
        COMPRESSED_RG_RGTC2 = ((int)0x8DBD),
        COMPRESSED_SIGNED_RG_RGTC2 = ((int)0x8DBE),
        SAMPLER_1D_ARRAY = ((int)0x8DC0),
        SAMPLER_2D_ARRAY = ((int)0x8DC1),
        SAMPLER_1D_ARRAY_SHADOW = ((int)0x8DC3),
        SAMPLER_2D_ARRAY_SHADOW = ((int)0x8DC4),
        SAMPLER_CUBE_SHADOW = ((int)0x8DC5),
        UNSIGNED_INT_VEC2 = ((int)0x8DC6),
        UNSIGNED_INT_VEC3 = ((int)0x8DC7),
        UNSIGNED_INT_VEC4 = ((int)0x8DC8),
        INT_SAMPLER_1D = ((int)0x8DC9),
        INT_SAMPLER_2D = ((int)0x8DCA),
        INT_SAMPLER_3D = ((int)0x8DCB),
        INT_SAMPLER_CUBE = ((int)0x8DCC),
        INT_SAMPLER_1D_ARRAY = ((int)0x8DCE),
        INT_SAMPLER_2D_ARRAY = ((int)0x8DCF),
        UNSIGNED_INT_SAMPLER_1D = ((int)0x8DD1),
        UNSIGNED_INT_SAMPLER_2D = ((int)0x8DD2),
        UNSIGNED_INT_SAMPLER_3D = ((int)0x8DD3),
        UNSIGNED_INT_SAMPLER_CUBE = ((int)0x8DD4),
        UNSIGNED_INT_SAMPLER_1D_ARRAY = ((int)0x8DD6),
        UNSIGNED_INT_SAMPLER_2D_ARRAY = ((int)0x8DD7),
        QUERY_WAIT = ((int)0x8E13),
        QUERY_NO_WAIT = ((int)0x8E14),
        QUERY_BY_REGION_WAIT = ((int)0x8E15),
        QUERY_BY_REGION_NO_WAIT = ((int)0x8E16),
        BUFFER_ACCESS_FLAGS = ((int)0x911F),
        BUFFER_MAP_LENGTH = ((int)0x9120),
        BUFFER_MAP_OFFSET = ((int)0x9121),
    }

    public enum VERSION_3_0_DEPRECATED : int
    {
        CLAMP_VERTEX_COLOR = ((int)0x891A),
        CLAMP_FRAGMENT_COLOR = ((int)0x891B),
        TEXTURE_LUMINANCE_TYPE = ((int)0x8C14),
        TEXTURE_INTENSITY_TYPE = ((int)0x8C15),
        ALPHA_INTEGER = ((int)0x8D97),
    }

    public enum VERSION_3_1 : int
    {
        TEXTURE_RECTANGLE = ((int)0x84F5),
        TEXTURE_BINDING_RECTANGLE = ((int)0x84F6),
        PROXY_TEXTURE_RECTANGLE = ((int)0x84F7),
        MAX_RECTANGLE_TEXTURE_SIZE = ((int)0x84F8),
        UNIFORM_BUFFER = ((int)0x8A11),
        UNIFORM_BUFFER_BINDING = ((int)0x8A28),
        UNIFORM_BUFFER_START = ((int)0x8A29),
        UNIFORM_BUFFER_SIZE = ((int)0x8A2A),
        MAX_VERTEX_UNIFORM_BLOCKS = ((int)0x8A2B),
        MAX_FRAGMENT_UNIFORM_BLOCKS = ((int)0x8A2D),
        MAX_COMBINED_UNIFORM_BLOCKS = ((int)0x8A2E),
        MAX_UNIFORM_BUFFER_BINDINGS = ((int)0x8A2F),
        MAX_UNIFORM_BLOCK_SIZE = ((int)0x8A30),
        MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = ((int)0x8A31),
        MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = ((int)0x8A33),
        UNIFORM_BUFFER_OFFSET_ALIGNMENT = ((int)0x8A34),
        ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = ((int)0x8A35),
        ACTIVE_UNIFORM_BLOCKS = ((int)0x8A36),
        UNIFORM_TYPE = ((int)0x8A37),
        UNIFORM_SIZE = ((int)0x8A38),
        UNIFORM_NAME_LENGTH = ((int)0x8A39),
        UNIFORM_BLOCK_INDEX = ((int)0x8A3A),
        UNIFORM_OFFSET = ((int)0x8A3B),
        UNIFORM_ARRAY_STRIDE = ((int)0x8A3C),
        UNIFORM_MATRIX_STRIDE = ((int)0x8A3D),
        UNIFORM_IS_ROW_MAJOR = ((int)0x8A3E),
        UNIFORM_BLOCK_BINDING = ((int)0x8A3F),
        UNIFORM_BLOCK_DATA_SIZE = ((int)0x8A40),
        UNIFORM_BLOCK_NAME_LENGTH = ((int)0x8A41),
        UNIFORM_BLOCK_ACTIVE_UNIFORMS = ((int)0x8A42),
        UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = ((int)0x8A43),
        UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = ((int)0x8A44),
        UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = ((int)0x8A46),
        SAMPLER_2D_RECT = ((int)0x8B63),
        SAMPLER_2D_RECT_SHADOW = ((int)0x8B64),
        TEXTURE_BUFFER = ((int)0x8C2A),
        MAX_TEXTURE_BUFFER_SIZE = ((int)0x8C2B),
        TEXTURE_BINDING_BUFFER = ((int)0x8C2C),
        TEXTURE_BUFFER_DATA_STORE_BINDING = ((int)0x8C2D),
        TEXTURE_BUFFER_FORMAT = ((int)0x8C2E),
        SAMPLER_BUFFER = ((int)0x8DC2),
        INT_SAMPLER_2D_RECT = ((int)0x8DCD),
        INT_SAMPLER_BUFFER = ((int)0x8DD0),
        UNSIGNED_INT_SAMPLER_2D_RECT = ((int)0x8DD5),
        UNSIGNED_INT_SAMPLER_BUFFER = ((int)0x8DD8),
        COPY_READ_BUFFER = ((int)0x8F36),
        COPY_WRITE_BUFFER = ((int)0x8F37),
        RED_SNORM = ((int)0x8F90),
        RG_SNORM = ((int)0x8F91),
        RGB_SNORM = ((int)0x8F92),
        RGBA_SNORM = ((int)0x8F93),
        R8_SNORM = ((int)0x8F94),
        RG8_SNORM = ((int)0x8F95),
        RGB8_SNORM = ((int)0x8F96),
        RGBA8_SNORM = ((int)0x8F97),
        R16_SNORM = ((int)0x8F98),
        RG16_SNORM = ((int)0x8F99),
        RGB16_SNORM = ((int)0x8F9A),
        RGBA16_SNORM = ((int)0x8F9B),
        SIGNED_NORMALIZED = ((int)0x8F9C),
        PRIMITIVE_RESTART = ((int)0x8F9D),
        PRIMITIVE_RESTART_INDEX = ((int)0x8F9E),
        INVALID_INDEX = unchecked((int)0xFFFFFFFF),
    }

    public enum VERSION_3_2 : int
    {
        CONTEXT_CORE_PROFILE_BIT = ((int)0x00000001),
        SYNC_FLUSH_COMMANDS_BIT = ((int)0x00000001),
        CONTEXT_COMPATIBILITY_PROFILE_BIT = ((int)0x00000002),
        LINES_ADJACENCY = ((int)0x000A),
        LINE_STRIP_ADJACENCY = ((int)0x000B),
        TRIANGLES_ADJACENCY = ((int)0x000C),
        TRIANGLE_STRIP_ADJACENCY = ((int)0x000D),
        PROGRAM_POINT_SIZE = ((int)0x8642),
        DEPTH_CLAMP = ((int)0x864F),
        TEXTURE_CUBE_MAP_SEAMLESS = ((int)0x884F),
        GEOMETRY_VERTICES_OUT = ((int)0x8916),
        GEOMETRY_INPUT_TYPE = ((int)0x8917),
        GEOMETRY_OUTPUT_TYPE = ((int)0x8918),
        MAX_VARYING_COMPONENTS = ((int)0x8B4B),
        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = ((int)0x8C29),
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = ((int)0x8CD4),
        FRAMEBUFFER_ATTACHMENT_LAYERED = ((int)0x8DA7),
        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = ((int)0x8DA8),
        GEOMETRY_SHADER = ((int)0x8DD9),
        MAX_GEOMETRY_UNIFORM_COMPONENTS = ((int)0x8DDF),
        MAX_GEOMETRY_OUTPUT_VERTICES = ((int)0x8DE0),
        MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = ((int)0x8DE1),
        QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = ((int)0x8E4C),
        FIRST_VERTEX_CONVENTION = ((int)0x8E4D),
        LAST_VERTEX_CONVENTION = ((int)0x8E4E),
        PROVOKING_VERTEX = ((int)0x8E4F),
        SAMPLE_POSITION = ((int)0x8E50),
        SAMPLE_MASK = ((int)0x8E51),
        SAMPLE_MASK_VALUE = ((int)0x8E52),
        MAX_SAMPLE_MASK_WORDS = ((int)0x8E59),
        TEXTURE_2D_MULTISAMPLE = ((int)0x9100),
        PROXY_TEXTURE_2D_MULTISAMPLE = ((int)0x9101),
        TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9102),
        PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = ((int)0x9103),
        TEXTURE_BINDING_2D_MULTISAMPLE = ((int)0x9104),
        TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = ((int)0x9105),
        TEXTURE_SAMPLES = ((int)0x9106),
        TEXTURE_FIXED_SAMPLE_LOCATIONS = ((int)0x9107),
        SAMPLER_2D_MULTISAMPLE = ((int)0x9108),
        INT_SAMPLER_2D_MULTISAMPLE = ((int)0x9109),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = ((int)0x910A),
        SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910B),
        INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910C),
        UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = ((int)0x910D),
        MAX_COLOR_TEXTURE_SAMPLES = ((int)0x910E),
        MAX_DEPTH_TEXTURE_SAMPLES = ((int)0x910F),
        MAX_INTEGER_SAMPLES = ((int)0x9110),
        MAX_SERVER_WAIT_TIMEOUT = ((int)0x9111),
        OBJECT_TYPE = ((int)0x9112),
        SYNC_CONDITION = ((int)0x9113),
        SYNC_STATUS = ((int)0x9114),
        SYNC_FLAGS = ((int)0x9115),
        SYNC_FENCE = ((int)0x9116),
        SYNC_GPU_COMMANDS_COMPLETE = ((int)0x9117),
        UNSIGNALED = ((int)0x9118),
        SIGNALED = ((int)0x9119),
        ALREADY_SIGNALED = ((int)0x911A),
        TIMEOUT_EXPIRED = ((int)0x911B),
        CONDITION_SATISFIED = ((int)0x911C),
        WAIT_FAILED = ((int)0x911D),
        MAX_VERTEX_OUTPUT_COMPONENTS = ((int)0x9122),
        MAX_GEOMETRY_INPUT_COMPONENTS = ((int)0x9123),
        MAX_GEOMETRY_OUTPUT_COMPONENTS = ((int)0x9124),
        MAX_FRAGMENT_INPUT_COMPONENTS = ((int)0x9125),
        CONTEXT_PROFILE_MASK = ((int)0x9126),
        TIMEOUT_IGNORED = unchecked((int)0xFFFFFFFFFFFFFFFF),
    }

    public enum VertexAttribIPointerType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
    }

    public enum VertexAttribParameter : int
    {
        ARRAY_ENABLED = ((int)0x8622),
        ARRAY_SIZE = ((int)0x8623),
        ARRAY_STRIDE = ((int)0x8624),
        ARRAY_TYPE = ((int)0x8625),
        CURRENT_VERTEX_ATTRIB = ((int)0x8626),
        ARRAY_NORMALIZED = ((int)0x886A),
        VERTEX_ATTRIB_ARRAY_INTEGER = ((int)0x88FD),
    }

    public enum VertexAttribParameterARB : int
    {
        ARRAY_ENABLED = ((int)0x8622),
        ARRAY_SIZE = ((int)0x8623),
        ARRAY_STRIDE = ((int)0x8624),
        ARRAY_TYPE = ((int)0x8625),
        CURRENT_VERTEX_ATTRIB = ((int)0x8626),
        ARRAY_NORMALIZED = ((int)0x886A),
        ARRAY_DIVISOR = ((int)0x88FE),
    }

    public enum VertexAttribPointerParameter : int
    {
        ARRAY_POINTER = ((int)0x8645),
    }

    public enum VertexAttribPointerParameterARB : int
    {
        ARRAY_POINTER = ((int)0x8645),
    }

    public enum VertexAttribPointerType : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

    public enum VertexAttribPointerTypeARB : int
    {
        BYTE = ((int)0x1400),
        UNSIGNED_BYTE = ((int)0x1401),
        SHORT = ((int)0x1402),
        UNSIGNED_SHORT = ((int)0x1403),
        INT = ((int)0x1404),
        UNSIGNED_INT = ((int)0x1405),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
    }

    public enum VertexPointerType : int
    {
        SHORT = ((int)0x1402),
        INT = ((int)0x1404),
        FLOAT = ((int)0x1406),
        DOUBLE = ((int)0x140A),
        HALF_FLOAT = ((int)0x140B),
    }

}
