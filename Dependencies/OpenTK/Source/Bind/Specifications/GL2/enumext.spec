# List of GL enumerants for glext.h header
#
# This is derived from the master GL enumerant registry (enum.spec).
#
# Unlike enum.spec, enumext.spec is
#   (1) Grouped by GL core version or extension number
#   (2) While it includes all extension and core enumerants, the
#   generator scripts for glext.h leave out VERSION_1_1
#   tokens since it's assumed all <gl.h> today support at least
#   OpenGL 1.1
#   (3) Has no 'Extensions' section, since enums are always
#   conditionally protected against multiple definition
#   by glextenum.pl.
#   (4) Is processed by glextenum.pl, which has evolved
#   from enum.pl - should merge back into one script.

# glext.h version number - this should be automatically updated,
#   when changing either enum or template spec files.

###############################################################################
#
# OpenGL 1.0/1.1 enums (there is no VERSION_1_0 token)
#
###############################################################################

VERSION_1_1 enum:
passthru: /* AttribMask */
    DEPTH_BUFFER_BIT                = 0x00000100    # AttribMask
    STENCIL_BUFFER_BIT              = 0x00000400    # AttribMask
    COLOR_BUFFER_BIT                = 0x00004000    # AttribMask
passthru: /* Boolean */
    FALSE                       = 0     # Boolean
    TRUE                        = 1     # Boolean
passthru: /* BeginMode */
    POINTS                      = 0x0000    # BeginMode
    LINES                       = 0x0001    # BeginMode
    LINE_LOOP                   = 0x0002    # BeginMode
    LINE_STRIP                  = 0x0003    # BeginMode
    TRIANGLES                   = 0x0004    # BeginMode
    TRIANGLE_STRIP                  = 0x0005    # BeginMode
    TRIANGLE_FAN                    = 0x0006    # BeginMode
passthru: /* AlphaFunction */
    NEVER                       = 0x0200    # AlphaFunction
    LESS                        = 0x0201    # AlphaFunction
    EQUAL                       = 0x0202    # AlphaFunction
    LEQUAL                      = 0x0203    # AlphaFunction
    GREATER                     = 0x0204    # AlphaFunction
    NOTEQUAL                    = 0x0205    # AlphaFunction
    GEQUAL                      = 0x0206    # AlphaFunction
    ALWAYS                      = 0x0207    # AlphaFunction
passthru: /* BlendingFactorDest */
    ZERO                        = 0     # BlendingFactorDest
    ONE                     = 1     # BlendingFactorDest
    SRC_COLOR                   = 0x0300    # BlendingFactorDest
    ONE_MINUS_SRC_COLOR             = 0x0301    # BlendingFactorDest
    SRC_ALPHA                   = 0x0302    # BlendingFactorDest
    ONE_MINUS_SRC_ALPHA             = 0x0303    # BlendingFactorDest
    DST_ALPHA                   = 0x0304    # BlendingFactorDest
    ONE_MINUS_DST_ALPHA             = 0x0305    # BlendingFactorDest
passthru: /* BlendingFactorSrc */
    DST_COLOR                   = 0x0306    # BlendingFactorSrc
    ONE_MINUS_DST_COLOR             = 0x0307    # BlendingFactorSrc
    SRC_ALPHA_SATURATE              = 0x0308    # BlendingFactorSrc
passthru: /* DrawBufferMode */
    NONE                        = 0     # DrawBufferMode
    FRONT_LEFT                  = 0x0400    # DrawBufferMode
    FRONT_RIGHT                 = 0x0401    # DrawBufferMode
    BACK_LEFT                   = 0x0402    # DrawBufferMode
    BACK_RIGHT                  = 0x0403    # DrawBufferMode
    FRONT                       = 0x0404    # DrawBufferMode
    BACK                        = 0x0405    # DrawBufferMode
    LEFT                        = 0x0406    # DrawBufferMode
    RIGHT                       = 0x0407    # DrawBufferMode
    FRONT_AND_BACK                  = 0x0408    # DrawBufferMode
passthru: /* ErrorCode */
    NO_ERROR                    = 0     # ErrorCode
    INVALID_ENUM                    = 0x0500    # ErrorCode
    INVALID_VALUE                   = 0x0501    # ErrorCode
    INVALID_OPERATION               = 0x0502    # ErrorCode
    OUT_OF_MEMORY                   = 0x0505    # ErrorCode
passthru: /* FrontFaceDirection */
    CW                      = 0x0900    # FrontFaceDirection
    CCW                     = 0x0901    # FrontFaceDirection
passthru: /* GetPName */
    POINT_SIZE                  = 0x0B11 # 1 F  # GetPName
    POINT_SIZE_RANGE                = 0x0B12 # 2 F  # GetPName
    POINT_SIZE_GRANULARITY              = 0x0B13 # 1 F  # GetPName
    LINE_SMOOTH                 = 0x0B20 # 1 I  # GetPName
    LINE_WIDTH                  = 0x0B21 # 1 F  # GetPName
    LINE_WIDTH_RANGE                = 0x0B22 # 2 F  # GetPName
    LINE_WIDTH_GRANULARITY              = 0x0B23 # 1 F  # GetPName
    POLYGON_SMOOTH                  = 0x0B41 # 1 I  # GetPName
    CULL_FACE                   = 0x0B44 # 1 I  # GetPName
    CULL_FACE_MODE                  = 0x0B45 # 1 I  # GetPName
    FRONT_FACE                  = 0x0B46 # 1 I  # GetPName
    DEPTH_RANGE                 = 0x0B70 # 2 F  # GetPName
    DEPTH_TEST                  = 0x0B71 # 1 I  # GetPName
    DEPTH_WRITEMASK                 = 0x0B72 # 1 I  # GetPName
    DEPTH_CLEAR_VALUE               = 0x0B73 # 1 F  # GetPName
    DEPTH_FUNC                  = 0x0B74 # 1 I  # GetPName
    STENCIL_TEST                    = 0x0B90 # 1 I  # GetPName
    STENCIL_CLEAR_VALUE             = 0x0B91 # 1 I  # GetPName
    STENCIL_FUNC                    = 0x0B92 # 1 I  # GetPName
    STENCIL_VALUE_MASK              = 0x0B93 # 1 I  # GetPName
    STENCIL_FAIL                    = 0x0B94 # 1 I  # GetPName
    STENCIL_PASS_DEPTH_FAIL             = 0x0B95 # 1 I  # GetPName
    STENCIL_PASS_DEPTH_PASS             = 0x0B96 # 1 I  # GetPName
    STENCIL_REF                 = 0x0B97 # 1 I  # GetPName
    STENCIL_WRITEMASK               = 0x0B98 # 1 I  # GetPName
    VIEWPORT                    = 0x0BA2 # 4 I  # GetPName
    DITHER                      = 0x0BD0 # 1 I  # GetPName
    BLEND_DST                   = 0x0BE0 # 1 I  # GetPName
    BLEND_SRC                   = 0x0BE1 # 1 I  # GetPName
    BLEND                       = 0x0BE2 # 1 I  # GetPName
    LOGIC_OP_MODE                   = 0x0BF0 # 1 I  # GetPName
    COLOR_LOGIC_OP                  = 0x0BF2 # 1 I  # GetPName
    DRAW_BUFFER                 = 0x0C01 # 1 I  # GetPName
    READ_BUFFER                 = 0x0C02 # 1 I  # GetPName
    SCISSOR_BOX                 = 0x0C10 # 4 I  # GetPName
    SCISSOR_TEST                    = 0x0C11 # 1 I  # GetPName
    COLOR_CLEAR_VALUE               = 0x0C22 # 4 F  # GetPName
    COLOR_WRITEMASK                 = 0x0C23 # 4 I  # GetPName
    DOUBLEBUFFER                    = 0x0C32 # 1 I  # GetPName
    STEREO                      = 0x0C33 # 1 I  # GetPName
    LINE_SMOOTH_HINT                = 0x0C52 # 1 I  # GetPName
    POLYGON_SMOOTH_HINT             = 0x0C53 # 1 I  # GetPName
    UNPACK_SWAP_BYTES               = 0x0CF0 # 1 I  # GetPName
    UNPACK_LSB_FIRST                = 0x0CF1 # 1 I  # GetPName
    UNPACK_ROW_LENGTH               = 0x0CF2 # 1 I  # GetPName
    UNPACK_SKIP_ROWS                = 0x0CF3 # 1 I  # GetPName
    UNPACK_SKIP_PIXELS              = 0x0CF4 # 1 I  # GetPName
    UNPACK_ALIGNMENT                = 0x0CF5 # 1 I  # GetPName
    PACK_SWAP_BYTES                 = 0x0D00 # 1 I  # GetPName
    PACK_LSB_FIRST                  = 0x0D01 # 1 I  # GetPName
    PACK_ROW_LENGTH                 = 0x0D02 # 1 I  # GetPName
    PACK_SKIP_ROWS                  = 0x0D03 # 1 I  # GetPName
    PACK_SKIP_PIXELS                = 0x0D04 # 1 I  # GetPName
    PACK_ALIGNMENT                  = 0x0D05 # 1 I  # GetPName
    MAX_TEXTURE_SIZE                = 0x0D33 # 1 I  # GetPName
    MAX_VIEWPORT_DIMS               = 0x0D3A # 2 F  # GetPName
    SUBPIXEL_BITS                   = 0x0D50 # 1 I  # GetPName
    TEXTURE_1D                  = 0x0DE0 # 1 I  # GetPName
    TEXTURE_2D                  = 0x0DE1 # 1 I  # GetPName
    POLYGON_OFFSET_UNITS                = 0x2A00 # 1 F  # GetPName
    POLYGON_OFFSET_POINT                = 0x2A01 # 1 I  # GetPName
    POLYGON_OFFSET_LINE             = 0x2A02 # 1 I  # GetPName
    POLYGON_OFFSET_FILL             = 0x8037 # 1 I  # GetPName
    POLYGON_OFFSET_FACTOR               = 0x8038 # 1 F  # GetPName
    TEXTURE_BINDING_1D              = 0x8068 # 1 I  # GetPName
    TEXTURE_BINDING_2D              = 0x8069 # 1 I  # GetPName
passthru: /* GetTextureParameter */
    TEXTURE_WIDTH                   = 0x1000    # GetTextureParameter
    TEXTURE_HEIGHT                  = 0x1001    # GetTextureParameter
    TEXTURE_INTERNAL_FORMAT             = 0x1003    # GetTextureParameter
    TEXTURE_BORDER_COLOR                = 0x1004    # GetTextureParameter
    TEXTURE_BORDER                  = 0x1005    # GetTextureParameter
    TEXTURE_RED_SIZE                = 0x805C    # GetTextureParameter
    TEXTURE_GREEN_SIZE              = 0x805D    # GetTextureParameter
    TEXTURE_BLUE_SIZE               = 0x805E    # GetTextureParameter
    TEXTURE_ALPHA_SIZE              = 0x805F    # GetTextureParameter
passthru: /* HintMode */
    DONT_CARE                   = 0x1100    # HintMode
    FASTEST                     = 0x1101    # HintMode
    NICEST                      = 0x1102    # HintMode
passthru: /* DataType */
    BYTE                        = 0x1400    # DataType
    UNSIGNED_BYTE                   = 0x1401    # DataType
    SHORT                       = 0x1402    # DataType
    UNSIGNED_SHORT                  = 0x1403    # DataType
    INT                     = 0x1404    # DataType
    UNSIGNED_INT                    = 0x1405    # DataType
    FLOAT                       = 0x1406    # DataType
    DOUBLE                      = 0x140A    # DataType
passthru: /* LogicOp */
    CLEAR                       = 0x1500    # LogicOp
    AND                     = 0x1501    # LogicOp
    AND_REVERSE                 = 0x1502    # LogicOp
    COPY                        = 0x1503    # LogicOp
    AND_INVERTED                    = 0x1504    # LogicOp
    NOOP                        = 0x1505    # LogicOp
    XOR                     = 0x1506    # LogicOp
    OR                      = 0x1507    # LogicOp
    NOR                     = 0x1508    # LogicOp
    EQUIV                       = 0x1509    # LogicOp
    INVERT                      = 0x150A    # LogicOp
    OR_REVERSE                  = 0x150B    # LogicOp
    COPY_INVERTED                   = 0x150C    # LogicOp
    OR_INVERTED                 = 0x150D    # LogicOp
    NAND                        = 0x150E    # LogicOp
    SET                     = 0x150F    # LogicOp
passthru: /* MatrixMode (for gl3.h, FBO attachment type) */
    TEXTURE                     = 0x1702    # MatrixMode
passthru: /* PixelCopyType */
    COLOR                       = 0x1800    # PixelCopyType
    DEPTH                       = 0x1801    # PixelCopyType
    STENCIL                     = 0x1802    # PixelCopyType
passthru: /* PixelFormat */
    STENCIL_INDEX                   = 0x1901    # PixelFormat
    DEPTH_COMPONENT                 = 0x1902    # PixelFormat
    RED                     = 0x1903    # PixelFormat
    GREEN                       = 0x1904    # PixelFormat
    BLUE                        = 0x1905    # PixelFormat
    ALPHA                       = 0x1906    # PixelFormat
    RGB                     = 0x1907    # PixelFormat
    RGBA                        = 0x1908    # PixelFormat
passthru: /* PolygonMode */
    POINT                       = 0x1B00    # PolygonMode
    LINE                        = 0x1B01    # PolygonMode
    FILL                        = 0x1B02    # PolygonMode
passthru: /* StencilOp */
    KEEP                        = 0x1E00    # StencilOp
    REPLACE                     = 0x1E01    # StencilOp
    INCR                        = 0x1E02    # StencilOp
    DECR                        = 0x1E03    # StencilOp
passthru: /* StringName */
    VENDOR                      = 0x1F00    # StringName
    RENDERER                    = 0x1F01    # StringName
    VERSION                     = 0x1F02    # StringName
    EXTENSIONS                  = 0x1F03    # StringName
passthru: /* TextureMagFilter */
    NEAREST                     = 0x2600    # TextureMagFilter
    LINEAR                      = 0x2601    # TextureMagFilter
passthru: /* TextureMinFilter */
    NEAREST_MIPMAP_NEAREST              = 0x2700    # TextureMinFilter
    LINEAR_MIPMAP_NEAREST               = 0x2701    # TextureMinFilter
    NEAREST_MIPMAP_LINEAR               = 0x2702    # TextureMinFilter
    LINEAR_MIPMAP_LINEAR                = 0x2703    # TextureMinFilter
passthru: /* TextureParameterName */
    TEXTURE_MAG_FILTER              = 0x2800    # TextureParameterName
    TEXTURE_MIN_FILTER              = 0x2801    # TextureParameterName
    TEXTURE_WRAP_S                  = 0x2802    # TextureParameterName
    TEXTURE_WRAP_T                  = 0x2803    # TextureParameterName
passthru: /* TextureTarget */
    PROXY_TEXTURE_1D                = 0x8063    # TextureTarget
    PROXY_TEXTURE_2D                = 0x8064    # TextureTarget
passthru: /* TextureWrapMode */
    REPEAT                      = 0x2901    # TextureWrapMode
passthru: /* PixelInternalFormat */
    R3_G3_B2                    = 0x2A10    # PixelInternalFormat
    RGB4                        = 0x804F    # PixelInternalFormat
    RGB5                        = 0x8050    # PixelInternalFormat
    RGB8                        = 0x8051    # PixelInternalFormat
    RGB10                       = 0x8052    # PixelInternalFormat
    RGB12                       = 0x8053    # PixelInternalFormat
    RGB16                       = 0x8054    # PixelInternalFormat
    RGBA2                       = 0x8055    # PixelInternalFormat
    RGBA4                       = 0x8056    # PixelInternalFormat
    RGB5_A1                     = 0x8057    # PixelInternalFormat
    RGBA8                       = 0x8058    # PixelInternalFormat
    RGB10_A2                    = 0x8059    # PixelInternalFormat
    RGBA12                      = 0x805A    # PixelInternalFormat
    RGBA16                      = 0x805B    # PixelInternalFormat

VERSION_1_1_DEPRECATED enum:
passthru: /* AttribMask */
    CURRENT_BIT                 = 0x00000001    # AttribMask
    POINT_BIT                   = 0x00000002    # AttribMask
    LINE_BIT                    = 0x00000004    # AttribMask
    POLYGON_BIT                 = 0x00000008    # AttribMask
    POLYGON_STIPPLE_BIT             = 0x00000010    # AttribMask
    PIXEL_MODE_BIT                  = 0x00000020    # AttribMask
    LIGHTING_BIT                    = 0x00000040    # AttribMask
    FOG_BIT                     = 0x00000080    # AttribMask
    ACCUM_BUFFER_BIT                = 0x00000200    # AttribMask
    VIEWPORT_BIT                    = 0x00000800    # AttribMask
    TRANSFORM_BIT                   = 0x00001000    # AttribMask
    ENABLE_BIT                  = 0x00002000    # AttribMask
    HINT_BIT                    = 0x00008000    # AttribMask
    EVAL_BIT                    = 0x00010000    # AttribMask
    LIST_BIT                    = 0x00020000    # AttribMask
    TEXTURE_BIT                 = 0x00040000    # AttribMask
    SCISSOR_BIT                 = 0x00080000    # AttribMask
    ALL_ATTRIB_BITS                 = 0xFFFFFFFF    # AttribMask
passthru: /* ClientAttribMask */
    CLIENT_PIXEL_STORE_BIT              = 0x00000001    # ClientAttribMask
    CLIENT_VERTEX_ARRAY_BIT             = 0x00000002    # ClientAttribMask
    CLIENT_ALL_ATTRIB_BITS              = 0xFFFFFFFF    # ClientAttribMask
passthru: /* BeginMode */
    QUADS                       = 0x0007    # BeginMode
    QUAD_STRIP                  = 0x0008    # BeginMode
    POLYGON                     = 0x0009    # BeginMode
passthru: /* AccumOp */
    ACCUM                       = 0x0100    # AccumOp
    LOAD                        = 0x0101    # AccumOp
    RETURN                      = 0x0102    # AccumOp
    MULT                        = 0x0103    # AccumOp
    ADD                     = 0x0104    # AccumOp
passthru: /* DrawBufferMode */
    AUX0                        = 0x0409    # DrawBufferMode
    AUX1                        = 0x040A    # DrawBufferMode
    AUX2                        = 0x040B    # DrawBufferMode
    AUX3                        = 0x040C    # DrawBufferMode
passthru: /* ErrorCode */
    STACK_OVERFLOW                  = 0x0503    # ErrorCode
    STACK_UNDERFLOW                 = 0x0504    # ErrorCode
passthru: /* FeedbackType */
    2D                      = 0x0600    # FeedbackType
    3D                      = 0x0601    # FeedbackType
    3D_COLOR                    = 0x0602    # FeedbackType
    3D_COLOR_TEXTURE                = 0x0603    # FeedbackType
    4D_COLOR_TEXTURE                = 0x0604    # FeedbackType
passthru: /* FeedBackToken */
    PASS_THROUGH_TOKEN              = 0x0700    # FeedBackToken
    POINT_TOKEN                 = 0x0701    # FeedBackToken
    LINE_TOKEN                  = 0x0702    # FeedBackToken
    POLYGON_TOKEN                   = 0x0703    # FeedBackToken
    BITMAP_TOKEN                    = 0x0704    # FeedBackToken
    DRAW_PIXEL_TOKEN                = 0x0705    # FeedBackToken
    COPY_PIXEL_TOKEN                = 0x0706    # FeedBackToken
    LINE_RESET_TOKEN                = 0x0707    # FeedBackToken
passthru: /* FogMode */
    EXP                     = 0x0800    # FogMode
    EXP2                        = 0x0801    # FogMode
passthru: /* GetMapQuery */
    COEFF                       = 0x0A00    # GetMapQuery
    ORDER                       = 0x0A01    # GetMapQuery
    DOMAIN                      = 0x0A02    # GetMapQuery
passthru: /* GetPixelMap */
    PIXEL_MAP_I_TO_I                = 0x0C70    # GetPixelMap
    PIXEL_MAP_S_TO_S                = 0x0C71    # GetPixelMap
    PIXEL_MAP_I_TO_R                = 0x0C72    # GetPixelMap
    PIXEL_MAP_I_TO_G                = 0x0C73    # GetPixelMap
    PIXEL_MAP_I_TO_B                = 0x0C74    # GetPixelMap
    PIXEL_MAP_I_TO_A                = 0x0C75    # GetPixelMap
    PIXEL_MAP_R_TO_R                = 0x0C76    # GetPixelMap
    PIXEL_MAP_G_TO_G                = 0x0C77    # GetPixelMap
    PIXEL_MAP_B_TO_B                = 0x0C78    # GetPixelMap
    PIXEL_MAP_A_TO_A                = 0x0C79    # GetPixelMap
passthru: /* GetPointervPName */
    VERTEX_ARRAY_POINTER                = 0x808E    # GetPointervPName
    NORMAL_ARRAY_POINTER                = 0x808F    # GetPointervPName
    COLOR_ARRAY_POINTER             = 0x8090    # GetPointervPName
    INDEX_ARRAY_POINTER             = 0x8091    # GetPointervPName
    TEXTURE_COORD_ARRAY_POINTER         = 0x8092    # GetPointervPName
    EDGE_FLAG_ARRAY_POINTER             = 0x8093    # GetPointervPName
    FEEDBACK_BUFFER_POINTER             = 0x0DF0    # GetPointervPName
    SELECTION_BUFFER_POINTER            = 0x0DF3    # GetPointervPName
passthru: /* GetPName */
    CURRENT_COLOR                   = 0x0B00 # 4 F  # GetPName
    CURRENT_INDEX                   = 0x0B01 # 1 F  # GetPName
    CURRENT_NORMAL                  = 0x0B02 # 3 F  # GetPName
    CURRENT_TEXTURE_COORDS              = 0x0B03 # 4 F  # GetPName
    CURRENT_RASTER_COLOR                = 0x0B04 # 4 F  # GetPName
    CURRENT_RASTER_INDEX                = 0x0B05 # 1 F  # GetPName
    CURRENT_RASTER_TEXTURE_COORDS           = 0x0B06 # 4 F  # GetPName
    CURRENT_RASTER_POSITION             = 0x0B07 # 4 F  # GetPName
    CURRENT_RASTER_POSITION_VALID           = 0x0B08 # 1 I  # GetPName
    CURRENT_RASTER_DISTANCE             = 0x0B09 # 1 F  # GetPName
    POINT_SMOOTH                    = 0x0B10 # 1 I  # GetPName
    LINE_STIPPLE                    = 0x0B24 # 1 I  # GetPName
    LINE_STIPPLE_PATTERN                = 0x0B25 # 1 I  # GetPName
    LINE_STIPPLE_REPEAT             = 0x0B26 # 1 I  # GetPName
    LIST_MODE                   = 0x0B30 # 1 I  # GetPName
    MAX_LIST_NESTING                = 0x0B31 # 1 I  # GetPName
    LIST_BASE                   = 0x0B32 # 1 I  # GetPName
    LIST_INDEX                  = 0x0B33 # 1 I  # GetPName
    POLYGON_MODE                    = 0x0B40 # 2 I  # GetPName
    POLYGON_STIPPLE                 = 0x0B42 # 1 I  # GetPName
    EDGE_FLAG                   = 0x0B43 # 1 I  # GetPName
    LIGHTING                    = 0x0B50 # 1 I  # GetPName
    LIGHT_MODEL_LOCAL_VIEWER            = 0x0B51 # 1 I  # GetPName
    LIGHT_MODEL_TWO_SIDE                = 0x0B52 # 1 I  # GetPName
    LIGHT_MODEL_AMBIENT             = 0x0B53 # 4 F  # GetPName
    SHADE_MODEL                 = 0x0B54 # 1 I  # GetPName
    COLOR_MATERIAL_FACE             = 0x0B55 # 1 I  # GetPName
    COLOR_MATERIAL_PARAMETER            = 0x0B56 # 1 I  # GetPName
    COLOR_MATERIAL                  = 0x0B57 # 1 I  # GetPName
    FOG                     = 0x0B60 # 1 I  # GetPName
    FOG_INDEX                   = 0x0B61 # 1 I  # GetPName
    FOG_DENSITY                 = 0x0B62 # 1 F  # GetPName
    FOG_START                   = 0x0B63 # 1 F  # GetPName
    FOG_END                     = 0x0B64 # 1 F  # GetPName
    FOG_MODE                    = 0x0B65 # 1 I  # GetPName
    FOG_COLOR                   = 0x0B66 # 4 F  # GetPName
    ACCUM_CLEAR_VALUE               = 0x0B80 # 4 F  # GetPName
    MATRIX_MODE                 = 0x0BA0 # 1 I  # GetPName
    NORMALIZE                   = 0x0BA1 # 1 I  # GetPName
    MODELVIEW_STACK_DEPTH               = 0x0BA3 # 1 I  # GetPName
    PROJECTION_STACK_DEPTH              = 0x0BA4 # 1 I  # GetPName
    TEXTURE_STACK_DEPTH             = 0x0BA5 # 1 I  # GetPName
    MODELVIEW_MATRIX                = 0x0BA6 # 16 F # GetPName
    PROJECTION_MATRIX               = 0x0BA7 # 16 F # GetPName
    TEXTURE_MATRIX                  = 0x0BA8 # 16 F # GetPName
    ATTRIB_STACK_DEPTH              = 0x0BB0 # 1 I  # GetPName
    CLIENT_ATTRIB_STACK_DEPTH           = 0x0BB1 # 1 I  # GetPName
    ALPHA_TEST                  = 0x0BC0 # 1 I  # GetPName
    ALPHA_TEST_FUNC                 = 0x0BC1 # 1 I  # GetPName
    ALPHA_TEST_REF                  = 0x0BC2 # 1 F  # GetPName
    INDEX_LOGIC_OP                  = 0x0BF1 # 1 I  # GetPName
    LOGIC_OP                    = 0x0BF1 # 1 I  # GetPName
    AUX_BUFFERS                 = 0x0C00 # 1 I  # GetPName
    INDEX_CLEAR_VALUE               = 0x0C20 # 1 I  # GetPName
    INDEX_WRITEMASK                 = 0x0C21 # 1 I  # GetPName
    INDEX_MODE                  = 0x0C30 # 1 I  # GetPName
    RGBA_MODE                   = 0x0C31 # 1 I  # GetPName
    RENDER_MODE                 = 0x0C40 # 1 I  # GetPName
    PERSPECTIVE_CORRECTION_HINT         = 0x0C50 # 1 I  # GetPName
    POINT_SMOOTH_HINT               = 0x0C51 # 1 I  # GetPName
    FOG_HINT                    = 0x0C54 # 1 I  # GetPName
    TEXTURE_GEN_S                   = 0x0C60 # 1 I  # GetPName
    TEXTURE_GEN_T                   = 0x0C61 # 1 I  # GetPName
    TEXTURE_GEN_R                   = 0x0C62 # 1 I  # GetPName
    TEXTURE_GEN_Q                   = 0x0C63 # 1 I  # GetPName
    PIXEL_MAP_I_TO_I_SIZE               = 0x0CB0 # 1 I  # GetPName
    PIXEL_MAP_S_TO_S_SIZE               = 0x0CB1 # 1 I  # GetPName
    PIXEL_MAP_I_TO_R_SIZE               = 0x0CB2 # 1 I  # GetPName
    PIXEL_MAP_I_TO_G_SIZE               = 0x0CB3 # 1 I  # GetPName
    PIXEL_MAP_I_TO_B_SIZE               = 0x0CB4 # 1 I  # GetPName
    PIXEL_MAP_I_TO_A_SIZE               = 0x0CB5 # 1 I  # GetPName
    PIXEL_MAP_R_TO_R_SIZE               = 0x0CB6 # 1 I  # GetPName
    PIXEL_MAP_G_TO_G_SIZE               = 0x0CB7 # 1 I  # GetPName
    PIXEL_MAP_B_TO_B_SIZE               = 0x0CB8 # 1 I  # GetPName
    PIXEL_MAP_A_TO_A_SIZE               = 0x0CB9 # 1 I  # GetPName
    MAP_COLOR                   = 0x0D10 # 1 I  # GetPName
    MAP_STENCIL                 = 0x0D11 # 1 I  # GetPName
    INDEX_SHIFT                 = 0x0D12 # 1 I  # GetPName
    INDEX_OFFSET                    = 0x0D13 # 1 I  # GetPName
    RED_SCALE                   = 0x0D14 # 1 F  # GetPName
    RED_BIAS                    = 0x0D15 # 1 F  # GetPName
    ZOOM_X                      = 0x0D16 # 1 F  # GetPName
    ZOOM_Y                      = 0x0D17 # 1 F  # GetPName
    GREEN_SCALE                 = 0x0D18 # 1 F  # GetPName
    GREEN_BIAS                  = 0x0D19 # 1 F  # GetPName
    BLUE_SCALE                  = 0x0D1A # 1 F  # GetPName
    BLUE_BIAS                   = 0x0D1B # 1 F  # GetPName
    ALPHA_SCALE                 = 0x0D1C # 1 F  # GetPName
    ALPHA_BIAS                  = 0x0D1D # 1 F  # GetPName
    DEPTH_SCALE                 = 0x0D1E # 1 F  # GetPName
    DEPTH_BIAS                  = 0x0D1F # 1 F  # GetPName
    MAX_EVAL_ORDER                  = 0x0D30 # 1 I  # GetPName
    MAX_LIGHTS                  = 0x0D31 # 1 I  # GetPName
    MAX_CLIP_PLANES                 = 0x0D32 # 1 I  # GetPName
    MAX_PIXEL_MAP_TABLE             = 0x0D34 # 1 I  # GetPName
    MAX_ATTRIB_STACK_DEPTH              = 0x0D35 # 1 I  # GetPName
    MAX_MODELVIEW_STACK_DEPTH           = 0x0D36 # 1 I  # GetPName
    MAX_NAME_STACK_DEPTH                = 0x0D37 # 1 I  # GetPName
    MAX_PROJECTION_STACK_DEPTH          = 0x0D38 # 1 I  # GetPName
    MAX_TEXTURE_STACK_DEPTH             = 0x0D39 # 1 I  # GetPName
    MAX_CLIENT_ATTRIB_STACK_DEPTH           = 0x0D3B # 1 I  # GetPName
    INDEX_BITS                  = 0x0D51 # 1 I  # GetPName
    RED_BITS                    = 0x0D52 # 1 I  # GetPName
    GREEN_BITS                  = 0x0D53 # 1 I  # GetPName
    BLUE_BITS                   = 0x0D54 # 1 I  # GetPName
    ALPHA_BITS                  = 0x0D55 # 1 I  # GetPName
    DEPTH_BITS                  = 0x0D56 # 1 I  # GetPName
    STENCIL_BITS                    = 0x0D57 # 1 I  # GetPName
    ACCUM_RED_BITS                  = 0x0D58 # 1 I  # GetPName
    ACCUM_GREEN_BITS                = 0x0D59 # 1 I  # GetPName
    ACCUM_BLUE_BITS                 = 0x0D5A # 1 I  # GetPName
    ACCUM_ALPHA_BITS                = 0x0D5B # 1 I  # GetPName
    NAME_STACK_DEPTH                = 0x0D70 # 1 I  # GetPName
    AUTO_NORMAL                 = 0x0D80 # 1 I  # GetPName
    MAP1_COLOR_4                    = 0x0D90 # 1 I  # GetPName
    MAP1_INDEX                  = 0x0D91 # 1 I  # GetPName
    MAP1_NORMAL                 = 0x0D92 # 1 I  # GetPName
    MAP1_TEXTURE_COORD_1                = 0x0D93 # 1 I  # GetPName
    MAP1_TEXTURE_COORD_2                = 0x0D94 # 1 I  # GetPName
    MAP1_TEXTURE_COORD_3                = 0x0D95 # 1 I  # GetPName
    MAP1_TEXTURE_COORD_4                = 0x0D96 # 1 I  # GetPName
    MAP1_VERTEX_3                   = 0x0D97 # 1 I  # GetPName
    MAP1_VERTEX_4                   = 0x0D98 # 1 I  # GetPName
    MAP2_COLOR_4                    = 0x0DB0 # 1 I  # GetPName
    MAP2_INDEX                  = 0x0DB1 # 1 I  # GetPName
    MAP2_NORMAL                 = 0x0DB2 # 1 I  # GetPName
    MAP2_TEXTURE_COORD_1                = 0x0DB3 # 1 I  # GetPName
    MAP2_TEXTURE_COORD_2                = 0x0DB4 # 1 I  # GetPName
    MAP2_TEXTURE_COORD_3                = 0x0DB5 # 1 I  # GetPName
    MAP2_TEXTURE_COORD_4                = 0x0DB6 # 1 I  # GetPName
    MAP2_VERTEX_3                   = 0x0DB7 # 1 I  # GetPName
    MAP2_VERTEX_4                   = 0x0DB8 # 1 I  # GetPName
    MAP1_GRID_DOMAIN                = 0x0DD0 # 2 F  # GetPName
    MAP1_GRID_SEGMENTS              = 0x0DD1 # 1 I  # GetPName
    MAP2_GRID_DOMAIN                = 0x0DD2 # 4 F  # GetPName
    MAP2_GRID_SEGMENTS              = 0x0DD3 # 2 I  # GetPName
    FEEDBACK_BUFFER_SIZE                = 0x0DF1 # 1 I  # GetPName
    FEEDBACK_BUFFER_TYPE                = 0x0DF2 # 1 I  # GetPName
    SELECTION_BUFFER_SIZE               = 0x0DF4 # 1 I  # GetPName
    VERTEX_ARRAY                    = 0x8074 # 1 I  # GetPName
    NORMAL_ARRAY                    = 0x8075 # 1 I  # GetPName
    COLOR_ARRAY                 = 0x8076 # 1 I  # GetPName
    INDEX_ARRAY                 = 0x8077 # 1 I  # GetPName
    TEXTURE_COORD_ARRAY             = 0x8078 # 1 I  # GetPName
    EDGE_FLAG_ARRAY                 = 0x8079 # 1 I  # GetPName
    VERTEX_ARRAY_SIZE               = 0x807A # 1 I  # GetPName
    VERTEX_ARRAY_TYPE               = 0x807B # 1 I  # GetPName
    VERTEX_ARRAY_STRIDE             = 0x807C # 1 I  # GetPName
    NORMAL_ARRAY_TYPE               = 0x807E # 1 I  # GetPName
    NORMAL_ARRAY_STRIDE             = 0x807F # 1 I  # GetPName
    COLOR_ARRAY_SIZE                = 0x8081 # 1 I  # GetPName
    COLOR_ARRAY_TYPE                = 0x8082 # 1 I  # GetPName
    COLOR_ARRAY_STRIDE              = 0x8083 # 1 I  # GetPName
    INDEX_ARRAY_TYPE                = 0x8085 # 1 I  # GetPName
    INDEX_ARRAY_STRIDE              = 0x8086 # 1 I  # GetPName
    TEXTURE_COORD_ARRAY_SIZE            = 0x8088 # 1 I  # GetPName
    TEXTURE_COORD_ARRAY_TYPE            = 0x8089 # 1 I  # GetPName
    TEXTURE_COORD_ARRAY_STRIDE          = 0x808A # 1 I  # GetPName
    EDGE_FLAG_ARRAY_STRIDE              = 0x808C # 1 I  # GetPName
passthru: /* GetTextureParameter */
    TEXTURE_COMPONENTS              = 0x1003    # GetTextureParameter
    TEXTURE_LUMINANCE_SIZE              = 0x8060    # GetTextureParameter
    TEXTURE_INTENSITY_SIZE              = 0x8061    # GetTextureParameter
    TEXTURE_PRIORITY                = 0x8066    # GetTextureParameter
    TEXTURE_RESIDENT                = 0x8067    # GetTextureParameter
passthru: /* LightParameter */
    AMBIENT                     = 0x1200    # LightParameter
    DIFFUSE                     = 0x1201    # LightParameter
    SPECULAR                    = 0x1202    # LightParameter
    POSITION                    = 0x1203    # LightParameter
    SPOT_DIRECTION                  = 0x1204    # LightParameter
    SPOT_EXPONENT                   = 0x1205    # LightParameter
    SPOT_CUTOFF                 = 0x1206    # LightParameter
    CONSTANT_ATTENUATION                = 0x1207    # LightParameter
    LINEAR_ATTENUATION              = 0x1208    # LightParameter
    QUADRATIC_ATTENUATION               = 0x1209    # LightParameter
passthru: /* ListMode */
    COMPILE                     = 0x1300    # ListMode
    COMPILE_AND_EXECUTE             = 0x1301    # ListMode
passthru: /* DataType */
    2_BYTES                     = 0x1407    # DataType
    3_BYTES                     = 0x1408    # DataType
    4_BYTES                     = 0x1409    # DataType
passthru: /* MaterialParameter */
    EMISSION                    = 0x1600    # MaterialParameter
    SHININESS                   = 0x1601    # MaterialParameter
    AMBIENT_AND_DIFFUSE             = 0x1602    # MaterialParameter
    COLOR_INDEXES                   = 0x1603    # MaterialParameter
passthru: /* MatrixMode */
    MODELVIEW                   = 0x1700    # MatrixMode
    PROJECTION                  = 0x1701    # MatrixMode
passthru: /* PixelFormat */
    COLOR_INDEX                 = 0x1900    # PixelFormat
    LUMINANCE                   = 0x1909    # PixelFormat
    LUMINANCE_ALPHA                 = 0x190A    # PixelFormat
passthru: /* PixelType */
    BITMAP                      = 0x1A00    # PixelType
passthru: /* RenderingMode */
    RENDER                      = 0x1C00    # RenderingMode
    FEEDBACK                    = 0x1C01    # RenderingMode
    SELECT                      = 0x1C02    # RenderingMode
passthru: /* ShadingModel */
    FLAT                        = 0x1D00    # ShadingModel
    SMOOTH                      = 0x1D01    # ShadingModel
passthru: /* TextureCoordName */
    S                       = 0x2000    # TextureCoordName
    T                       = 0x2001    # TextureCoordName
    R                       = 0x2002    # TextureCoordName
    Q                       = 0x2003    # TextureCoordName
passthru: /* TextureEnvMode */
    MODULATE                    = 0x2100    # TextureEnvMode
    DECAL                       = 0x2101    # TextureEnvMode
passthru: /* TextureEnvParameter */
    TEXTURE_ENV_MODE                = 0x2200    # TextureEnvParameter
    TEXTURE_ENV_COLOR               = 0x2201    # TextureEnvParameter
passthru: /* TextureEnvTarget */
    TEXTURE_ENV                 = 0x2300    # TextureEnvTarget
passthru: /* TextureGenMode */
    EYE_LINEAR                  = 0x2400    # TextureGenMode
    OBJECT_LINEAR                   = 0x2401    # TextureGenMode
    SPHERE_MAP                  = 0x2402    # TextureGenMode
passthru: /* TextureGenParameter */
    TEXTURE_GEN_MODE                = 0x2500    # TextureGenParameter
    OBJECT_PLANE                    = 0x2501    # TextureGenParameter
    EYE_PLANE                   = 0x2502    # TextureGenParameter
passthru: /* TextureWrapMode */
    CLAMP                       = 0x2900    # TextureWrapMode
passthru: /* PixelInternalFormat */
    ALPHA4                      = 0x803B    # PixelInternalFormat
    ALPHA8                      = 0x803C    # PixelInternalFormat
    ALPHA12                     = 0x803D    # PixelInternalFormat
    ALPHA16                     = 0x803E    # PixelInternalFormat
    LUMINANCE4                  = 0x803F    # PixelInternalFormat
    LUMINANCE8                  = 0x8040    # PixelInternalFormat
    LUMINANCE12                 = 0x8041    # PixelInternalFormat
    LUMINANCE16                 = 0x8042    # PixelInternalFormat
    LUMINANCE4_ALPHA4               = 0x8043    # PixelInternalFormat
    LUMINANCE6_ALPHA2               = 0x8044    # PixelInternalFormat
    LUMINANCE8_ALPHA8               = 0x8045    # PixelInternalFormat
    LUMINANCE12_ALPHA4              = 0x8046    # PixelInternalFormat
    LUMINANCE12_ALPHA12             = 0x8047    # PixelInternalFormat
    LUMINANCE16_ALPHA16             = 0x8048    # PixelInternalFormat
    INTENSITY                   = 0x8049    # PixelInternalFormat
    INTENSITY4                  = 0x804A    # PixelInternalFormat
    INTENSITY8                  = 0x804B    # PixelInternalFormat
    INTENSITY12                 = 0x804C    # PixelInternalFormat
    INTENSITY16                 = 0x804D    # PixelInternalFormat
passthru: /* InterleavedArrayFormat */
    V2F                     = 0x2A20    # InterleavedArrayFormat
    V3F                     = 0x2A21    # InterleavedArrayFormat
    C4UB_V2F                    = 0x2A22    # InterleavedArrayFormat
    C4UB_V3F                    = 0x2A23    # InterleavedArrayFormat
    C3F_V3F                     = 0x2A24    # InterleavedArrayFormat
    N3F_V3F                     = 0x2A25    # InterleavedArrayFormat
    C4F_N3F_V3F                 = 0x2A26    # InterleavedArrayFormat
    T2F_V3F                     = 0x2A27    # InterleavedArrayFormat
    T4F_V4F                     = 0x2A28    # InterleavedArrayFormat
    T2F_C4UB_V3F                    = 0x2A29    # InterleavedArrayFormat
    T2F_C3F_V3F                 = 0x2A2A    # InterleavedArrayFormat
    T2F_N3F_V3F                 = 0x2A2B    # InterleavedArrayFormat
    T2F_C4F_N3F_V3F                 = 0x2A2C    # InterleavedArrayFormat
    T4F_C4F_N3F_V4F                 = 0x2A2D    # InterleavedArrayFormat
passthru: /* ClipPlaneName */
    CLIP_PLANE0                 = 0x3000 # 1 I  # ClipPlaneName
    CLIP_PLANE1                 = 0x3001 # 1 I  # ClipPlaneName
    CLIP_PLANE2                 = 0x3002 # 1 I  # ClipPlaneName
    CLIP_PLANE3                 = 0x3003 # 1 I  # ClipPlaneName
    CLIP_PLANE4                 = 0x3004 # 1 I  # ClipPlaneName
    CLIP_PLANE5                 = 0x3005 # 1 I  # ClipPlaneName
passthru: /* LightName */
    LIGHT0                      = 0x4000 # 1 I  # LightName
    LIGHT1                      = 0x4001 # 1 I  # LightName
    LIGHT2                      = 0x4002 # 1 I  # LightName
    LIGHT3                      = 0x4003 # 1 I  # LightName
    LIGHT4                      = 0x4004 # 1 I  # LightName
    LIGHT5                      = 0x4005 # 1 I  # LightName
    LIGHT6                      = 0x4006 # 1 I  # LightName
    LIGHT7                      = 0x4007 # 1 I  # LightName


###############################################################################
#
# OpenGL 1.2 enums
#
###############################################################################

VERSION_1_2 enum:
    UNSIGNED_BYTE_3_3_2             = 0x8032 # Equivalent to EXT_packed_pixels
    UNSIGNED_SHORT_4_4_4_4              = 0x8033
    UNSIGNED_SHORT_5_5_5_1              = 0x8034
    UNSIGNED_INT_8_8_8_8                = 0x8035
    UNSIGNED_INT_10_10_10_2             = 0x8036
    TEXTURE_BINDING_3D              = 0x806A # 1 I
    PACK_SKIP_IMAGES                = 0x806B # 1 I
    PACK_IMAGE_HEIGHT               = 0x806C # 1 F
    UNPACK_SKIP_IMAGES              = 0x806D # 1 I
    UNPACK_IMAGE_HEIGHT             = 0x806E # 1 F
    TEXTURE_3D                  = 0x806F # 1 I
    PROXY_TEXTURE_3D                = 0x8070
    TEXTURE_DEPTH                   = 0x8071
    TEXTURE_WRAP_R                  = 0x8072
    MAX_3D_TEXTURE_SIZE             = 0x8073 # 1 I
    UNSIGNED_BYTE_2_3_3_REV             = 0x8362 # New for OpenGL 1.2
    UNSIGNED_SHORT_5_6_5                = 0x8363
    UNSIGNED_SHORT_5_6_5_REV            = 0x8364
    UNSIGNED_SHORT_4_4_4_4_REV          = 0x8365
    UNSIGNED_SHORT_1_5_5_5_REV          = 0x8366
    UNSIGNED_INT_8_8_8_8_REV            = 0x8367
    UNSIGNED_INT_2_10_10_10_REV         = 0x8368
    BGR                     = 0x80E0
    BGRA                        = 0x80E1
    MAX_ELEMENTS_VERTICES               = 0x80E8
    MAX_ELEMENTS_INDICES                = 0x80E9
    CLAMP_TO_EDGE                   = 0x812F # Equivalent to SGIS_texture_edge_clamp
    TEXTURE_MIN_LOD                 = 0x813A # Equivalent to SGIS_texture_lod
    TEXTURE_MAX_LOD                 = 0x813B
    TEXTURE_BASE_LEVEL              = 0x813C
    TEXTURE_MAX_LEVEL               = 0x813D
    SMOOTH_POINT_SIZE_RANGE             = 0x0B12 # 2 F
    SMOOTH_POINT_SIZE_GRANULARITY           = 0x0B13 # 1 F
    SMOOTH_LINE_WIDTH_RANGE             = 0x0B22 # 2 F
    SMOOTH_LINE_WIDTH_GRANULARITY           = 0x0B23 # 1 F
    ALIASED_LINE_WIDTH_RANGE            = 0x846E # 2 F

VERSION_1_2_DEPRECATED enum:
    RESCALE_NORMAL                  = 0x803A # 1 I # Equivalent to EXT_rescale_normal
    LIGHT_MODEL_COLOR_CONTROL           = 0x81F8 # 1 I
    SINGLE_COLOR                    = 0x81F9
    SEPARATE_SPECULAR_COLOR             = 0x81FA
    ALIASED_POINT_SIZE_RANGE            = 0x846D # 2 F

ARB_imaging enum:
    CONSTANT_COLOR                  = 0x8001 # Equivalent to EXT_blend_color
    ONE_MINUS_CONSTANT_COLOR            = 0x8002
    CONSTANT_ALPHA                  = 0x8003
    ONE_MINUS_CONSTANT_ALPHA            = 0x8004
    BLEND_COLOR                 = 0x8005 # 4 F
    FUNC_ADD                    = 0x8006 # Equivalent to EXT_blend_minmax
    MIN                     = 0x8007
    MAX                     = 0x8008
    BLEND_EQUATION                  = 0x8009 # 1 I
    FUNC_SUBTRACT                   = 0x800A # Equivalent to EXT_blend_subtract
    FUNC_REVERSE_SUBTRACT               = 0x800B

ARB_imaging_DEPRECATED enum:
    CONVOLUTION_1D                  = 0x8010 # 1 I # Equivalent to EXT_convolution
    CONVOLUTION_2D                  = 0x8011 # 1 I
    SEPARABLE_2D                    = 0x8012 # 1 I
    CONVOLUTION_BORDER_MODE             = 0x8013
    CONVOLUTION_FILTER_SCALE            = 0x8014
    CONVOLUTION_FILTER_BIAS             = 0x8015
    REDUCE                      = 0x8016
    CONVOLUTION_FORMAT              = 0x8017
    CONVOLUTION_WIDTH               = 0x8018
    CONVOLUTION_HEIGHT              = 0x8019
    MAX_CONVOLUTION_WIDTH               = 0x801A
    MAX_CONVOLUTION_HEIGHT              = 0x801B
    POST_CONVOLUTION_RED_SCALE          = 0x801C # 1 F
    POST_CONVOLUTION_GREEN_SCALE            = 0x801D # 1 F
    POST_CONVOLUTION_BLUE_SCALE         = 0x801E # 1 F
    POST_CONVOLUTION_ALPHA_SCALE            = 0x801F # 1 F
    POST_CONVOLUTION_RED_BIAS           = 0x8020 # 1 F
    POST_CONVOLUTION_GREEN_BIAS         = 0x8021 # 1 F
    POST_CONVOLUTION_BLUE_BIAS          = 0x8022 # 1 F
    POST_CONVOLUTION_ALPHA_BIAS         = 0x8023 # 1 F
    HISTOGRAM                   = 0x8024 # 1 I # Equivalent to EXT_histogram
    PROXY_HISTOGRAM                 = 0x8025
    HISTOGRAM_WIDTH                 = 0x8026
    HISTOGRAM_FORMAT                = 0x8027
    HISTOGRAM_RED_SIZE              = 0x8028
    HISTOGRAM_GREEN_SIZE                = 0x8029
    HISTOGRAM_BLUE_SIZE             = 0x802A
    HISTOGRAM_ALPHA_SIZE                = 0x802B
    HISTOGRAM_LUMINANCE_SIZE            = 0x802C
    HISTOGRAM_SINK                  = 0x802D
    MINMAX                      = 0x802E # 1 I
    MINMAX_FORMAT                   = 0x802F
    MINMAX_SINK                 = 0x8030
    TABLE_TOO_LARGE                 = 0x8031
    COLOR_MATRIX                    = 0x80B1 # 16 F # Equivalent to SGI_color_matrix
    COLOR_MATRIX_STACK_DEPTH            = 0x80B2 # 1 I
    MAX_COLOR_MATRIX_STACK_DEPTH            = 0x80B3 # 1 I
    POST_COLOR_MATRIX_RED_SCALE         = 0x80B4 # 1 F
    POST_COLOR_MATRIX_GREEN_SCALE           = 0x80B5 # 1 F
    POST_COLOR_MATRIX_BLUE_SCALE            = 0x80B6 # 1 F
    POST_COLOR_MATRIX_ALPHA_SCALE           = 0x80B7 # 1 F
    POST_COLOR_MATRIX_RED_BIAS          = 0x80B8 # 1 F
    POST_COLOR_MATRIX_GREEN_BIAS            = 0x80B9 # 1 F
    POST_COLOR_MATRIX_BLUE_BIAS         = 0x80BA # 1 F
    POST_COLOR_MATRIX_ALPHA_BIAS            = 0x80BB # 1 F
    COLOR_TABLE                 = 0x80D0 # 1 I # Equivalent to SGI_color_table
    POST_CONVOLUTION_COLOR_TABLE            = 0x80D1 # 1 I
    POST_COLOR_MATRIX_COLOR_TABLE           = 0x80D2 # 1 I
    PROXY_COLOR_TABLE               = 0x80D3
    PROXY_POST_CONVOLUTION_COLOR_TABLE      = 0x80D4
    PROXY_POST_COLOR_MATRIX_COLOR_TABLE     = 0x80D5
    COLOR_TABLE_SCALE               = 0x80D6
    COLOR_TABLE_BIAS                = 0x80D7
    COLOR_TABLE_FORMAT              = 0x80D8
    COLOR_TABLE_WIDTH               = 0x80D9
    COLOR_TABLE_RED_SIZE                = 0x80DA
    COLOR_TABLE_GREEN_SIZE              = 0x80DB
    COLOR_TABLE_BLUE_SIZE               = 0x80DC
    COLOR_TABLE_ALPHA_SIZE              = 0x80DD
    COLOR_TABLE_LUMINANCE_SIZE          = 0x80DE
    COLOR_TABLE_INTENSITY_SIZE          = 0x80DF
    CONSTANT_BORDER                 = 0x8151
    REPLICATE_BORDER                = 0x8153
    CONVOLUTION_BORDER_COLOR            = 0x8154


###############################################################################
#
# OpenGL 1.3 enums
#
###############################################################################

VERSION_1_3 enum:
    TEXTURE0                    = 0x84C0    # Promoted from ARB_multitexture
    TEXTURE1                    = 0x84C1
    TEXTURE2                    = 0x84C2
    TEXTURE3                    = 0x84C3
    TEXTURE4                    = 0x84C4
    TEXTURE5                    = 0x84C5
    TEXTURE6                    = 0x84C6
    TEXTURE7                    = 0x84C7
    TEXTURE8                    = 0x84C8
    TEXTURE9                    = 0x84C9
    TEXTURE10                   = 0x84CA
    TEXTURE11                   = 0x84CB
    TEXTURE12                   = 0x84CC
    TEXTURE13                   = 0x84CD
    TEXTURE14                   = 0x84CE
    TEXTURE15                   = 0x84CF
    TEXTURE16                   = 0x84D0
    TEXTURE17                   = 0x84D1
    TEXTURE18                   = 0x84D2
    TEXTURE19                   = 0x84D3
    TEXTURE20                   = 0x84D4
    TEXTURE21                   = 0x84D5
    TEXTURE22                   = 0x84D6
    TEXTURE23                   = 0x84D7
    TEXTURE24                   = 0x84D8
    TEXTURE25                   = 0x84D9
    TEXTURE26                   = 0x84DA
    TEXTURE27                   = 0x84DB
    TEXTURE28                   = 0x84DC
    TEXTURE29                   = 0x84DD
    TEXTURE30                   = 0x84DE
    TEXTURE31                   = 0x84DF
    ACTIVE_TEXTURE                  = 0x84E0 # 1 I
    MULTISAMPLE                 = 0x809D    # Promoted from ARB_multisample
    SAMPLE_ALPHA_TO_COVERAGE            = 0x809E
    SAMPLE_ALPHA_TO_ONE             = 0x809F
    SAMPLE_COVERAGE                 = 0x80A0
    SAMPLE_BUFFERS                  = 0x80A8
    SAMPLES                     = 0x80A9
    SAMPLE_COVERAGE_VALUE               = 0x80AA
    SAMPLE_COVERAGE_INVERT              = 0x80AB
    TEXTURE_CUBE_MAP                = 0x8513
    TEXTURE_BINDING_CUBE_MAP            = 0x8514
    TEXTURE_CUBE_MAP_POSITIVE_X         = 0x8515
    TEXTURE_CUBE_MAP_NEGATIVE_X         = 0x8516
    TEXTURE_CUBE_MAP_POSITIVE_Y         = 0x8517
    TEXTURE_CUBE_MAP_NEGATIVE_Y         = 0x8518
    TEXTURE_CUBE_MAP_POSITIVE_Z         = 0x8519
    TEXTURE_CUBE_MAP_NEGATIVE_Z         = 0x851A
    PROXY_TEXTURE_CUBE_MAP              = 0x851B
    MAX_CUBE_MAP_TEXTURE_SIZE           = 0x851C
    COMPRESSED_RGB                  = 0x84ED
    COMPRESSED_RGBA                 = 0x84EE
    TEXTURE_COMPRESSION_HINT            = 0x84EF
    TEXTURE_COMPRESSED_IMAGE_SIZE           = 0x86A0
    TEXTURE_COMPRESSED              = 0x86A1
    NUM_COMPRESSED_TEXTURE_FORMATS          = 0x86A2
    COMPRESSED_TEXTURE_FORMATS          = 0x86A3
    CLAMP_TO_BORDER                 = 0x812D    # Promoted from ARB_texture_border_clamp

VERSION_1_3_DEPRECATED enum:
    CLIENT_ACTIVE_TEXTURE               = 0x84E1 # 1 I
    MAX_TEXTURE_UNITS               = 0x84E2 # 1 I
    TRANSPOSE_MODELVIEW_MATRIX          = 0x84E3 # 16 F # Promoted from ARB_transpose_matrix
    TRANSPOSE_PROJECTION_MATRIX         = 0x84E4 # 16 F
    TRANSPOSE_TEXTURE_MATRIX            = 0x84E5 # 16 F
    TRANSPOSE_COLOR_MATRIX              = 0x84E6 # 16 F
    MULTISAMPLE_BIT                 = 0x20000000
    NORMAL_MAP                  = 0x8511    # Promoted from ARB_texture_cube_map
    REFLECTION_MAP                  = 0x8512
    COMPRESSED_ALPHA                = 0x84E9    # Promoted from ARB_texture_compression
    COMPRESSED_LUMINANCE                = 0x84EA
    COMPRESSED_LUMINANCE_ALPHA          = 0x84EB
    COMPRESSED_INTENSITY                = 0x84EC
    COMBINE                     = 0x8570    # Promoted from ARB_texture_env_combine
    COMBINE_RGB                 = 0x8571
    COMBINE_ALPHA                   = 0x8572
    SOURCE0_RGB                 = 0x8580
    SOURCE1_RGB                 = 0x8581
    SOURCE2_RGB                 = 0x8582
    SOURCE0_ALPHA                   = 0x8588
    SOURCE1_ALPHA                   = 0x8589
    SOURCE2_ALPHA                   = 0x858A
    OPERAND0_RGB                    = 0x8590
    OPERAND1_RGB                    = 0x8591
    OPERAND2_RGB                    = 0x8592
    OPERAND0_ALPHA                  = 0x8598
    OPERAND1_ALPHA                  = 0x8599
    OPERAND2_ALPHA                  = 0x859A
    RGB_SCALE                   = 0x8573
    ADD_SIGNED                  = 0x8574
    INTERPOLATE                 = 0x8575
    SUBTRACT                    = 0x84E7
    CONSTANT                    = 0x8576
    PRIMARY_COLOR                   = 0x8577
    PREVIOUS                    = 0x8578
    DOT3_RGB                    = 0x86AE    # Promoted from ARB_texture_env_dot3
    DOT3_RGBA                   = 0x86AF


###############################################################################
#
# OpenGL 1.4 enums
#
###############################################################################

VERSION_1_4 enum:
    BLEND_DST_RGB                   = 0x80C8
    BLEND_SRC_RGB                   = 0x80C9
    BLEND_DST_ALPHA                 = 0x80CA
    BLEND_SRC_ALPHA                 = 0x80CB
    POINT_FADE_THRESHOLD_SIZE           = 0x8128 # 1 F
    DEPTH_COMPONENT16               = 0x81A5
    DEPTH_COMPONENT24               = 0x81A6
    DEPTH_COMPONENT32               = 0x81A7
    MIRRORED_REPEAT                 = 0x8370
    MAX_TEXTURE_LOD_BIAS                = 0x84FD
    TEXTURE_LOD_BIAS                = 0x8501
    INCR_WRAP                   = 0x8507
    DECR_WRAP                   = 0x8508
    TEXTURE_DEPTH_SIZE              = 0x884A
    TEXTURE_COMPARE_MODE                = 0x884C
    TEXTURE_COMPARE_FUNC                = 0x884D

VERSION_1_4_DEPRECATED enum:
    POINT_SIZE_MIN                  = 0x8126 # 1 F
    POINT_SIZE_MAX                  = 0x8127 # 1 F
    POINT_DISTANCE_ATTENUATION          = 0x8129 # 3 F
    GENERATE_MIPMAP                 = 0x8191
    GENERATE_MIPMAP_HINT                = 0x8192 # 1 I
    FOG_COORDINATE_SOURCE               = 0x8450 # 1 I
    FOG_COORDINATE                  = 0x8451
    FRAGMENT_DEPTH                  = 0x8452
    CURRENT_FOG_COORDINATE              = 0x8453 # 1 F
    FOG_COORDINATE_ARRAY_TYPE           = 0x8454 # 1 I
    FOG_COORDINATE_ARRAY_STRIDE         = 0x8455 # 1 I
    FOG_COORDINATE_ARRAY_POINTER            = 0x8456
    FOG_COORDINATE_ARRAY                = 0x8457 # 1 I
    COLOR_SUM                   = 0x8458 # 1 I
    CURRENT_SECONDARY_COLOR             = 0x8459 # 3 F
    SECONDARY_COLOR_ARRAY_SIZE          = 0x845A # 1 I
    SECONDARY_COLOR_ARRAY_TYPE          = 0x845B # 1 I
    SECONDARY_COLOR_ARRAY_STRIDE            = 0x845C # 1 I
    SECONDARY_COLOR_ARRAY_POINTER           = 0x845D
    SECONDARY_COLOR_ARRAY               = 0x845E # 1 I
    TEXTURE_FILTER_CONTROL              = 0x8500
    DEPTH_TEXTURE_MODE              = 0x884B
    COMPARE_R_TO_TEXTURE                = 0x884E


###############################################################################
#
# OpenGL 1.5 enums
#
###############################################################################

VERSION_1_5 enum:
    BUFFER_SIZE                 = 0x8764 # ARB_vertex_buffer_object
    BUFFER_USAGE                    = 0x8765 # ARB_vertex_buffer_object
    QUERY_COUNTER_BITS              = 0x8864 # ARB_occlusion_query
    CURRENT_QUERY                   = 0x8865 # ARB_occlusion_query
    QUERY_RESULT                    = 0x8866 # ARB_occlusion_query
    QUERY_RESULT_AVAILABLE              = 0x8867 # ARB_occlusion_query
    ARRAY_BUFFER                    = 0x8892 # ARB_vertex_buffer_object
    ELEMENT_ARRAY_BUFFER                = 0x8893 # ARB_vertex_buffer_object
    ARRAY_BUFFER_BINDING                = 0x8894 # ARB_vertex_buffer_object
    ELEMENT_ARRAY_BUFFER_BINDING            = 0x8895 # ARB_vertex_buffer_object
    VERTEX_ATTRIB_ARRAY_BUFFER_BINDING      = 0x889F # ARB_vertex_buffer_object
    READ_ONLY                   = 0x88B8 # ARB_vertex_buffer_object
    WRITE_ONLY                  = 0x88B9 # ARB_vertex_buffer_object
    READ_WRITE                  = 0x88BA # ARB_vertex_buffer_object
    BUFFER_ACCESS                   = 0x88BB # ARB_vertex_buffer_object
    BUFFER_MAPPED                   = 0x88BC # ARB_vertex_buffer_object
    BUFFER_MAP_POINTER              = 0x88BD # ARB_vertex_buffer_object
    STREAM_DRAW                 = 0x88E0 # ARB_vertex_buffer_object
    STREAM_READ                 = 0x88E1 # ARB_vertex_buffer_object
    STREAM_COPY                 = 0x88E2 # ARB_vertex_buffer_object
    STATIC_DRAW                 = 0x88E4 # ARB_vertex_buffer_object
    STATIC_READ                 = 0x88E5 # ARB_vertex_buffer_object
    STATIC_COPY                 = 0x88E6 # ARB_vertex_buffer_object
    DYNAMIC_DRAW                    = 0x88E8 # ARB_vertex_buffer_object
    DYNAMIC_READ                    = 0x88E9 # ARB_vertex_buffer_object
    DYNAMIC_COPY                    = 0x88EA # ARB_vertex_buffer_object
    SAMPLES_PASSED                  = 0x8914 # ARB_occlusion_query

VERSION_1_5_DEPRECATED enum:
    VERTEX_ARRAY_BUFFER_BINDING         = 0x8896 # ARB_vertex_buffer_object
    NORMAL_ARRAY_BUFFER_BINDING         = 0x8897 # ARB_vertex_buffer_object
    COLOR_ARRAY_BUFFER_BINDING          = 0x8898 # ARB_vertex_buffer_object
    INDEX_ARRAY_BUFFER_BINDING          = 0x8899 # ARB_vertex_buffer_object
    TEXTURE_COORD_ARRAY_BUFFER_BINDING      = 0x889A # ARB_vertex_buffer_object
    EDGE_FLAG_ARRAY_BUFFER_BINDING          = 0x889B # ARB_vertex_buffer_object
    SECONDARY_COLOR_ARRAY_BUFFER_BINDING        = 0x889C # ARB_vertex_buffer_object
    FOG_COORDINATE_ARRAY_BUFFER_BINDING     = 0x889D # ARB_vertex_buffer_object
    WEIGHT_ARRAY_BUFFER_BINDING         = 0x889E # ARB_vertex_buffer_object
    FOG_COORD_SRC                   = 0x8450    # alias GL_FOG_COORDINATE_SOURCE
    FOG_COORD                   = 0x8451    # alias GL_FOG_COORDINATE
    CURRENT_FOG_COORD               = 0x8453    # alias GL_CURRENT_FOG_COORDINATE
    FOG_COORD_ARRAY_TYPE                = 0x8454    # alias GL_FOG_COORDINATE_ARRAY_TYPE
    FOG_COORD_ARRAY_STRIDE              = 0x8455    # alias GL_FOG_COORDINATE_ARRAY_STRIDE
    FOG_COORD_ARRAY_POINTER             = 0x8456    # alias GL_FOG_COORDINATE_ARRAY_POINTER
    FOG_COORD_ARRAY                 = 0x8457    # alias GL_FOG_COORDINATE_ARRAY
    FOG_COORD_ARRAY_BUFFER_BINDING          = 0x889D    # alias GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING
# New naming scheme
    SRC0_RGB                    = 0x8580    # alias GL_SOURCE0_RGB
    SRC1_RGB                    = 0x8581    # alias GL_SOURCE1_RGB
    SRC2_RGB                    = 0x8582    # alias GL_SOURCE2_RGB
    SRC0_ALPHA                  = 0x8588    # alias GL_SOURCE0_ALPHA
    SRC1_ALPHA                  = 0x8589    # alias GL_SOURCE1_ALPHA
    SRC2_ALPHA                  = 0x858A    # alias GL_SOURCE2_ALPHA

###############################################################################
#
# OpenGL 2.0 enums
#
###############################################################################

VERSION_2_0 enum:
    BLEND_EQUATION_RGB              = 0x8009    # EXT_blend_equation_separate   # alias GL_BLEND_EQUATION
    VERTEX_ATTRIB_ARRAY_ENABLED         = 0x8622    # ARB_vertex_shader
    VERTEX_ATTRIB_ARRAY_SIZE            = 0x8623    # ARB_vertex_shader
    VERTEX_ATTRIB_ARRAY_STRIDE          = 0x8624    # ARB_vertex_shader
    VERTEX_ATTRIB_ARRAY_TYPE            = 0x8625    # ARB_vertex_shader
    CURRENT_VERTEX_ATTRIB               = 0x8626    # ARB_vertex_shader
    VERTEX_PROGRAM_POINT_SIZE           = 0x8642    # ARB_vertex_shader
    VERTEX_ATTRIB_ARRAY_POINTER         = 0x8645    # ARB_vertex_shader
    STENCIL_BACK_FUNC               = 0x8800    # ARB_stencil_two_side
    STENCIL_BACK_FAIL               = 0x8801    # ARB_stencil_two_side
    STENCIL_BACK_PASS_DEPTH_FAIL            = 0x8802    # ARB_stencil_two_side
    STENCIL_BACK_PASS_DEPTH_PASS            = 0x8803    # ARB_stencil_two_side
    MAX_DRAW_BUFFERS                = 0x8824    # ARB_draw_buffers
    DRAW_BUFFER0                    = 0x8825    # ARB_draw_buffers
    DRAW_BUFFER1                    = 0x8826    # ARB_draw_buffers
    DRAW_BUFFER2                    = 0x8827    # ARB_draw_buffers
    DRAW_BUFFER3                    = 0x8828    # ARB_draw_buffers
    DRAW_BUFFER4                    = 0x8829    # ARB_draw_buffers
    DRAW_BUFFER5                    = 0x882A    # ARB_draw_buffers
    DRAW_BUFFER6                    = 0x882B    # ARB_draw_buffers
    DRAW_BUFFER7                    = 0x882C    # ARB_draw_buffers
    DRAW_BUFFER8                    = 0x882D    # ARB_draw_buffers
    DRAW_BUFFER9                    = 0x882E    # ARB_draw_buffers
    DRAW_BUFFER10                   = 0x882F    # ARB_draw_buffers
    DRAW_BUFFER11                   = 0x8830    # ARB_draw_buffers
    DRAW_BUFFER12                   = 0x8831    # ARB_draw_buffers
    DRAW_BUFFER13                   = 0x8832    # ARB_draw_buffers
    DRAW_BUFFER14                   = 0x8833    # ARB_draw_buffers
    DRAW_BUFFER15                   = 0x8834    # ARB_draw_buffers
    BLEND_EQUATION_ALPHA                = 0x883D    # EXT_blend_equation_separate
    MAX_VERTEX_ATTRIBS              = 0x8869    # ARB_vertex_shader
    VERTEX_ATTRIB_ARRAY_NORMALIZED          = 0x886A    # ARB_vertex_shader
    MAX_TEXTURE_IMAGE_UNITS             = 0x8872    # ARB_vertex_shader, ARB_fragment_shader
    FRAGMENT_SHADER                 = 0x8B30    # ARB_fragment_shader
    VERTEX_SHADER                   = 0x8B31    # ARB_vertex_shader
    MAX_FRAGMENT_UNIFORM_COMPONENTS         = 0x8B49    # ARB_fragment_shader
    MAX_VERTEX_UNIFORM_COMPONENTS           = 0x8B4A    # ARB_vertex_shader
    MAX_VARYING_FLOATS              = 0x8B4B    # ARB_vertex_shader
    MAX_VERTEX_TEXTURE_IMAGE_UNITS          = 0x8B4C    # ARB_vertex_shader
    MAX_COMBINED_TEXTURE_IMAGE_UNITS        = 0x8B4D    # ARB_vertex_shader
    SHADER_TYPE                 = 0x8B4F    # ARB_shader_objects
    FLOAT_VEC2                  = 0x8B50    # ARB_shader_objects
    FLOAT_VEC3                  = 0x8B51    # ARB_shader_objects
    FLOAT_VEC4                  = 0x8B52    # ARB_shader_objects
    INT_VEC2                    = 0x8B53    # ARB_shader_objects
    INT_VEC3                    = 0x8B54    # ARB_shader_objects
    INT_VEC4                    = 0x8B55    # ARB_shader_objects
    BOOL                        = 0x8B56    # ARB_shader_objects
    BOOL_VEC2                   = 0x8B57    # ARB_shader_objects
    BOOL_VEC3                   = 0x8B58    # ARB_shader_objects
    BOOL_VEC4                   = 0x8B59    # ARB_shader_objects
    FLOAT_MAT2                  = 0x8B5A    # ARB_shader_objects
    FLOAT_MAT3                  = 0x8B5B    # ARB_shader_objects
    FLOAT_MAT4                  = 0x8B5C    # ARB_shader_objects
    SAMPLER_1D                  = 0x8B5D    # ARB_shader_objects
    SAMPLER_2D                  = 0x8B5E    # ARB_shader_objects
    SAMPLER_3D                  = 0x8B5F    # ARB_shader_objects
    SAMPLER_CUBE                    = 0x8B60    # ARB_shader_objects
    SAMPLER_1D_SHADOW               = 0x8B61    # ARB_shader_objects
    SAMPLER_2D_SHADOW               = 0x8B62    # ARB_shader_objects
    DELETE_STATUS                   = 0x8B80    # ARB_shader_objects
    COMPILE_STATUS                  = 0x8B81    # ARB_shader_objects
    LINK_STATUS                 = 0x8B82    # ARB_shader_objects
    VALIDATE_STATUS                 = 0x8B83    # ARB_shader_objects
    INFO_LOG_LENGTH                 = 0x8B84    # ARB_shader_objects
    ATTACHED_SHADERS                = 0x8B85    # ARB_shader_objects
    ACTIVE_UNIFORMS                 = 0x8B86    # ARB_shader_objects
    ACTIVE_UNIFORM_MAX_LENGTH           = 0x8B87    # ARB_shader_objects
    SHADER_SOURCE_LENGTH                = 0x8B88    # ARB_shader_objects
    ACTIVE_ATTRIBUTES               = 0x8B89    # ARB_vertex_shader
    ACTIVE_ATTRIBUTE_MAX_LENGTH         = 0x8B8A    # ARB_vertex_shader
    FRAGMENT_SHADER_DERIVATIVE_HINT         = 0x8B8B    # ARB_fragment_shader
    SHADING_LANGUAGE_VERSION            = 0x8B8C    # ARB_shading_language_100
    CURRENT_PROGRAM                 = 0x8B8D    # ARB_shader_objects (added for 2.0)
    POINT_SPRITE_COORD_ORIGIN           = 0x8CA0    # ARB_point_sprite (added for 2.0)
    LOWER_LEFT                  = 0x8CA1    # ARB_point_sprite (added for 2.0)
    UPPER_LEFT                  = 0x8CA2    # ARB_point_sprite (added for 2.0)
    STENCIL_BACK_REF                = 0x8CA3    # ARB_stencil_two_side
    STENCIL_BACK_VALUE_MASK             = 0x8CA4    # ARB_stencil_two_side
    STENCIL_BACK_WRITEMASK              = 0x8CA5    # ARB_stencil_two_side

VERSION_2_0_DEPRECATED enum:
    VERTEX_PROGRAM_TWO_SIDE             = 0x8643    # ARB_vertex_shader
    POINT_SPRITE                    = 0x8861    # ARB_point_sprite
    COORD_REPLACE                   = 0x8862    # ARB_point_sprite
    MAX_TEXTURE_COORDS              = 0x8871    # ARB_vertex_shader, ARB_fragment_shader


###############################################################################
#
# OpenGL 2.1 enums
#
###############################################################################

VERSION_2_1 enum:
    PIXEL_PACK_BUFFER               = 0x88EB    # ARB_pixel_buffer_object
    PIXEL_UNPACK_BUFFER             = 0x88EC    # ARB_pixel_buffer_object
    PIXEL_PACK_BUFFER_BINDING           = 0x88ED    # ARB_pixel_buffer_object
    PIXEL_UNPACK_BUFFER_BINDING         = 0x88EF    # ARB_pixel_buffer_object
    FLOAT_MAT2x3                    = 0x8B65    # New for 2.1
    FLOAT_MAT2x4                    = 0x8B66    # New for 2.1
    FLOAT_MAT3x2                    = 0x8B67    # New for 2.1
    FLOAT_MAT3x4                    = 0x8B68    # New for 2.1
    FLOAT_MAT4x2                    = 0x8B69    # New for 2.1
    FLOAT_MAT4x3                    = 0x8B6A    # New for 2.1
    SRGB                        = 0x8C40    # EXT_texture_sRGB
    SRGB8                       = 0x8C41    # EXT_texture_sRGB
    SRGB_ALPHA                  = 0x8C42    # EXT_texture_sRGB
    SRGB8_ALPHA8                    = 0x8C43    # EXT_texture_sRGB
    COMPRESSED_SRGB                 = 0x8C48    # EXT_texture_sRGB
    COMPRESSED_SRGB_ALPHA               = 0x8C49    # EXT_texture_sRGB

VERSION_2_1_DEPRECATED enum:
    CURRENT_RASTER_SECONDARY_COLOR          = 0x845F    # New for 2.1
    SLUMINANCE_ALPHA                = 0x8C44    # EXT_texture_sRGB
    SLUMINANCE8_ALPHA8              = 0x8C45    # EXT_texture_sRGB
    SLUMINANCE                  = 0x8C46    # EXT_texture_sRGB
    SLUMINANCE8                 = 0x8C47    # EXT_texture_sRGB
    COMPRESSED_SLUMINANCE               = 0x8C4A    # EXT_texture_sRGB
    COMPRESSED_SLUMINANCE_ALPHA         = 0x8C4B    # EXT_texture_sRGB


###############################################################################
#
# OpenGL 3.0 enums
#
###############################################################################

VERSION_3_0 enum:
    COMPARE_REF_TO_TEXTURE              = 0x884E    # alias GL_COMPARE_R_TO_TEXTURE_ARB
    CLIP_DISTANCE0                  = 0x3000    # alias GL_CLIP_PLANE0
    CLIP_DISTANCE1                  = 0x3001    # alias GL_CLIP_PLANE1
    CLIP_DISTANCE2                  = 0x3002    # alias GL_CLIP_PLANE2
    CLIP_DISTANCE3                  = 0x3003    # alias GL_CLIP_PLANE3
    CLIP_DISTANCE4                  = 0x3004    # alias GL_CLIP_PLANE4
    CLIP_DISTANCE5                  = 0x3005    # alias GL_CLIP_PLANE5
    CLIP_DISTANCE6                  = 0x3006
    CLIP_DISTANCE7                  = 0x3007
    MAX_CLIP_DISTANCES              = 0x0D32    # alias GL_MAX_CLIP_PLANES
    MAJOR_VERSION                   = 0x821B
    MINOR_VERSION                   = 0x821C
    NUM_EXTENSIONS                  = 0x821D
    CONTEXT_FLAGS                   = 0x821E
    DEPTH_BUFFER                    = 0x8223
    STENCIL_BUFFER                  = 0x8224
    COMPRESSED_RED                  = 0x8225
    COMPRESSED_RG                   = 0x8226
    CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT     = 0x0001
    RGBA32F                     = 0x8814
    RGB32F                      = 0x8815
    RGBA16F                     = 0x881A
    RGB16F                      = 0x881B
    VERTEX_ATTRIB_ARRAY_INTEGER         = 0x88FD
    MAX_ARRAY_TEXTURE_LAYERS            = 0x88FF
    MIN_PROGRAM_TEXEL_OFFSET            = 0x8904
    MAX_PROGRAM_TEXEL_OFFSET            = 0x8905
    CLAMP_READ_COLOR                = 0x891C
    FIXED_ONLY                  = 0x891D
    MAX_VARYING_COMPONENTS              = 0x8B4B    # alias GL_MAX_VARYING_FLOATS
    TEXTURE_1D_ARRAY                = 0x8C18
    PROXY_TEXTURE_1D_ARRAY              = 0x8C19
    TEXTURE_2D_ARRAY                = 0x8C1A
    PROXY_TEXTURE_2D_ARRAY              = 0x8C1B
    TEXTURE_BINDING_1D_ARRAY            = 0x8C1C
    TEXTURE_BINDING_2D_ARRAY            = 0x8C1D
    R11F_G11F_B10F                  = 0x8C3A
    UNSIGNED_INT_10F_11F_11F_REV            = 0x8C3B
    RGB9_E5                     = 0x8C3D
    UNSIGNED_INT_5_9_9_9_REV            = 0x8C3E
    TEXTURE_SHARED_SIZE             = 0x8C3F
    TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH       = 0x8C76
    TRANSFORM_FEEDBACK_BUFFER_MODE          = 0x8C7F
    MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS  = 0x8C80
    TRANSFORM_FEEDBACK_VARYINGS         = 0x8C83
    TRANSFORM_FEEDBACK_BUFFER_START         = 0x8C84
    TRANSFORM_FEEDBACK_BUFFER_SIZE          = 0x8C85
    PRIMITIVES_GENERATED                = 0x8C87
    TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN       = 0x8C88
    RASTERIZER_DISCARD              = 0x8C89
    MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS   = 0x8C8A
    MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS     = 0x8C8B
    INTERLEAVED_ATTRIBS             = 0x8C8C
    SEPARATE_ATTRIBS                = 0x8C8D
    TRANSFORM_FEEDBACK_BUFFER           = 0x8C8E
    TRANSFORM_FEEDBACK_BUFFER_BINDING       = 0x8C8F
    RGBA32UI                    = 0x8D70
    RGB32UI                     = 0x8D71
    RGBA16UI                    = 0x8D76
    RGB16UI                     = 0x8D77
    RGBA8UI                     = 0x8D7C
    RGB8UI                      = 0x8D7D
    RGBA32I                     = 0x8D82
    RGB32I                      = 0x8D83
    RGBA16I                     = 0x8D88
    RGB16I                      = 0x8D89
    RGBA8I                      = 0x8D8E
    RGB8I                       = 0x8D8F
    RED_INTEGER                 = 0x8D94
    GREEN_INTEGER                   = 0x8D95
    BLUE_INTEGER                    = 0x8D96
    RGB_INTEGER                 = 0x8D98
    RGBA_INTEGER                    = 0x8D99
    BGR_INTEGER                 = 0x8D9A
    BGRA_INTEGER                    = 0x8D9B
    SAMPLER_1D_ARRAY                = 0x8DC0
    SAMPLER_2D_ARRAY                = 0x8DC1
    SAMPLER_1D_ARRAY_SHADOW             = 0x8DC3
    SAMPLER_2D_ARRAY_SHADOW             = 0x8DC4
    SAMPLER_CUBE_SHADOW             = 0x8DC5
    UNSIGNED_INT_VEC2               = 0x8DC6
    UNSIGNED_INT_VEC3               = 0x8DC7
    UNSIGNED_INT_VEC4               = 0x8DC8
    INT_SAMPLER_1D                  = 0x8DC9
    INT_SAMPLER_2D                  = 0x8DCA
    INT_SAMPLER_3D                  = 0x8DCB
    INT_SAMPLER_CUBE                = 0x8DCC
    INT_SAMPLER_1D_ARRAY                = 0x8DCE
    INT_SAMPLER_2D_ARRAY                = 0x8DCF
    UNSIGNED_INT_SAMPLER_1D             = 0x8DD1
    UNSIGNED_INT_SAMPLER_2D             = 0x8DD2
    UNSIGNED_INT_SAMPLER_3D             = 0x8DD3
    UNSIGNED_INT_SAMPLER_CUBE           = 0x8DD4
    UNSIGNED_INT_SAMPLER_1D_ARRAY           = 0x8DD6
    UNSIGNED_INT_SAMPLER_2D_ARRAY           = 0x8DD7
    QUERY_WAIT                  = 0x8E13
    QUERY_NO_WAIT                   = 0x8E14
    QUERY_BY_REGION_WAIT                = 0x8E15
    QUERY_BY_REGION_NO_WAIT             = 0x8E16
    BUFFER_ACCESS_FLAGS             = 0x911F
    BUFFER_MAP_LENGTH               = 0x9120
    BUFFER_MAP_OFFSET               = 0x9121
passthru: /* Reuse tokens from ARB_depth_buffer_float */
    use ARB_depth_buffer_float      DEPTH_COMPONENT32F
    use ARB_depth_buffer_float      DEPTH32F_STENCIL8
    use ARB_depth_buffer_float      FLOAT_32_UNSIGNED_INT_24_8_REV
passthru: /* Reuse tokens from ARB_framebuffer_object */
    use ARB_framebuffer_object      INVALID_FRAMEBUFFER_OPERATION
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_RED_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_GREEN_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_BLUE_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_DEFAULT
    use ARB_framebuffer_object      FRAMEBUFFER_UNDEFINED
    use ARB_framebuffer_object      DEPTH_STENCIL_ATTACHMENT
    use ARB_framebuffer_object      INDEX
    use ARB_framebuffer_object      MAX_RENDERBUFFER_SIZE
    use ARB_framebuffer_object      DEPTH_STENCIL
    use ARB_framebuffer_object      UNSIGNED_INT_24_8
    use ARB_framebuffer_object      DEPTH24_STENCIL8
    use ARB_framebuffer_object      TEXTURE_STENCIL_SIZE
    use ARB_framebuffer_object      TEXTURE_RED_TYPE
    use ARB_framebuffer_object      TEXTURE_GREEN_TYPE
    use ARB_framebuffer_object      TEXTURE_BLUE_TYPE
    use ARB_framebuffer_object      TEXTURE_ALPHA_TYPE
    use ARB_framebuffer_object      TEXTURE_DEPTH_TYPE
    use ARB_framebuffer_object      UNSIGNED_NORMALIZED
    use ARB_framebuffer_object      FRAMEBUFFER_BINDING
    use ARB_framebuffer_object      DRAW_FRAMEBUFFER_BINDING
    use ARB_framebuffer_object      RENDERBUFFER_BINDING
    use ARB_framebuffer_object      READ_FRAMEBUFFER
    use ARB_framebuffer_object      DRAW_FRAMEBUFFER
    use ARB_framebuffer_object      READ_FRAMEBUFFER_BINDING
    use ARB_framebuffer_object      RENDERBUFFER_SAMPLES
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_OBJECT_NAME
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER
    use ARB_framebuffer_object      FRAMEBUFFER_COMPLETE
    use ARB_framebuffer_object      FRAMEBUFFER_INCOMPLETE_ATTACHMENT
    use ARB_framebuffer_object      FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT
    use ARB_framebuffer_object      FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER
    use ARB_framebuffer_object      FRAMEBUFFER_INCOMPLETE_READ_BUFFER
    use ARB_framebuffer_object      FRAMEBUFFER_UNSUPPORTED
    use ARB_framebuffer_object      MAX_COLOR_ATTACHMENTS
    use ARB_framebuffer_object      COLOR_ATTACHMENT0
    use ARB_framebuffer_object      COLOR_ATTACHMENT1
    use ARB_framebuffer_object      COLOR_ATTACHMENT2
    use ARB_framebuffer_object      COLOR_ATTACHMENT3
    use ARB_framebuffer_object      COLOR_ATTACHMENT4
    use ARB_framebuffer_object      COLOR_ATTACHMENT5
    use ARB_framebuffer_object      COLOR_ATTACHMENT6
    use ARB_framebuffer_object      COLOR_ATTACHMENT7
    use ARB_framebuffer_object      COLOR_ATTACHMENT8
    use ARB_framebuffer_object      COLOR_ATTACHMENT9
    use ARB_framebuffer_object      COLOR_ATTACHMENT10
    use ARB_framebuffer_object      COLOR_ATTACHMENT11
    use ARB_framebuffer_object      COLOR_ATTACHMENT12
    use ARB_framebuffer_object      COLOR_ATTACHMENT13
    use ARB_framebuffer_object      COLOR_ATTACHMENT14
    use ARB_framebuffer_object      COLOR_ATTACHMENT15
    use ARB_framebuffer_object      DEPTH_ATTACHMENT
    use ARB_framebuffer_object      STENCIL_ATTACHMENT
    use ARB_framebuffer_object      FRAMEBUFFER
    use ARB_framebuffer_object      RENDERBUFFER
    use ARB_framebuffer_object      RENDERBUFFER_WIDTH
    use ARB_framebuffer_object      RENDERBUFFER_HEIGHT
    use ARB_framebuffer_object      RENDERBUFFER_INTERNAL_FORMAT
    use ARB_framebuffer_object      STENCIL_INDEX1
    use ARB_framebuffer_object      STENCIL_INDEX4
    use ARB_framebuffer_object      STENCIL_INDEX8
    use ARB_framebuffer_object      STENCIL_INDEX16
    use ARB_framebuffer_object      RENDERBUFFER_RED_SIZE
    use ARB_framebuffer_object      RENDERBUFFER_GREEN_SIZE
    use ARB_framebuffer_object      RENDERBUFFER_BLUE_SIZE
    use ARB_framebuffer_object      RENDERBUFFER_ALPHA_SIZE
    use ARB_framebuffer_object      RENDERBUFFER_DEPTH_SIZE
    use ARB_framebuffer_object      RENDERBUFFER_STENCIL_SIZE
    use ARB_framebuffer_object      FRAMEBUFFER_INCOMPLETE_MULTISAMPLE
    use ARB_framebuffer_object      MAX_SAMPLES
passthru: /* Reuse tokens from ARB_framebuffer_sRGB */
    use ARB_framebuffer_sRGB        FRAMEBUFFER_SRGB
passthru: /* Reuse tokens from ARB_half_float_vertex */
    use ARB_half_float_vertex       HALF_FLOAT
passthru: /* Reuse tokens from ARB_map_buffer_range */
    use ARB_map_buffer_range        MAP_READ_BIT
    use ARB_map_buffer_range        MAP_WRITE_BIT
    use ARB_map_buffer_range        MAP_INVALIDATE_RANGE_BIT
    use ARB_map_buffer_range        MAP_INVALIDATE_BUFFER_BIT
    use ARB_map_buffer_range        MAP_FLUSH_EXPLICIT_BIT
    use ARB_map_buffer_range        MAP_UNSYNCHRONIZED_BIT
passthru: /* Reuse tokens from ARB_texture_compression_rgtc */
    use ARB_texture_compression_rgtc    COMPRESSED_RED_RGTC1
    use ARB_texture_compression_rgtc    COMPRESSED_SIGNED_RED_RGTC1
    use ARB_texture_compression_rgtc    COMPRESSED_RG_RGTC2
    use ARB_texture_compression_rgtc    COMPRESSED_SIGNED_RG_RGTC2
passthru: /* Reuse tokens from ARB_texture_rg */
    use ARB_texture_rg          RG
    use ARB_texture_rg          RG_INTEGER
    use ARB_texture_rg          R8
    use ARB_texture_rg          R16
    use ARB_texture_rg          RG8
    use ARB_texture_rg          RG16
    use ARB_texture_rg          R16F
    use ARB_texture_rg          R32F
    use ARB_texture_rg          RG16F
    use ARB_texture_rg          RG32F
    use ARB_texture_rg          R8I
    use ARB_texture_rg          R8UI
    use ARB_texture_rg          R16I
    use ARB_texture_rg          R16UI
    use ARB_texture_rg          R32I
    use ARB_texture_rg          R32UI
    use ARB_texture_rg          RG8I
    use ARB_texture_rg          RG8UI
    use ARB_texture_rg          RG16I
    use ARB_texture_rg          RG16UI
    use ARB_texture_rg          RG32I
    use ARB_texture_rg          RG32UI
passthru: /* Reuse tokens from ARB_vertex_array_object */
    use ARB_vertex_array_object     VERTEX_ARRAY_BINDING

VERSION_3_0_DEPRECATED enum:
    CLAMP_VERTEX_COLOR              = 0x891A
    CLAMP_FRAGMENT_COLOR                = 0x891B
    ALPHA_INTEGER                   = 0x8D97
passthru: /* Reuse tokens from ARB_framebuffer_object */
    use ARB_framebuffer_object      TEXTURE_LUMINANCE_TYPE
    use ARB_framebuffer_object      TEXTURE_INTENSITY_TYPE


###############################################################################
#
# OpenGL 3.1 enums
#
###############################################################################

VERSION_3_1 enum:
    SAMPLER_2D_RECT                 = 0x8B63    # ARB_shader_objects + ARB_texture_rectangle
    SAMPLER_2D_RECT_SHADOW              = 0x8B64    # ARB_shader_objects + ARB_texture_rectangle
    SAMPLER_BUFFER                  = 0x8DC2    # EXT_gpu_shader4 + ARB_texture_buffer_object
    INT_SAMPLER_2D_RECT             = 0x8DCD    # EXT_gpu_shader4 + ARB_texture_rectangle
    INT_SAMPLER_BUFFER              = 0x8DD0    # EXT_gpu_shader4 + ARB_texture_buffer_object
    UNSIGNED_INT_SAMPLER_2D_RECT            = 0x8DD5    # EXT_gpu_shader4 + ARB_texture_rectangle
    UNSIGNED_INT_SAMPLER_BUFFER         = 0x8DD8    # EXT_gpu_shader4 + ARB_texture_buffer_object
    TEXTURE_BUFFER                  = 0x8C2A    # ARB_texture_buffer_object
    MAX_TEXTURE_BUFFER_SIZE             = 0x8C2B    # ARB_texture_buffer_object
    TEXTURE_BINDING_BUFFER              = 0x8C2C    # ARB_texture_buffer_object
    TEXTURE_BUFFER_DATA_STORE_BINDING       = 0x8C2D    # ARB_texture_buffer_object
    TEXTURE_BUFFER_FORMAT               = 0x8C2E    # ARB_texture_buffer_object
    TEXTURE_RECTANGLE               = 0x84F5    # ARB_texture_rectangle
    TEXTURE_BINDING_RECTANGLE           = 0x84F6    # ARB_texture_rectangle
    PROXY_TEXTURE_RECTANGLE             = 0x84F7    # ARB_texture_rectangle
    MAX_RECTANGLE_TEXTURE_SIZE          = 0x84F8    # ARB_texture_rectangle
    RED_SNORM                   = 0x8F90    # 3.1
    RG_SNORM                    = 0x8F91    # 3.1
    RGB_SNORM                   = 0x8F92    # 3.1
    RGBA_SNORM                  = 0x8F93    # 3.1
    R8_SNORM                    = 0x8F94    # 3.1
    RG8_SNORM                   = 0x8F95    # 3.1
    RGB8_SNORM                  = 0x8F96    # 3.1
    RGBA8_SNORM                 = 0x8F97    # 3.1
    R16_SNORM                   = 0x8F98    # 3.1
    RG16_SNORM                  = 0x8F99    # 3.1
    RGB16_SNORM                 = 0x8F9A    # 3.1
    RGBA16_SNORM                    = 0x8F9B    # 3.1
    SIGNED_NORMALIZED               = 0x8F9C    # 3.1
    PRIMITIVE_RESTART               = 0x8F9D    # 3.1 (different from NV_primitive_restart)
    PRIMITIVE_RESTART_INDEX             = 0x8F9E    # 3.1 (different from NV_primitive_restart)
passthru: /* Reuse tokens from ARB_copy_buffer */
    use ARB_copy_buffer         COPY_READ_BUFFER
    use ARB_copy_buffer         COPY_WRITE_BUFFER
passthru: /* Would reuse tokens from ARB_draw_instanced, but it has none */
passthru: /* Reuse tokens from ARB_uniform_buffer_object */
    use ARB_uniform_buffer_object       UNIFORM_BUFFER
    use ARB_uniform_buffer_object       UNIFORM_BUFFER_BINDING
    use ARB_uniform_buffer_object       UNIFORM_BUFFER_START
    use ARB_uniform_buffer_object       UNIFORM_BUFFER_SIZE
    use ARB_uniform_buffer_object       MAX_VERTEX_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object       MAX_FRAGMENT_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object       MAX_COMBINED_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object       MAX_UNIFORM_BUFFER_BINDINGS
    use ARB_uniform_buffer_object       MAX_UNIFORM_BLOCK_SIZE
    use ARB_uniform_buffer_object       MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS
    use ARB_uniform_buffer_object       MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS
    use ARB_uniform_buffer_object       UNIFORM_BUFFER_OFFSET_ALIGNMENT
    use ARB_uniform_buffer_object       ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH
    use ARB_uniform_buffer_object       ACTIVE_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object       UNIFORM_TYPE
    use ARB_uniform_buffer_object       UNIFORM_SIZE
    use ARB_uniform_buffer_object       UNIFORM_NAME_LENGTH
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_INDEX
    use ARB_uniform_buffer_object       UNIFORM_OFFSET
    use ARB_uniform_buffer_object       UNIFORM_ARRAY_STRIDE
    use ARB_uniform_buffer_object       UNIFORM_MATRIX_STRIDE
    use ARB_uniform_buffer_object       UNIFORM_IS_ROW_MAJOR
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_BINDING
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_DATA_SIZE
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_NAME_LENGTH
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_ACTIVE_UNIFORMS
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER
    use ARB_uniform_buffer_object       INVALID_INDEX


###############################################################################
#
# OpenGL 3.2 enums
#
###############################################################################

VERSION_3_2 enum:
    CONTEXT_CORE_PROFILE_BIT            = 0x00000001
    CONTEXT_COMPATIBILITY_PROFILE_BIT       = 0x00000002
    LINES_ADJACENCY                 = 0x000A
    LINE_STRIP_ADJACENCY                = 0x000B
    TRIANGLES_ADJACENCY             = 0x000C
    TRIANGLE_STRIP_ADJACENCY            = 0x000D
    PROGRAM_POINT_SIZE              = 0x8642
    MAX_GEOMETRY_TEXTURE_IMAGE_UNITS        = 0x8C29
    FRAMEBUFFER_ATTACHMENT_LAYERED          = 0x8DA7
    FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS        = 0x8DA8
    GEOMETRY_SHADER                 = 0x8DD9
    GEOMETRY_VERTICES_OUT               = 0x8916
    GEOMETRY_INPUT_TYPE             = 0x8917
    GEOMETRY_OUTPUT_TYPE                = 0x8918
    MAX_GEOMETRY_UNIFORM_COMPONENTS         = 0x8DDF
    MAX_GEOMETRY_OUTPUT_VERTICES            = 0x8DE0
    MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS        = 0x8DE1
    MAX_VERTEX_OUTPUT_COMPONENTS            = 0x9122
    MAX_GEOMETRY_INPUT_COMPONENTS           = 0x9123
    MAX_GEOMETRY_OUTPUT_COMPONENTS          = 0x9124
    MAX_FRAGMENT_INPUT_COMPONENTS           = 0x9125
    CONTEXT_PROFILE_MASK                = 0x9126
    use VERSION_3_0             MAX_VARYING_COMPONENTS
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER
passthru: /* Reuse tokens from ARB_depth_clamp */
    use ARB_depth_clamp         DEPTH_CLAMP
passthru: /* Would reuse tokens from ARB_draw_elements_base_vertex, but it has none */
passthru: /* Would reuse tokens from ARB_fragment_coord_conventions, but it has none */
passthru: /* Reuse tokens from ARB_provoking_vertex */
    use ARB_provoking_vertex        QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION
    use ARB_provoking_vertex        FIRST_VERTEX_CONVENTION
    use ARB_provoking_vertex        LAST_VERTEX_CONVENTION
    use ARB_provoking_vertex        PROVOKING_VERTEX
passthru: /* Reuse tokens from ARB_seamless_cube_map */
    use ARB_seamless_cube_map       TEXTURE_CUBE_MAP_SEAMLESS
passthru: /* Reuse tokens from ARB_sync */
    use ARB_sync                MAX_SERVER_WAIT_TIMEOUT
    use ARB_sync                OBJECT_TYPE
    use ARB_sync                SYNC_CONDITION
    use ARB_sync                SYNC_STATUS
    use ARB_sync                SYNC_FLAGS
    use ARB_sync                SYNC_FENCE
    use ARB_sync                SYNC_GPU_COMMANDS_COMPLETE
    use ARB_sync                UNSIGNALED
    use ARB_sync                SIGNALED
    use ARB_sync                ALREADY_SIGNALED
    use ARB_sync                TIMEOUT_EXPIRED
    use ARB_sync                CONDITION_SATISFIED
    use ARB_sync                WAIT_FAILED
    use ARB_sync                TIMEOUT_IGNORED
    use ARB_sync                SYNC_FLUSH_COMMANDS_BIT    
passthru: /* Reuse tokens from ARB_texture_multisample */
    use ARB_texture_multisample     SAMPLE_POSITION
    use ARB_texture_multisample     SAMPLE_MASK
    use ARB_texture_multisample     SAMPLE_MASK_VALUE
    use ARB_texture_multisample     MAX_SAMPLE_MASK_WORDS
    use ARB_texture_multisample     TEXTURE_2D_MULTISAMPLE
    use ARB_texture_multisample     PROXY_TEXTURE_2D_MULTISAMPLE
    use ARB_texture_multisample     TEXTURE_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     TEXTURE_BINDING_2D_MULTISAMPLE
    use ARB_texture_multisample     TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     TEXTURE_SAMPLES
    use ARB_texture_multisample     TEXTURE_FIXED_SAMPLE_LOCATIONS
    use ARB_texture_multisample     SAMPLER_2D_MULTISAMPLE
    use ARB_texture_multisample     INT_SAMPLER_2D_MULTISAMPLE
    use ARB_texture_multisample     UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE
    use ARB_texture_multisample     SAMPLER_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     INT_SAMPLER_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY
    use ARB_texture_multisample     MAX_COLOR_TEXTURE_SAMPLES
    use ARB_texture_multisample     MAX_DEPTH_TEXTURE_SAMPLES
    use ARB_texture_multisample     MAX_INTEGER_SAMPLES
passthru: /* Don't need to reuse tokens from ARB_vertex_array_bgra since they're already in 1.2 core */

###############################################################################
#
# ARB extensions, in ARB extension order
#
###############################################################################

###############################################################################

# ARB Extension #1
ARB_multitexture enum:
    TEXTURE0_ARB                    = 0x84C0
    TEXTURE1_ARB                    = 0x84C1
    TEXTURE2_ARB                    = 0x84C2
    TEXTURE3_ARB                    = 0x84C3
    TEXTURE4_ARB                    = 0x84C4
    TEXTURE5_ARB                    = 0x84C5
    TEXTURE6_ARB                    = 0x84C6
    TEXTURE7_ARB                    = 0x84C7
    TEXTURE8_ARB                    = 0x84C8
    TEXTURE9_ARB                    = 0x84C9
    TEXTURE10_ARB                   = 0x84CA
    TEXTURE11_ARB                   = 0x84CB
    TEXTURE12_ARB                   = 0x84CC
    TEXTURE13_ARB                   = 0x84CD
    TEXTURE14_ARB                   = 0x84CE
    TEXTURE15_ARB                   = 0x84CF
    TEXTURE16_ARB                   = 0x84D0
    TEXTURE17_ARB                   = 0x84D1
    TEXTURE18_ARB                   = 0x84D2
    TEXTURE19_ARB                   = 0x84D3
    TEXTURE20_ARB                   = 0x84D4
    TEXTURE21_ARB                   = 0x84D5
    TEXTURE22_ARB                   = 0x84D6
    TEXTURE23_ARB                   = 0x84D7
    TEXTURE24_ARB                   = 0x84D8
    TEXTURE25_ARB                   = 0x84D9
    TEXTURE26_ARB                   = 0x84DA
    TEXTURE27_ARB                   = 0x84DB
    TEXTURE28_ARB                   = 0x84DC
    TEXTURE29_ARB                   = 0x84DD
    TEXTURE30_ARB                   = 0x84DE
    TEXTURE31_ARB                   = 0x84DF
    ACTIVE_TEXTURE_ARB              = 0x84E0 # 1 I
    CLIENT_ACTIVE_TEXTURE_ARB           = 0x84E1 # 1 I
    MAX_TEXTURE_UNITS_ARB               = 0x84E2 # 1 I

###############################################################################

# No new tokens
# ARB Extension #2 - GLX_ARB_get_proc_address

###############################################################################

# ARB Extension #3
ARB_transpose_matrix enum:
    TRANSPOSE_MODELVIEW_MATRIX_ARB          = 0x84E3 # 16 F
    TRANSPOSE_PROJECTION_MATRIX_ARB         = 0x84E4 # 16 F
    TRANSPOSE_TEXTURE_MATRIX_ARB            = 0x84E5 # 16 F
    TRANSPOSE_COLOR_MATRIX_ARB          = 0x84E6 # 16 F

###############################################################################

# No new tokens
# ARB Extension #4 - WGL_ARB_buffer_region

###############################################################################

# ARB Extension #5
ARB_multisample enum:
    MULTISAMPLE_ARB                 = 0x809D
    SAMPLE_ALPHA_TO_COVERAGE_ARB            = 0x809E
    SAMPLE_ALPHA_TO_ONE_ARB             = 0x809F
    SAMPLE_COVERAGE_ARB             = 0x80A0
    SAMPLE_BUFFERS_ARB              = 0x80A8
    SAMPLES_ARB                 = 0x80A9
    SAMPLE_COVERAGE_VALUE_ARB           = 0x80AA
    SAMPLE_COVERAGE_INVERT_ARB          = 0x80AB
    MULTISAMPLE_BIT_ARB             = 0x20000000

###############################################################################

# No new tokens
# ARB Extension #6
ARB_texture_env_add enum:

###############################################################################

# ARB Extension #7
ARB_texture_cube_map enum:
    NORMAL_MAP_ARB                  = 0x8511
    REFLECTION_MAP_ARB              = 0x8512
    TEXTURE_CUBE_MAP_ARB                = 0x8513
    TEXTURE_BINDING_CUBE_MAP_ARB            = 0x8514
    TEXTURE_CUBE_MAP_POSITIVE_X_ARB         = 0x8515
    TEXTURE_CUBE_MAP_NEGATIVE_X_ARB         = 0x8516
    TEXTURE_CUBE_MAP_POSITIVE_Y_ARB         = 0x8517
    TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB         = 0x8518
    TEXTURE_CUBE_MAP_POSITIVE_Z_ARB         = 0x8519
    TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB         = 0x851A
    PROXY_TEXTURE_CUBE_MAP_ARB          = 0x851B
    MAX_CUBE_MAP_TEXTURE_SIZE_ARB           = 0x851C

###############################################################################

# No new tokens
# ARB Extension #8 - WGL_ARB_extensions_string
# ARB Extension #9 - WGL_ARB_pixel_format
# ARB Extension #10 - WGL_ARB_make_current_read
# ARB Extension #11 - WGL_ARB_pbuffer

###############################################################################

# ARB Extension #12
ARB_texture_compression enum:
    COMPRESSED_ALPHA_ARB                = 0x84E9
    COMPRESSED_LUMINANCE_ARB            = 0x84EA
    COMPRESSED_LUMINANCE_ALPHA_ARB          = 0x84EB
    COMPRESSED_INTENSITY_ARB            = 0x84EC
    COMPRESSED_RGB_ARB              = 0x84ED
    COMPRESSED_RGBA_ARB             = 0x84EE
    TEXTURE_COMPRESSION_HINT_ARB            = 0x84EF
    TEXTURE_COMPRESSED_IMAGE_SIZE_ARB       = 0x86A0
    TEXTURE_COMPRESSED_ARB              = 0x86A1
    NUM_COMPRESSED_TEXTURE_FORMATS_ARB      = 0x86A2
    COMPRESSED_TEXTURE_FORMATS_ARB          = 0x86A3

###############################################################################

# ARB Extension #13
# Promoted from #36 SGIS_texture_border_clamp
ARB_texture_border_clamp enum:
    CLAMP_TO_BORDER_ARB             = 0x812D

###############################################################################

# ARB Extension #14 - promoted from #54 EXT_point_parameters
# Promoted from #54 {SGIS,EXT}_point_parameters
ARB_point_parameters enum:
    POINT_SIZE_MIN_ARB              = 0x8126 # 1 F
    POINT_SIZE_MAX_ARB              = 0x8127 # 1 F
    POINT_FADE_THRESHOLD_SIZE_ARB           = 0x8128 # 1 F
    POINT_DISTANCE_ATTENUATION_ARB          = 0x8129 # 3 F

###############################################################################

# ARB Extension #15
ARB_vertex_blend enum:
    MAX_VERTEX_UNITS_ARB                = 0x86A4
    ACTIVE_VERTEX_UNITS_ARB             = 0x86A5
    WEIGHT_SUM_UNITY_ARB                = 0x86A6
    VERTEX_BLEND_ARB                = 0x86A7
    CURRENT_WEIGHT_ARB              = 0x86A8
    WEIGHT_ARRAY_TYPE_ARB               = 0x86A9
    WEIGHT_ARRAY_STRIDE_ARB             = 0x86AA
    WEIGHT_ARRAY_SIZE_ARB               = 0x86AB
    WEIGHT_ARRAY_POINTER_ARB            = 0x86AC
    WEIGHT_ARRAY_ARB                = 0x86AD
    MODELVIEW0_ARB                  = 0x1700
    MODELVIEW1_ARB                  = 0x850A
    MODELVIEW2_ARB                  = 0x8722
    MODELVIEW3_ARB                  = 0x8723
    MODELVIEW4_ARB                  = 0x8724
    MODELVIEW5_ARB                  = 0x8725
    MODELVIEW6_ARB                  = 0x8726
    MODELVIEW7_ARB                  = 0x8727
    MODELVIEW8_ARB                  = 0x8728
    MODELVIEW9_ARB                  = 0x8729
    MODELVIEW10_ARB                 = 0x872A
    MODELVIEW11_ARB                 = 0x872B
    MODELVIEW12_ARB                 = 0x872C
    MODELVIEW13_ARB                 = 0x872D
    MODELVIEW14_ARB                 = 0x872E
    MODELVIEW15_ARB                 = 0x872F
    MODELVIEW16_ARB                 = 0x8730
    MODELVIEW17_ARB                 = 0x8731
    MODELVIEW18_ARB                 = 0x8732
    MODELVIEW19_ARB                 = 0x8733
    MODELVIEW20_ARB                 = 0x8734
    MODELVIEW21_ARB                 = 0x8735
    MODELVIEW22_ARB                 = 0x8736
    MODELVIEW23_ARB                 = 0x8737
    MODELVIEW24_ARB                 = 0x8738
    MODELVIEW25_ARB                 = 0x8739
    MODELVIEW26_ARB                 = 0x873A
    MODELVIEW27_ARB                 = 0x873B
    MODELVIEW28_ARB                 = 0x873C
    MODELVIEW29_ARB                 = 0x873D
    MODELVIEW30_ARB                 = 0x873E
    MODELVIEW31_ARB                 = 0x873F

###############################################################################

# ARB Extension #16
ARB_matrix_palette enum:
    MATRIX_PALETTE_ARB              = 0x8840
    MAX_MATRIX_PALETTE_STACK_DEPTH_ARB      = 0x8841
    MAX_PALETTE_MATRICES_ARB            = 0x8842
    CURRENT_PALETTE_MATRIX_ARB          = 0x8843
    MATRIX_INDEX_ARRAY_ARB              = 0x8844
    CURRENT_MATRIX_INDEX_ARB            = 0x8845
    MATRIX_INDEX_ARRAY_SIZE_ARB         = 0x8846
    MATRIX_INDEX_ARRAY_TYPE_ARB         = 0x8847
    MATRIX_INDEX_ARRAY_STRIDE_ARB           = 0x8848
    MATRIX_INDEX_ARRAY_POINTER_ARB          = 0x8849

###############################################################################

# ARB Extension #17
# Shares enum values with EXT_texture_env_combine
ARB_texture_env_combine enum:
    COMBINE_ARB                 = 0x8570
    COMBINE_RGB_ARB                 = 0x8571
    COMBINE_ALPHA_ARB               = 0x8572
    SOURCE0_RGB_ARB                 = 0x8580
    SOURCE1_RGB_ARB                 = 0x8581
    SOURCE2_RGB_ARB                 = 0x8582
    SOURCE0_ALPHA_ARB               = 0x8588
    SOURCE1_ALPHA_ARB               = 0x8589
    SOURCE2_ALPHA_ARB               = 0x858A
    OPERAND0_RGB_ARB                = 0x8590
    OPERAND1_RGB_ARB                = 0x8591
    OPERAND2_RGB_ARB                = 0x8592
    OPERAND0_ALPHA_ARB              = 0x8598
    OPERAND1_ALPHA_ARB              = 0x8599
    OPERAND2_ALPHA_ARB              = 0x859A
    RGB_SCALE_ARB                   = 0x8573
    ADD_SIGNED_ARB                  = 0x8574
    INTERPOLATE_ARB                 = 0x8575
    SUBTRACT_ARB                    = 0x84E7
    CONSTANT_ARB                    = 0x8576
    PRIMARY_COLOR_ARB               = 0x8577
    PREVIOUS_ARB                    = 0x8578

###############################################################################

# No new tokens
# ARB Extension #18
ARB_texture_env_crossbar enum:

###############################################################################

# ARB Extension #19
# Promoted from #220 EXT_texture_env_dot3; enum values changed
ARB_texture_env_dot3 enum:
    DOT3_RGB_ARB                    = 0x86AE
    DOT3_RGBA_ARB                   = 0x86AF

###############################################################################

# No new tokens
# ARB Extension #20 - WGL_ARB_render_texture

###############################################################################

# ARB Extension #21
ARB_texture_mirrored_repeat enum:
    MIRRORED_REPEAT_ARB             = 0x8370

###############################################################################

# ARB Extension #22
ARB_depth_texture enum:
    DEPTH_COMPONENT16_ARB               = 0x81A5
    DEPTH_COMPONENT24_ARB               = 0x81A6
    DEPTH_COMPONENT32_ARB               = 0x81A7
    TEXTURE_DEPTH_SIZE_ARB              = 0x884A
    DEPTH_TEXTURE_MODE_ARB              = 0x884B

###############################################################################

# ARB Extension #23
ARB_shadow enum:
       TEXTURE_COMPARE_MODE_ARB             = 0x884C
       TEXTURE_COMPARE_FUNC_ARB             = 0x884D
       COMPARE_R_TO_TEXTURE_ARB             = 0x884E

###############################################################################

# ARB Extension #24
ARB_shadow_ambient enum:
    TEXTURE_COMPARE_FAIL_VALUE_ARB          = 0x80BF

###############################################################################

# No new tokens
# ARB Extension #25
ARB_window_pos enum:

###############################################################################

# ARB Extension #26
# ARB_vertex_program enums are shared by ARB_fragment_program are so marked.
# Unfortunately, PROGRAM_BINDING_ARB does accidentally reuse 0x8677 -
#   this was a spec editing typo that's now uncorrectable.
ARB_vertex_program enum:
    COLOR_SUM_ARB                   = 0x8458
    VERTEX_PROGRAM_ARB              = 0x8620
    VERTEX_ATTRIB_ARRAY_ENABLED_ARB         = 0x8622
    VERTEX_ATTRIB_ARRAY_SIZE_ARB            = 0x8623
    VERTEX_ATTRIB_ARRAY_STRIDE_ARB          = 0x8624
    VERTEX_ATTRIB_ARRAY_TYPE_ARB            = 0x8625
    CURRENT_VERTEX_ATTRIB_ARB           = 0x8626
    PROGRAM_LENGTH_ARB              = 0x8627    # shared
    PROGRAM_STRING_ARB              = 0x8628    # shared
    MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB      = 0x862E    # shared
    MAX_PROGRAM_MATRICES_ARB            = 0x862F    # shared
    CURRENT_MATRIX_STACK_DEPTH_ARB          = 0x8640    # shared
    CURRENT_MATRIX_ARB              = 0x8641    # shared
    VERTEX_PROGRAM_POINT_SIZE_ARB           = 0x8642
    VERTEX_PROGRAM_TWO_SIDE_ARB         = 0x8643
    VERTEX_ATTRIB_ARRAY_POINTER_ARB         = 0x8645
    PROGRAM_ERROR_POSITION_ARB          = 0x864B    # shared
    PROGRAM_BINDING_ARB             = 0x8677    # shared
    MAX_VERTEX_ATTRIBS_ARB              = 0x8869
    VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB      = 0x886A
    PROGRAM_ERROR_STRING_ARB            = 0x8874    # shared
    PROGRAM_FORMAT_ASCII_ARB            = 0x8875    # shared
    PROGRAM_FORMAT_ARB              = 0x8876    # shared
    PROGRAM_INSTRUCTIONS_ARB            = 0x88A0    # shared
    MAX_PROGRAM_INSTRUCTIONS_ARB            = 0x88A1    # shared
    PROGRAM_NATIVE_INSTRUCTIONS_ARB         = 0x88A2    # shared
    MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB     = 0x88A3    # shared
    PROGRAM_TEMPORARIES_ARB             = 0x88A4    # shared
    MAX_PROGRAM_TEMPORARIES_ARB         = 0x88A5    # shared
    PROGRAM_NATIVE_TEMPORARIES_ARB          = 0x88A6    # shared
    MAX_PROGRAM_NATIVE_TEMPORARIES_ARB      = 0x88A7    # shared
    PROGRAM_PARAMETERS_ARB              = 0x88A8    # shared
    MAX_PROGRAM_PARAMETERS_ARB          = 0x88A9    # shared
    PROGRAM_NATIVE_PARAMETERS_ARB           = 0x88AA    # shared
    MAX_PROGRAM_NATIVE_PARAMETERS_ARB       = 0x88AB    # shared
    PROGRAM_ATTRIBS_ARB             = 0x88AC    # shared
    MAX_PROGRAM_ATTRIBS_ARB             = 0x88AD    # shared
    PROGRAM_NATIVE_ATTRIBS_ARB          = 0x88AE    # shared
    MAX_PROGRAM_NATIVE_ATTRIBS_ARB          = 0x88AF    # shared
    PROGRAM_ADDRESS_REGISTERS_ARB           = 0x88B0    # shared
    MAX_PROGRAM_ADDRESS_REGISTERS_ARB       = 0x88B1    # shared
    PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB        = 0x88B2    # shared
    MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB    = 0x88B3    # shared
    MAX_PROGRAM_LOCAL_PARAMETERS_ARB        = 0x88B4    # shared
    MAX_PROGRAM_ENV_PARAMETERS_ARB          = 0x88B5    # shared
    PROGRAM_UNDER_NATIVE_LIMITS_ARB         = 0x88B6    # shared
    TRANSPOSE_CURRENT_MATRIX_ARB            = 0x88B7    # shared
    MATRIX0_ARB                 = 0x88C0    # shared
    MATRIX1_ARB                 = 0x88C1    # shared
    MATRIX2_ARB                 = 0x88C2    # shared
    MATRIX3_ARB                 = 0x88C3    # shared
    MATRIX4_ARB                 = 0x88C4    # shared
    MATRIX5_ARB                 = 0x88C5    # shared
    MATRIX6_ARB                 = 0x88C6    # shared
    MATRIX7_ARB                 = 0x88C7    # shared
    MATRIX8_ARB                 = 0x88C8    # shared
    MATRIX9_ARB                 = 0x88C9    # shared
    MATRIX10_ARB                    = 0x88CA    # shared
    MATRIX11_ARB                    = 0x88CB    # shared
    MATRIX12_ARB                    = 0x88CC    # shared
    MATRIX13_ARB                    = 0x88CD    # shared
    MATRIX14_ARB                    = 0x88CE    # shared
    MATRIX15_ARB                    = 0x88CF    # shared
    MATRIX16_ARB                    = 0x88D0    # shared
    MATRIX17_ARB                    = 0x88D1    # shared
    MATRIX18_ARB                    = 0x88D2    # shared
    MATRIX19_ARB                    = 0x88D3    # shared
    MATRIX20_ARB                    = 0x88D4    # shared
    MATRIX21_ARB                    = 0x88D5    # shared
    MATRIX22_ARB                    = 0x88D6    # shared
    MATRIX23_ARB                    = 0x88D7    # shared
    MATRIX24_ARB                    = 0x88D8    # shared
    MATRIX25_ARB                    = 0x88D9    # shared
    MATRIX26_ARB                    = 0x88DA    # shared
    MATRIX27_ARB                    = 0x88DB    # shared
    MATRIX28_ARB                    = 0x88DC    # shared
    MATRIX29_ARB                    = 0x88DD    # shared
    MATRIX30_ARB                    = 0x88DE    # shared
    MATRIX31_ARB                    = 0x88DF    # shared

###############################################################################

# ARB Extension #27
# Some ARB_fragment_program enums are shared with ARB_vertex_program,
#   and are only included in that #define block, for now.
ARB_fragment_program enum:
#   PROGRAM_LENGTH_ARB              = 0x8627    # shared
#   PROGRAM_STRING_ARB              = 0x8628    # shared
#   MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB      = 0x862E    # shared
#   MAX_PROGRAM_MATRICES_ARB            = 0x862F    # shared
#   CURRENT_MATRIX_STACK_DEPTH_ARB          = 0x8640    # shared
#   CURRENT_MATRIX_ARB              = 0x8641    # shared
#   PROGRAM_ERROR_POSITION_ARB          = 0x864B    # shared
#   PROGRAM_BINDING_ARB             = 0x8677    # shared
    FRAGMENT_PROGRAM_ARB                = 0x8804
    PROGRAM_ALU_INSTRUCTIONS_ARB            = 0x8805
    PROGRAM_TEX_INSTRUCTIONS_ARB            = 0x8806
    PROGRAM_TEX_INDIRECTIONS_ARB            = 0x8807
    PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB     = 0x8808
    PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB     = 0x8809
    PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB     = 0x880A
    MAX_PROGRAM_ALU_INSTRUCTIONS_ARB        = 0x880B
    MAX_PROGRAM_TEX_INSTRUCTIONS_ARB        = 0x880C
    MAX_PROGRAM_TEX_INDIRECTIONS_ARB        = 0x880D
    MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB     = 0x880E
    MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB     = 0x880F
    MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB     = 0x8810
    MAX_TEXTURE_COORDS_ARB              = 0x8871
    MAX_TEXTURE_IMAGE_UNITS_ARB         = 0x8872
#   PROGRAM_ERROR_STRING_ARB            = 0x8874    # shared
#   PROGRAM_FORMAT_ASCII_ARB            = 0x8875    # shared
#   PROGRAM_FORMAT_ARB              = 0x8876    # shared
#   PROGRAM_INSTRUCTIONS_ARB            = 0x88A0    # shared
#   MAX_PROGRAM_INSTRUCTIONS_ARB            = 0x88A1    # shared
#   PROGRAM_NATIVE_INSTRUCTIONS_ARB         = 0x88A2    # shared
#   MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB     = 0x88A3    # shared
#   PROGRAM_TEMPORARIES_ARB             = 0x88A4    # shared
#   MAX_PROGRAM_TEMPORARIES_ARB         = 0x88A5    # shared
#   PROGRAM_NATIVE_TEMPORARIES_ARB          = 0x88A6    # shared
#   MAX_PROGRAM_NATIVE_TEMPORARIES_ARB      = 0x88A7    # shared
#   PROGRAM_PARAMETERS_ARB              = 0x88A8    # shared
#   MAX_PROGRAM_PARAMETERS_ARB          = 0x88A9    # shared
#   PROGRAM_NATIVE_PARAMETERS_ARB           = 0x88AA    # shared
#   MAX_PROGRAM_NATIVE_PARAMETERS_ARB       = 0x88AB    # shared
#   PROGRAM_ATTRIBS_ARB             = 0x88AC    # shared
#   MAX_PROGRAM_ATTRIBS_ARB             = 0x88AD    # shared
#   PROGRAM_NATIVE_ATTRIBS_ARB          = 0x88AE    # shared
#   MAX_PROGRAM_NATIVE_ATTRIBS_ARB          = 0x88AF    # shared
#   PROGRAM_ADDRESS_REGISTERS_ARB           = 0x88B0    # shared
#   MAX_PROGRAM_ADDRESS_REGISTERS_ARB       = 0x88B1    # shared
#   PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB        = 0x88B2    # shared
#   MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB    = 0x88B3    # shared
#   MAX_PROGRAM_LOCAL_PARAMETERS_ARB        = 0x88B4    # shared
#   MAX_PROGRAM_ENV_PARAMETERS_ARB          = 0x88B5    # shared
#   PROGRAM_UNDER_NATIVE_LIMITS_ARB         = 0x88B6    # shared
#   TRANSPOSE_CURRENT_MATRIX_ARB            = 0x88B7    # shared
#   MATRIX0_ARB                 = 0x88C0    # shared
#   MATRIX1_ARB                 = 0x88C1    # shared
#   MATRIX2_ARB                 = 0x88C2    # shared
#   MATRIX3_ARB                 = 0x88C3    # shared
#   MATRIX4_ARB                 = 0x88C4    # shared
#   MATRIX5_ARB                 = 0x88C5    # shared
#   MATRIX6_ARB                 = 0x88C6    # shared
#   MATRIX7_ARB                 = 0x88C7    # shared
#   MATRIX8_ARB                 = 0x88C8    # shared
#   MATRIX9_ARB                 = 0x88C9    # shared
#   MATRIX10_ARB                    = 0x88CA    # shared
#   MATRIX11_ARB                    = 0x88CB    # shared
#   MATRIX12_ARB                    = 0x88CC    # shared
#   MATRIX13_ARB                    = 0x88CD    # shared
#   MATRIX14_ARB                    = 0x88CE    # shared
#   MATRIX15_ARB                    = 0x88CF    # shared
#   MATRIX16_ARB                    = 0x88D0    # shared
#   MATRIX17_ARB                    = 0x88D1    # shared
#   MATRIX18_ARB                    = 0x88D2    # shared
#   MATRIX19_ARB                    = 0x88D3    # shared
#   MATRIX20_ARB                    = 0x88D4    # shared
#   MATRIX21_ARB                    = 0x88D5    # shared
#   MATRIX22_ARB                    = 0x88D6    # shared
#   MATRIX23_ARB                    = 0x88D7    # shared
#   MATRIX24_ARB                    = 0x88D8    # shared
#   MATRIX25_ARB                    = 0x88D9    # shared
#   MATRIX26_ARB                    = 0x88DA    # shared
#   MATRIX27_ARB                    = 0x88DB    # shared
#   MATRIX28_ARB                    = 0x88DC    # shared
#   MATRIX29_ARB                    = 0x88DD    # shared
#   MATRIX30_ARB                    = 0x88DE    # shared
#   MATRIX31_ARB                    = 0x88DF    # shared


###############################################################################

# ARB Extension #28
ARB_vertex_buffer_object enum:
    BUFFER_SIZE_ARB                 = 0x8764
    BUFFER_USAGE_ARB                = 0x8765
    ARRAY_BUFFER_ARB                = 0x8892
    ELEMENT_ARRAY_BUFFER_ARB            = 0x8893
    ARRAY_BUFFER_BINDING_ARB            = 0x8894
    ELEMENT_ARRAY_BUFFER_BINDING_ARB        = 0x8895
    VERTEX_ARRAY_BUFFER_BINDING_ARB         = 0x8896
    NORMAL_ARRAY_BUFFER_BINDING_ARB         = 0x8897
    COLOR_ARRAY_BUFFER_BINDING_ARB          = 0x8898
    INDEX_ARRAY_BUFFER_BINDING_ARB          = 0x8899
    TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB      = 0x889A
    EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB      = 0x889B
    SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB    = 0x889C
    FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB     = 0x889D
    WEIGHT_ARRAY_BUFFER_BINDING_ARB         = 0x889E
    VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB      = 0x889F
    READ_ONLY_ARB                   = 0x88B8
    WRITE_ONLY_ARB                  = 0x88B9
    READ_WRITE_ARB                  = 0x88BA
    BUFFER_ACCESS_ARB               = 0x88BB
    BUFFER_MAPPED_ARB               = 0x88BC
    BUFFER_MAP_POINTER_ARB              = 0x88BD
    STREAM_DRAW_ARB                 = 0x88E0
    STREAM_READ_ARB                 = 0x88E1
    STREAM_COPY_ARB                 = 0x88E2
    STATIC_DRAW_ARB                 = 0x88E4
    STATIC_READ_ARB                 = 0x88E5
    STATIC_COPY_ARB                 = 0x88E6
    DYNAMIC_DRAW_ARB                = 0x88E8
    DYNAMIC_READ_ARB                = 0x88E9
    DYNAMIC_COPY_ARB                = 0x88EA

###############################################################################

# ARB Extension #29
ARB_occlusion_query enum:
    QUERY_COUNTER_BITS_ARB              = 0x8864
    CURRENT_QUERY_ARB               = 0x8865
    QUERY_RESULT_ARB                = 0x8866
    QUERY_RESULT_AVAILABLE_ARB          = 0x8867
    SAMPLES_PASSED_ARB              = 0x8914

###############################################################################

# ARB Extension #30
ARB_shader_objects enum:
    PROGRAM_OBJECT_ARB              = 0x8B40
    SHADER_OBJECT_ARB               = 0x8B48
    OBJECT_TYPE_ARB                 = 0x8B4E
    OBJECT_SUBTYPE_ARB              = 0x8B4F
    FLOAT_VEC2_ARB                  = 0x8B50
    FLOAT_VEC3_ARB                  = 0x8B51
    FLOAT_VEC4_ARB                  = 0x8B52
    INT_VEC2_ARB                    = 0x8B53
    INT_VEC3_ARB                    = 0x8B54
    INT_VEC4_ARB                    = 0x8B55
    BOOL_ARB                    = 0x8B56
    BOOL_VEC2_ARB                   = 0x8B57
    BOOL_VEC3_ARB                   = 0x8B58
    BOOL_VEC4_ARB                   = 0x8B59
    FLOAT_MAT2_ARB                  = 0x8B5A
    FLOAT_MAT3_ARB                  = 0x8B5B
    FLOAT_MAT4_ARB                  = 0x8B5C
    SAMPLER_1D_ARB                  = 0x8B5D
    SAMPLER_2D_ARB                  = 0x8B5E
    SAMPLER_3D_ARB                  = 0x8B5F
    SAMPLER_CUBE_ARB                = 0x8B60
    SAMPLER_1D_SHADOW_ARB               = 0x8B61
    SAMPLER_2D_SHADOW_ARB               = 0x8B62
    SAMPLER_2D_RECT_ARB             = 0x8B63
    SAMPLER_2D_RECT_SHADOW_ARB          = 0x8B64
    OBJECT_DELETE_STATUS_ARB            = 0x8B80
    OBJECT_COMPILE_STATUS_ARB           = 0x8B81
    OBJECT_LINK_STATUS_ARB              = 0x8B82
    OBJECT_VALIDATE_STATUS_ARB          = 0x8B83
    OBJECT_INFO_LOG_LENGTH_ARB          = 0x8B84
    OBJECT_ATTACHED_OBJECTS_ARB         = 0x8B85
    OBJECT_ACTIVE_UNIFORMS_ARB          = 0x8B86
    OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB        = 0x8B87
    OBJECT_SHADER_SOURCE_LENGTH_ARB         = 0x8B88

###############################################################################

# ARB Extension #31
# Additional enums are reused from ARB_vertex/fragment_program and ARB_shader_objects
ARB_vertex_shader enum:
    VERTEX_SHADER_ARB               = 0x8B31
    MAX_VERTEX_UNIFORM_COMPONENTS_ARB       = 0x8B4A
    MAX_VARYING_FLOATS_ARB              = 0x8B4B
    MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB      = 0x8B4C
    MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB        = 0x8B4D
    OBJECT_ACTIVE_ATTRIBUTES_ARB            = 0x8B89
    OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB      = 0x8B8A

###############################################################################

# ARB Extension #32
# Additional enums are reused from ARB_fragment_program and ARB_shader_objects
ARB_fragment_shader enum:
    FRAGMENT_SHADER_ARB             = 0x8B30
    MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB     = 0x8B49
    FRAGMENT_SHADER_DERIVATIVE_HINT_ARB     = 0x8B8B

###############################################################################

# ARB Extension #33
ARB_shading_language_100 enum:
    SHADING_LANGUAGE_VERSION_ARB            = 0x8B8C

###############################################################################

# ARB Extension #34
# No new tokens
ARB_texture_non_power_of_two enum:

###############################################################################

# ARB Extension #35
ARB_point_sprite enum:
    POINT_SPRITE_ARB                = 0x8861
    COORD_REPLACE_ARB               = 0x8862

###############################################################################

# ARB Extension #36
# No new tokens
ARB_fragment_program_shadow enum:

###############################################################################

# ARB Extension #37
ARB_draw_buffers enum:
    MAX_DRAW_BUFFERS_ARB                = 0x8824
    DRAW_BUFFER0_ARB                = 0x8825
    DRAW_BUFFER1_ARB                = 0x8826
    DRAW_BUFFER2_ARB                = 0x8827
    DRAW_BUFFER3_ARB                = 0x8828
    DRAW_BUFFER4_ARB                = 0x8829
    DRAW_BUFFER5_ARB                = 0x882A
    DRAW_BUFFER6_ARB                = 0x882B
    DRAW_BUFFER7_ARB                = 0x882C
    DRAW_BUFFER8_ARB                = 0x882D
    DRAW_BUFFER9_ARB                = 0x882E
    DRAW_BUFFER10_ARB               = 0x882F
    DRAW_BUFFER11_ARB               = 0x8830
    DRAW_BUFFER12_ARB               = 0x8831
    DRAW_BUFFER13_ARB               = 0x8832
    DRAW_BUFFER14_ARB               = 0x8833
    DRAW_BUFFER15_ARB               = 0x8834

###############################################################################

# ARB Extension #38
ARB_texture_rectangle enum:
    TEXTURE_RECTANGLE_ARB               = 0x84F5
    TEXTURE_BINDING_RECTANGLE_ARB           = 0x84F6
    PROXY_TEXTURE_RECTANGLE_ARB         = 0x84F7
    MAX_RECTANGLE_TEXTURE_SIZE_ARB          = 0x84F8

###############################################################################

# ARB Extension #39
ARB_color_buffer_float enum:
    RGBA_FLOAT_MODE_ARB             = 0x8820
    CLAMP_VERTEX_COLOR_ARB              = 0x891A
    CLAMP_FRAGMENT_COLOR_ARB            = 0x891B
    CLAMP_READ_COLOR_ARB                = 0x891C
    FIXED_ONLY_ARB                  = 0x891D

###############################################################################

# ARB Extension #40
ARB_half_float_pixel enum:
    HALF_FLOAT_ARB                  = 0x140B

###############################################################################

# ARB Extension #41
ARB_texture_float enum:
    TEXTURE_RED_TYPE_ARB                = 0x8C10
    TEXTURE_GREEN_TYPE_ARB              = 0x8C11
    TEXTURE_BLUE_TYPE_ARB               = 0x8C12
    TEXTURE_ALPHA_TYPE_ARB              = 0x8C13
    TEXTURE_LUMINANCE_TYPE_ARB          = 0x8C14
    TEXTURE_INTENSITY_TYPE_ARB          = 0x8C15
    TEXTURE_DEPTH_TYPE_ARB              = 0x8C16
    UNSIGNED_NORMALIZED_ARB             = 0x8C17
    RGBA32F_ARB                 = 0x8814
    RGB32F_ARB                  = 0x8815
    ALPHA32F_ARB                    = 0x8816
    INTENSITY32F_ARB                = 0x8817
    LUMINANCE32F_ARB                = 0x8818
    LUMINANCE_ALPHA32F_ARB              = 0x8819
    RGBA16F_ARB                 = 0x881A
    RGB16F_ARB                  = 0x881B
    ALPHA16F_ARB                    = 0x881C
    INTENSITY16F_ARB                = 0x881D
    LUMINANCE16F_ARB                = 0x881E
    LUMINANCE_ALPHA16F_ARB              = 0x881F

###############################################################################

# ARB Extension #42
ARB_pixel_buffer_object enum:
    PIXEL_PACK_BUFFER_ARB               = 0x88EB
    PIXEL_UNPACK_BUFFER_ARB             = 0x88EC
    PIXEL_PACK_BUFFER_BINDING_ARB           = 0x88ED
    PIXEL_UNPACK_BUFFER_BINDING_ARB         = 0x88EF

###############################################################################

# ARB Extension #43
ARB_depth_buffer_float enum:
    DEPTH_COMPONENT32F              = 0x8CAC
    DEPTH32F_STENCIL8               = 0x8CAD
    FLOAT_32_UNSIGNED_INT_24_8_REV          = 0x8DAD

###############################################################################

# ARB Extension #44
# No new tokens
ARB_draw_instanced enum:

###############################################################################

# ARB Extension #45
ARB_framebuffer_object enum:
    INVALID_FRAMEBUFFER_OPERATION           = 0x0506
    FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING       = 0x8210
    FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE       = 0x8211
    FRAMEBUFFER_ATTACHMENT_RED_SIZE         = 0x8212
    FRAMEBUFFER_ATTACHMENT_GREEN_SIZE       = 0x8213
    FRAMEBUFFER_ATTACHMENT_BLUE_SIZE        = 0x8214
    FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE       = 0x8215
    FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE       = 0x8216
    FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE     = 0x8217
    FRAMEBUFFER_DEFAULT             = 0x8218
    FRAMEBUFFER_UNDEFINED               = 0x8219
    DEPTH_STENCIL_ATTACHMENT            = 0x821A
    MAX_RENDERBUFFER_SIZE               = 0x84E8
    DEPTH_STENCIL                   = 0x84F9
    UNSIGNED_INT_24_8               = 0x84FA
    DEPTH24_STENCIL8                = 0x88F0
    TEXTURE_STENCIL_SIZE                = 0x88F1
    TEXTURE_RED_TYPE                = 0x8C10
    TEXTURE_GREEN_TYPE              = 0x8C11
    TEXTURE_BLUE_TYPE               = 0x8C12
    TEXTURE_ALPHA_TYPE              = 0x8C13
    TEXTURE_DEPTH_TYPE              = 0x8C16
    UNSIGNED_NORMALIZED             = 0x8C17
    FRAMEBUFFER_BINDING             = 0x8CA6
    DRAW_FRAMEBUFFER_BINDING            = GL_FRAMEBUFFER_BINDING
    RENDERBUFFER_BINDING                = 0x8CA7
    READ_FRAMEBUFFER                = 0x8CA8
    DRAW_FRAMEBUFFER                = 0x8CA9
    READ_FRAMEBUFFER_BINDING            = 0x8CAA
    RENDERBUFFER_SAMPLES                = 0x8CAB
    FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE      = 0x8CD0
    FRAMEBUFFER_ATTACHMENT_OBJECT_NAME      = 0x8CD1
    FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL        = 0x8CD2
    FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE    = 0x8CD3
    FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER        = 0x8CD4
    FRAMEBUFFER_COMPLETE                = 0x8CD5
    FRAMEBUFFER_INCOMPLETE_ATTACHMENT       = 0x8CD6
    FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT   = 0x8CD7
    FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER      = 0x8CDB
    FRAMEBUFFER_INCOMPLETE_READ_BUFFER      = 0x8CDC
    FRAMEBUFFER_UNSUPPORTED             = 0x8CDD
    MAX_COLOR_ATTACHMENTS               = 0x8CDF
    COLOR_ATTACHMENT0               = 0x8CE0
    COLOR_ATTACHMENT1               = 0x8CE1
    COLOR_ATTACHMENT2               = 0x8CE2
    COLOR_ATTACHMENT3               = 0x8CE3
    COLOR_ATTACHMENT4               = 0x8CE4
    COLOR_ATTACHMENT5               = 0x8CE5
    COLOR_ATTACHMENT6               = 0x8CE6
    COLOR_ATTACHMENT7               = 0x8CE7
    COLOR_ATTACHMENT8               = 0x8CE8
    COLOR_ATTACHMENT9               = 0x8CE9
    COLOR_ATTACHMENT10              = 0x8CEA
    COLOR_ATTACHMENT11              = 0x8CEB
    COLOR_ATTACHMENT12              = 0x8CEC
    COLOR_ATTACHMENT13              = 0x8CED
    COLOR_ATTACHMENT14              = 0x8CEE
    COLOR_ATTACHMENT15              = 0x8CEF
    DEPTH_ATTACHMENT                = 0x8D00
    STENCIL_ATTACHMENT              = 0x8D20
    FRAMEBUFFER                 = 0x8D40
    RENDERBUFFER                    = 0x8D41
    RENDERBUFFER_WIDTH              = 0x8D42
    RENDERBUFFER_HEIGHT             = 0x8D43
    RENDERBUFFER_INTERNAL_FORMAT            = 0x8D44
    STENCIL_INDEX1                  = 0x8D46
    STENCIL_INDEX4                  = 0x8D47
    STENCIL_INDEX8                  = 0x8D48
    STENCIL_INDEX16                 = 0x8D49
    RENDERBUFFER_RED_SIZE               = 0x8D50
    RENDERBUFFER_GREEN_SIZE             = 0x8D51
    RENDERBUFFER_BLUE_SIZE              = 0x8D52
    RENDERBUFFER_ALPHA_SIZE             = 0x8D53
    RENDERBUFFER_DEPTH_SIZE             = 0x8D54
    RENDERBUFFER_STENCIL_SIZE           = 0x8D55
    FRAMEBUFFER_INCOMPLETE_MULTISAMPLE      = 0x8D56
    MAX_SAMPLES                 = 0x8D57

ARB_framebuffer_object enum:
    INDEX                       = 0x8222
    TEXTURE_LUMINANCE_TYPE              = 0x8C14
    TEXTURE_INTENSITY_TYPE              = 0x8C15

###############################################################################

# ARB Extension #46
ARB_framebuffer_sRGB enum:
    FRAMEBUFFER_SRGB                = 0x8DB9

###############################################################################

# ARB Extension #47
ARB_geometry_shader4 enum:
    LINES_ADJACENCY_ARB             = 0x000A
    LINE_STRIP_ADJACENCY_ARB            = 0x000B
    TRIANGLES_ADJACENCY_ARB             = 0x000C
    TRIANGLE_STRIP_ADJACENCY_ARB            = 0x000D
    PROGRAM_POINT_SIZE_ARB              = 0x8642
    MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_ARB        = 0x8C29
    FRAMEBUFFER_ATTACHMENT_LAYERED_ARB      = 0x8DA7
    FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_ARB    = 0x8DA8
    FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_ARB      = 0x8DA9
    GEOMETRY_SHADER_ARB             = 0x8DD9
    GEOMETRY_VERTICES_OUT_ARB           = 0x8DDA
    GEOMETRY_INPUT_TYPE_ARB             = 0x8DDB
    GEOMETRY_OUTPUT_TYPE_ARB            = 0x8DDC
    MAX_GEOMETRY_VARYING_COMPONENTS_ARB     = 0x8DDD
    MAX_VERTEX_VARYING_COMPONENTS_ARB       = 0x8DDE
    MAX_GEOMETRY_UNIFORM_COMPONENTS_ARB     = 0x8DDF
    MAX_GEOMETRY_OUTPUT_VERTICES_ARB        = 0x8DE0
    MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_ARB    = 0x8DE1
    use VERSION_3_0             MAX_VARYING_COMPONENTS
    use ARB_framebuffer_object      FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER

###############################################################################

# ARB Extension #48
ARB_half_float_vertex enum:
    HALF_FLOAT                  = 0x140B

###############################################################################

# ARB Extension #49
ARB_instanced_arrays enum:
       VERTEX_ATTRIB_ARRAY_DIVISOR_ARB          = 0x88FE

###############################################################################

# ARB Extension #50
ARB_map_buffer_range enum:
    MAP_READ_BIT                    = 0x0001
    MAP_WRITE_BIT                   = 0x0002
    MAP_INVALIDATE_RANGE_BIT            = 0x0004
    MAP_INVALIDATE_BUFFER_BIT           = 0x0008
    MAP_FLUSH_EXPLICIT_BIT              = 0x0010
    MAP_UNSYNCHRONIZED_BIT              = 0x0020

###############################################################################

# ARB Extension #51
ARB_texture_buffer_object enum:
    TEXTURE_BUFFER_ARB              = 0x8C2A
    MAX_TEXTURE_BUFFER_SIZE_ARB         = 0x8C2B
    TEXTURE_BINDING_BUFFER_ARB          = 0x8C2C
    TEXTURE_BUFFER_DATA_STORE_BINDING_ARB       = 0x8C2D
    TEXTURE_BUFFER_FORMAT_ARB           = 0x8C2E

###############################################################################

# ARB Extension #52
ARB_texture_compression_rgtc enum:
    COMPRESSED_RED_RGTC1                = 0x8DBB
    COMPRESSED_SIGNED_RED_RGTC1         = 0x8DBC
    COMPRESSED_RG_RGTC2             = 0x8DBD
    COMPRESSED_SIGNED_RG_RGTC2          = 0x8DBE

###############################################################################

# ARB Extension #53
ARB_texture_rg enum:
    RG                      = 0x8227
    RG_INTEGER                  = 0x8228
    R8                      = 0x8229
    R16                     = 0x822A
    RG8                     = 0x822B
    RG16                        = 0x822C
    R16F                        = 0x822D
    R32F                        = 0x822E
    RG16F                       = 0x822F
    RG32F                       = 0x8230
    R8I                     = 0x8231
    R8UI                        = 0x8232
    R16I                        = 0x8233
    R16UI                       = 0x8234
    R32I                        = 0x8235
    R32UI                       = 0x8236
    RG8I                        = 0x8237
    RG8UI                       = 0x8238
    RG16I                       = 0x8239
    RG16UI                      = 0x823A
    RG32I                       = 0x823B
    RG32UI                      = 0x823C

###############################################################################

# ARB Extension #54
ARB_vertex_array_object enum:
    VERTEX_ARRAY_BINDING                = 0x85B5

###############################################################################

# No new tokens
# ARB Extension #55 - WGL_ARB_create_context
# ARB Extension #56 - GLX_ARB_create_context

###############################################################################

# ARB Extension #57
ARB_uniform_buffer_object enum:
    UNIFORM_BUFFER                  = 0x8A11
    UNIFORM_BUFFER_BINDING              = 0x8A28
    UNIFORM_BUFFER_START                = 0x8A29
    UNIFORM_BUFFER_SIZE             = 0x8A2A
    MAX_VERTEX_UNIFORM_BLOCKS           = 0x8A2B
    MAX_GEOMETRY_UNIFORM_BLOCKS         = 0x8A2C
    MAX_FRAGMENT_UNIFORM_BLOCKS         = 0x8A2D
    MAX_COMBINED_UNIFORM_BLOCKS         = 0x8A2E
    MAX_UNIFORM_BUFFER_BINDINGS         = 0x8A2F
    MAX_UNIFORM_BLOCK_SIZE              = 0x8A30
    MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS      = 0x8A31
    MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS    = 0x8A32
    MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS    = 0x8A33
    UNIFORM_BUFFER_OFFSET_ALIGNMENT         = 0x8A34
    ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH        = 0x8A35
    ACTIVE_UNIFORM_BLOCKS               = 0x8A36
    UNIFORM_TYPE                    = 0x8A37
    UNIFORM_SIZE                    = 0x8A38
    UNIFORM_NAME_LENGTH             = 0x8A39
    UNIFORM_BLOCK_INDEX             = 0x8A3A
    UNIFORM_OFFSET                  = 0x8A3B
    UNIFORM_ARRAY_STRIDE                = 0x8A3C
    UNIFORM_MATRIX_STRIDE               = 0x8A3D
    UNIFORM_IS_ROW_MAJOR                = 0x8A3E
    UNIFORM_BLOCK_BINDING               = 0x8A3F
    UNIFORM_BLOCK_DATA_SIZE             = 0x8A40
    UNIFORM_BLOCK_NAME_LENGTH           = 0x8A41
    UNIFORM_BLOCK_ACTIVE_UNIFORMS           = 0x8A42
    UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES        = 0x8A43
    UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER   = 0x8A44
    UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45
    UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46
    INVALID_INDEX                   = 0xFFFFFFFFu

###############################################################################

# ARB Extension #58
# No new tokens
ARB_compatibility enum:
passthru: /* ARB_compatibility just defines tokens from core 3.0 */

###############################################################################

# ARB Extension #59
ARB_copy_buffer enum:
    COPY_READ_BUFFER                = 0x8F36
    COPY_WRITE_BUFFER               = 0x8F37

###############################################################################

# ARB Extension #60
# No new tokens
ARB_shader_texture_lod enum:

###############################################################################

# ARB Extension #61
ARB_depth_clamp enum:
    DEPTH_CLAMP                 = 0x864F

###############################################################################

# No new tokens
# ARB Extension #62
ARB_draw_elements_base_vertex enum:

###############################################################################

# No new tokens
# ARB Extension #63
ARB_fragment_coord_conventions enum:

###############################################################################

# ARB Extension #64
ARB_provoking_vertex enum:
    QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION    = 0x8E4C
    FIRST_VERTEX_CONVENTION             = 0x8E4D
    LAST_VERTEX_CONVENTION              = 0x8E4E
    PROVOKING_VERTEX                = 0x8E4F

###############################################################################

# ARB Extension #65
ARB_seamless_cube_map enum:
    TEXTURE_CUBE_MAP_SEAMLESS           = 0x884F

###############################################################################

# ARB Extension #66
ARB_sync enum:
    MAX_SERVER_WAIT_TIMEOUT             = 0x9111
    OBJECT_TYPE                 = 0x9112
    SYNC_CONDITION                  = 0x9113
    SYNC_STATUS                 = 0x9114
    SYNC_FLAGS                  = 0x9115
    SYNC_FENCE                  = 0x9116
    SYNC_GPU_COMMANDS_COMPLETE          = 0x9117
    UNSIGNALED                  = 0x9118
    SIGNALED                    = 0x9119
    ALREADY_SIGNALED                = 0x911A
    TIMEOUT_EXPIRED                 = 0x911B
    CONDITION_SATISFIED             = 0x911C
    WAIT_FAILED                 = 0x911D
    SYNC_FLUSH_COMMANDS_BIT             = 0x00000001
    TIMEOUT_IGNORED                 = 0xFFFFFFFFFFFFFFFFull

###############################################################################

# ARB Extension #67
ARB_texture_multisample enum:
    SAMPLE_POSITION                 = 0x8E50
    SAMPLE_MASK                 = 0x8E51
    SAMPLE_MASK_VALUE               = 0x8E52
    MAX_SAMPLE_MASK_WORDS               = 0x8E59
    TEXTURE_2D_MULTISAMPLE              = 0x9100
    PROXY_TEXTURE_2D_MULTISAMPLE            = 0x9101
    TEXTURE_2D_MULTISAMPLE_ARRAY            = 0x9102
    PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY      = 0x9103
    TEXTURE_BINDING_2D_MULTISAMPLE          = 0x9104
    TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY        = 0x9105
    TEXTURE_SAMPLES                 = 0x9106
    TEXTURE_FIXED_SAMPLE_LOCATIONS          = 0x9107
    SAMPLER_2D_MULTISAMPLE              = 0x9108
    INT_SAMPLER_2D_MULTISAMPLE          = 0x9109
    UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE     = 0x910A
    SAMPLER_2D_MULTISAMPLE_ARRAY            = 0x910B
    INT_SAMPLER_2D_MULTISAMPLE_ARRAY        = 0x910C
    UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY   = 0x910D
    MAX_COLOR_TEXTURE_SAMPLES           = 0x910E
    MAX_DEPTH_TEXTURE_SAMPLES           = 0x910F
    MAX_INTEGER_SAMPLES             = 0x9110

###############################################################################

# ARB Extension #68
ARB_vertex_array_bgra enum:
    use VERSION_1_2             BGRA

###############################################################################

# No new tokens
# ARB Extension #69
ARB_draw_buffers_blend enum:

###############################################################################

# ARB Extension #70
ARB_sample_shading enum:
    SAMPLE_SHADING                  = 0x8C36
    MIN_SAMPLE_SHADING_VALUE            = 0x8C37

###############################################################################

# ARB Extension #71
ARB_texture_cube_map_array enum:
    TEXTURE_CUBE_MAP_ARRAY              = 0x9009
    TEXTURE_BINDING_CUBE_MAP_ARRAY          = 0x900A
    PROXY_TEXTURE_CUBE_MAP_ARRAY            = 0x900B
    SAMPLER_CUBE_MAP_ARRAY              = 0x900C
    SAMPLER_CUBE_MAP_ARRAY_SHADOW           = 0x900D
    INT_SAMPLER_CUBE_MAP_ARRAY          = 0x900E
    UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY     = 0x900F

###############################################################################

# ARB Extension #72
ARB_texture_gather enum:
    MIN_PROGRAM_TEXTURE_GATHER_OFFSET       = 0x8E5E
    MAX_PROGRAM_TEXTURE_GATHER_OFFSET       = 0x8E5F
    MAX_PROGRAM_TEXTURE_GATHER_COMPONENTS       = 0x8F9F

###############################################################################

# No new tokens
# ARB Extension #73
ARB_texture_query_lod enum:

###############################################################################

# No new tokens
# ARB Extension #74 - WGL_ARB_create_context_profile
# ARB Extension #75 - GLX_ARB_create_context_profile

###############################################################################
#
# non-ARB extensions follow, in registry order
#
###############################################################################

###############################################################################

# Extension #1
EXT_abgr enum:
    ABGR_EXT                    = 0x8000

###############################################################################

# Extension #2
EXT_blend_color enum:
    CONSTANT_COLOR_EXT              = 0x8001
    ONE_MINUS_CONSTANT_COLOR_EXT            = 0x8002
    CONSTANT_ALPHA_EXT              = 0x8003
    ONE_MINUS_CONSTANT_ALPHA_EXT            = 0x8004
    BLEND_COLOR_EXT                 = 0x8005 # 4 F

###############################################################################

# Extension #3
EXT_polygon_offset enum:
    POLYGON_OFFSET_EXT              = 0x8037
    POLYGON_OFFSET_FACTOR_EXT           = 0x8038
    POLYGON_OFFSET_BIAS_EXT             = 0x8039 # 1 F

###############################################################################

# Extension #4
EXT_texture enum:
    ALPHA4_EXT                  = 0x803B
    ALPHA8_EXT                  = 0x803C
    ALPHA12_EXT                 = 0x803D
    ALPHA16_EXT                 = 0x803E
    LUMINANCE4_EXT                  = 0x803F
    LUMINANCE8_EXT                  = 0x8040
    LUMINANCE12_EXT                 = 0x8041
    LUMINANCE16_EXT                 = 0x8042
    LUMINANCE4_ALPHA4_EXT               = 0x8043
    LUMINANCE6_ALPHA2_EXT               = 0x8044
    LUMINANCE8_ALPHA8_EXT               = 0x8045
    LUMINANCE12_ALPHA4_EXT              = 0x8046
    LUMINANCE12_ALPHA12_EXT             = 0x8047
    LUMINANCE16_ALPHA16_EXT             = 0x8048
    INTENSITY_EXT                   = 0x8049
    INTENSITY4_EXT                  = 0x804A
    INTENSITY8_EXT                  = 0x804B
    INTENSITY12_EXT                 = 0x804C
    INTENSITY16_EXT                 = 0x804D
    RGB2_EXT                    = 0x804E
    RGB4_EXT                    = 0x804F
    RGB5_EXT                    = 0x8050
    RGB8_EXT                    = 0x8051
    RGB10_EXT                   = 0x8052
    RGB12_EXT                   = 0x8053
    RGB16_EXT                   = 0x8054
    RGBA2_EXT                   = 0x8055
    RGBA4_EXT                   = 0x8056
    RGB5_A1_EXT                 = 0x8057
    RGBA8_EXT                   = 0x8058
    RGB10_A2_EXT                    = 0x8059
    RGBA12_EXT                  = 0x805A
    RGBA16_EXT                  = 0x805B
    TEXTURE_RED_SIZE_EXT                = 0x805C
    TEXTURE_GREEN_SIZE_EXT              = 0x805D
    TEXTURE_BLUE_SIZE_EXT               = 0x805E
    TEXTURE_ALPHA_SIZE_EXT              = 0x805F
    TEXTURE_LUMINANCE_SIZE_EXT          = 0x8060
    TEXTURE_INTENSITY_SIZE_EXT          = 0x8061
    REPLACE_EXT                 = 0x8062
    PROXY_TEXTURE_1D_EXT                = 0x8063
    PROXY_TEXTURE_2D_EXT                = 0x8064
    TEXTURE_TOO_LARGE_EXT               = 0x8065

###############################################################################

# Extension #5 - skipped

###############################################################################

# Extension #6
EXT_texture3D enum:
    PACK_SKIP_IMAGES_EXT                = 0x806B # 1 I
    PACK_IMAGE_HEIGHT_EXT               = 0x806C # 1 F
    UNPACK_SKIP_IMAGES_EXT              = 0x806D # 1 I
    UNPACK_IMAGE_HEIGHT_EXT             = 0x806E # 1 F
    TEXTURE_3D_EXT                  = 0x806F # 1 I
    PROXY_TEXTURE_3D_EXT                = 0x8070
    TEXTURE_DEPTH_EXT               = 0x8071
    TEXTURE_WRAP_R_EXT              = 0x8072
    MAX_3D_TEXTURE_SIZE_EXT             = 0x8073 # 1 I

###############################################################################

# Extension #7
SGIS_texture_filter4 enum:
    FILTER4_SGIS                    = 0x8146
    TEXTURE_FILTER4_SIZE_SGIS           = 0x8147

###############################################################################

# Extension #8 - skipped

###############################################################################

# No new tokens
# Extension #9
EXT_subtexture enum:

###############################################################################

# No new tokens
# Extension #10
EXT_copy_texture enum:

###############################################################################

# Extension #11
EXT_histogram enum:
    HISTOGRAM_EXT                   = 0x8024 # 1 I
    PROXY_HISTOGRAM_EXT             = 0x8025
    HISTOGRAM_WIDTH_EXT             = 0x8026
    HISTOGRAM_FORMAT_EXT                = 0x8027
    HISTOGRAM_RED_SIZE_EXT              = 0x8028
    HISTOGRAM_GREEN_SIZE_EXT            = 0x8029
    HISTOGRAM_BLUE_SIZE_EXT             = 0x802A
    HISTOGRAM_ALPHA_SIZE_EXT            = 0x802B
    HISTOGRAM_LUMINANCE_SIZE_EXT            = 0x802C
    HISTOGRAM_SINK_EXT              = 0x802D
    MINMAX_EXT                  = 0x802E # 1 I
    MINMAX_FORMAT_EXT               = 0x802F
    MINMAX_SINK_EXT                 = 0x8030
    TABLE_TOO_LARGE_EXT             = 0x8031

###############################################################################

# Extension #12
EXT_convolution enum:
    CONVOLUTION_1D_EXT              = 0x8010 # 1 I
    CONVOLUTION_2D_EXT              = 0x8011 # 1 I
    SEPARABLE_2D_EXT                = 0x8012 # 1 I
    CONVOLUTION_BORDER_MODE_EXT         = 0x8013
    CONVOLUTION_FILTER_SCALE_EXT            = 0x8014
    CONVOLUTION_FILTER_BIAS_EXT         = 0x8015
    REDUCE_EXT                  = 0x8016
    CONVOLUTION_FORMAT_EXT              = 0x8017
    CONVOLUTION_WIDTH_EXT               = 0x8018
    CONVOLUTION_HEIGHT_EXT              = 0x8019
    MAX_CONVOLUTION_WIDTH_EXT           = 0x801A
    MAX_CONVOLUTION_HEIGHT_EXT          = 0x801B
    POST_CONVOLUTION_RED_SCALE_EXT          = 0x801C # 1 F
    POST_CONVOLUTION_GREEN_SCALE_EXT        = 0x801D # 1 F
    POST_CONVOLUTION_BLUE_SCALE_EXT         = 0x801E # 1 F
    POST_CONVOLUTION_ALPHA_SCALE_EXT        = 0x801F # 1 F
    POST_CONVOLUTION_RED_BIAS_EXT           = 0x8020 # 1 F
    POST_CONVOLUTION_GREEN_BIAS_EXT         = 0x8021 # 1 F
    POST_CONVOLUTION_BLUE_BIAS_EXT          = 0x8022 # 1 F
    POST_CONVOLUTION_ALPHA_BIAS_EXT         = 0x8023 # 1 F

###############################################################################

# Extension #13
SGI_color_matrix enum:
    COLOR_MATRIX_SGI                = 0x80B1 # 16 F
    COLOR_MATRIX_STACK_DEPTH_SGI            = 0x80B2 # 1 I
    MAX_COLOR_MATRIX_STACK_DEPTH_SGI        = 0x80B3 # 1 I
    POST_COLOR_MATRIX_RED_SCALE_SGI         = 0x80B4 # 1 F
    POST_COLOR_MATRIX_GREEN_SCALE_SGI       = 0x80B5 # 1 F
    POST_COLOR_MATRIX_BLUE_SCALE_SGI        = 0x80B6 # 1 F
    POST_COLOR_MATRIX_ALPHA_SCALE_SGI       = 0x80B7 # 1 F
    POST_COLOR_MATRIX_RED_BIAS_SGI          = 0x80B8 # 1 F
    POST_COLOR_MATRIX_GREEN_BIAS_SGI        = 0x80B9 # 1 F
    POST_COLOR_MATRIX_BLUE_BIAS_SGI         = 0x80BA # 1 F
    POST_COLOR_MATRIX_ALPHA_BIAS_SGI        = 0x80BB # 1 F

###############################################################################

# Extension #14
SGI_color_table enum:
    COLOR_TABLE_SGI                 = 0x80D0 # 1 I
    POST_CONVOLUTION_COLOR_TABLE_SGI        = 0x80D1 # 1 I
    POST_COLOR_MATRIX_COLOR_TABLE_SGI       = 0x80D2 # 1 I
    PROXY_COLOR_TABLE_SGI               = 0x80D3
    PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI      = 0x80D4
    PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI     = 0x80D5
    COLOR_TABLE_SCALE_SGI               = 0x80D6
    COLOR_TABLE_BIAS_SGI                = 0x80D7
    COLOR_TABLE_FORMAT_SGI              = 0x80D8
    COLOR_TABLE_WIDTH_SGI               = 0x80D9
    COLOR_TABLE_RED_SIZE_SGI            = 0x80DA
    COLOR_TABLE_GREEN_SIZE_SGI          = 0x80DB
    COLOR_TABLE_BLUE_SIZE_SGI           = 0x80DC
    COLOR_TABLE_ALPHA_SIZE_SGI          = 0x80DD
    COLOR_TABLE_LUMINANCE_SIZE_SGI          = 0x80DE
    COLOR_TABLE_INTENSITY_SIZE_SGI          = 0x80DF


# Extension #18
EXT_cmyka enum:
    CMYK_EXT                    = 0x800C
    CMYKA_EXT                   = 0x800D
    PACK_CMYK_HINT_EXT              = 0x800E # 1 I
    UNPACK_CMYK_HINT_EXT                = 0x800F # 1 I

###############################################################################

# Extension #19 - skipped

###############################################################################

# Extension #20
EXT_texture_object enum:
    TEXTURE_PRIORITY_EXT                = 0x8066
    TEXTURE_RESIDENT_EXT                = 0x8067
    TEXTURE_1D_BINDING_EXT              = 0x8068
    TEXTURE_2D_BINDING_EXT              = 0x8069
    TEXTURE_3D_BINDING_EXT              = 0x806A # 1 I

###############################################################################



###############################################################################

# Extension #23
EXT_packed_pixels enum:
    UNSIGNED_BYTE_3_3_2_EXT             = 0x8032
    UNSIGNED_SHORT_4_4_4_4_EXT          = 0x8033
    UNSIGNED_SHORT_5_5_5_1_EXT          = 0x8034
    UNSIGNED_INT_8_8_8_8_EXT            = 0x8035
    UNSIGNED_INT_10_10_10_2_EXT         = 0x8036

###############################################################################

# Extension #24
SGIS_texture_lod enum:
    TEXTURE_MIN_LOD_SGIS                = 0x813A
    TEXTURE_MAX_LOD_SGIS                = 0x813B
    TEXTURE_BASE_LEVEL_SGIS             = 0x813C
    TEXTURE_MAX_LEVEL_SGIS              = 0x813D

###############################################################################

# Extension #25
SGIS_multisample enum:
    MULTISAMPLE_SGIS                = 0x809D # 1 I
    SAMPLE_ALPHA_TO_MASK_SGIS           = 0x809E # 1 I
    SAMPLE_ALPHA_TO_ONE_SGIS            = 0x809F # 1 I
    SAMPLE_MASK_SGIS                = 0x80A0 # 1 I
    1PASS_SGIS                  = 0x80A1
    2PASS_0_SGIS                    = 0x80A2
    2PASS_1_SGIS                    = 0x80A3
    4PASS_0_SGIS                    = 0x80A4
    4PASS_1_SGIS                    = 0x80A5
    4PASS_2_SGIS                    = 0x80A6
    4PASS_3_SGIS                    = 0x80A7
    SAMPLE_BUFFERS_SGIS             = 0x80A8 # 1 I
    SAMPLES_SGIS                    = 0x80A9 # 1 I
    SAMPLE_MASK_VALUE_SGIS              = 0x80AA # 1 F
    SAMPLE_MASK_INVERT_SGIS             = 0x80AB # 1 I
    SAMPLE_PATTERN_SGIS             = 0x80AC # 1 I

###############################################################################

# Extension #26 - no specification?
# SGIS_premultiply_blend enum:

##############################################################################

# Extension #27
# Diamond ships an otherwise identical IBM_rescale_normal extension;
#  Dan Brokenshire says this is deprecated and should not be advertised.
EXT_rescale_normal enum:
    RESCALE_NORMAL_EXT              = 0x803A # 1 I

###############################################################################

# Extension #28 - GLX_EXT_visual_info

###############################################################################

# Extension #29 - skipped

###############################################################################

# Extension #30
EXT_vertex_array enum:
    VERTEX_ARRAY_EXT                = 0x8074
    NORMAL_ARRAY_EXT                = 0x8075
    COLOR_ARRAY_EXT                 = 0x8076
    INDEX_ARRAY_EXT                 = 0x8077
    TEXTURE_COORD_ARRAY_EXT             = 0x8078
    EDGE_FLAG_ARRAY_EXT             = 0x8079
    VERTEX_ARRAY_SIZE_EXT               = 0x807A
    VERTEX_ARRAY_TYPE_EXT               = 0x807B
    VERTEX_ARRAY_STRIDE_EXT             = 0x807C
    VERTEX_ARRAY_COUNT_EXT              = 0x807D # 1 I
    NORMAL_ARRAY_TYPE_EXT               = 0x807E
    NORMAL_ARRAY_STRIDE_EXT             = 0x807F
    NORMAL_ARRAY_COUNT_EXT              = 0x8080 # 1 I
    COLOR_ARRAY_SIZE_EXT                = 0x8081
    COLOR_ARRAY_TYPE_EXT                = 0x8082
    COLOR_ARRAY_STRIDE_EXT              = 0x8083
    COLOR_ARRAY_COUNT_EXT               = 0x8084 # 1 I
    INDEX_ARRAY_TYPE_EXT                = 0x8085
    INDEX_ARRAY_STRIDE_EXT              = 0x8086
    INDEX_ARRAY_COUNT_EXT               = 0x8087 # 1 I
    TEXTURE_COORD_ARRAY_SIZE_EXT            = 0x8088
    TEXTURE_COORD_ARRAY_TYPE_EXT            = 0x8089
    TEXTURE_COORD_ARRAY_STRIDE_EXT          = 0x808A
    TEXTURE_COORD_ARRAY_COUNT_EXT           = 0x808B # 1 I
    EDGE_FLAG_ARRAY_STRIDE_EXT          = 0x808C
    EDGE_FLAG_ARRAY_COUNT_EXT           = 0x808D # 1 I
    VERTEX_ARRAY_POINTER_EXT            = 0x808E
    NORMAL_ARRAY_POINTER_EXT            = 0x808F
    COLOR_ARRAY_POINTER_EXT             = 0x8090
    INDEX_ARRAY_POINTER_EXT             = 0x8091
    TEXTURE_COORD_ARRAY_POINTER_EXT         = 0x8092
    EDGE_FLAG_ARRAY_POINTER_EXT         = 0x8093

###############################################################################


# Extension #37
EXT_blend_minmax enum:
    FUNC_ADD_EXT                    = 0x8006
    MIN_EXT                     = 0x8007
    MAX_EXT                     = 0x8008
    BLEND_EQUATION_EXT              = 0x8009 # 1 I

###############################################################################

# Extension #38
EXT_blend_subtract enum:
    FUNC_SUBTRACT_EXT               = 0x800A
    FUNC_REVERSE_SUBTRACT_EXT           = 0x800B

###############################################################################

# No new tokens
# Extension #39
EXT_blend_logic_op enum:

###############################################################################







###############################################################################

# Extension #54
# EXT form promoted from SGIS form; both are included
EXT_point_parameters enum:
    POINT_SIZE_MIN_EXT              = 0x8126 # 1 F
    POINT_SIZE_MAX_EXT              = 0x8127 # 1 F
    POINT_FADE_THRESHOLD_SIZE_EXT           = 0x8128 # 1 F
    DISTANCE_ATTENUATION_EXT            = 0x8129 # 3 F




# No new tokens
# Extension #74
EXT_color_subtable enum:

###############################################################################

# Extension #75 - GLU_EXT_object_space_tess



###############################################################################

# Extension #78
EXT_paletted_texture enum:
    COLOR_INDEX1_EXT                = 0x80E2
    COLOR_INDEX2_EXT                = 0x80E3
    COLOR_INDEX4_EXT                = 0x80E4
    COLOR_INDEX8_EXT                = 0x80E5
    COLOR_INDEX12_EXT               = 0x80E6
    COLOR_INDEX16_EXT               = 0x80E7
    TEXTURE_INDEX_SIZE_EXT              = 0x80ED

###############################################################################

# Extension #79
EXT_clip_volume_hint enum:
    CLIP_VOLUME_CLIPPING_HINT_EXT           = 0x80F0

###############################################################################



###############################################################################

# No new tokens
# Extension #93
EXT_index_texture enum:

###############################################################################

# Extension #94
# Promoted from SGI?
EXT_index_material enum:
    INDEX_MATERIAL_EXT              = 0x81B8
    INDEX_MATERIAL_PARAMETER_EXT            = 0x81B9
    INDEX_MATERIAL_FACE_EXT             = 0x81BA

###############################################################################

# Extension #95
# Promoted from SGI?
EXT_index_func enum:
    INDEX_TEST_EXT                  = 0x81B5
    INDEX_TEST_FUNC_EXT             = 0x81B6
    INDEX_TEST_REF_EXT              = 0x81B7

###############################################################################

# Extension #96
# Promoted from SGI?
EXT_index_array_formats enum:
    IUI_V2F_EXT                 = 0x81AD
    IUI_V3F_EXT                 = 0x81AE
    IUI_N3F_V2F_EXT                 = 0x81AF
    IUI_N3F_V3F_EXT                 = 0x81B0
    T2F_IUI_V2F_EXT                 = 0x81B1
    T2F_IUI_V3F_EXT                 = 0x81B2
    T2F_IUI_N3F_V2F_EXT             = 0x81B3
    T2F_IUI_N3F_V3F_EXT             = 0x81B4

###############################################################################

# Extension #97
# Promoted from SGI?
EXT_compiled_vertex_array enum:
    ARRAY_ELEMENT_LOCK_FIRST_EXT            = 0x81A8
    ARRAY_ELEMENT_LOCK_COUNT_EXT            = 0x81A9

###############################################################################

# Extension #98
# Promoted from SGI?
EXT_cull_vertex enum:
    CULL_VERTEX_EXT                 = 0x81AA
    CULL_VERTEX_EYE_POSITION_EXT            = 0x81AB
    CULL_VERTEX_OBJECT_POSITION_EXT         = 0x81AC

###############################################################################

# Extension #99 - skipped



# Extension #112
EXT_draw_range_elements enum:
    MAX_ELEMENTS_VERTICES_EXT           = 0x80E8
    MAX_ELEMENTS_INDICES_EXT            = 0x80E9

###############################################################################


###############################################################################

# Extension #117
EXT_light_texture enum:
    FRAGMENT_MATERIAL_EXT               = 0x8349
    FRAGMENT_NORMAL_EXT             = 0x834A
    FRAGMENT_COLOR_EXT              = 0x834C
    ATTENUATION_EXT                 = 0x834D
    SHADOW_ATTENUATION_EXT              = 0x834E
    TEXTURE_APPLICATION_MODE_EXT            = 0x834F # 1 I
    TEXTURE_LIGHT_EXT               = 0x8350 # 1 I
    TEXTURE_MATERIAL_FACE_EXT           = 0x8351 # 1 I
    TEXTURE_MATERIAL_PARAMETER_EXT          = 0x8352 # 1 I
    use EXT_fog_coord           FRAGMENT_DEPTH_EXT

###############################################################################

# Extension #129
EXT_bgra enum:
    BGR_EXT                     = 0x80E0
    BGRA_EXT                    = 0x80E1


###############################################################################

# Extension #138
EXT_pixel_transform enum:
    PIXEL_TRANSFORM_2D_EXT              = 0x8330
    PIXEL_MAG_FILTER_EXT                = 0x8331
    PIXEL_MIN_FILTER_EXT                = 0x8332
    PIXEL_CUBIC_WEIGHT_EXT              = 0x8333
    CUBIC_EXT                   = 0x8334
    AVERAGE_EXT                 = 0x8335
    PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT      = 0x8336
    MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT      = 0x8337
    PIXEL_TRANSFORM_2D_MATRIX_EXT           = 0x8338

###############################################################################

# Unknown enum values
# Extension #139
EXT_pixel_transform_color_table enum:

#    PIXEL_TRANSFORM_COLOR_TABLE_EXT
#    PROXY_PIXEL_TRANSFORM_COLOR_TABLE_EXT

###############################################################################

# Extension #140 - skipped

###############################################################################

# Extension #141
EXT_shared_texture_palette enum:
    SHARED_TEXTURE_PALETTE_EXT          = 0x81FB



###############################################################################

# Extension #144
EXT_separate_specular_color enum:
    LIGHT_MODEL_COLOR_CONTROL_EXT           = 0x81F8
    SINGLE_COLOR_EXT                = 0x81F9
    SEPARATE_SPECULAR_COLOR_EXT         = 0x81FA

###############################################################################

# Extension #145
EXT_secondary_color enum:
    COLOR_SUM_EXT                   = 0x8458 # 1 I
    CURRENT_SECONDARY_COLOR_EXT         = 0x8459 # 3 F
    SECONDARY_COLOR_ARRAY_SIZE_EXT          = 0x845A # 1 I
    SECONDARY_COLOR_ARRAY_TYPE_EXT          = 0x845B # 1 I
    SECONDARY_COLOR_ARRAY_STRIDE_EXT        = 0x845C # 1 I
    SECONDARY_COLOR_ARRAY_POINTER_EXT       = 0x845D
    SECONDARY_COLOR_ARRAY_EXT           = 0x845E # 1 I

###############################################################################

# Dead extension - EXT_texture_env_combine was finished instead
# Extension #146
#EXT_texture_env enum:

###############################################################################

# Extension #147
EXT_texture_perturb_normal enum:
    PERTURB_EXT                 = 0x85AE
    TEXTURE_NORMAL_EXT              = 0x85AF

###############################################################################

# No new tokens
# Extension #148
# Diamond ships an otherwise identical IBM_multi_draw_arrays extension;
#  Dan Brokenshire says this is deprecated and should not be advertised.
EXT_multi_draw_arrays enum:

###############################################################################

# Extension #149
EXT_fog_coord enum:
    FOG_COORDINATE_SOURCE_EXT           = 0x8450 # 1 I
    FOG_COORDINATE_EXT              = 0x8451
    FRAGMENT_DEPTH_EXT              = 0x8452
    CURRENT_FOG_COORDINATE_EXT          = 0x8453 # 1 F
    FOG_COORDINATE_ARRAY_TYPE_EXT           = 0x8454 # 1 I
    FOG_COORDINATE_ARRAY_STRIDE_EXT         = 0x8455 # 1 I
    FOG_COORDINATE_ARRAY_POINTER_EXT        = 0x8456
    FOG_COORDINATE_ARRAY_EXT            = 0x8457 # 1 I

###############################################################################

# Extension #150 - skipped
# Extension #151 - skipped
# Extension #152 - skipped
# Extension #153 - skipped
# Extension #154 - skipped

###############################################################################

# Extension #155
REND_screen_coordinates enum:
    SCREEN_COORDINATES_REND             = 0x8490
    INVERTED_SCREEN_W_REND              = 0x8491

###############################################################################

# Extension #156
EXT_coordinate_frame enum:
    TANGENT_ARRAY_EXT               = 0x8439
    BINORMAL_ARRAY_EXT              = 0x843A
    CURRENT_TANGENT_EXT             = 0x843B
    CURRENT_BINORMAL_EXT                = 0x843C
    TANGENT_ARRAY_TYPE_EXT              = 0x843E
    TANGENT_ARRAY_STRIDE_EXT            = 0x843F
    BINORMAL_ARRAY_TYPE_EXT             = 0x8440
    BINORMAL_ARRAY_STRIDE_EXT           = 0x8441
    TANGENT_ARRAY_POINTER_EXT           = 0x8442
    BINORMAL_ARRAY_POINTER_EXT          = 0x8443
    MAP1_TANGENT_EXT                = 0x8444
    MAP2_TANGENT_EXT                = 0x8445
    MAP1_BINORMAL_EXT               = 0x8446
    MAP2_BINORMAL_EXT               = 0x8447

###############################################################################

# Extension #157 - skipped

###############################################################################

# Extension #158
EXT_texture_env_combine enum:
    COMBINE_EXT                 = 0x8570
    COMBINE_RGB_EXT                 = 0x8571
    COMBINE_ALPHA_EXT               = 0x8572
    RGB_SCALE_EXT                   = 0x8573
    ADD_SIGNED_EXT                  = 0x8574
    INTERPOLATE_EXT                 = 0x8575
    CONSTANT_EXT                    = 0x8576
    PRIMARY_COLOR_EXT               = 0x8577
    PREVIOUS_EXT                    = 0x8578
    SOURCE0_RGB_EXT                 = 0x8580
    SOURCE1_RGB_EXT                 = 0x8581
    SOURCE2_RGB_EXT                 = 0x8582
    SOURCE0_ALPHA_EXT               = 0x8588
    SOURCE1_ALPHA_EXT               = 0x8589
    SOURCE2_ALPHA_EXT               = 0x858A
    OPERAND0_RGB_EXT                = 0x8590
    OPERAND1_RGB_EXT                = 0x8591
    OPERAND2_RGB_EXT                = 0x8592
    OPERAND0_ALPHA_EXT              = 0x8598
    OPERAND1_ALPHA_EXT              = 0x8599
    OPERAND2_ALPHA_EXT              = 0x859A

###############################################################################


###############################################################################

# Extension #167 - WGL_EXT_display_color_table
# Extension #168 - WGL_EXT_extensions_string
# Extension #169 - WGL_EXT_make_current_read
# Extension #170 - WGL_EXT_pixel_format
# Extension #171 - WGL_EXT_pbuffer
# Extension #172 - WGL_EXT_swap_control

###############################################################################

# Extension #173
EXT_blend_func_separate enum:
    BLEND_DST_RGB_EXT               = 0x80C8
    BLEND_SRC_RGB_EXT               = 0x80C9
    BLEND_DST_ALPHA_EXT             = 0x80CA
    BLEND_SRC_ALPHA_EXT             = 0x80CB

###############################################################################



###############################################################################

# Extension #176
EXT_stencil_wrap enum:
    INCR_WRAP_EXT                   = 0x8507
    DECR_WRAP_EXT                   = 0x8508

###############################################################################

# Extension #177 - skipped

###############################################################################

# Extension #178
EXT_422_pixels enum:
    422_EXT                     = 0x80CC
    422_REV_EXT                 = 0x80CD
    422_AVERAGE_EXT                 = 0x80CE
    422_REV_AVERAGE_EXT             = 0x80CF





###############################################################################

# Is this shipping? No extension number assigned.
# Extension #?
EXT_texture_cube_map enum:
    NORMAL_MAP_EXT                  = 0x8511
    REFLECTION_MAP_EXT              = 0x8512
    TEXTURE_CUBE_MAP_EXT                = 0x8513
    TEXTURE_BINDING_CUBE_MAP_EXT            = 0x8514
    TEXTURE_CUBE_MAP_POSITIVE_X_EXT         = 0x8515
    TEXTURE_CUBE_MAP_NEGATIVE_X_EXT         = 0x8516
    TEXTURE_CUBE_MAP_POSITIVE_Y_EXT         = 0x8517
    TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT         = 0x8518
    TEXTURE_CUBE_MAP_POSITIVE_Z_EXT         = 0x8519
    TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT         = 0x851A
    PROXY_TEXTURE_CUBE_MAP_EXT          = 0x851B
    MAX_CUBE_MAP_TEXTURE_SIZE_EXT           = 0x851C

###############################################################################


###############################################################################

# No new tokens
# Extension #185
EXT_texture_env_add enum:

###############################################################################

# Extension #186
EXT_texture_lod_bias enum:
    MAX_TEXTURE_LOD_BIAS_EXT            = 0x84FD
    TEXTURE_FILTER_CONTROL_EXT          = 0x8500
    TEXTURE_LOD_BIAS_EXT                = 0x8501

###############################################################################

# Extension #187
EXT_texture_filter_anisotropic enum:
    TEXTURE_MAX_ANISOTROPY_EXT          = 0x84FE
    MAX_TEXTURE_MAX_ANISOTROPY_EXT          = 0x84FF

###############################################################################

# Extension #188
EXT_vertex_weighting enum:
    MODELVIEW0_STACK_DEPTH_EXT          = GL_MODELVIEW_STACK_DEPTH
    MODELVIEW1_STACK_DEPTH_EXT          = 0x8502
    MODELVIEW0_MATRIX_EXT               = GL_MODELVIEW_MATRIX
    MODELVIEW1_MATRIX_EXT               = 0x8506
    VERTEX_WEIGHTING_EXT                = 0x8509
    MODELVIEW0_EXT                  = GL_MODELVIEW
    MODELVIEW1_EXT                  = 0x850A
    CURRENT_VERTEX_WEIGHT_EXT           = 0x850B
    VERTEX_WEIGHT_ARRAY_EXT             = 0x850C
    VERTEX_WEIGHT_ARRAY_SIZE_EXT            = 0x850D
    VERTEX_WEIGHT_ARRAY_TYPE_EXT            = 0x850E
    VERTEX_WEIGHT_ARRAY_STRIDE_EXT          = 0x850F
    VERTEX_WEIGHT_ARRAY_POINTER_EXT         = 0x8510

###############################################################################

# Extension #192
NV_fog_distance enum:
    FOG_DISTANCE_MODE_NV                = 0x855A
    EYE_RADIAL_NV                   = 0x855B
    EYE_PLANE_ABSOLUTE_NV               = 0x855C
    use TextureGenParameter         EYE_PLANE

###############################################################################

# Extension #193
NV_texgen_emboss enum:
    EMBOSS_LIGHT_NV                 = 0x855D
    EMBOSS_CONSTANT_NV              = 0x855E
    EMBOSS_MAP_NV                   = 0x855F

###############################################################################

# No new tokens
# Extension #194
NV_blend_square enum:

###############################################################################

# Extension #195
NV_texture_env_combine4 enum:
    COMBINE4_NV                 = 0x8503
    SOURCE3_RGB_NV                  = 0x8583
    SOURCE3_ALPHA_NV                = 0x858B
    OPERAND3_RGB_NV                 = 0x8593
    OPERAND3_ALPHA_NV               = 0x859B

###############################################################################

# No new tokens
# Extension #196
MESA_resize_buffers enum:

###############################################################################

# No new tokens
# Extension #197
MESA_window_pos enum:

###############################################################################

# Extension #198
EXT_texture_compression_s3tc enum:
    COMPRESSED_RGB_S3TC_DXT1_EXT            = 0x83F0
    COMPRESSED_RGBA_S3TC_DXT1_EXT           = 0x83F1
    COMPRESSED_RGBA_S3TC_DXT3_EXT           = 0x83F2
    COMPRESSED_RGBA_S3TC_DXT5_EXT           = 0x83F3



###############################################################################

# Extension #209
EXT_multisample enum:
    MULTISAMPLE_EXT                 = 0x809D
    SAMPLE_ALPHA_TO_MASK_EXT            = 0x809E
    SAMPLE_ALPHA_TO_ONE_EXT             = 0x809F
    SAMPLE_MASK_EXT                 = 0x80A0
    1PASS_EXT                   = 0x80A1
    2PASS_0_EXT                 = 0x80A2
    2PASS_1_EXT                 = 0x80A3
    4PASS_0_EXT                 = 0x80A4
    4PASS_1_EXT                 = 0x80A5
    4PASS_2_EXT                 = 0x80A6
    4PASS_3_EXT                 = 0x80A7
    SAMPLE_BUFFERS_EXT              = 0x80A8 # 1 I
    SAMPLES_EXT                 = 0x80A9 # 1 I
    SAMPLE_MASK_VALUE_EXT               = 0x80AA # 1 F
    SAMPLE_MASK_INVERT_EXT              = 0x80AB # 1 I
    SAMPLE_PATTERN_EXT              = 0x80AC # 1 I
    MULTISAMPLE_BIT_EXT             = 0x20000000


###############################################################################

# Extension #220
# Promoted to ARB_texture_env_dot3, enum values changed
EXT_texture_env_dot3 enum:
    DOT3_RGB_EXT                    = 0x8740
    DOT3_RGBA_EXT                   = 0x8741


###############################################################################

# Extension #248
EXT_vertex_shader enum:
    VERTEX_SHADER_EXT               = 0x8780
    VERTEX_SHADER_BINDING_EXT           = 0x8781
    OP_INDEX_EXT                    = 0x8782
    OP_NEGATE_EXT                   = 0x8783
    OP_DOT3_EXT                 = 0x8784
    OP_DOT4_EXT                 = 0x8785
    OP_MUL_EXT                  = 0x8786
    OP_ADD_EXT                  = 0x8787
    OP_MADD_EXT                 = 0x8788
    OP_FRAC_EXT                 = 0x8789
    OP_MAX_EXT                  = 0x878A
    OP_MIN_EXT                  = 0x878B
    OP_SET_GE_EXT                   = 0x878C
    OP_SET_LT_EXT                   = 0x878D
    OP_CLAMP_EXT                    = 0x878E
    OP_FLOOR_EXT                    = 0x878F
    OP_ROUND_EXT                    = 0x8790
    OP_EXP_BASE_2_EXT               = 0x8791
    OP_LOG_BASE_2_EXT               = 0x8792
    OP_POWER_EXT                    = 0x8793
    OP_RECIP_EXT                    = 0x8794
    OP_RECIP_SQRT_EXT               = 0x8795
    OP_SUB_EXT                  = 0x8796
    OP_CROSS_PRODUCT_EXT                = 0x8797
    OP_MULTIPLY_MATRIX_EXT              = 0x8798
    OP_MOV_EXT                  = 0x8799
    OUTPUT_VERTEX_EXT               = 0x879A
    OUTPUT_COLOR0_EXT               = 0x879B
    OUTPUT_COLOR1_EXT               = 0x879C
    OUTPUT_TEXTURE_COORD0_EXT           = 0x879D
    OUTPUT_TEXTURE_COORD1_EXT           = 0x879E
    OUTPUT_TEXTURE_COORD2_EXT           = 0x879F
    OUTPUT_TEXTURE_COORD3_EXT           = 0x87A0
    OUTPUT_TEXTURE_COORD4_EXT           = 0x87A1
    OUTPUT_TEXTURE_COORD5_EXT           = 0x87A2
    OUTPUT_TEXTURE_COORD6_EXT           = 0x87A3
    OUTPUT_TEXTURE_COORD7_EXT           = 0x87A4
    OUTPUT_TEXTURE_COORD8_EXT           = 0x87A5
    OUTPUT_TEXTURE_COORD9_EXT           = 0x87A6
    OUTPUT_TEXTURE_COORD10_EXT          = 0x87A7
    OUTPUT_TEXTURE_COORD11_EXT          = 0x87A8
    OUTPUT_TEXTURE_COORD12_EXT          = 0x87A9
    OUTPUT_TEXTURE_COORD13_EXT          = 0x87AA
    OUTPUT_TEXTURE_COORD14_EXT          = 0x87AB
    OUTPUT_TEXTURE_COORD15_EXT          = 0x87AC
    OUTPUT_TEXTURE_COORD16_EXT          = 0x87AD
    OUTPUT_TEXTURE_COORD17_EXT          = 0x87AE
    OUTPUT_TEXTURE_COORD18_EXT          = 0x87AF
    OUTPUT_TEXTURE_COORD19_EXT          = 0x87B0
    OUTPUT_TEXTURE_COORD20_EXT          = 0x87B1
    OUTPUT_TEXTURE_COORD21_EXT          = 0x87B2
    OUTPUT_TEXTURE_COORD22_EXT          = 0x87B3
    OUTPUT_TEXTURE_COORD23_EXT          = 0x87B4
    OUTPUT_TEXTURE_COORD24_EXT          = 0x87B5
    OUTPUT_TEXTURE_COORD25_EXT          = 0x87B6
    OUTPUT_TEXTURE_COORD26_EXT          = 0x87B7
    OUTPUT_TEXTURE_COORD27_EXT          = 0x87B8
    OUTPUT_TEXTURE_COORD28_EXT          = 0x87B9
    OUTPUT_TEXTURE_COORD29_EXT          = 0x87BA
    OUTPUT_TEXTURE_COORD30_EXT          = 0x87BB
    OUTPUT_TEXTURE_COORD31_EXT          = 0x87BC
    OUTPUT_FOG_EXT                  = 0x87BD
    SCALAR_EXT                  = 0x87BE
    VECTOR_EXT                  = 0x87BF
    MATRIX_EXT                  = 0x87C0
    VARIANT_EXT                 = 0x87C1
    INVARIANT_EXT                   = 0x87C2
    LOCAL_CONSTANT_EXT              = 0x87C3
    LOCAL_EXT                   = 0x87C4
    MAX_VERTEX_SHADER_INSTRUCTIONS_EXT      = 0x87C5
    MAX_VERTEX_SHADER_VARIANTS_EXT          = 0x87C6
    MAX_VERTEX_SHADER_INVARIANTS_EXT        = 0x87C7
    MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT       = 0x87C8
    MAX_VERTEX_SHADER_LOCALS_EXT            = 0x87C9
    MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT    = 0x87CA
    MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT    = 0x87CB
    MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87CC
    MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT  = 0x87CD
    MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT      = 0x87CE
    VERTEX_SHADER_INSTRUCTIONS_EXT          = 0x87CF
    VERTEX_SHADER_VARIANTS_EXT          = 0x87D0
    VERTEX_SHADER_INVARIANTS_EXT            = 0x87D1
    VERTEX_SHADER_LOCAL_CONSTANTS_EXT       = 0x87D2
    VERTEX_SHADER_LOCALS_EXT            = 0x87D3
    VERTEX_SHADER_OPTIMIZED_EXT         = 0x87D4
    X_EXT                       = 0x87D5
    Y_EXT                       = 0x87D6
    Z_EXT                       = 0x87D7
    W_EXT                       = 0x87D8
    NEGATIVE_X_EXT                  = 0x87D9
    NEGATIVE_Y_EXT                  = 0x87DA
    NEGATIVE_Z_EXT                  = 0x87DB
    NEGATIVE_W_EXT                  = 0x87DC
    ZERO_EXT                    = 0x87DD
    ONE_EXT                     = 0x87DE
    NEGATIVE_ONE_EXT                = 0x87DF
    NORMALIZED_RANGE_EXT                = 0x87E0
    FULL_RANGE_EXT                  = 0x87E1
    CURRENT_VERTEX_EXT              = 0x87E2
    MVP_MATRIX_EXT                  = 0x87E3
    VARIANT_VALUE_EXT               = 0x87E4
    VARIANT_DATATYPE_EXT                = 0x87E5
    VARIANT_ARRAY_STRIDE_EXT            = 0x87E6
    VARIANT_ARRAY_TYPE_EXT              = 0x87E7
    VARIANT_ARRAY_EXT               = 0x87E8
    VARIANT_ARRAY_POINTER_EXT           = 0x87E9
    INVARIANT_VALUE_EXT             = 0x87EA
    INVARIANT_DATATYPE_EXT              = 0x87EB
    LOCAL_CONSTANT_VALUE_EXT            = 0x87EC
    LOCAL_CONSTANT_DATATYPE_EXT         = 0x87ED

###############################################################################



###############################################################################

# Extension #250 - WGL_I3D_digital_video_control
# Extension #251 - WGL_I3D_gamma
# Extension #252 - WGL_I3D_genlock
# Extension #253 - WGL_I3D_image_buffer
# Extension #254 - WGL_I3D_swap_frame_lock
# Extension #255 - WGL_I3D_swap_frame_usage



###############################################################################


###############################################################################

# Extension #263 - WGL_NV_render_depth_texture
# Extension #264 - WGL_NV_render_texture_rectangle

###############################################################################



###############################################################################



###############################################################################

# No new tokens
# Extension #267
EXT_shadow_funcs enum:

###############################################################################

# Extension #268
EXT_stencil_two_side enum:
    STENCIL_TEST_TWO_SIDE_EXT           = 0x8910
    ACTIVE_STENCIL_FACE_EXT             = 0x8911



###############################################################################


###############################################################################

# No new tokens
# Extension #291 - OpenGL ES only, not in glext.h
# OES_byte_coordinates enum:

###############################################################################

# Extension #292 - OpenGL ES only, not in glext.h
# OES_fixed_point enum:
#   FIXED_OES                   = 0x140C

###############################################################################

# No new tokens
# Extension #293 - OpenGL ES only, not in glext.h
# OES_single_precision enum:

###############################################################################

# Extension #294 - OpenGL ES only, not in glext.h
# OES_compressed_paletted_texture enum:
#   PALETTE4_RGB8_OES               = 0x8B90
#   PALETTE4_RGBA8_OES              = 0x8B91
#   PALETTE4_R5_G6_B5_OES               = 0x8B92
#   PALETTE4_RGBA4_OES              = 0x8B93
#   PALETTE4_RGB5_A1_OES                = 0x8B94
#   PALETTE8_RGB8_OES               = 0x8B95
#   PALETTE8_RGBA8_OES              = 0x8B96
#   PALETTE8_R5_G6_B5_OES               = 0x8B97
#   PALETTE8_RGBA4_OES              = 0x8B98
#   PALETTE8_RGB5_A1_OES                = 0x8B99

###############################################################################

# Extension #295 - This is an OpenGL ES extension, but also implemented in Mesa
OES_read_format enum:
    IMPLEMENTATION_COLOR_READ_TYPE_OES      = 0x8B9A
    IMPLEMENTATION_COLOR_READ_FORMAT_OES        = 0x8B9B

###############################################################################

# No new tokens
# Extension #296 - OpenGL ES only, not in glext.h
# OES_query_matrix enum:

###############################################################################

# Extension #297
EXT_depth_bounds_test enum:
    DEPTH_BOUNDS_TEST_EXT               = 0x8890
    DEPTH_BOUNDS_EXT                = 0x8891

###############################################################################

# Extension #298
EXT_texture_mirror_clamp enum:
    MIRROR_CLAMP_EXT                = 0x8742
    MIRROR_CLAMP_TO_EDGE_EXT            = 0x8743
    MIRROR_CLAMP_TO_BORDER_EXT          = 0x8912

###############################################################################

# Extension #299
EXT_blend_equation_separate enum:
    BLEND_EQUATION_RGB_EXT              = 0x8009    # alias GL_BLEND_EQUATION_EXT
    BLEND_EQUATION_ALPHA_EXT            = 0x883D

###############################################################################

###############################################################################

# Extension #302
EXT_pixel_buffer_object enum:
    PIXEL_PACK_BUFFER_EXT               = 0x88EB
    PIXEL_UNPACK_BUFFER_EXT             = 0x88EC
    PIXEL_PACK_BUFFER_BINDING_EXT           = 0x88ED
    PIXEL_UNPACK_BUFFER_BINDING_EXT         = 0x88EF

###############################################################################



###############################################################################



###############################################################################


# Extension #308 - GLX_MESA_agp_offset
# Extension #309 - GL_EXT_texture_compression_dxt1 (OpenGL ES only, subset of _s3tc version)

###############################################################################

# Extension #310
EXT_framebuffer_object enum:
    INVALID_FRAMEBUFFER_OPERATION_EXT       = 0x0506
    MAX_RENDERBUFFER_SIZE_EXT           = 0x84E8
    FRAMEBUFFER_BINDING_EXT             = 0x8CA6
    RENDERBUFFER_BINDING_EXT            = 0x8CA7
    FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT      = 0x8CD0
    FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT      = 0x8CD1
    FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT    = 0x8CD2
    FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 0x8CD3
    FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT   = 0x8CD4
    FRAMEBUFFER_COMPLETE_EXT            = 0x8CD5
    FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT       = 0x8CD6
    FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT   = 0x8CD7
## Removed 2005/09/26 in revision #117 of the extension:
##    FRAMEBUFFER_INCOMPLETE_DUPLICATE_ATTACHMENT_EXT = 0x8CD8
    FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT       = 0x8CD9
    FRAMEBUFFER_INCOMPLETE_FORMATS_EXT      = 0x8CDA
    FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT      = 0x8CDB
    FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT      = 0x8CDC
    FRAMEBUFFER_UNSUPPORTED_EXT         = 0x8CDD
## Removed 2005/05/31 in revision #113 of the extension:
##    FRAMEBUFFER_STATUS_ERROR_EXT            = 0x8CDE
    MAX_COLOR_ATTACHMENTS_EXT           = 0x8CDF
    COLOR_ATTACHMENT0_EXT               = 0x8CE0
    COLOR_ATTACHMENT1_EXT               = 0x8CE1
    COLOR_ATTACHMENT2_EXT               = 0x8CE2
    COLOR_ATTACHMENT3_EXT               = 0x8CE3
    COLOR_ATTACHMENT4_EXT               = 0x8CE4
    COLOR_ATTACHMENT5_EXT               = 0x8CE5
    COLOR_ATTACHMENT6_EXT               = 0x8CE6
    COLOR_ATTACHMENT7_EXT               = 0x8CE7
    COLOR_ATTACHMENT8_EXT               = 0x8CE8
    COLOR_ATTACHMENT9_EXT               = 0x8CE9
    COLOR_ATTACHMENT10_EXT              = 0x8CEA
    COLOR_ATTACHMENT11_EXT              = 0x8CEB
    COLOR_ATTACHMENT12_EXT              = 0x8CEC
    COLOR_ATTACHMENT13_EXT              = 0x8CED
    COLOR_ATTACHMENT14_EXT              = 0x8CEE
    COLOR_ATTACHMENT15_EXT              = 0x8CEF
    DEPTH_ATTACHMENT_EXT                = 0x8D00
    STENCIL_ATTACHMENT_EXT              = 0x8D20
    FRAMEBUFFER_EXT                 = 0x8D40
    RENDERBUFFER_EXT                = 0x8D41
    RENDERBUFFER_WIDTH_EXT              = 0x8D42
    RENDERBUFFER_HEIGHT_EXT             = 0x8D43
    RENDERBUFFER_INTERNAL_FORMAT_EXT        = 0x8D44
# removed STENCIL_INDEX_EXT = 0x8D45 in rev. #114 of the spec
    STENCIL_INDEX1_EXT              = 0x8D46
    STENCIL_INDEX4_EXT              = 0x8D47
    STENCIL_INDEX8_EXT              = 0x8D48
    STENCIL_INDEX16_EXT             = 0x8D49
    RENDERBUFFER_RED_SIZE_EXT           = 0x8D50
    RENDERBUFFER_GREEN_SIZE_EXT         = 0x8D51
    RENDERBUFFER_BLUE_SIZE_EXT          = 0x8D52
    RENDERBUFFER_ALPHA_SIZE_EXT         = 0x8D53
    RENDERBUFFER_DEPTH_SIZE_EXT         = 0x8D54
    RENDERBUFFER_STENCIL_SIZE_EXT           = 0x8D55

###############################################################################

# No new tokens
# Extension #311
GREMEDY_string_marker enum:

###############################################################################

# Extension #312
EXT_packed_depth_stencil enum:
    DEPTH_STENCIL_EXT               = 0x84F9
    UNSIGNED_INT_24_8_EXT               = 0x84FA
    DEPTH24_STENCIL8_EXT                = 0x88F0
    TEXTURE_STENCIL_SIZE_EXT            = 0x88F1

###############################################################################

# Extension #313 - WGL_3DL_stereo_control

###############################################################################

# Extension #314
EXT_stencil_clear_tag enum:
    STENCIL_TAG_BITS_EXT                = 0x88F2
    STENCIL_CLEAR_TAG_VALUE_EXT         = 0x88F3

###############################################################################

# Extension #315
EXT_texture_sRGB enum:
    SRGB_EXT                    = 0x8C40
    SRGB8_EXT                   = 0x8C41
    SRGB_ALPHA_EXT                  = 0x8C42
    SRGB8_ALPHA8_EXT                = 0x8C43
    SLUMINANCE_ALPHA_EXT                = 0x8C44
    SLUMINANCE8_ALPHA8_EXT              = 0x8C45
    SLUMINANCE_EXT                  = 0x8C46
    SLUMINANCE8_EXT                 = 0x8C47
    COMPRESSED_SRGB_EXT             = 0x8C48
    COMPRESSED_SRGB_ALPHA_EXT           = 0x8C49
    COMPRESSED_SLUMINANCE_EXT           = 0x8C4A
    COMPRESSED_SLUMINANCE_ALPHA_EXT         = 0x8C4B
    COMPRESSED_SRGB_S3TC_DXT1_EXT           = 0x8C4C
    COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT     = 0x8C4D
    COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT     = 0x8C4E
    COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT     = 0x8C4F

###############################################################################

# Extension #316
EXT_framebuffer_blit enum:
    READ_FRAMEBUFFER_EXT                = 0x8CA8
    DRAW_FRAMEBUFFER_EXT                = 0x8CA9
    DRAW_FRAMEBUFFER_BINDING_EXT            = GL_FRAMEBUFFER_BINDING_EXT
    READ_FRAMEBUFFER_BINDING_EXT            = 0x8CAA

###############################################################################

# Extension #317
EXT_framebuffer_multisample enum:
    RENDERBUFFER_SAMPLES_EXT            = 0x8CAB
    FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_EXT      = 0x8D56
    MAX_SAMPLES_EXT                 = 0x8D57

###############################################################################

# Extension #318
MESAX_texture_stack enum:
    TEXTURE_1D_STACK_MESAX              = 0x8759
    TEXTURE_2D_STACK_MESAX              = 0x875A
    PROXY_TEXTURE_1D_STACK_MESAX            = 0x875B
    PROXY_TEXTURE_2D_STACK_MESAX            = 0x875C
    TEXTURE_1D_STACK_BINDING_MESAX          = 0x875D
    TEXTURE_2D_STACK_BINDING_MESAX          = 0x875E

###############################################################################

# Extension #319
EXT_timer_query enum:
    TIME_ELAPSED_EXT                = 0x88BF

###############################################################################

# No new tokens
# Extension #320
EXT_gpu_program_parameters enum:

###############################################################################


# Extension #322
NV_gpu_program4 enum:
    MIN_PROGRAM_TEXEL_OFFSET_NV         = 0x8904
    MAX_PROGRAM_TEXEL_OFFSET_NV         = 0x8905
    PROGRAM_ATTRIB_COMPONENTS_NV            = 0x8906
    PROGRAM_RESULT_COMPONENTS_NV            = 0x8907
    MAX_PROGRAM_ATTRIB_COMPONENTS_NV        = 0x8908
    MAX_PROGRAM_RESULT_COMPONENTS_NV        = 0x8909
    MAX_PROGRAM_GENERIC_ATTRIBS_NV          = 0x8DA5
    MAX_PROGRAM_GENERIC_RESULTS_NV          = 0x8DA6

###############################################################################

# Extension #323
NV_geometry_program4 enum:
    LINES_ADJACENCY_EXT             = 0x000A
    LINE_STRIP_ADJACENCY_EXT            = 0x000B
    TRIANGLES_ADJACENCY_EXT             = 0x000C
    TRIANGLE_STRIP_ADJACENCY_EXT            = 0x000D
    GEOMETRY_PROGRAM_NV             = 0x8C26
    MAX_PROGRAM_OUTPUT_VERTICES_NV          = 0x8C27
    MAX_PROGRAM_TOTAL_OUTPUT_COMPONENTS_NV      = 0x8C28
    GEOMETRY_VERTICES_OUT_EXT           = 0x8DDA
    GEOMETRY_INPUT_TYPE_EXT             = 0x8DDB
    GEOMETRY_OUTPUT_TYPE_EXT            = 0x8DDC
    MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT        = 0x8C29
    FRAMEBUFFER_ATTACHMENT_LAYERED_EXT      = 0x8DA7
    FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT    = 0x8DA8
    FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT      = 0x8DA9
    FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT    = 0x8CD4
    PROGRAM_POINT_SIZE_EXT              = 0x8642


###############################################################################

# Extension #324
EXT_geometry_shader4 enum:
    GEOMETRY_SHADER_EXT             = 0x8DD9
    use NV_geometry_program4        GEOMETRY_VERTICES_OUT_EXT
    use NV_geometry_program4        GEOMETRY_INPUT_TYPE_EXT
    use NV_geometry_program4        GEOMETRY_OUTPUT_TYPE_EXT
    use NV_geometry_program4        MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT
    MAX_GEOMETRY_VARYING_COMPONENTS_EXT     = 0x8DDD
    MAX_VERTEX_VARYING_COMPONENTS_EXT       = 0x8DDE
    MAX_VARYING_COMPONENTS_EXT          = 0x8B4B
    MAX_GEOMETRY_UNIFORM_COMPONENTS_EXT     = 0x8DDF
    MAX_GEOMETRY_OUTPUT_VERTICES_EXT        = 0x8DE0
    MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_EXT    = 0x8DE1
    use NV_geometry_program4        LINES_ADJACENCY_EXT
    use NV_geometry_program4        LINE_STRIP_ADJACENCY_EXT
    use NV_geometry_program4        TRIANGLES_ADJACENCY_EXT
    use NV_geometry_program4        TRIANGLE_STRIP_ADJACENCY_EXT
    use NV_geometry_program4        FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT
    use NV_geometry_program4        FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT
    use NV_geometry_program4        FRAMEBUFFER_ATTACHMENT_LAYERED_EXT
    use NV_geometry_program4        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT
    use NV_geometry_program4        PROGRAM_POINT_SIZE_EXT

###############################################################################

# Extension #325
NV_vertex_program4 enum:
    VERTEX_ATTRIB_ARRAY_INTEGER_NV          = 0x88FD

###############################################################################

# Extension #326
EXT_gpu_shader4 enum:
    SAMPLER_1D_ARRAY_EXT                = 0x8DC0
    SAMPLER_2D_ARRAY_EXT                = 0x8DC1
    SAMPLER_BUFFER_EXT              = 0x8DC2
    SAMPLER_1D_ARRAY_SHADOW_EXT         = 0x8DC3
    SAMPLER_2D_ARRAY_SHADOW_EXT         = 0x8DC4
    SAMPLER_CUBE_SHADOW_EXT             = 0x8DC5
    UNSIGNED_INT_VEC2_EXT               = 0x8DC6
    UNSIGNED_INT_VEC3_EXT               = 0x8DC7
    UNSIGNED_INT_VEC4_EXT               = 0x8DC8
    INT_SAMPLER_1D_EXT              = 0x8DC9
    INT_SAMPLER_2D_EXT              = 0x8DCA
    INT_SAMPLER_3D_EXT              = 0x8DCB
    INT_SAMPLER_CUBE_EXT                = 0x8DCC
    INT_SAMPLER_2D_RECT_EXT             = 0x8DCD
    INT_SAMPLER_1D_ARRAY_EXT            = 0x8DCE
    INT_SAMPLER_2D_ARRAY_EXT            = 0x8DCF
    INT_SAMPLER_BUFFER_EXT              = 0x8DD0
    UNSIGNED_INT_SAMPLER_1D_EXT         = 0x8DD1
    UNSIGNED_INT_SAMPLER_2D_EXT         = 0x8DD2
    UNSIGNED_INT_SAMPLER_3D_EXT         = 0x8DD3
    UNSIGNED_INT_SAMPLER_CUBE_EXT           = 0x8DD4
    UNSIGNED_INT_SAMPLER_2D_RECT_EXT        = 0x8DD5
    UNSIGNED_INT_SAMPLER_1D_ARRAY_EXT       = 0x8DD6
    UNSIGNED_INT_SAMPLER_2D_ARRAY_EXT       = 0x8DD7
    UNSIGNED_INT_SAMPLER_BUFFER_EXT         = 0x8DD8

###############################################################################

# No new tokens
# Extension #327
EXT_draw_instanced enum:

###############################################################################

# Extension #328
EXT_packed_float enum:
    R11F_G11F_B10F_EXT              = 0x8C3A
    UNSIGNED_INT_10F_11F_11F_REV_EXT        = 0x8C3B
    RGBA_SIGNED_COMPONENTS_EXT          = 0x8C3C

###############################################################################

# Extension #329
EXT_texture_array enum:
    TEXTURE_1D_ARRAY_EXT                = 0x8C18
    PROXY_TEXTURE_1D_ARRAY_EXT          = 0x8C19
    TEXTURE_2D_ARRAY_EXT                = 0x8C1A
    PROXY_TEXTURE_2D_ARRAY_EXT          = 0x8C1B
    TEXTURE_BINDING_1D_ARRAY_EXT            = 0x8C1C
    TEXTURE_BINDING_2D_ARRAY_EXT            = 0x8C1D
    MAX_ARRAY_TEXTURE_LAYERS_EXT            = 0x88FF
    COMPARE_REF_DEPTH_TO_TEXTURE_EXT        = 0x884E
    use NV_geometry_program4        FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT

###############################################################################

# Extension #330
EXT_texture_buffer_object enum:
    TEXTURE_BUFFER_EXT              = 0x8C2A
    MAX_TEXTURE_BUFFER_SIZE_EXT         = 0x8C2B
    TEXTURE_BINDING_BUFFER_EXT          = 0x8C2C
    TEXTURE_BUFFER_DATA_STORE_BINDING_EXT       = 0x8C2D
    TEXTURE_BUFFER_FORMAT_EXT           = 0x8C2E

###############################################################################

# Extension #331
EXT_texture_compression_latc enum:
    COMPRESSED_LUMINANCE_LATC1_EXT          = 0x8C70
    COMPRESSED_SIGNED_LUMINANCE_LATC1_EXT       = 0x8C71
    COMPRESSED_LUMINANCE_ALPHA_LATC2_EXT        = 0x8C72
    COMPRESSED_SIGNED_LUMINANCE_ALPHA_LATC2_EXT = 0x8C73

###############################################################################

# Extension #332
EXT_texture_compression_rgtc enum:
    COMPRESSED_RED_RGTC1_EXT            = 0x8DBB
    COMPRESSED_SIGNED_RED_RGTC1_EXT         = 0x8DBC
    COMPRESSED_RED_GREEN_RGTC2_EXT          = 0x8DBD
    COMPRESSED_SIGNED_RED_GREEN_RGTC2_EXT       = 0x8DBE

###############################################################################

# Extension #333
EXT_texture_shared_exponent enum:
    RGB9_E5_EXT                 = 0x8C3D
    UNSIGNED_INT_5_9_9_9_REV_EXT            = 0x8C3E
    TEXTURE_SHARED_SIZE_EXT             = 0x8C3F

###############################################################################



###############################################################################

# Extension #337
# ??? Also WGL/GLX extensions ???
EXT_framebuffer_sRGB enum:
    FRAMEBUFFER_SRGB_EXT                = 0x8DB9
    FRAMEBUFFER_SRGB_CAPABLE_EXT            = 0x8DBA

###############################################################################



###############################################################################

# Extension #339
NV_parameter_buffer_object enum:
    MAX_PROGRAM_PARAMETER_BUFFER_BINDINGS_NV    = 0x8DA0
    MAX_PROGRAM_PARAMETER_BUFFER_SIZE_NV        = 0x8DA1
    VERTEX_PROGRAM_PARAMETER_BUFFER_NV      = 0x8DA2
    GEOMETRY_PROGRAM_PARAMETER_BUFFER_NV        = 0x8DA3
    FRAGMENT_PROGRAM_PARAMETER_BUFFER_NV        = 0x8DA4

###############################################################################

# No new tokens
# Extension #340
EXT_draw_buffers2 enum:

###############################################################################

# Extension #341
NV_transform_feedback enum:
    BACK_PRIMARY_COLOR_NV               = 0x8C77
    BACK_SECONDARY_COLOR_NV             = 0x8C78
    TEXTURE_COORD_NV                = 0x8C79
    CLIP_DISTANCE_NV                = 0x8C7A
    VERTEX_ID_NV                    = 0x8C7B
    PRIMITIVE_ID_NV                 = 0x8C7C
    GENERIC_ATTRIB_NV               = 0x8C7D
    TRANSFORM_FEEDBACK_ATTRIBS_NV           = 0x8C7E
    TRANSFORM_FEEDBACK_BUFFER_MODE_NV       = 0x8C7F
    MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_NV   = 0x8C80
    ACTIVE_VARYINGS_NV              = 0x8C81
    ACTIVE_VARYING_MAX_LENGTH_NV            = 0x8C82
    TRANSFORM_FEEDBACK_VARYINGS_NV          = 0x8C83
    TRANSFORM_FEEDBACK_BUFFER_START_NV      = 0x8C84
    TRANSFORM_FEEDBACK_BUFFER_SIZE_NV       = 0x8C85
    TRANSFORM_FEEDBACK_RECORD_NV            = 0x8C86
    PRIMITIVES_GENERATED_NV             = 0x8C87
    TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV    = 0x8C88
    RASTERIZER_DISCARD_NV               = 0x8C89
    MAX_TRANSFORM_FEEDBACK_INTERLEAVED_ATTRIBS_NV   = 0x8C8A
    MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_NV  = 0x8C8B
    INTERLEAVED_ATTRIBS_NV              = 0x8C8C
    SEPARATE_ATTRIBS_NV             = 0x8C8D
    TRANSFORM_FEEDBACK_BUFFER_NV            = 0x8C8E
    TRANSFORM_FEEDBACK_BUFFER_BINDING_NV        = 0x8C8F

###############################################################################

# Extension #342
EXT_bindable_uniform enum:
    MAX_VERTEX_BINDABLE_UNIFORMS_EXT        = 0x8DE2
    MAX_FRAGMENT_BINDABLE_UNIFORMS_EXT      = 0x8DE3
    MAX_GEOMETRY_BINDABLE_UNIFORMS_EXT      = 0x8DE4
    MAX_BINDABLE_UNIFORM_SIZE_EXT           = 0x8DED
    UNIFORM_BUFFER_EXT              = 0x8DEE
    UNIFORM_BUFFER_BINDING_EXT          = 0x8DEF

###############################################################################

# Extension #343
EXT_texture_integer enum:
    RGBA32UI_EXT                    = 0x8D70
    RGB32UI_EXT                 = 0x8D71
    ALPHA32UI_EXT                   = 0x8D72
    INTENSITY32UI_EXT               = 0x8D73
    LUMINANCE32UI_EXT               = 0x8D74
    LUMINANCE_ALPHA32UI_EXT             = 0x8D75
    RGBA16UI_EXT                    = 0x8D76
    RGB16UI_EXT                 = 0x8D77
    ALPHA16UI_EXT                   = 0x8D78
    INTENSITY16UI_EXT               = 0x8D79
    LUMINANCE16UI_EXT               = 0x8D7A
    LUMINANCE_ALPHA16UI_EXT             = 0x8D7B
    RGBA8UI_EXT                 = 0x8D7C
    RGB8UI_EXT                  = 0x8D7D
    ALPHA8UI_EXT                    = 0x8D7E
    INTENSITY8UI_EXT                = 0x8D7F
    LUMINANCE8UI_EXT                = 0x8D80
    LUMINANCE_ALPHA8UI_EXT              = 0x8D81
    RGBA32I_EXT                 = 0x8D82
    RGB32I_EXT                  = 0x8D83
    ALPHA32I_EXT                    = 0x8D84
    INTENSITY32I_EXT                = 0x8D85
    LUMINANCE32I_EXT                = 0x8D86
    LUMINANCE_ALPHA32I_EXT              = 0x8D87
    RGBA16I_EXT                 = 0x8D88
    RGB16I_EXT                  = 0x8D89
    ALPHA16I_EXT                    = 0x8D8A
    INTENSITY16I_EXT                = 0x8D8B
    LUMINANCE16I_EXT                = 0x8D8C
    LUMINANCE_ALPHA16I_EXT              = 0x8D8D
    RGBA8I_EXT                  = 0x8D8E
    RGB8I_EXT                   = 0x8D8F
    ALPHA8I_EXT                 = 0x8D90
    INTENSITY8I_EXT                 = 0x8D91
    LUMINANCE8I_EXT                 = 0x8D92
    LUMINANCE_ALPHA8I_EXT               = 0x8D93
    RED_INTEGER_EXT                 = 0x8D94
    GREEN_INTEGER_EXT               = 0x8D95
    BLUE_INTEGER_EXT                = 0x8D96
    ALPHA_INTEGER_EXT               = 0x8D97
    RGB_INTEGER_EXT                 = 0x8D98
    RGBA_INTEGER_EXT                = 0x8D99
    BGR_INTEGER_EXT                 = 0x8D9A
    BGRA_INTEGER_EXT                = 0x8D9B
    LUMINANCE_INTEGER_EXT               = 0x8D9C
    LUMINANCE_ALPHA_INTEGER_EXT         = 0x8D9D
    RGBA_INTEGER_MODE_EXT               = 0x8D9E

###############################################################################

# Extension #344 - GLX_EXT_texture_from_pixmap

###############################################################################

# No new tokens
# Extension #345
GREMEDY_frame_terminator enum:

###############################################################################

# Extension #346
NV_conditional_render enum:
    QUERY_WAIT_NV                   = 0x8E13
    QUERY_NO_WAIT_NV                = 0x8E14
    QUERY_BY_REGION_WAIT_NV             = 0x8E15
    QUERY_BY_REGION_NO_WAIT_NV          = 0x8E16

###############################################################################

# Extension #347
NV_present_video enum:
    FRAME_NV                    = 0x8E26
    FIELDS_NV                   = 0x8E27
    CURRENT_TIME_NV                 = 0x8E28
    NUM_FILL_STREAMS_NV             = 0x8E29
    PRESENT_TIME_NV                 = 0x8E2A
    PRESENT_DURATION_NV             = 0x8E2B

###############################################################################

# Extension #348 - GLX_NV_video_out
# Extension #349 - WGL_NV_video_out
# Extension #350 - GLX_NV_swap_group
# Extension #351 - WGL_NV_swap_group

###############################################################################

# Extension #352
EXT_transform_feedback enum:
    TRANSFORM_FEEDBACK_BUFFER_EXT           = 0x8C8E
    TRANSFORM_FEEDBACK_BUFFER_START_EXT     = 0x8C84
    TRANSFORM_FEEDBACK_BUFFER_SIZE_EXT      = 0x8C85
    TRANSFORM_FEEDBACK_BUFFER_BINDING_EXT       = 0x8C8F
    INTERLEAVED_ATTRIBS_EXT             = 0x8C8C
    SEPARATE_ATTRIBS_EXT                = 0x8C8D
    PRIMITIVES_GENERATED_EXT            = 0x8C87
    TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_EXT   = 0x8C88
    RASTERIZER_DISCARD_EXT              = 0x8C89
    MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_EXT = 0x8C8A
    MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_EXT = 0x8C8B
    MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_EXT  = 0x8C80
    TRANSFORM_FEEDBACK_VARYINGS_EXT         = 0x8C83
    TRANSFORM_FEEDBACK_BUFFER_MODE_EXT      = 0x8C7F
    TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH_EXT   = 0x8C76

###############################################################################

# Extension #353
EXT_direct_state_access enum:
    PROGRAM_MATRIX_EXT              = 0x8E2D
    TRANSPOSE_PROGRAM_MATRIX_EXT            = 0x8E2E
    PROGRAM_MATRIX_STACK_DEPTH_EXT          = 0x8E2F

###############################################################################

# Extension #354
EXT_vertex_array_bgra enum:
    use VERSION_1_2             BGRA

###############################################################################

# Extension #355 - WGL_NV_gpu_affinity

###############################################################################

# Extension #356
EXT_texture_swizzle enum:
    TEXTURE_SWIZZLE_R_EXT               = 0x8E42
    TEXTURE_SWIZZLE_G_EXT               = 0x8E43
    TEXTURE_SWIZZLE_B_EXT               = 0x8E44
    TEXTURE_SWIZZLE_A_EXT               = 0x8E45
    TEXTURE_SWIZZLE_RGBA_EXT            = 0x8E46

###############################################################################

# Extension #357
NV_explicit_multisample enum:
    SAMPLE_POSITION_NV              = 0x8E50
    SAMPLE_MASK_NV                  = 0x8E51
    SAMPLE_MASK_VALUE_NV                = 0x8E52
    TEXTURE_BINDING_RENDERBUFFER_NV         = 0x8E53
    TEXTURE_RENDERBUFFER_DATA_STORE_BINDING_NV  = 0x8E54
    TEXTURE_RENDERBUFFER_NV             = 0x8E55
    SAMPLER_RENDERBUFFER_NV             = 0x8E56
    INT_SAMPLER_RENDERBUFFER_NV         = 0x8E57
    UNSIGNED_INT_SAMPLER_RENDERBUFFER_NV        = 0x8E58
    MAX_SAMPLE_MASK_WORDS_NV            = 0x8E59

###############################################################################

# Extension #358
NV_transform_feedback2 enum:
    TRANSFORM_FEEDBACK_NV               = 0x8E22
    TRANSFORM_FEEDBACK_BUFFER_PAUSED_NV     = 0x8E23
    TRANSFORM_FEEDBACK_BUFFER_ACTIVE_NV     = 0x8E24
    TRANSFORM_FEEDBACK_BINDING_NV           = 0x8E25

###############################################################################

# Extension #359
ATI_meminfo enum:
    VBO_FREE_MEMORY_ATI             = 0x87FB
    TEXTURE_FREE_MEMORY_ATI             = 0x87FC
    RENDERBUFFER_FREE_MEMORY_ATI            = 0x87FD

###############################################################################

# Extension #360
AMD_performance_monitor enum:
    COUNTER_TYPE_AMD                = 0x8BC0
    COUNTER_RANGE_AMD               = 0x8BC1
    UNSIGNED_INT64_AMD              = 0x8BC2
    PERCENTAGE_AMD                  = 0x8BC3
    PERFMON_RESULT_AVAILABLE_AMD            = 0x8BC4
    PERFMON_RESULT_SIZE_AMD             = 0x8BC5
    PERFMON_RESULT_AMD              = 0x8BC6

###############################################################################

# Extension #361 - WGL_AMD_gpu_association

###############################################################################

# No new tokens
# Extension #362
AMD_texture_texture4 enum:

###############################################################################

# Extension #363
AMD_vertex_shader_tesselator enum:
    SAMPLER_BUFFER_AMD              = 0x9001
    INT_SAMPLER_BUFFER_AMD              = 0x9002
    UNSIGNED_INT_SAMPLER_BUFFER_AMD         = 0x9003
    TESSELLATION_MODE_AMD               = 0x9004
    TESSELLATION_FACTOR_AMD             = 0x9005
    DISCRETE_AMD                    = 0x9006
    CONTINUOUS_AMD                  = 0x9007

###############################################################################

# Extension #364
EXT_provoking_vertex enum:
    QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION_EXT    = 0x8E4C
    FIRST_VERTEX_CONVENTION_EXT         = 0x8E4D
    LAST_VERTEX_CONVENTION_EXT          = 0x8E4E
    PROVOKING_VERTEX_EXT                = 0x8E4F

###############################################################################

# Extension #365
EXT_texture_snorm enum:
    ALPHA_SNORM                 = 0x9010
    LUMINANCE_SNORM                 = 0x9011
    LUMINANCE_ALPHA_SNORM               = 0x9012
    INTENSITY_SNORM                 = 0x9013
    ALPHA8_SNORM                    = 0x9014
    LUMINANCE8_SNORM                = 0x9015
    LUMINANCE8_ALPHA8_SNORM             = 0x9016
    INTENSITY8_SNORM                = 0x9017
    ALPHA16_SNORM                   = 0x9018
    LUMINANCE16_SNORM               = 0x9019
    LUMINANCE16_ALPHA16_SNORM           = 0x901A
    INTENSITY16_SNORM               = 0x901B
    use VERSION_3_1             RED_SNORM
    use VERSION_3_1             RG_SNORM
    use VERSION_3_1             RGB_SNORM
    use VERSION_3_1             RGBA_SNORM
    use VERSION_3_1             R8_SNORM
    use VERSION_3_1             RG8_SNORM
    use VERSION_3_1             RGB8_SNORM
    use VERSION_3_1             RGBA8_SNORM
    use VERSION_3_1             R16_SNORM
    use VERSION_3_1             RG16_SNORM
    use VERSION_3_1             RGB16_SNORM
    use VERSION_3_1             RGBA16_SNORM
    use VERSION_3_1             SIGNED_NORMALIZED

###############################################################################



###############################################################################



###############################################################################



























#------------------------------------------------------------------------------
#
# OpenTK edits for type safety
#
#------------------------------------------------------------------------------


# Version 1.1

ArrayCap enum:
	use GetPName VERTEX_ARRAY
	use GetPName NORMAL_ARRAY
	use GetPName COLOR_ARRAY
	SECONDARY_COLOR_ARRAY               = 0x845E # 1 I
	use GetPName INDEX_ARRAY
	use GetPName EDGE_FLAG_ARRAY
	use GetPName TEXTURE_COORD_ARRAY
	FOG_COORD_ARRAY				= 0x8457
	

# Version 1.2


# Light Model (http://www.opengl.org/sdk/docs/man/xhtml/glLightModel.xml)
LightModelParameter enum:
	LIGHT_MODEL_COLOR_CONTROL		= 0x81F8 # 1 I

LightModelColorControl enum:
	SINGLE_COLOR					= 0x81F9
	SEPARATE_SPECULAR_COLOR			= 0x81FA
	
GetPName enum:
	LIGHT_MODEL_COLOR_CONTROL		= 0x81F8
	
# Rescale Normal (http://www.opengl.org/registry/specs/EXT/rescale_normal.txt)
EnableCap enum:
	RESCALE_NORMAL				= 0x803A # 1 I # Equivalent to EXT_rescale_normal

# Draw Range Elements (http://www.opengl.org/sdk/docs/man/xhtml/glGet.xml)
GetPName enum:
	MAX_ELEMENTS_VERTICES			= 0x80E8
	MAX_ELEMENTS_INDICES			= 0x80E9

# 3d textures (http://www.opengl.org/sdk/docs/man/xhtml/glTexImage3D.xml)
# http://www.opengl.org/sdk/docs/man/xhtml/glPixelStore.xml
TextureTarget enum:
	TEXTURE_3D					= 0x806F # 1 I
	PROXY_TEXTURE_3D			= 0x8070
	
PixelType enum:
	UNSIGNED_BYTE_3_3_2			= 0x8032 # Equivalent to EXT_packed_pixels
	UNSIGNED_SHORT_4_4_4_4		= 0x8033
	UNSIGNED_SHORT_5_5_5_1		= 0x8034
	UNSIGNED_INT_8_8_8_8		= 0x8035
	UNSIGNED_INT_10_10_10_2		= 0x8036
	UNSIGNED_BYTE_2_3_3_REVERSED	= 0x8362 # New for OpenGL 1.2
	UNSIGNED_SHORT_5_6_5		= 0x8363
	UNSIGNED_SHORT_5_6_5_REVERSED	= 0x8364
	UNSIGNED_SHORT_4_4_4_4_REVERSED	= 0x8365
	UNSIGNED_SHORT_1_5_5_5_REVERSED	= 0x8366
	UNSIGNED_INT_8_8_8_8_REVERSED	= 0x8367
	UNSIGNED_INT_2_10_10_10_REVERSED	= 0x8368

PixelFormat enum:
	BGR							= 0x80E0
	BGRA						= 0x80E1

GetPName enum:
	TEXTURE_BINDING_3D			= 0x806A # 1 I
	SMOOTH_POINT_SIZE_RANGE		= 0x0B12 # 2 F
	SMOOTH_POINT_SIZE_GRANULARITY	= 0x0B13 # 1 F
	SMOOTH_LINE_WIDTH_RANGE		= 0x0B22 # 2 F
	SMOOTH_LINE_WIDTH_GRANULARITY	= 0x0B23 # 1 F
	ALIASED_POINT_SIZE_RANGE	= 0x846D # 2 F
	ALIASED_LINE_WIDTH_RANGE	= 0x846E # 2 F
	MAX_3D_TEXTURE_SIZE			= 0x8073 # 1 I

GetTextureParameter enum:
	TEXTURE_MIN_LOD					= 0x813A # Equivalent to SGIS_texture_lod
	TEXTURE_MAX_LOD					= 0x813B
	TEXTURE_BASE_LEVEL				= 0x813C
	TEXTURE_MAX_LEVEL				= 0x813D
	TEXTURE_DEPTH					= 0x8071
	TEXTURE_WRAP_R					= 0x8072
	
TextureParameterName enum:
	CLAMP_TO_EDGE					= 0x812F # Equivalent to SGIS_texture_edge_clamp
	use GetTextureParameter TEXTURE_MIN_LOD
	use GetTextureParameter TEXTURE_MAX_LOD
	use GetTextureParameter TEXTURE_BASE_LEVEL
	use GetTextureParameter TEXTURE_MAX_LEVEL
	use GetTextureParameter TEXTURE_DEPTH
	use GetTextureParameter TEXTURE_WRAP_R

TextureWrapMode enum:
	CLAMP_TO_EDGE					= 0x812F # Equivalent to SGIS_texture_edge_clamp

PixelStoreParameter enum:
	PACK_SKIP_IMAGES				= 0x806B # 1 I
	PACK_IMAGE_HEIGHT				= 0x806C # 1 F
	UNPACK_SKIP_IMAGES				= 0x806D # 1 I
	UNPACK_IMAGE_HEIGHT				= 0x806E # 1 F
	
MatrixMode enum:
	use PixelCopyType COLOR		# <summary>Supported by the ARB_imaging extension</summary>
	
BlendEquationMode enum:
	FUNC_ADD					= 0x8006 # Equivalent to EXT_blend_minmax
	MIN							= 0x8007
	MAX							= 0x8008
	FUNC_SUBTRACT				= 0x800A # Equivalent to EXT_blend_subtract
	FUNC_REVERSE_SUBTRACT		= 0x800B

# Promoted from EXT_blend_color (pg. 178 of GL3.1 spec).
BlendingFactorDest enum:
	CONSTANT_COLOR										= 0x8001
	ONE_MINUS_CONSTANT_COLOR			= 0x8002
	CONSTANT_ALPHA										= 0x8003
	ONE_MINUS_CONSTANT_ALPHA			= 0x8004

BlendingFactorSrc enum:
	CONSTANT_COLOR										= 0x8001
	ONE_MINUS_CONSTANT_COLOR			= 0x8002
	CONSTANT_ALPHA										= 0x8003
	ONE_MINUS_CONSTANT_ALPHA			= 0x8004

# Promoted from SGI_color_table
ColorTableTarget enum:
	COLOR_TABLE                 = 0x80D0 # 1 I # Equivalent to SGI_color_table
    POST_CONVOLUTION_COLOR_TABLE            = 0x80D1 # 1 I
    POST_COLOR_MATRIX_COLOR_TABLE           = 0x80D2 # 1 I
    PROXY_COLOR_TABLE               = 0x80D3
    PROXY_POST_CONVOLUTION_COLOR_TABLE      = 0x80D4
    PROXY_POST_COLOR_MATRIX_COLOR_TABLE     = 0x80D5

ColorTableParameterPName enum:
	COLOR_TABLE_SCALE               = 0x80D6
    COLOR_TABLE_BIAS                = 0x80D7
	
GetColorTableParameterPName enum:
	COLOR_TABLE_SCALE               = 0x80D6
    COLOR_TABLE_BIAS                = 0x80D7
    COLOR_TABLE_FORMAT              = 0x80D8
    COLOR_TABLE_WIDTH               = 0x80D9
    COLOR_TABLE_RED_SIZE                = 0x80DA
    COLOR_TABLE_GREEN_SIZE              = 0x80DB
    COLOR_TABLE_BLUE_SIZE               = 0x80DC
    COLOR_TABLE_ALPHA_SIZE              = 0x80DD
    COLOR_TABLE_LUMINANCE_SIZE          = 0x80DE
    COLOR_TABLE_INTENSITY_SIZE          = 0x80DF
	
EnableCap enum:
	COLOR_TABLE                 = 0x80D0
	POST_CONVOLUTION_COLOR_TABLE            = 0x80D1
	POST_COLOR_MATRIX_COLOR_TABLE           = 0x80D2

# Promoted from EXT_convolution
ConvolutionParameter enum:
    CONVOLUTION_BORDER_MODE             = 0x8013
    CONVOLUTION_FILTER_SCALE            = 0x8014
    CONVOLUTION_FILTER_BIAS             = 0x8015
    
ConvolutionParameterValue enum:
	REDUCE                      = 0x8016
	CONSTANT_BORDER                 = 0x8151
    REPLICATE_BORDER                = 0x8153

ConvolutionTarget enum:
    CONVOLUTION_1D                  = 0x8010 # 1 I # Equivalent to EXT_convolution
    CONVOLUTION_2D                  = 0x8011 # 1 I
    SEPARABLE_2D                          = 0x8012
    
GetConvolutionParameterPName enum:
    CONVOLUTION_BORDER_MODE             = 0x8013
    CONVOLUTION_BORDER_COLOR            = 0x8154
    CONVOLUTION_FILTER_SCALE            = 0x8014
    CONVOLUTION_FILTER_BIAS             = 0x8015
    CONVOLUTION_FORMAT              = 0x8017
    CONVOLUTION_WIDTH               = 0x8018
    CONVOLUTION_HEIGHT              = 0x8019
    MAX_CONVOLUTION_WIDTH               = 0x801A
    MAX_CONVOLUTION_HEIGHT              = 0x801B
    
SeparableTarget enum:
    SEPARABLE_2D                    = 0x8012 # 1 I

EnableCap enum:
	CONVOLUTION_1D                  = 0x8010
    CONVOLUTION_2D                  = 0x8011
    SEPARABLE_2D                          = 0x8012
    
# Promoted from EXT_histogram
MinmaxTarget enum:
	MINMAX = 0x802E

GetMinmaxParameterPName enum:
	MINMAX_FORMAT                   = 0x802F
    MINMAX_SINK                 = 0x8030

HistogramTarget enum:
    HISTOGRAM                   = 0x8024 # 1 I # Equivalent to EXT_histogram
    PROXY_HISTOGRAM                 = 0x8025
    
GetHistogramParameterPName enum:
    HISTOGRAM_WIDTH                 = 0x8026
    HISTOGRAM_FORMAT                = 0x8027
    HISTOGRAM_RED_SIZE              = 0x8028
    HISTOGRAM_GREEN_SIZE                = 0x8029
    HISTOGRAM_BLUE_SIZE             = 0x802A
    HISTOGRAM_ALPHA_SIZE                = 0x802B
    HISTOGRAM_LUMINANCE_SIZE            = 0x802C
    HISTOGRAM_SINK                  = 0x802D

EnableCap enum:
    HISTOGRAM                   = 0x8024


# Version 1.3

# Texture Parameter (http://www.opengl.org/sdk/docs/man/xhtml/glTexParameter.xml)
TextureParameterName enum:
	CLAMP_TO_BORDER				= 0x812D	# Promoted from ARB_texture_border_clamp

TextureWrapMode enum:
	CLAMP_TO_BORDER				= 0x812D	# Promoted from ARB_texture_border_clamp

# Multisample (http://www.opengl.org/registry/specs/ARB/multisample.txt)
EnableCap enum:
	MULTISAMPLE					= 0x809D	# Promoted from ARB_multisample
	SAMPLE_ALPHA_TO_COVERAGE	= 0x809E
	SAMPLE_ALPHA_TO_ONE			= 0x809F
	SAMPLE_COVERAGE				= 0x80A0
	
GetPName enum:
	MULTISAMPLE					= 0x809D	# Promoted from ARB_multisample
	SAMPLE_ALPHA_TO_COVERAGE	= 0x809E
	SAMPLE_ALPHA_TO_ONE			= 0x809F
	SAMPLE_COVERAGE				= 0x80A0
	SAMPLE_BUFFERS				= 0x80A8
	SAMPLES						= 0x80A9
	SAMPLE_COVERAGE_VALUE		= 0x80AA
	SAMPLE_COVERAGE_INVERT		= 0x80AB

AttribMask enum:
	MULTISAMPLE_BIT				= 0x20000000

# Texture Environment Combine, Crossbar and Dot3
# http://www.opengl.org/sdk/docs/man/xhtml/glTexEnv.xml
# http://www.opengl.org/registry/specs/ARB/texture_env_combine.txt
# http://www.opengl.org/registry/specs/ARB/texture_env_crossbar.txt
# http://www.opengl.org/registry/specs/ARB/texture_env_dot3.txt
TextureEnvMode enum:
	COMBINE						= 0x8570	# Promoted from ARB_texture_env_combine

TextureEnvParameter enum:
	COMBINE_RGB					= 0x8571
	COMBINE_ALPHA				= 0x8572
	SOURCE0_RGB					= 0x8580
	SRC1_RGB					= 0x8581
	SRC2_RGB					= 0x8582
	SRC0_ALPHA					= 0x8588
	SRC1_ALPHA					= 0x8589
	SRC2_ALPHA					= 0x858A
	OPERAND0_RGB				= 0x8590
	OPERAND1_RGB				= 0x8591
	OPERAND2_RGB				= 0x8592
	OPERAND0_ALPHA				= 0x8598
	OPERAND1_ALPHA				= 0x8599
	OPERAND2_ALPHA				= 0x859A
	RGB_SCALE					= 0x8573
	use GetPName ALPHA_SCALE

# <summary>Accepted by GL.TexGen when the pname parameter value is CombineRgb or CombineAlpha.</summary>
TextureEnvModeCombine enum:
	use StencilOp  REPLACE
	use TextureEnvMode MODULATE
	use AccumOp    ADD
	ADD_SIGNED					= 0x8574
	INTERPOLATE					= 0x8575
	SUBTRACT					= 0x84E7
	DOT3_RGB					= 0x86AE	# Promoted from ARB_texture_env_dot3
	DOT3_RGBA					= 0x86AF

# <summary>Accepted by GL.TexGen when the pname parameter value is Source0Rgb, Source1Rgb, Source2Rgb, Source0Alpha, Source1Alpha, or Source2Alpha.</summary>
TextureEnvModeSource enum:
	use MatrixMode TEXTURE
	CONSTANT					= 0x8576
	PRIMARY_COLOR				= 0x8577
	PREVIOUS					= 0x8578
	TEXTURE0					= 0x84C0	# Promoted from ARB_multitexture
	TEXTURE1					= 0x84C1
	TEXTURE2					= 0x84C2
	TEXTURE3					= 0x84C3
	TEXTURE4					= 0x84C4
	TEXTURE5					= 0x84C5
	TEXTURE6					= 0x84C6
	TEXTURE7					= 0x84C7
	TEXTURE8					= 0x84C8
	TEXTURE9					= 0x84C9
	TEXTURE10					= 0x84CA
	TEXTURE11					= 0x84CB
	TEXTURE12					= 0x84CC
	TEXTURE13					= 0x84CD
	TEXTURE14					= 0x84CE
	TEXTURE15					= 0x84CF
	TEXTURE16					= 0x84D0
	TEXTURE17					= 0x84D1
	TEXTURE18					= 0x84D2
	TEXTURE19					= 0x84D3
	TEXTURE20					= 0x84D4
	TEXTURE21					= 0x84D5
	TEXTURE22					= 0x84D6
	TEXTURE23					= 0x84D7
	TEXTURE24					= 0x84D8
	TEXTURE25					= 0x84D9
	TEXTURE26					= 0x84DA
	TEXTURE27					= 0x84DB
	TEXTURE28					= 0x84DC
	TEXTURE29					= 0x84DD
	TEXTURE30					= 0x84DE
	TEXTURE31					= 0x84DF

# <summary>Accepted by GL.TexGen when the pname parameter value is Operand0Rgb, Operand1Rgb, or Operand2Rgb.</summary>
TextureEnvModeOperandRgb enum:
	use BlendingFactorDest SRC_COLOR
	use BlendingFactorDest ONE_MINUS_SRC_COLOR
	use BlendingFactorDest SRC_ALPHA
	use BlendingFactorDest ONE_MINUS_SRC_ALPHA

# <summary>Accepted by GL.TexGen when the pname parameter value is Operand0Alpha, Operand1Alpha, or Operand2Alpha.</summary>
TextureEnvModeOperandAlpha enum:
	use BlendingFactorDest SRC_ALPHA
	use BlendingFactorDest ONE_MINUS_SRC_ALPHA
	
# <summary>Accepted by GL.TexGen when the pname parameter value is RgbScale or AlphaScale.</summary>
TextureEnvModeScale enum:
	ONE							= 1
	TWO							= 2
	FOUR						= 4

# Transpose Matrix (http://www.opengl.org/registry/specs/ARB/transpose_matrix.txt)
GetPName enum:
	TRANSPOSE_MODELVIEW_MATRIX			= 0x84E3 # 16 F # Promoted from ARB_transpose_matrix
	TRANSPOSE_PROJECTION_MATRIX			= 0x84E4 # 16 F
	TRANSPOSE_TEXTURE_MATRIX			= 0x84E5 # 16 F
	TRANSPOSE_COLOR_MATRIX				= 0x84E6 # 16 F
	
# Cube Maps (http://www.opengl.org/registry/specs/ARB/texture_cube_map.txt)
TextureGenMode enum:
	NORMAL_MAP							= 0x8511	# Promoted from ARB_texture_cube_map
	REFLECTION_MAP						= 0x8512

EnableCap enum:
	TEXTURE_CUBE_MAP					= 0x8513
	
TextureTarget enum:
	TEXTURE_CUBE_MAP					= 0x8513
	TEXTURE_BINDING_CUBE_MAP			= 0x8514
	TEXTURE_CUBE_MAP_POSITIVE_X			= 0x8515
	TEXTURE_CUBE_MAP_NEGATIVE_X			= 0x8516
	TEXTURE_CUBE_MAP_POSITIVE_Y			= 0x8517
	TEXTURE_CUBE_MAP_NEGATIVE_Y			= 0x8518
	TEXTURE_CUBE_MAP_POSITIVE_Z			= 0x8519
	TEXTURE_CUBE_MAP_NEGATIVE_Z			= 0x851A
	PROXY_TEXTURE_CUBE_MAP				= 0x851B

GetPName enum:
	TEXTURE_CUBE_MAP					= 0x8513
	TEXTURE_BINDING_CUBE_MAP			= 0x8514
	MAX_CUBE_MAP_TEXTURE_SIZE			= 0x851C
	
# Multitexture (http://www.opengl.org/documentation/specs/version1.2/opengl1.2.1.pdf)
GetPName enum:
	ACTIVE_TEXTURE					= 0x84E0 # 1 I
	CLIENT_ACTIVE_TEXTURE			= 0x84E1 # 1 I
	MAX_TEXTURE_UNITS				= 0x84E2 # 1 I

TextureUnit enum:
	TEXTURE0					= 0x84C0	# Promoted from ARB_multitexture
	TEXTURE1					= 0x84C1
	TEXTURE2					= 0x84C2
	TEXTURE3					= 0x84C3
	TEXTURE4					= 0x84C4
	TEXTURE5					= 0x84C5
	TEXTURE6					= 0x84C6
	TEXTURE7					= 0x84C7
	TEXTURE8					= 0x84C8
	TEXTURE9					= 0x84C9
	TEXTURE10					= 0x84CA
	TEXTURE11					= 0x84CB
	TEXTURE12					= 0x84CC
	TEXTURE13					= 0x84CD
	TEXTURE14					= 0x84CE
	TEXTURE15					= 0x84CF
	TEXTURE16					= 0x84D0
	TEXTURE17					= 0x84D1
	TEXTURE18					= 0x84D2
	TEXTURE19					= 0x84D3
	TEXTURE20					= 0x84D4
	TEXTURE21					= 0x84D5
	TEXTURE22					= 0x84D6
	TEXTURE23					= 0x84D7
	TEXTURE24					= 0x84D8
	TEXTURE25					= 0x84D9
	TEXTURE26					= 0x84DA
	TEXTURE27					= 0x84DB
	TEXTURE28					= 0x84DC
	TEXTURE29					= 0x84DD
	TEXTURE30					= 0x84DE
	TEXTURE31					= 0x84DF
	
# Compressed Textures (http://www.opengl.org/registry/specs/ARB/texture_compression.txt)
PixelInternalFormat enum:
	COMPRESSED_ALPHA			= 0x84E9	# Promoted from ARB_texture_compression
	COMPRESSED_LUMINANCE		= 0x84EA
	COMPRESSED_LUMINANCE_ALPHA	= 0x84EB
	COMPRESSED_INTENSITY		= 0x84EC
	COMPRESSED_RGB				= 0x84ED
	COMPRESSED_RGBA				= 0x84EE
	
# Tokens from EXT_texture_compression_s3tc enum:
    COMPRESSED_RGB_S3TC_DXT1_EXT            = 0x83F0
    COMPRESSED_RGBA_S3TC_DXT1_EXT           = 0x83F1
    COMPRESSED_RGBA_S3TC_DXT3_EXT           = 0x83F2
    COMPRESSED_RGBA_S3TC_DXT5_EXT           = 0x83F3

HintTarget enum:
	TEXTURE_COMPRESSION_HINT	= 0x84EF
	
GetTextureParameter enum:
	TEXTURE_COMPRESSED_IMAGE_SIZE	= 0x86A0
	TEXTURE_COMPRESSED			= 0x86A1
	
GetPName enum:
	TEXTURE_COMPRESSION_HINT	= 0x84EF
	NUM_COMPRESSED_TEXTURE_FORMATS	= 0x86A2
	COMPRESSED_TEXTURE_FORMATS	= 0x86A3


# Version 1.4

# Generate Mipmap (http://www.opengl.org/registry/specs/SGIS/generate_mipmap.txt)
TextureParameterName enum:
	GENERATE_MIPMAP				= 0x8191
	
GetPName enum:
	GENERATE_MIPMAP_HINT		= 0x8192 # 1 I
	
GetTextureParameter enum:
	GENERATE_MIPMAP				= 0x8191

HintTarget enum:
	GENERATE_MIPMAP_HINT		= 0x8192 # 1 I

# Stencil Wrap (http://www.opengl.org/registry/specs/EXT/stencil_wrap.txt)
StencilOp enum:
	INCR_WRAP					= 0x8507
	DECR_WRAP					= 0x8508	

# Texture LOD Bias (http://www.opengl.org/registry/specs/EXT/texture_lod_bias.txt)
TextureEnvTarget enum:
	TEXTURE_FILTER_CONTROL				= 0x8500
	
TextureEnvParameter enum:
	TEXTURE_LOD_BIAS				= 0x8501

GetPName enum:
	MAX_TEXTURE_LOD_BIAS				= 0x84FD

# Blendfunc Separate (http://www.opengl.org/registry/specs/EXT/blend_func_separate.txt)
GetPName enum:
	BLEND_DST_RGB					= 0x80C8
	BLEND_SRC_RGB					= 0x80C9
	BLEND_DST_ALPHA					= 0x80CA
	BLEND_SRC_ALPHA					= 0x80CB

# Texture Filter Control
TextureEnvTarget enum:
	TEXTURE_FILTER_CONTROL				= 0x8500

# Depth Texture
PixelInternalFormat enum:
    use PixelFormat DEPTH_COMPONENT
    DEPTH_COMPONENT16 = 0x81a5
    DEPTH_COMPONENT24 = 0x81a6
    DEPTH_COMPONENT32 = 0x81a7
    
GetTextureParameter enum:
    TEXTURE_DEPTH_SIZE				= 0x884A
    DEPTH_TEXTURE_MODE				= 0x884B
	
TextureParameterName enum:
    DEPTH_TEXTURE_MODE				= 0x884B
    
# Texture Wrap Mode
TextureWrapMode enum:
	MIRRORED_REPEAT					= 0x8370
	
# Shadow (http://opengl.org/registry/specs/ARB/shadow.txt)
TextureParameterName enum:
	TEXTURE_COMPARE_MODE				= 0x884C
	TEXTURE_COMPARE_FUNC				= 0x884D
	
GetTextureParameter enum:
	TEXTURE_COMPARE_MODE				= 0x884C
	TEXTURE_COMPARE_FUNC				= 0x884D
	
TextureCompareMode enum:
	COMPARE_R_TO_TEXTURE				= 0x884E

# Shadow Ambient (http://opengl.org/registry/specs/ARB/shadow_ambient.txt)
TextureParameterName enum:
	TEXTURE_COMPARE_FAIL_VALUE			= 0x80BF

# Fog (http://www.opengl.org/registry/specs/EXT/fog_coord.txt)
FogPointerType enum:
	use DataType FLOAT
	use DataType DOUBLE

FogParameter enum:
	FOG_COORD_SRC = 0x8450

FogMode enum:
	FOG_COORD					= 0x8451
	FRAGMENT_DEPTH				= 0x8452

GetPName enum:
	CURRENT_FOG_COORD			= 0x8453
	FOG_COORD_ARRAY_TYPE		= 0x8454
	FOG_COORD_ARRAY_STRIDE		= 0x8455

GetPointervPName enum:
	FOG_COORD_ARRAY_POINTER		= 0x8456

EnableCap enum:
	FOG_COORD_ARRAY				= 0x8457
	
# Secondary Color (http://www.opengl.org/registry/specs/EXT/secondary_color.txt)
EnableCap enum:
	COLOR_SUM					= 0x8458
	SECONDARY_COLOR_ARRAY		= 0x845E
	
GetPName enum:
	COLOR_SUM					= 0x8458
	CURRENT_SECONDARY_COLOR		= 0x8459
	SECONDARY_COLOR_ARRAY_SIZE	= 0x845A
	SECONDARY_COLOR_ARRAY_TYPE	= 0x845B
	SECONDARY_COLOR_ARRAY_STRIDE = 0x845C
	
GetPointervPName enum:
	SECONDARY_COLOR_ARRAY_POINTER			= 0x845D
	
# Point Parameters (http://www.opengl.org/registry/specs/ARB/point_parameters.txt)
PointParameterName enum:
	POINT_SIZE_MIN					= 0x8126
	POINT_SIZE_MAX					= 0x8127
	POINT_FADE_THRESHOLD_SIZE		= 0x8128
	# <summary>this token is only accepted by GL.PointParameterv not GL.PointParameter</summary>
	POINT_DISTANCE_ATTENUATION		= 0x8129

GetPName enum:
	POINT_SIZE_MIN					= 0x8126
	POINT_SIZE_MAX					= 0x8127
	POINT_FADE_THRESHOLD_SIZE		= 0x8128
	# <summary>this token is only accepted by GL.PointParameterv not GL.PointParameter</summary>
	POINT_DISTANCE_ATTENUATION		= 0x8129

# Version 1.5

# Occlusion Query
QueryTarget enum:
	SAMPLES_PASSED				= 0x8914

GetQueryParam enum:
	QUERY_COUNTER_BITS			= 0x8864
	CURRENT_QUERY				= 0x8865
	
GetQueryObjectParam enum:
    QUERY_RESULT				= 0x8866
	QUERY_RESULT_AVAILABLE		= 0x8867


# Buffer Objects (http://www.opengl.org/sdk/docs/man/xhtml/glBindBuffer.xml)
BufferTarget enum:
	ARRAY_BUFFER				= 0x8892 # ARB_vertex_buffer_object
	ELEMENT_ARRAY_BUFFER		= 0x8893 # ARB_vertex_buffer_object

BufferUsageHint enum:
	STREAM_DRAW					= 0x88E0 # ARB_vertex_buffer_object
	STREAM_READ					= 0x88E1 # ARB_vertex_buffer_object
	STREAM_COPY					= 0x88E2 # ARB_vertex_buffer_object
	STATIC_DRAW					= 0x88E4 # ARB_vertex_buffer_object
	STATIC_READ					= 0x88E5 # ARB_vertex_buffer_object
	STATIC_COPY					= 0x88E6 # ARB_vertex_buffer_object
	DYNAMIC_DRAW				= 0x88E8 # ARB_vertex_buffer_object
	DYNAMIC_READ				= 0x88E9 # ARB_vertex_buffer_object
	DYNAMIC_COPY				= 0x88EA # ARB_vertex_buffer_object
	
BufferAccess enum:
	READ_ONLY					= 0x88B8 # ARB_vertex_buffer_object
	WRITE_ONLY					= 0x88B9 # ARB_vertex_buffer_object
	READ_WRITE					= 0x88BA # ARB_vertex_buffer_object
	
BufferParameterName enum:
	BUFFER_SIZE					= 0x8764 # ARB_vertex_buffer_object
	BUFFER_USAGE				= 0x8765 # ARB_vertex_buffer_object
	BUFFER_ACCESS				= 0x88BB # ARB_vertex_buffer_object
	BUFFER_MAPPED				= 0x88BC # ARB_vertex_buffer_object

BufferPointer enum:
	BUFFER_MAP_POINTER			= 0x88BD # ARB_vertex_buffer_object

GetPName enum:
	ARRAY_BUFFER_BINDING				= 0x8894 # ARB_vertex_buffer_object
	ELEMENT_ARRAY_BUFFER_BINDING		= 0x8895 # ARB_vertex_buffer_object
	VERTEX_ARRAY_BUFFER_BINDING			= 0x8896 # ARB_vertex_buffer_object
	NORMAL_ARRAY_BUFFER_BINDING			= 0x8897 # ARB_vertex_buffer_object
	COLOR_ARRAY_BUFFER_BINDING			= 0x8898 # ARB_vertex_buffer_object
	INDEX_ARRAY_BUFFER_BINDING			= 0x8899 # ARB_vertex_buffer_object
	TEXTURE_COORD_ARRAY_BUFFER_BINDING	= 0x889A # ARB_vertex_buffer_object
	EDGE_FLAG_ARRAY_BUFFER_BINDING		= 0x889B # ARB_vertex_buffer_object
	SECONDARY_COLOR_ARRAY_BUFFER_BINDING	= 0x889C # ARB_vertex_buffer_object
	FOG_COORD_ARRAY_BUFFER_BINDING		= 0x889D # ARB_vertex_buffer_object
	WEIGHT_ARRAY_BUFFER_BINDING			= 0x889E # ARB_vertex_buffer_object
	VERTEX_ATTRIB_ARRAY_BUFFER_BINDING	= 0x889F # ARB_vertex_buffer_object


# Version 2.0

# Two Side Stencil
# http://www.opengl.org/sdk/docs/man/xhtml/glStencilFuncSeparate.xml
# http://www.opengl.org/sdk/docs/man/xhtml/glStencilMaskSeparate.xml
# http://www.opengl.org/sdk/docs/man/xhtml/glStencilOpSeparate.xml
GetPName enum:
	STENCIL_BACK_FUNC				= 0x8800    # ARB_stencil_two_side
	STENCIL_BACK_FAIL				= 0x8801    # ARB_stencil_two_side
	STENCIL_BACK_PASS_DEPTH_FAIL	= 0x8802    # ARB_stencil_two_side
	STENCIL_BACK_PASS_DEPTH_PASS	= 0x8803    # ARB_stencil_two_side
	STENCIL_BACK_REF				= 0x8CA3    # ARB_stencil_two_side
	STENCIL_BACK_VALUE_MASK			= 0x8CA4    # ARB_stencil_two_side
	STENCIL_BACK_WRITEMASK			= 0x8CA5    # ARB_stencil_two_side

# Blend equation separate (http://www.opengl.org/registry/specs/EXT/blend_equation_separate.txt)
GetPName enum:
	BLEND_EQUATION_RGB				= 0x8009    # EXT_blend_equation_separate
	BLEND_EQUATION_ALPHA			= 0x883D    # EXT_blend_equation_separate

# Shader Objects
# http://www.opengl.org/sdk/docs/man/xhtml/glCreateShader.xml
# http://www.opengl.org/sdk/docs/man/xhtml/glGetActiveUniform.xml
ShaderType enum:
	FRAGMENT_SHADER					= 0x8B30    # ARB_fragment_shader
	VERTEX_SHADER					= 0x8B31    # ARB_vertex_shader
	GEOMETRY_SHADER_EXT				= 0x8DD9	# EXT_geometry_shader4 -- not core

EnableCap enum:
	VERTEX_PROGRAM_POINT_SIZE		= 0x8642    # ARB_vertex_shader
	VERTEX_PROGRAM_TWO_SIDE			= 0x8643    # ARB_vertex_shader

GetPName enum:
	FRAGMENT_SHADER_DERIVATIVE_HINT	= 0x8B8B    # ARB_fragment_shader
	MAX_FRAGMENT_UNIFORM_COMPONENTS	= 0x8B49    # ARB_fragment_shader
	MAX_VERTEX_UNIFORM_COMPONENTS	= 0x8B4A    # ARB_vertex_shader
	MAX_VARYING_FLOATS				= 0x8B4B    # ARB_vertex_shader
	MAX_VERTEX_TEXTURE_IMAGE_UNITS	= 0x8B4C    # ARB_vertex_shader
	MAX_COMBINED_TEXTURE_IMAGE_UNITS	= 0x8B4D    # ARB_vertex_shader
	MAX_TEXTURE_COORDS				= 0x8871    # ARB_vertex_shader, ARB_fragment_shader
	MAX_TEXTURE_IMAGE_UNITS			= 0x8872    # ARB_vertex_shader, ARB_fragment_shader
	MAX_VERTEX_ATTRIBS				= 0x8869    # ARB_vertex_shader
	CURRENT_PROGRAM					= 0x8B8D    # ARB_shader_objects (added for 2.0)
	
HintTarget enum:
	FRAGMENT_SHADER_DERIVATIVE_HINT	= 0x8B8B    # ARB_fragment_shader

ActiveUniformType enum:
	use DataType FLOAT
	FLOAT_VEC2					= 0x8B50    # ARB_shader_objects
	FLOAT_VEC3					= 0x8B51    # ARB_shader_objects
	FLOAT_VEC4					= 0x8B52    # ARB_shader_objects
	use DataType INT
	INT_VEC2					= 0x8B53    # ARB_shader_objects
	INT_VEC3					= 0x8B54    # ARB_shader_objects
	INT_VEC4					= 0x8B55    # ARB_shader_objects
	BOOL						= 0x8B56    # ARB_shader_objects
	BOOL_VEC2					= 0x8B57    # ARB_shader_objects
	BOOL_VEC3					= 0x8B58    # ARB_shader_objects
	BOOL_VEC4					= 0x8B59    # ARB_shader_objects
	FLOAT_MAT2					= 0x8B5A    # ARB_shader_objects
	FLOAT_MAT3					= 0x8B5B    # ARB_shader_objects
	FLOAT_MAT4					= 0x8B5C    # ARB_shader_objects
	SAMPLER_1D					= 0x8B5D    # ARB_shader_objects
	SAMPLER_2D					= 0x8B5E    # ARB_shader_objects
	SAMPLER_3D					= 0x8B5F    # ARB_shader_objects
	SAMPLER_CUBE				= 0x8B60    # ARB_shader_objects
	SAMPLER_1D_SHADOW			= 0x8B61    # ARB_shader_objects
	SAMPLER_2D_SHADOW			= 0x8B62    # ARB_shader_objects
	
ActiveAttribType enum:
	use DataType FLOAT
	FLOAT_VEC2					= 0x8B50    # ARB_shader_objects
	FLOAT_VEC3					= 0x8B51    # ARB_shader_objects
	FLOAT_VEC4					= 0x8B52    # ARB_shader_objects
	FLOAT_MAT2					= 0x8B5A    # ARB_shader_objects
	FLOAT_MAT3					= 0x8B5B    # ARB_shader_objects
	FLOAT_MAT4					= 0x8B5C    # ARB_shader_objects
	
VertexAttribPointerType enum:
	use DataType BYTE
	use DataType UNSIGNED_BYTE
	use DataType SHORT
	use DataType UNSIGNED_SHORT
	use DataType INT
	use DataType UNSIGNED_INT
	use DataType FLOAT
	use DataType DOUBLE
	
# Shading Language
StringName enum:
	SHADING_LANGUAGE_VERSION	= 0x8B8C

# Used in GetShader (http://www.opengl.org/sdk/docs/man/xhtml/glGetShader.xml)
ShaderParameter enum:
	DELETE_STATUS				= 0x8B80    # ARB_shader_objects
	COMPILE_STATUS				= 0x8B81    # ARB_shader_objects
	INFO_LOG_LENGTH				= 0x8B84    # ARB_shader_objects
	SHADER_SOURCE_LENGTH		= 0x8B88    # ARB_shader_objects
	SHADER_TYPE					= 0x8B4F    # ARB_shader_objects

# Used in GetProgram (http://www.opengl.org/sdk/docs/man/xhtml/glGetProgram.xml)
ProgramParameter enum:
	DELETE_STATUS				= 0x8B80    # ARB_shader_objects
	LINK_STATUS					= 0x8B82    # ARB_shader_objects
	VALIDATE_STATUS				= 0x8B83    # ARB_shader_objects
	INFO_LOG_LENGTH				= 0x8B84    # ARB_shader_objects
	ATTACHED_SHADERS			= 0x8B85    # ARB_shader_objects
	ACTIVE_UNIFORMS				= 0x8B86    # ARB_shader_objects
	ACTIVE_UNIFORM_MAX_LENGTH	= 0x8B87    # ARB_shader_objects
	ACTIVE_ATTRIBUTES			= 0x8B89    # ARB_vertex_shader
	ACTIVE_ATTRIBUTE_MAX_LENGTH	= 0x8B8A    # ARB_vertex_shader

VertexAttribParameter enum:
#	VERTEX_ATTRIB_ARRAY_ENABLED	= 0x8622    # ARB_vertex_shader
#	VERTEX_ATTRIB_ARRAY_SIZE	= 0x8623    # ARB_vertex_shader
#	VERTEX_ATTRIB_ARRAY_STRIDE	= 0x8624    # ARB_vertex_shader
#	VERTEX_ATTRIB_ARRAY_TYPE	= 0x8625    # ARB_vertex_shader
#	CURRENT_VERTEX_ATTRIB		= 0x8626    # ARB_vertex_shader
#	VERTEX_ATTRIB_ARRAY_NORMALIZED	= 0x886A    # ARB_vertex_shader
	ARRAY_ENABLED				= 0x8622    # ARB_vertex_shader
	ARRAY_SIZE					= 0x8623    # ARB_vertex_shader
	ARRAY_STRIDE				= 0x8624    # ARB_vertex_shader
	ARRAY_TYPE					= 0x8625    # ARB_vertex_shader
	CURRENT_VERTEX_ATTRIB		= 0x8626    # ARB_vertex_shader
	ARRAY_NORMALIZED			= 0x886A    # ARB_vertex_shader

VertexAttribPointerParameter enum:
#	VERTEX_ATTRIB_ARRAY_POINTER	= 0x8645    # ARB_vertex_shader
	ARRAY_POINTER				= 0x8645    # ARB_vertex_shader
	
# Half Float (http://www.opengl.org/registry/specs/ARB/half_float_pixel.txt)
PixelType enum:
	HALF_FLOAT					= 0x140B

# Draw Buffers (http://www.opengl.org/registry/specs/ARB/draw_buffers.txt)
# <summary>Monoscopic contexts include only left buffers, while stereoscopic contexts include both left and right buffers.  Likewise, single buffered contexts include only front buffers, while double buffered contexts include both front and back buffers.</summary>
DrawBuffersEnum enum:
	use DrawBufferMode NONE
	use DrawBufferMode FRONT_LEFT
	use DrawBufferMode FRONT_RIGHT
	use DrawBufferMode BACK_LEFT
	use DrawBufferMode BACK_RIGHT
	use DrawBufferMode AUX0
	use DrawBufferMode AUX1
	use DrawBufferMode AUX2
	use DrawBufferMode AUX3
	
	
GetPName enum:
	MAX_DRAW_BUFFERS				= 0x8824
	DRAW_BUFFER0					= 0x8825
	DRAW_BUFFER1					= 0x8826
	DRAW_BUFFER2					= 0x8827
	DRAW_BUFFER3					= 0x8828
	DRAW_BUFFER4					= 0x8829
	DRAW_BUFFER5					= 0x882A
	DRAW_BUFFER6					= 0x882B
	DRAW_BUFFER7					= 0x882C
	DRAW_BUFFER8					= 0x882D
	DRAW_BUFFER9					= 0x882E
	DRAW_BUFFER10					= 0x882F
	DRAW_BUFFER11					= 0x8830
	DRAW_BUFFER12					= 0x8831
	DRAW_BUFFER13					= 0x8832
	DRAW_BUFFER14					= 0x8833
	DRAW_BUFFER15					= 0x8834

# Point Sprites
# http://opengl.org/registry/specs/ARB/point_sprite.txt
# http://www.opengl.org/sdk/docs/man/xhtml/glPointParameter.xml
PointParameterName enum:
	POINT_SPRITE_COORD_ORIGIN		= 0x8CA0    # ARB_point_sprite (added for 2.0)

# <summary>Specifies the coordinate origin of the Point Sprite.</summary>
PointSpriteCoordOriginParameter enum:
	LOWER_LEFT						= 0x8CA1    # ARB_point_sprite (added for 2.0)
	UPPER_LEFT						= 0x8CA2    # ARB_point_sprite (added for 2.0)
	
EnableCap enum:
	POINT_SPRITE					= 0x8861

TextureEnvTarget enum:
	POINT_SPRITE					= 0x8861

TextureEnvParameter enum:
	COORD_REPLACE					= 0x8862

# <summary>This Enum may only be used with GL.TexEnv if target is PointSprite and pname is CoordReplace.</summary>
TextureEnvModePointSprite enum:
	use Boolean TRUE
	use Boolean FALSE

GetPName enum:
	POINT_SPRITE					= 0x8861


# Version 2.1

# Raster Secondary Color (http://www.opengl.org/sdk/docs/man/xhtml/glGet.xml)
GetPName enum:
	CURRENT_RASTER_SECONDARY_COLOR	= 0x845F    # New for 2.1

# Shader Uniforms (http://www.opengl.org/sdk/docs/man/xhtml/glGetActiveUniform.xml)
ActiveUniformType enum:
	FLOAT_MAT2x3					= 0x8B65    # New for 2.1
	FLOAT_MAT2x4					= 0x8B66    # New for 2.1
	FLOAT_MAT3x2					= 0x8B67    # New for 2.1
	FLOAT_MAT3x4					= 0x8B68    # New for 2.1
	FLOAT_MAT4x2					= 0x8B69    # New for 2.1
	FLOAT_MAT4x3					= 0x8B6A    # New for 2.1

# Pixel Buffer Objects http://www.opengl.org/sdk/docs/man/xhtml/glBindBuffer.xml
BufferTarget enum:
	PIXEL_PACK_BUFFER				= 0x88EB    # ARB_pixel_buffer_object
	PIXEL_UNPACK_BUFFER				= 0x88EC    # ARB_pixel_buffer_object
	
GetPName enum:
	PIXEL_PACK_BUFFER_BINDING		= 0x88ED    # ARB_pixel_buffer_object
	PIXEL_UNPACK_BUFFER_BINDING		= 0x88EF    # ARB_pixel_buffer_object
	
# sRGB textures (http://www.opengl.org/registry/specs/EXT/texture_sRGB.txt)
PixelInternalFormat enum:
	SRGB							= 0x8C40    # EXT_texture_sRGB
	SRGB8							= 0x8C41    # EXT_texture_sRGB
	SRGB_ALPHA						= 0x8C42    # EXT_texture_sRGB
	SRGB8_ALPHA8					= 0x8C43    # EXT_texture_sRGB
	SLUMINANCE_ALPHA				= 0x8C44    # EXT_texture_sRGB
	SLUMINANCE8_ALPHA8				= 0x8C45    # EXT_texture_sRGB
	SLUMINANCE						= 0x8C46    # EXT_texture_sRGB
	SLUMINANCE8						= 0x8C47    # EXT_texture_sRGB
	COMPRESSED_SRGB					= 0x8C48    # EXT_texture_sRGB
	COMPRESSED_SRGB_ALPHA			= 0x8C49    # EXT_texture_sRGB
	COMPRESSED_SLUMINANCE			= 0x8C4A    # EXT_texture_sRGB
	COMPRESSED_SLUMINANCE_ALPHA		= 0x8C4B    # EXT_texture_sRGB

	# <summary>Format only valid for 2D Textures</summary>
	COMPRESSED_SRGB_S3TC_DXT1_EXT			= 0x8C4C
	# <summary>Format only valid for 2D Textures</summary>
	COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT		= 0x8C4D
	# <summary>Format only valid for 2D Textures</summary>
	COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT		= 0x8C4E
	# <summary>Format only valid for 2D Textures</summary>
	COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT		= 0x8C4F


# Version 3.0

# Promoted from ARB_color_buffer_float
ClampColorTarget enum:
	CLAMP_VERTEX_COLOR = 0x891A
	CLAMP_FRAGMENT_COLOR = 0x891B
	CLAMP_READ_COLOR = 0x891C
	
ClampColorMode enum:
	FIXED_ONLY = 0x891D
	use Boolean TRUE
	use Boolean FALSE
	
GetPName enum:
	RGBA_FLOAT_MODE = 0x8820
	use ClampColorTarget CLAMP_VERTEX_COLOR
	use ClampColorTarget CLAMP_FRAGMENT_COLOR
	use ClampColorTarget CLAMP_READ_COLOR

# Promoted from ARB_texture_float
GetTextureParameter enum:
	TEXTURE_RED_TYPE = 0x8C10
	TEXTURE_GREEN_TYPE = 0x8C11
	TEXTURE_BLUE_TYPE = 0x8C12
	TEXTURE_ALPHA_TYPE = 0x8C13
	TEXTURE_LUMINANCE_TYPE = 0x8C14
	TEXTURE_INTENSITY_TYPE = 0x8C15
	TEXTURE_DEPTH_TYPE = 0x8C16

# Page 180 of glspec30.20080923.pdf
PixelInternalFormat enum:
	RGBA32F = 0x8814
	RGB32F = 0x8815
	RGBA16F = 0x881A
	RGB16F = 0x881B
	use ARB_depth_buffer_float	    DEPTH_COMPONENT32F
	use ARB_depth_buffer_float	    DEPTH32F_STENCIL8
	use ARB_depth_buffer_float	    FLOAT_32_UNSIGNED_INT_24_8_REV
	
# Promoted from EXT_texture_integer
PixelInternalFormat enum:
	RGBA32UI					= 0x8D70
	RGB32UI						= 0x8D71
	RGBA16UI					= 0x8D76
	RGB16UI						= 0x8D77
	RGBA8UI						= 0x8D7C
	RGB8UI						= 0x8D7D
	RGBA32I						= 0x8D82
	RGB32I						= 0x8D83
	RGBA16I						= 0x8D88
	RGB16I						= 0x8D89
	RGBA8I						= 0x8D8E
	RGB8I							= 0x8D8F

PixelFormat enum:
	RED_INTEGER				= 0x8D94
	GREEN_INTEGER		= 0x8D95
	BLUE_INTEGER			= 0x8D96
	ALPHA_INTEGER		= 0x8D97
	RGB_INTEGER				= 0x8D98
	RGBA_INTEGER			= 0x8D99
	BGR_INTEGER				= 0x8D9A
	BGRA_INTEGER			= 0x8D9B
	
# Promoted from ARB_texture_rg
PixelInternalFormat enum:
	use ARB_texture_rg		    R8
	use ARB_texture_rg		    R16
	use ARB_texture_rg		    RG8
	use ARB_texture_rg		    RG16
	use ARB_texture_rg		    R16F
	use ARB_texture_rg		    R32F
	use ARB_texture_rg		    RG16F
	use ARB_texture_rg		    RG32F
	use ARB_texture_rg		    R8I
	use ARB_texture_rg		    R8UI
	use ARB_texture_rg		    R16I
	use ARB_texture_rg		    R16UI
	use ARB_texture_rg		    R32I
	use ARB_texture_rg		    R32UI
	use ARB_texture_rg		    RG8I
	use ARB_texture_rg		    RG8UI
	use ARB_texture_rg		    RG16I
	use ARB_texture_rg		    RG16UI
	use ARB_texture_rg		    RG32I
	use ARB_texture_rg		    RG32UI

PixelFormat enum:
	use ARB_texture_rg		    RG
	use ARB_texture_rg		    RG_INTEGER

TextureParameterName enum:
	RED = 0x1903
	
# Promoted from ARB_texture_compression_rgtc
PixelInternalFormat enum:
	use ARB_texture_compression_rgtc    COMPRESSED_RED_RGTC1
	use ARB_texture_compression_rgtc    COMPRESSED_SIGNED_RED_RGTC1
	use ARB_texture_compression_rgtc    COMPRESSED_RG_RGTC2
	use ARB_texture_compression_rgtc    COMPRESSED_SIGNED_RG_RGTC2
	COMPRESSED_RED			= 0x8225
	COMPRESSED_RG				= 0x8226

# Promoted from EXT_texture_array
TextureTarget enum:
	TEXTURE_1D_ARRAY								= 0x8C18
	PROXY_TEXTURE_1D_ARRAY				= 0x8C19
	TEXTURE_2D_ARRAY								= 0x8C1A
	PROXY_TEXTURE_2D_ARRAY				= 0x8C1B

GetPName enum:
	TEXTURE_BINDING_1D_ARRAY			= 0x8C1C
	TEXTURE_BINDING_2D_ARRAY			= 0x8C1D
	MAX_ARRAY_TEXTURE_LAYERS		= 0x88FF

TextureCompareMode enum:
	COMPARE_REF_TO_TEXTURE			= GL_COMPARE_R_TO_TEXTURE_ARB

ActiveUniformType enum:
	SAMPLER_1D_ARRAY								= 0x8DC0
	SAMPLER_2D_ARRAY								= 0x8DC1
	SAMPLER_1D_ARRAY_SHADOW			= 0x8DC3
	SAMPLER_2D_ARRAY_SHADOW			= 0x8DC4

# Promoted from ARB_framebuffer_object
BlitFramebufferFilter enum:
	use TextureMagFilter LINEAR
	use TextureMagFilter NEAREST

FramebufferTarget enum:
	use ARB_framebuffer_object	    READ_FRAMEBUFFER
	use ARB_framebuffer_object	    DRAW_FRAMEBUFFER
	use ARB_framebuffer_object	    FRAMEBUFFER
	
FramebufferParameterName enum:
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_RED_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_GREEN_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_BLUE_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_OBJECT_NAME
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL
	use ARB_framebuffer_object	    FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE	

FramebufferAttachment enum:
	use ARB_framebuffer_object	    COLOR_ATTACHMENT0
	use ARB_framebuffer_object	    COLOR_ATTACHMENT1
	use ARB_framebuffer_object	    COLOR_ATTACHMENT2
	use ARB_framebuffer_object	    COLOR_ATTACHMENT3
	use ARB_framebuffer_object	    COLOR_ATTACHMENT4
	use ARB_framebuffer_object	    COLOR_ATTACHMENT5
	use ARB_framebuffer_object	    COLOR_ATTACHMENT6
	use ARB_framebuffer_object	    COLOR_ATTACHMENT7
	use ARB_framebuffer_object	    COLOR_ATTACHMENT8
	use ARB_framebuffer_object	    COLOR_ATTACHMENT9
	use ARB_framebuffer_object	    COLOR_ATTACHMENT10
	use ARB_framebuffer_object	    COLOR_ATTACHMENT11
	use ARB_framebuffer_object	    COLOR_ATTACHMENT12
	use ARB_framebuffer_object	    COLOR_ATTACHMENT13
	use ARB_framebuffer_object	    COLOR_ATTACHMENT14
	use ARB_framebuffer_object	    COLOR_ATTACHMENT15
	use ARB_framebuffer_object	    DEPTH_ATTACHMENT
	use ARB_framebuffer_object	    STENCIL_ATTACHMENT
	use ARB_framebuffer_object	    DEPTH_STENCIL_ATTACHMENT

# These tokens are only valid when the current FramebufferBinding is non-zero
# See page 182 of the 3.1 specs.
DrawBuffersEnum enum:
	use ARB_framebuffer_object	    COLOR_ATTACHMENT0
	use ARB_framebuffer_object	    COLOR_ATTACHMENT1
	use ARB_framebuffer_object	    COLOR_ATTACHMENT2
	use ARB_framebuffer_object	    COLOR_ATTACHMENT3
	use ARB_framebuffer_object	    COLOR_ATTACHMENT4
	use ARB_framebuffer_object	    COLOR_ATTACHMENT5
	use ARB_framebuffer_object	    COLOR_ATTACHMENT6
	use ARB_framebuffer_object	    COLOR_ATTACHMENT7
	use ARB_framebuffer_object	    COLOR_ATTACHMENT8
	use ARB_framebuffer_object	    COLOR_ATTACHMENT9
	use ARB_framebuffer_object	    COLOR_ATTACHMENT10
	use ARB_framebuffer_object	    COLOR_ATTACHMENT11
	use ARB_framebuffer_object	    COLOR_ATTACHMENT12
	use ARB_framebuffer_object	    COLOR_ATTACHMENT13
	use ARB_framebuffer_object	    COLOR_ATTACHMENT14
	use ARB_framebuffer_object	    COLOR_ATTACHMENT15

# These tokens are only valid when the current FramebufferBinding is non-zero
# See page 182 of the 3.1 specs.
DrawBufferMode enum:
	use ARB_framebuffer_object	    COLOR_ATTACHMENT0
	use ARB_framebuffer_object	    COLOR_ATTACHMENT1
	use ARB_framebuffer_object	    COLOR_ATTACHMENT2
	use ARB_framebuffer_object	    COLOR_ATTACHMENT3
	use ARB_framebuffer_object	    COLOR_ATTACHMENT4
	use ARB_framebuffer_object	    COLOR_ATTACHMENT5
	use ARB_framebuffer_object	    COLOR_ATTACHMENT6
	use ARB_framebuffer_object	    COLOR_ATTACHMENT7
	use ARB_framebuffer_object	    COLOR_ATTACHMENT8
	use ARB_framebuffer_object	    COLOR_ATTACHMENT9
	use ARB_framebuffer_object	    COLOR_ATTACHMENT10
	use ARB_framebuffer_object	    COLOR_ATTACHMENT11
	use ARB_framebuffer_object	    COLOR_ATTACHMENT12
	use ARB_framebuffer_object	    COLOR_ATTACHMENT13
	use ARB_framebuffer_object	    COLOR_ATTACHMENT14
	use ARB_framebuffer_object	    COLOR_ATTACHMENT15
    
# These tokens are only valid when the current FramebufferBinding is non-zero
# See page 182 of the 3.1 specs.
ReadBufferMode enum:
    use ARB_framebuffer_object      COLOR_ATTACHMENT0
    use ARB_framebuffer_object      COLOR_ATTACHMENT1
    use ARB_framebuffer_object      COLOR_ATTACHMENT2
    use ARB_framebuffer_object      COLOR_ATTACHMENT3
    use ARB_framebuffer_object      COLOR_ATTACHMENT4
    use ARB_framebuffer_object      COLOR_ATTACHMENT5
    use ARB_framebuffer_object      COLOR_ATTACHMENT6
    use ARB_framebuffer_object      COLOR_ATTACHMENT7
    use ARB_framebuffer_object      COLOR_ATTACHMENT8
    use ARB_framebuffer_object      COLOR_ATTACHMENT9
    use ARB_framebuffer_object      COLOR_ATTACHMENT10
    use ARB_framebuffer_object      COLOR_ATTACHMENT11
    use ARB_framebuffer_object      COLOR_ATTACHMENT12
    use ARB_framebuffer_object      COLOR_ATTACHMENT13
    use ARB_framebuffer_object      COLOR_ATTACHMENT14
    use ARB_framebuffer_object      COLOR_ATTACHMENT15

FramebufferAttachmentObjectType enum:
	NONE													= 0
	use ARB_framebuffer_object	    FRAMEBUFFER_DEFAULT
	use MatrixMode								TEXTURE
	use ARB_framebuffer_object	    RENDERBUFFER	

FramebufferAttachmentComponentType enum:
	use DataType									FLOAT
	use DataType									INT
	use ARB_framebuffer_object	    UNSIGNED_NORMALIZED
	use ARB_framebuffer_object	    INDEX

FramebufferErrorCode enum:
	use ARB_framebuffer_object	    FRAMEBUFFER_COMPLETE
	use ARB_framebuffer_object	    FRAMEBUFFER_INCOMPLETE_ATTACHMENT
	use ARB_framebuffer_object	    FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT
	use ARB_framebuffer_object	    FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER
	use ARB_framebuffer_object	    FRAMEBUFFER_INCOMPLETE_READ_BUFFER
	use ARB_framebuffer_object	    FRAMEBUFFER_UNSUPPORTED	
	use ARB_framebuffer_object	    FRAMEBUFFER_INCOMPLETE_MULTISAMPLE
	use ARB_framebuffer_object	    FRAMEBUFFER_UNDEFINED

RenderbufferTarget enum:
	use ARB_framebuffer_object	    RENDERBUFFER

RenderbufferParameterName enum:
	use ARB_framebuffer_object	    RENDERBUFFER_SAMPLES
	use ARB_framebuffer_object	    RENDERBUFFER_WIDTH
	use ARB_framebuffer_object	    RENDERBUFFER_HEIGHT
	use ARB_framebuffer_object	    RENDERBUFFER_INTERNAL_FORMAT
	use ARB_framebuffer_object	    RENDERBUFFER_RED_SIZE
	use ARB_framebuffer_object	    RENDERBUFFER_GREEN_SIZE
	use ARB_framebuffer_object	    RENDERBUFFER_BLUE_SIZE
	use ARB_framebuffer_object	    RENDERBUFFER_ALPHA_SIZE
	use ARB_framebuffer_object	    RENDERBUFFER_DEPTH_SIZE
	use ARB_framebuffer_object	    RENDERBUFFER_STENCIL_SIZE

RenderbufferStorage enum:
	use PixelInternalFormat ALPHA4
	use PixelInternalFormat ALPHA8
	use PixelInternalFormat ALPHA12
	use PixelInternalFormat ALPHA16
	use PixelInternalFormat R8
	use PixelInternalFormat R16
	use PixelInternalFormat RG8
	use PixelInternalFormat RG16
	use PixelInternalFormat R3_G3_B2
	use PixelInternalFormat RGB4
	use PixelInternalFormat RGB5
	use PixelInternalFormat RGB8
	use PixelInternalFormat RGB10
	use PixelInternalFormat RGB12
	use PixelInternalFormat RGB16
	use PixelInternalFormat RGBA2
	use PixelInternalFormat RGBA4
	use PixelInternalFormat RGB5_A1
	use PixelInternalFormat RGBA8
	use PixelInternalFormat RGB10_A2
	use PixelInternalFormat RGBA12
	use PixelInternalFormat RGBA16
	use PixelInternalFormat SRGB8
	use PixelInternalFormat SRGB8_ALPHA8
	use PixelInternalFormat R16F
	use PixelInternalFormat RG16F
	use PixelInternalFormat RGB16F
	use PixelInternalFormat RGBA16F
	use PixelInternalFormat R32F
	use PixelInternalFormat RG32F
	use PixelInternalFormat RGB32F
	use PixelInternalFormat RGBA32F
	use PixelInternalFormat R11F_G11F_B10F
	use PixelInternalFormat RGB9_E5
	use PixelInternalFormat R8I
	use PixelInternalFormat R8UI
	use PixelInternalFormat R16I
	use PixelInternalFormat R16UI
	use PixelInternalFormat R32I
	use PixelInternalFormat R32UI
	use PixelInternalFormat RG8I
	use PixelInternalFormat RG8UI
	use PixelInternalFormat RG16I
	use PixelInternalFormat RG16UI
	use PixelInternalFormat RG32I
	use PixelInternalFormat RG32UI
	use PixelInternalFormat RGB8I
	use PixelInternalFormat RGB8UI
	use PixelInternalFormat RGB16I
	use PixelInternalFormat RGB16UI
	use PixelInternalFormat RGB32I
	use PixelInternalFormat RGB32UI
	use PixelInternalFormat RGBA8I
	use PixelInternalFormat RGBA8UI
	use PixelInternalFormat RGBA16I
	use PixelInternalFormat RGBA16UI
	use PixelInternalFormat RGBA32I
	use PixelInternalFormat RGBA32UI

	use PixelInternalFormat DEPTH_COMPONENT16
	use PixelInternalFormat DEPTH_COMPONENT24
	use PixelInternalFormat DEPTH_COMPONENT32
	use PixelInternalFormat DEPTH_COMPONENT32F
	use PixelInternalFormat DEPTH24_STENCIL8
	use PixelInternalFormat DEPTH32F_STENCIL8

	use ARB_framebuffer_object STENCIL_INDEX1
	use ARB_framebuffer_object	STENCIL_INDEX4
	use ARB_framebuffer_object	STENCIL_INDEX8
	use ARB_framebuffer_object	STENCIL_INDEX16

GetPName enum:
	use ARB_framebuffer_object	    MAX_SAMPLES
	use ARB_framebuffer_object	    MAX_COLOR_ATTACHMENTS
	use ARB_framebuffer_object	    FRAMEBUFFER_BINDING
	use ARB_framebuffer_object	    DRAW_FRAMEBUFFER_BINDING
	use ARB_framebuffer_object	    READ_FRAMEBUFFER_BINDING	
	use ARB_framebuffer_object	    RENDERBUFFER_BINDING
	use ARB_framebuffer_object	    MAX_RENDERBUFFER_SIZE

ErrorCode enum:
	use ARB_framebuffer_object	    INVALID_FRAMEBUFFER_OPERATION

PixelFormat enum:
	use ARB_framebuffer_object	    DEPTH_STENCIL

PixelInternalFormat enum:
	use ARB_framebuffer_object	    DEPTH_STENCIL
	use ARB_framebuffer_object	    DEPTH24_STENCIL8

PixelType enum:
	use ARB_framebuffer_object	    UNSIGNED_INT_24_8

GetTextureParameter enum:
	use ARB_framebuffer_object	    TEXTURE_STENCIL_SIZE
	use ARB_framebuffer_object	    TEXTURE_RED_TYPE
	use ARB_framebuffer_object	    TEXTURE_GREEN_TYPE
	use ARB_framebuffer_object	    TEXTURE_BLUE_TYPE
	use ARB_framebuffer_object	    TEXTURE_ALPHA_TYPE
	use ARB_framebuffer_object	    TEXTURE_LUMINANCE_TYPE
	use ARB_framebuffer_object	    TEXTURE_INTENSITY_TYPE
	use ARB_framebuffer_object	    TEXTURE_DEPTH_TYPE
	
# Promoted from ARB_depth_buffer_float
PixelType enum:
	use ARB_depth_buffer_float	    FLOAT_32_UNSIGNED_INT_24_8_REV

# Promoted from ARB_framebuffer_sRGB
EnableCap enum:
	use ARB_framebuffer_sRGB	    FRAMEBUFFER_SRGB

GetPName enum:	
	use ARB_framebuffer_sRGB	    FRAMEBUFFER_SRGB

# Promoted from ARB_half_float_vertex
VertexAttribPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

VertexPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

NormalPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

ColorPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

FogPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

TexCoordPointerType enum:
	use ARB_half_float_vertex	    HALF_FLOAT

# Promoted from ARB_vertex_array_objects
GetPName enum:
	use ARB_vertex_array_object	    VERTEX_ARRAY_BINDING

# Promoted from EXT_gpu_shader4
VertexAttribParameter enum:
	VERTEX_ATTRIB_ARRAY_INTEGER			= 0x88FD

ActiveUniformType enum:
	SAMPLER_CUBE_SHADOW				= 0x8DC5
	UNSIGNED_INT_VEC2				= 0x8DC6
	UNSIGNED_INT_VEC3				= 0x8DC7
	UNSIGNED_INT_VEC4				= 0x8DC8
	INT_SAMPLER_1D					= 0x8DC9
	INT_SAMPLER_2D					= 0x8DCA
	INT_SAMPLER_3D					= 0x8DCB
	INT_SAMPLER_CUBE				= 0x8DCC
	INT_SAMPLER_1D_ARRAY				= 0x8DCE
	INT_SAMPLER_2D_ARRAY				= 0x8DCF
	UNSIGNED_INT_SAMPLER_1D				= 0x8DD1
	UNSIGNED_INT_SAMPLER_2D				= 0x8DD2
	UNSIGNED_INT_SAMPLER_3D				= 0x8DD3
	UNSIGNED_INT_SAMPLER_CUBE			= 0x8DD4
	UNSIGNED_INT_SAMPLER_1D_ARRAY			= 0x8DD6
	UNSIGNED_INT_SAMPLER_2D_ARRAY			= 0x8DD7

GetPName enum:
	MIN_PROGRAM_TEXEL_OFFSET			= 0x8904
	MAX_PROGRAM_TEXEL_OFFSET			= 0x8905
	
# Promoted from EXT_packed_float
PixelType enum:
	UNSIGNED_INT_10F_11F_11F_REV			= 0x8C3B

PixelInternalFormat enum:
	R11F_G11F_B10F = 0x8C3A	

RenderbufferStorage enum:
	use PixelInternalFormat R11F_G11F_B10F

# Promoted from EXT_texture_ shared_exponent
PixelType enum:
	UNSIGNED_INT_5_9_9_9_REV			= 0x8C3E
	
PixelInternalFormat enum:
	RGB9_E5 = 0x8C3D

RenderbufferStorage enum:
	use PixelInternalFormat RGB9_E5

GetTextureParameter enum:
	TEXTURE_SHARED_SIZE			= 0x8C3F

# Promoted from ARB_map_buffer_range
BufferAccessMask enum:
	use ARB_map_buffer_range	    MAP_READ_BIT
	use ARB_map_buffer_range	    MAP_WRITE_BIT
	use ARB_map_buffer_range	    MAP_INVALIDATE_RANGE_BIT
	use ARB_map_buffer_range	    MAP_INVALIDATE_BUFFER_BIT
	use ARB_map_buffer_range	    MAP_FLUSH_EXPLICIT_BIT
	use ARB_map_buffer_range	    MAP_UNSYNCHRONIZED_BIT

# Promoted from NV_conditional_render:
ConditionalRenderType enum:
	QUERY_WAIT						= 0x8E13
	QUERY_NO_WAIT					= 0x8E14
	QUERY_BY_REGION_WAIT		= 0x8E15
	QUERY_BY_REGION_NO_WAIT	= 0x8E16    

# Promoted from EXT_draw_buffers2

# Promoted from EXT_transform_feedback
GetIndexedPName enum:
	TRANSFORM_FEEDBACK_BUFFER_START		= 0x8C84
	TRANSFORM_FEEDBACK_BUFFER_SIZE			= 0x8C85
	TRANSFORM_FEEDBACK_BUFFER_BINDING		= 0x8C8F

GetPName enum:
	MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS		= 0x8C80
	MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS	= 0x8C8A
	MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS				= 0x8C8B

ProgramParameter enum:
	TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH	= 0x8C76
	TRANSFORM_FEEDBACK_BUFFER_MODE			= 0x8C7F
	TRANSFORM_FEEDBACK_VARYINGS					= 0x8C83

QueryTarget enum:
	PRIMITIVES_GENERATED								= 0x8C87
	TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN	= 0x8C88
	
EnableCap enum:
	RASTERIZER_DISCARD								= 0x8C89

TransformFeedbackMode enum:
	INTERLEAVED_ATTRIBS			= 0x8C8C
	SEPARATE_ATTRIBS				= 0x8C8D

BufferTarget enum:
	TRANSFORM_FEEDBACK_BUFFER = 0x8C8E

BeginFeedbackMode enum:
    use BeginMode POINTS
    use BeginMode LINES
    use BeginMode TRIANGLES

# Other OpenGL 3.0 changes:
GetPName enum:
	MAJOR_VERSION					= 0x821B
	MINOR_VERSION					= 0x821C
	NUM_EXTENSIONS				= 0x821D
	CONTEXT_FLAGS					= 0x821E

StringName enum:
	use StringName EXTENSIONS		# Used in GetStringi

IndexedEnableCap enum:	
    use GetPName BLEND
    
# For ClearBuffer function, see specs pg. 189.
ClearBuffer enum:
	use VERSION_1_1 COLOR
	use VERSION_1_1 DEPTH
	use VERSION_1_1 STENCIL
	use VERSION_3_0 DEPTH_STENCIL
	
# Version 3.1 

# Promoted from ARB_copy_buffer
BufferTarget enum:
    use ARB_copy_buffer COPY_READ_BUFFER
    use ARB_copy_buffer COPY_WRITE_BUFFER

# Promoted from ARB_uniform_buffer_object
BufferTarget enum:
	use ARB_uniform_buffer_object UNIFORM_BUFFER

GetPName enum:
    use ARB_uniform_buffer_object MAX_VERTEX_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object MAX_GEOMETRY_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object MAX_FRAGMENT_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object MAX_COMBINED_UNIFORM_BLOCKS
    use ARB_uniform_buffer_object MAX_UNIFORM_BUFFER_BINDINGS
    use ARB_uniform_buffer_object MAX_UNIFORM_BLOCK_SIZE
    use ARB_uniform_buffer_object MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS
    use ARB_uniform_buffer_object MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS
    use ARB_uniform_buffer_object MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS
    use ARB_uniform_buffer_object UNIFORM_BUFFER_OFFSET_ALIGNMENT

GetIndexedPName enum:
    use ARB_uniform_buffer_object UNIFORM_BUFFER_BINDING
    use ARB_uniform_buffer_object UNIFORM_BUFFER_START
    use ARB_uniform_buffer_object UNIFORM_BUFFER_SIZE

ProgramParameter enum:
    use ARB_uniform_buffer_object ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH
    use ARB_uniform_buffer_object ACTIVE_UNIFORM_BLOCKS

# Used in TexBuffer
TextureBufferTarget enum:
	use VERSION_3_1 TEXTURE_BUFFER

SizedInternalFormat enum:
	use PixelInternalFormat R8
	use PixelInternalFormat R16
	use PixelInternalFormat R16F
	use PixelInternalFormat R32F
	use PixelInternalFormat R8I
	use PixelInternalFormat R16I
	use PixelInternalFormat R32I
	use PixelInternalFormat R8UI
	use PixelInternalFormat R16UI
	use PixelInternalFormat R32UI
	use PixelInternalFormat RG8
	use PixelInternalFormat RG16
	use PixelInternalFormat RG16F
	use PixelInternalFormat RG32F
	use PixelInternalFormat RG8I
	use PixelInternalFormat RG16I
	use PixelInternalFormat RG32I
	use PixelInternalFormat RG8UI
	use PixelInternalFormat RG16UI
	use PixelInternalFormat RG32UI
	use PixelInternalFormat RGBA8
	use PixelInternalFormat RGBA16
	use PixelInternalFormat RGBA16F
	use PixelInternalFormat RGBA32F
	use PixelInternalFormat RGBA8I
	use PixelInternalFormat RGBA16I
	use PixelInternalFormat RGBA32I
	use PixelInternalFormat RGBA8UI
	use PixelInternalFormat RGBA16UI
	use PixelInternalFormat RGBA32UI
	
TextureTarget enum:
	TEXTURE_RECTANGLE               = 0x84F5    # ARB_texture_rectangle
    PROXY_TEXTURE_RECTANGLE             = 0x84F7    # ARB_texture_rectangle
    
GetPName enum:
    TEXTURE_BINDING_RECTANGLE           = 0x84F6    # ARB_texture_rectangle
    MAX_RECTANGLE_TEXTURE_SIZE          = 0x84F8    # ARB_texture_rectangle

ActiveUniformType enum:
	SAMPLER_2D_RECT                 = 0x8B63    # ARB_shader_objects + ARB_texture_rectangle
    SAMPLER_2D_RECT_SHADOW              = 0x8B64    # ARB_shader_objects + ARB_texture_rectangle
    SAMPLER_BUFFER                  = 0x8DC2    # EXT_gpu_shader4 + ARB_texture_buffer_object
    INT_SAMPLER_2D_RECT             = 0x8DCD    # EXT_gpu_shader4 + ARB_texture_rectangle
    INT_SAMPLER_BUFFER              = 0x8DD0    # EXT_gpu_shader4 + ARB_texture_buffer_object
    UNSIGNED_INT_SAMPLER_2D_RECT            = 0x8DD5    # EXT_gpu_shader4 + ARB_texture_rectangle
    UNSIGNED_INT_SAMPLER_BUFFER         = 0x8DD8    # EXT_gpu_shader4 + ARB_texture_buffer_object
    
ActiveUniformBlockParameter enum:
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_BINDING
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_DATA_SIZE
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_NAME_LENGTH
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_ACTIVE_UNIFORMS
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER

# Used in primitive restart
EnableCap enum:
	PRIMITIVE_RESTART               = 0x8F9D    # 3.1 (different from NV_primitive_restart)
	

# Non-core 

# ARB_instanced_arrays
VertexAttribParameterARB enum:
    ARRAY_DIVISOR = 0x88FE

# Version ARB

# ARB_vertex_program

AssemblyProgramTargetARB enum:
	FRAGMENT_PROGRAM				= 0x8804
	VERTEX_PROGRAM					= 0x8620	

AssemblyProgramFormatARB enum:
	PROGRAM_FORMAT_ASCII_ARB		= 0x8875    # shared

AssemblyProgramParameterARB enum:
    PROGRAM_LENGTH					= 0x8627
    PROGRAM_FORMAT					= 0x8876
    PROGRAM_BINDING					= 0x8677
    PROGRAM_INSTRUCTION				= 0x88A0
    MAX_PROGRAM_INSTRUCTIONS		= 0x88A1
    PROGRAM_NATIVE_INSTRUCTIONS		= 0x88A2
    MAX_PROGRAM_NATIVE_INSTRUCTIONS	= 0x88A3
	PROGRAM_TEMPORARIES				= 0x88A4
	MAX_PROGRAM_TEMPORARIES			= 0x88A5
	PROGRAM_NATIVE_TEMPORARIES		= 0x88A6
	MAX_PROGRAM_NATIVE_TEMPORARIES	= 0x88A7
	PROGRAM_PARAMETERS				= 0x88A8
	MAX_PROGRAM_PARAMETERS			= 0x88A9
	PROGRAM_NATIVE_PARAMETERS		= 0x88AA
	MAX_PROGRAM_NATIVE_PARAMETERS	= 0x88AB
	PROGRAM_ATTRIBS					= 0x88AC
	MAX_PROGRAM_ATTRIBS				= 0x88AD
	PROGRAM_NATIVE_ATTRIBS			= 0x88AE
	MAX_PROGRAM_NATIVE_ATTRIBS		= 0x88AF
	PROGRAM_ADDRESS_REGISTERS		= 0x88B0
	MAX_PROGRAM_ADDRESS_REGISTERS	= 0x88B1
	PROGRAM_NATIVE_ADDRESS_REGISTERS	= 0x88B2
	MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS	= 0x88B3
	MAX_PROGRAM_LOCAL_PARAMETERS	= 0x88B4
	MAX_PROGRAM_ENV_PARAMETERS		= 0x88B5
	PROGRAM_UNDER_NATIVE_LIMITS		= 0x88B6

	PROGRAM_ALU_INSTRUCTIONS_ARB	= 0x8805
	PROGRAM_TEX_INSTRUCTIONS_ARB	= 0x8806
	PROGRAM_TEX_INDIRECTIONS_ARB	= 0x8807
	PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB	= 0x8808
	PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB	= 0x8809
	PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB	= 0x880A
	MAX_PROGRAM_ALU_INSTRUCTIONS_ARB	= 0x880B
	MAX_PROGRAM_TEX_INSTRUCTIONS_ARB	= 0x880C
	MAX_PROGRAM_TEX_INDIRECTIONS_ARB	= 0x880D
	MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB	= 0x880E
	MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB	= 0x880F
	MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB	= 0x8810

AssemblyProgramStringParameterARB enum:
	PROGRAM_STRING				= 0x8628

MatrixModeARB enum:
	use MatrixMode MODELVIEW
	use MatrixMode PROJECTION
	use MatrixMode TEXTURE
	use MatrixMode COLOR
	MATRIX0						= 0x88C0
	MATRIX1						= 0x88C1
	MATRIX2						= 0x88C2
	MATRIX3						= 0x88C3
	MATRIX4						= 0x88C4
	MATRIX5						= 0x88C5
	MATRIX6						= 0x88C6
	MATRIX7						= 0x88C7
	MATRIX8						= 0x88C8
	MATRIX9						= 0x88C9
	MATRIX10					= 0x88CA
	MATRIX11					= 0x88CB
	MATRIX12					= 0x88CC
	MATRIX13					= 0x88CD
	MATRIX14					= 0x88CE
	MATRIX15					= 0x88CF
	MATRIX16					= 0x88D0
	MATRIX17					= 0x88D1
	MATRIX18					= 0x88D2
	MATRIX19					= 0x88D3
	MATRIX20					= 0x88D4
	MATRIX21					= 0x88D5
	MATRIX22					= 0x88D6
	MATRIX23					= 0x88D7
	MATRIX24					= 0x88D8
	MATRIX25					= 0x88D9
	MATRIX26					= 0x88DA
	MATRIX27					= 0x88DB
	MATRIX28					= 0x88DC
	MATRIX29					= 0x88DD
	MATRIX30					= 0x88DE
	MATRIX31					= 0x88DF

VertexAttribParameterARB enum:
	ARRAY_ENABLED				= 0x8622
	ARRAY_SIZE					= 0x8623
	ARRAY_STRIDE				= 0x8624
	ARRAY_TYPE					= 0x8625
	CURRENT_VERTEX_ATTRIB		= 0x8626
	ARRAY_NORMALIZED			= 0x886A
	
VertexAttribPointerParameterARB enum:
	ARRAY_POINTER				= 0x8645	
	
VertexAttribPointerTypeARB enum:
	use DataType BYTE
	use DataType UNSIGNED_BYTE
	use DataType SHORT
	use DataType UNSIGNED_SHORT
	use DataType INT
	use DataType UNSIGNED_INT
	use DataType FLOAT
	use DataType DOUBLE

# ARB_fragment_program:

BufferTargetARB enum:
    ARRAY_BUFFER                    = 0x8892
    ELEMENT_ARRAY_BUFFER            = 0x8893

BufferUsageARB enum:
    STREAM_DRAW                     = 0x88E0
    STREAM_READ                     = 0x88E1
    STREAM_COPY                     = 0x88E2
    STATIC_DRAW                     = 0x88E4
    STATIC_READ                     = 0x88E5
    STATIC_COPY                     = 0x88E6
    DYNAMIC_DRAW                    = 0x88E8
    DYNAMIC_READ                    = 0x88E9
    DYNAMIC_COPY                    = 0x88EA

BufferAccessARB enum:
	READ_ONLY                       = 0x88B8
	WRITE_ONLY                      = 0x88B9
	READ_WRITE                      = 0x88BA
	
BufferParameterNameARB enum:
    BUFFER_SIZE						= 0x8764
    BUFFER_USAGE					= 0x8765
    BUFFER_ACCESS					= 0x88BB
    BUFFER_MAPPED					= 0x88BC

BufferPointerNameARB enum:
	BUFFER_MAP_POINTER				= 0x88BD


# Version EXT

# EXT_framebuffer:

GenerateMipmapTarget enum:
	use TextureTarget TEXTURE_1D
	use TextureTarget TEXTURE_1D_ARRAY
	use TextureTarget TEXTURE_2D
	use TextureTarget TEXTURE_2D_ARRAY
	use TextureTarget TEXTURE_2D_MULTISAMPLE
	use TextureTarget TEXTURE_2D_MULTISAMPLE_ARRAY
	use TextureTarget TEXTURE_3D
	use TextureTarget TEXTURE_CUBE_MAP

FramebufferTarget enum:
	FRAMEBUFFER_EXT						= 0x8D40

RenderbufferTarget enum:
	RENDERBUFFER_EXT					= 0x8D41
	
RenderbufferStorage enum:
	STENCIL_INDEX1_EXT = 0x8D46
	STENCIL_INDEX4_EXT = 0x8D47
	STENCIL_INDEX8_EXT = 0x8D48
	STENCIL_INDEX16_EXT = 0x8D49
	
FramebufferErrorCode enum:
	FRAMEBUFFER_COMPLETE_EXT = 0x8CD5
	FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = 0x8CD6
	FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = 0x8CD7
	FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = 0x8CD9
	FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA
	FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = 0x8CDB
	FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = 0x8CDC
	FRAMEBUFFER_UNSUPPORTED_EXT = 0x8CDD

FramebufferAttachment enum:
	COLOR_ATTACHMENT0_EXT = 0x8CE0
	COLOR_ATTACHMENT1_EXT = 0x8CE1
	COLOR_ATTACHMENT2_EXT = 0x8CE2
	COLOR_ATTACHMENT3_EXT = 0x8CE3
	COLOR_ATTACHMENT4_EXT = 0x8CE4
	COLOR_ATTACHMENT5_EXT = 0x8CE5
	COLOR_ATTACHMENT6_EXT = 0x8CE6
	COLOR_ATTACHMENT7_EXT = 0x8CE7
	COLOR_ATTACHMENT8_EXT = 0x8CE8
	COLOR_ATTACHMENT9_EXT = 0x8CE9
	COLOR_ATTACHMENT10_EXT = 0x8CEA
	COLOR_ATTACHMENT11_EXT = 0x8CEB
	COLOR_ATTACHMENT12_EXT = 0x8CEC
	COLOR_ATTACHMENT13_EXT = 0x8CED
	COLOR_ATTACHMENT14_EXT = 0x8CEE
	COLOR_ATTACHMENT15_EXT = 0x8CEF
	DEPTH_ATTACHMENT_EXT = 0x8D00
	STENCIL_ATTACHMENT_EXT = 0x8D20

FramebufferParameterName enum:
	FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = 0x8CD0
	FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = 0x8CD1
	FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = 0x8CD2
	FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 0x8CD3
	FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = 0x8CD4

RenderbufferParameterName enum:
	RENDERBUFFER_WIDTH_EXT = 0x8D42
	RENDERBUFFER_HEIGHT_EXT = 0x8D43
	RENDERBUFFER_INTERNAL_FORMAT_EXT = 0x8D44
	RENDERBUFFER_RED_SIZE_EXT = 0x8D50
	RENDERBUFFER_GREEN_SIZE_EXT = 0x8D51
	RENDERBUFFER_BLUE_SIZE_EXT = 0x8D52
	RENDERBUFFER_ALPHA_SIZE_EXT = 0x8D53
	RENDERBUFFER_DEPTH_SIZE_EXT = 0x8D54
	RENDERBUFFER_STENCIL_SIZE_EXT = 0x8D55

GetPName enum:
	FRAMEBUFFER_BINDING_EXT           = 0x8CA6
	RENDERBUFFER_BINDING_EXT          = 0x8CA7
	MAX_COLOR_ATTACHMENTS_EXT         = 0x8CDF
	MAX_RENDERBUFFER_SIZE_EXT         = 0x84E8
          
ErrorCode enum:             
	INVALID_FRAMEBUFFER_OPERATION_EXT = 0x0506
	
# ARB_texture_buffer_object tokens
# Sections 2.9, 3.8.5 and 3.8.14 of the 3.2 specs.
# See also http://www.opentk.com/node/1313
BufferTarget enum:
    TEXTURE_BUFFER                  = 0x8C2A

TextureTarget enum:
    TEXTURE_BUFFER                  = 0x8C2A
	
	
# Version 3.2

# ARB_texture_multisample tokens
# http://www.opengl.org/registry/specs/ARB/texture_multisample.txt

TextureTargetMultisample enum:
	TEXTURE_2D_MULTISAMPLE = 0x9100
	PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101
	TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102
	PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103

EnableCap enum:
	SAMPLE_MASK = 0x8E51

GetMultisamplePName enum:
	SAMPLE_POSITION = 0x8E50
	
GetPName enum:
	SAMPLE_MASK = 0x8E51
	MAX_SAMPLE_MASK_WORDS = 0x8E59
	MAX_COLOR_TEXTURE_SAMPLES = 0x910E
	MAX_DEPTH_TEXTURE_SAMPLES = 0x910F
	MAX_INTEGER_SAMPLES = 0x9110
	TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104
	TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105

GetIndexedPName enum:
	SAMPLE_MASK_VALUE = 0x8E52

GetTextureParameter enum:
	TEXTURE_SAMPLES = 0x9106
	TEXTURE_FIXED_SAMPLE_LOCATIONS = 0x9107

TextureTarget enum:
	TEXTURE_2D_MULTISAMPLE = 0x9100
	PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101
	TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102
	PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103
	
ActiveUniformType enum:
	SAMPLER_2D_MULTISAMPLE = 0x9108
	INT_SAMPLER_2D_MULTISAMPLE = 0x9109
	UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = 0x910A
	SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910B
	INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910C
	UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910D

# ARB_geometry_shader4 tokens
# http://www.opengl.org/registry/specs/ARB/geometry_shader4.txt

ShaderType enum:
	GEOMETRY_SHADER = 0x8DD9
	
ProgramParameter enum:
	GEOMETRY_VERTICES_OUT = 0x8DDA
	GEOMETRY_INPUT_TYPE = 0x8DDB
	GEOMETRY_OUTPUT_TYPE = 0x8DDC
	
GetPName enum:
	MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29
	MAX_GEOMETRY_VARYING_COMPONENTS = 0x8DDD
	MAX_VERTEX_VARYING_COMPONENTS = 0x8DDE
	MAX_VARYING_COMPONENTS = 0x8B4B 
	MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF
	MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0
	MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1

BeginMode enum:
	LINES_ADJACENCY = 0xA
	LINE_STRIP_ADJACENCY = 0xB
	TRIANGLES_ADJACENCY = 0xC
	TRIANGLE_STRIP_ADJACENCY = 0xD

FramebufferErrorCode enum:
	FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8
	FRAMEBUFFER_INCOMPLETE_LAYER_COUNT = 0x8DA9

FramebufferParameterName enum:
	FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7
	FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4

EnableCap enum:
	PROGRAM_POINT_SIZE = 0x8642
	
GetPName enum:
	PROGRAM_POINT_SIZE = 0x8642
	
# ARB_depth_clamp tokens
# http://www.opengl.org/registry/specs/ARB/depth_clamp.txt

EnableCap enum:
	DEPTH_CLAMP = 0x864F

GetPName enum:
	DEPTH_CLAMP = 0x864F

# ARB_vertex_array_bgra tokens
# http://www.opengl.org/registry/specs/ARB/vertex_array_bgra.txt
# The following tokens are incorrect. They are valid for the <size>
# parameteter, not the <type> parameter - but <size> is not an enum!
# (Maybe something changed between the ARB spec and its core version?)
#ColorPointerType enum:
#	BGRA = 0x80E1

#VertexAttribPointerType enum:
#	BGRA = 0x80E1

# ARB_seamless_cube_map tokens
# http://www.opengl.org/registry/specs/ARB/seamless_cube_map.txt
EnableCap enum:
	TEXTURE_CUBE_MAP_SEAMLESS = 0x884F

GetPName enum:
	TEXTURE_CUBE_MAP_SEAMLESS = 0x884F

# ARB_provoking_vertex tokens
# http://www.opengl.org/registry/specs/ARB/provoking_vertex.txt

ProvokingVertexMode enum:
	FIRST_VERTEX_CONVENTION = 0x8E4D
	LAST_VERTEX_CONVENTION = 0x8E4E

GetPName enum:
	PROVOKING_VERTEX = 0x8E4F
	QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = 0x8E4C

# ARB_draw_elements_base_vertex tokens
# http://www.opengl.org/registry/specs/ARB/draw_elements_base_vertex.txt

# VertexAttribIPointerType (see OpenGL 3.2 reference card)
# Note: the underscore is there to avoid changing IPointer to Ipointer.
VertexAttribIPointerType enum:
	use DataType BYTE
	use DataType UNSIGNED_BYTE
	use DataType SHORT
	use DataType UNSIGNED_SHORT
	use DataType INT
	use DataType UNSIGNED_INT

# See OpenGL 3.2 reference card
TextureParameterName enum:
	TEXTURE_LOD_BIAS                = 0x8501

# See OpenGL 3.2 reference card
ActiveUniformParameter enum:
    use ARB_uniform_buffer_object       UNIFORM_TYPE
    use ARB_uniform_buffer_object       UNIFORM_SIZE
    use ARB_uniform_buffer_object       UNIFORM_NAME_LENGTH
    use ARB_uniform_buffer_object       UNIFORM_BLOCK_INDEX
    use ARB_uniform_buffer_object       UNIFORM_OFFSET
    use ARB_uniform_buffer_object       UNIFORM_ARRAY_STRIDE
    use ARB_uniform_buffer_object       UNIFORM_MATRIX_STRIDE
    use ARB_uniform_buffer_object       UNIFORM_IS_ROW_MAJOR


# End (don't remove, or the last token may be removed!)
