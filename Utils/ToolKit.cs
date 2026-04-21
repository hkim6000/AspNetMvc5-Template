using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using static AspNetMvc5.Utils.ApiRequest;
using static AspNetMvc5.Utils.ToolKit;

namespace AspNetMvc5.Utils
{
    public class ToolKit
    {

        public static class HtmlTags
        {
            public const string a = "a";
            public const string abbr = "abbr";
            public const string address = "address";
            public const string area = "area";
            public const string article = "article";
            public const string aside = "aside";
            public const string audio = "audio";
            public const string b = "b";
            public const string @base = "base";
            public const string bdi = "bdi";
            public const string bdo = "bdo";
            public const string blockquote = "blockquote";
            public const string body = "body";
            public const string br = "br";
            public const string button = "button";
            public const string canvas = "canvas";
            public const string caption = "caption";
            public const string cite = "cite";
            public const string code = "code";
            public const string col = "col";
            public const string colgroup = "colgroup";
            public const string data = "data";
            public const string datalist = "datalist";
            public const string dd = "dd";
            public const string del = "del";
            public const string details = "details";
            public const string dfn = "dfn";
            public const string dialog = "dialog";
            public const string div = "div";
            public const string dl = "dl";
            public const string dt = "dt";
            public const string em = "em";
            public const string embed = "embed ";
            public const string fieldset = "fieldset ";
            public const string figcaption = "figcaption";
            public const string figure = "figure";
            public const string footer = "footer";
            public const string form = "form";
            public const string h1 = "h1";
            public const string h2 = "h2";
            public const string h3 = "h3";
            public const string h4 = "h4";
            public const string h5 = "h5";
            public const string h6 = "h6";
            public const string head = "head";
            public const string header = "header";
            public const string hgroup = "hgroup";
            public const string hr = "hr";
            public const string html = "html";
            public const string i = "i";
            public const string iframe = "iframe";
            public const string img = "img";
            public const string input = "input";
            public const string ins = "ins";
            public const string kbd = "kbd";
            public const string label = "label";
            public const string legend = "legend";
            public const string li = "li";
            public const string link = "link";
            public const string main = "main";
            public const string map = "map";
            public const string mark = "mark";
            public const string menu = "menu";
            public const string meta = "meta";
            public const string meter = "meter";
            public const string nav = "nav";
            public const string noscript = "noscript";
            public const string @object = "object";
            public const string ol = "ol";
            public const string optgroup = "optgroup";
            public const string @option = "option";
            public const string output = "output";
            public const string p = "p";
            public const string param = "param";
            public const string picture = "picture";
            public const string pre = "pre";
            public const string progress = "progress";
            public const string q = "q";
            public const string rp = "rp";
            public const string rt = "rt";
            public const string ruby = "ruby";
            public const string s = "s";
            public const string samp = "samp";
            public const string script = "script";
            public const string search = "search";
            public const string section = "section";
            public const string @select = "select";
            public const string small = "small";
            public const string source = "source";
            public const string span = "span";
            public const string strong = "strong";
            public const string style = "style";
            public const string @sub = "sub";
            public const string summary = "summary";
            public const string sup = "sup";
            public const string svg = "svg";
            public const string table = "table";
            public const string tbody = "tbody";
            public const string td = "td";
            public const string template = "template";
            public const string textarea = "textarea";
            public const string tfoot = "tfoot";
            public const string th = "th";
            public const string thead = "thead";
            public const string time = "time";
            public const string title = "title";
            public const string tr = "tr";
            public const string track = "track";
            public const string u = "u";
            public const string ul = "ul";
            public const string @var = "var";
            public const string video = "video";
            public const string wbr = "wbr";
        }
        public static class HtmlAttributes
        {
            public const string accept = "accept";
            public const string acceptCharset = "accept-charset";
            public const string accesskey = "accesskey";
            public const string action = "action";
            public const string align = "align";
            public const string alt = "alt";
            public const string async = "async";
            public const string autocomplete = "autocomplete";
            public const string autofocus = "autofocus";
            public const string autoplay = "autoplay";
            public const string aria_checked = "aria-checked";
            public const string aria_disabled = "aria-disabled";
            public const string aria_expanded = "aria-expanded";
            public const string aria_hidden = "aria-hidden";
            public const string aria_invalid = "aria-invalid";
            public const string aria_label = "aria-label";
            public const string aria_live = "aria-live";
            public const string aria_required = "aria-required";
            public const string aria_controls = "aria-controls";
            public const string aria_describedby = "aria-describedby";
            public const string aria_labelledby = "aria-labelledby";
            public const string aria_owns = "aria-owns";
            public const string bgcolor = "bgcolor";
            public const string border = "border";
            public const string charset = "charset";
            public const string @checked = "checked";
            public const string cite = "cite";
            public const string @class = "class";
            public const string color = "color";
            public const string cols = "cols";
            public const string colspan = "colspan";
            public const string content = "content";
            public const string contenteditable = "contenteditable";
            public const string controls = "controls";
            public const string coords = "coords";
            public const string data_id = "data-id";
            public const string data_name = "data-name";
            public const string data_type = "data-type";
            public const string data_value = "data-value";
            public const string data_controlname = "data-controlname";
            public const string datetime = "datetime";
            public const string @default = "default";
            public const string defer = "defer";
            public const string dir = "dir";
            public const string dirname = "dirname";
            public const string disabled = "disabled";
            public const string download = "download";
            public const string draggable = "draggable";
            public const string enctype = "enctype";
            public const string @for = "for";
            public const string form = "form";
            public const string formaction = "formaction";
            public const string headers = "headers";
            public const string height = "height";
            public const string hidden = "hidden";
            public const string high = "high";
            public const string href = "href";
            public const string hreflang = "hreflang";
            public const string httpEquiv = "http-equiv";
            public const string id = "id";
            public const string ismap = "ismap";
            public const string kind = "kind";
            public const string label = "label";
            public const string lang = "lang";
            public const string list = "list";
            public const string @loop = "loop";
            public const string low = "low";
            public const string max = "max";
            public const string maxlength = "maxlength";
            public const string media = "media";
            public const string method = "method";
            public const string min = "min";
            public const string multiple = "multiple";
            public const string muted = "muted";
            public const string name = "name";
            public const string novalidate = "novalidate";
            public const string nonce = "nonce";
            public const string open = "open";
            public const string optimum = "optimum";
            public const string pattern = "pattern";
            public const string placeholder = "placeholder";
            public const string poster = "poster";
            public const string preload = "preload";
            public const string @readonly = "readonly";
            public const string rel = "rel";
            public const string required = "required";
            public const string reversed = "reversed";
            public const string rows = "rows";
            public const string rowspan = "rowspan";
            public const string sandbox = "sandbox";
            public const string scope = "scope";
            public const string selected = "selected";
            public const string shape = "shape";
            public const string size = "size";
            public const string sizes = "sizes";
            public const string span = "span";
            public const string spellcheck = "spellcheck";
            public const string src = "src";
            public const string srcdoc = "srcdoc";
            public const string srclang = "srclang";
            public const string srcset = "srcset";
            public const string start = "start";
            public const string @step = "step";
            public const string style = "style";
            public const string tabindex = "tabindex";
            public const string target = "target";
            public const string title = "title";
            public const string translate = "translate";
            public const string type = "type";
            public const string usemap = "usemap";
            public const string value = "value";
            public const string width = "width";
            public const string wrap = "wrap";
            public const string xmlns = "xmlns";

            public static string data(string name)
            {
                return "data-" + name;
            }

            public static string aria(string name)
            {
                return "aria-" + name;
            }
        }
        public static class HtmlStyles
        {
            public const string accentColor = "accent-color";
            public const string alignContent = "align-content";
            public const string alignItems = "align-items";
            public const string alignSelf = "align-self";
            public const string all = "all";
            public const string animation = "animation";
            public const string animationDelay = "animation-delay";
            public const string animationDirection = "animation-direction";
            public const string animationDuration = "animation-duration";
            public const string animationFillMode = "animation-fill-mode";
            public const string animationIterationCount = "animation-iteration-count";
            public const string animationName = "animation-name";
            public const string animationPlayState = "animation-play-state";
            public const string animationTimingFunction = "animation-timing-function";
            public const string aspectRatio = "aspect-ratio";

            public const string backdropFilter = "backdrop-filter";
            public const string backfaceVisibility = "backface-visibility";
            public const string background = "background";
            public const string backgroundAttachment = "background-attachment";
            public const string backgroundBlendMode = "background-blend-mode";
            public const string backgroundClip = "background-clip";
            public const string backgroundColor = "background-color";
            public const string backgroundImage = "background-image";
            public const string backgroundOrigin = "background-origin";
            public const string backgroundPosition = "background-position";
            public const string backgroundPositionX = "background-position-x";
            public const string backgroundPositionY = "background-position-y";
            public const string backgroundRepeat = "background-repeat";
            public const string backgroundSize = "background-size";
            public const string blockSize = "block-size";
            public const string border = "border";
            public const string borderBlock = "border-block";
            public const string borderBlockColor = "border-block-color";
            public const string borderBlockEnd = "border-block-end";
            public const string borderBlockEndColor = "border-block-end-color";
            public const string borderBlockEndStyle = "border-block-end-style";
            public const string borderBlockEndWidth = "border-block-end-width";
            public const string borderBlockStart = "border-block-start";
            public const string borderBlockStartColor = "border-block-start-color";
            public const string borderBlockStartStyle = "border-block-start-style";
            public const string borderBlockStartWidth = "border-block-start-width";
            public const string borderBlockStyle = "border-block-style";
            public const string borderBlockWidth = "border-block-width";
            public const string borderBottom = "border-bottom";
            public const string borderBottomColor = "border-bottom-color";
            public const string borderBottomLeftRadius = "border-bottom-left-radius";
            public const string borderBottomRightRadius = "border-bottom-right-radius";
            public const string borderBottomStyle = "border-bottom-style";
            public const string borderBottomWidth = "border-bottom-width";
            public const string borderCollapse = "border-collapse";
            public const string borderColor = "border-color";
            public const string borderEndEndRadius = "border-end-end-radius";
            public const string borderEndStartRadius = "border-end-start-radius";
            public const string borderImage = "border-image";
            public const string borderImageOutset = "border-image-outset";
            public const string borderImageRepeat = "border-image-repeat";
            public const string borderImageSlice = "border-image-slice";
            public const string borderImageSource = "border-image-source";
            public const string borderImageWidth = "border-image-width";
            public const string borderInline = "border-inline";
            public const string borderInlineColor = "border-inline-color";
            public const string borderInlineEnd = "border-inline-end";
            public const string borderInlineEndColor = "border-inline-end-color";
            public const string borderInlineEndStyle = "border-inline-end-style";
            public const string borderInlineEndWidth = "border-inline-end-width";
            public const string borderInlineStart = "border-inline-start";
            public const string borderInlineStartColor = "border-inline-start-color";
            public const string borderInlineStartStyle = "border-inline-start-style";
            public const string borderInlineStartWidth = "border-inline-start-width";
            public const string borderInlineStyle = "border-inline-style";
            public const string borderInlineWidth = "border-inline-width";
            public const string borderLeft = "border-left";
            public const string borderLeftColor = "border-left-color";
            public const string borderLeftStyle = "border-left-style";
            public const string borderLeftWidth = "border-left-width";
            public const string borderRadius = "border-radius";
            public const string borderRight = "border-right";
            public const string borderRightColor = "border-right-color";
            public const string borderRightStyle = "border-right-style";
            public const string borderRightWidth = "border-right-width";
            public const string borderSpacing = "border-spacing";
            public const string borderStartEndRadius = "border-start-end-radius";
            public const string borderStartStartRadius = "border-start-start-radius";
            public const string borderStyle = "border-style";
            public const string borderTop = "border-top";
            public const string borderTopColor = "border-top-color";
            public const string borderTopLeftRadius = "border-top-left-radius";
            public const string borderTopRightRadius = "border-top-right-radius";
            public const string borderTopStyle = "border-top-style";
            public const string borderTopWidth = "border-top-width";
            public const string borderWidth = "border-width";
            public const string bottom = "bottom";
            public const string boxDecorationBreak = "box-decoration-break";
            public const string boxReflect = "box-reflect";
            public const string boxShadow = "box-shadow";
            public const string boxSizing = "box-sizing";
            public const string breakAfter = "break-after";
            public const string breakBefore = "break-before";
            public const string breakInside = "break-inside";

            public const string captionSide = "caption-side";
            public const string caretColor = "caret-color";
            public const string charset = "@charset";
            public const string clear = "clear";
            public const string clip = "clip";
            public const string clipPath = "clip-path";
            public const string color = "color";
            public const string colorScheme = "color-scheme";
            public const string columnCount = "column-count";
            public const string columnFill = "column-fill";
            public const string columnGap = "column-gap";
            public const string columnRule = "column-rule";
            public const string columnRuleColor = "column-rule-color";
            public const string columnRuleStyle = "column-rule-style";
            public const string columnRuleWidth = "column-rule-width";
            public const string columnSpan = "column-span";
            public const string columnWidth = "column-width";
            public const string columns = "columns";
            public const string container = "@container";
            public const string content = "content";
            public const string counterIncrement = "counter-increment";
            public const string counterReset = "counter-reset";
            public const string counterStyle = "@counter-style";
            public const string cursor = "cursor";

            public const string direction = "direction";
            public const string display = "display";

            public const string emptyCells = "empty-cells";

            public const string filter = "filter";
            public const string flex = "flex";
            public const string flexBasis = "flex-basis";
            public const string flexDirection = "flex-direction";
            public const string flexFlow = "flex-flow";
            public const string flexGrow = "flex-grow";
            public const string flexShrink = "flex-shrink";
            public const string flexWrap = "flex-wrap";
            public const string @float = "float";
            public const string font = "font";
            public const string fontFace = "@font-face";
            public const string fontFamily = "font-family";
            public const string fontFeatureSettings = "font-feature-settings";
            public const string fontKerning = "font-kerning";
            public const string fontLanguageOverride = "font-language-override";
            public const string fontPaletteValues = "@font-palette-values";
            public const string fontSize = "font-size";
            public const string fontSizeAdjust = "font-size-adjust";
            public const string fontStretch = "font-stretch";
            public const string fontStyle = "font-style";
            public const string fontSynthesis = "font-synthesis";
            public const string fontVariant = "font-variant";
            public const string fontVariantAlternates = "font-variant-alternates";
            public const string fontVariantCaps = "font-variant-caps";
            public const string fontVariantEastAsian = "font-variant-east-asian";
            public const string fontVariantLigatures = "font-variant-ligatures";
            public const string fontVariantnumeric = "font-variant-numeric";
            public const string fontVariantPosition = "font-variant-position";
            public const string fontWeight = "font-weight";

            public const string gap = "gap";
            public const string grid = "grid";
            public const string gridArea = "grid-area";
            public const string gridAutoColumns = "grid-auto-columns";
            public const string gridAutoFlow = "grid-auto-flow";
            public const string gridAutoRows = "grid-auto-rows";
            public const string gridColumn = "grid-column";
            public const string gridColumnEnd = "grid-column-end";
            public const string gridColumnStart = "grid-column-start";
            public const string gridRow = "grid-row";
            public const string gridRowEnd = "grid-row-end";
            public const string gridRowStart = "grid-row-start";
            public const string gridTemplate = "grid-template";
            public const string gridTemplateAreas = "grid-template-areas";
            public const string gridTemplateColumns = "grid-template-columns";
            public const string gridTemplateRows = "grid-template-rows";

            public const string hangingPunctuation = "hanging-punctuation";
            public const string height = "height";
            public const string hyphens = "hyphens";
            public const string hyphenateCharacter = "hyphenate-character";

            public const string imageRendering = "image-rendering";
            public const string import = "@import";
            public const string initialLetter = "initial-letter";
            public const string inlineSize = "inline-size";
            public const string inset = "inset";
            public const string insetBlock = "inset-block";
            public const string insetBlockEnd = "inset-block-end";
            public const string insetBlockStart = "inset-block-start";
            public const string insetInline = "inset-inline";
            public const string insetInlineEnd = "inset-inline-end";
            public const string insetInlineStart = "inset-inline-start";
            public const string isolation = "isolation";

            public const string justifyContent = "justify-content";
            public const string justifyItems = "justify-items";
            public const string justifySelf = "justify-self";

            public const string keyframes = "@keyframes";

            public const string layer = "@layer";
            public const string left = "left";
            public const string letterSpacing = "letter-spacing";
            public const string lineBreak = "line-break";
            public const string lineHeight = "line-height";
            public const string listStyle = "list-style";
            public const string listStyleImage = "list-style-image";
            public const string listStylePosition = "list-style-position";
            public const string listStyleType = "list-style-type";

            public const string margin = "margin";
            public const string marginBlock = "margin-block";
            public const string marginBlockEnd = "margin-block-end";
            public const string marginBlockStart = "margin-block-start";
            public const string marginBottom = "margin-bottom";
            public const string marginInline = "margin-inline";
            public const string marginInlineEnd = "margin-inline-end";
            public const string marginInlineStart = "margin-inline-start";
            public const string marginLeft = "margin-left";
            public const string marginRight = "margin-right";
            public const string marginTop = "margin-top";
            public const string marker = "marker";
            public const string markerEnd = "marker-end";
            public const string markerMid = "marker-mid";
            public const string markerStart = "marker-start";
            public const string mask = "mask";
            public const string maskClip = "mask-clip";
            public const string maskComposite = "mask-composite";
            public const string maskImage = "mask-image";
            public const string maskMode = "mask-mode";
            public const string maskOrigin = "mask-origin";
            public const string maskPosition = "mask-position";
            public const string maskRepeat = "mask-repeat";
            public const string maskSize = "mask-size";
            public const string maskType = "mask-type";
            public const string maxHeight = "max-height";
            public const string maxWidth = "max-width";

            public const string media = "@media";
            public const string maxBlockSize = "max-block-size";
            public const string maxInlineSize = "max-inline-size";
            public const string minBlockSize = "min-block-size";
            public const string minInlineSize = "min-inline-size";
            public const string minHeight = "min-height";
            public const string minWidth = "min-width";
            public const string mixBlendMode = "mix-blend-mode";

            public const string @namespace = "@namespace";

            public const string objectFit = "object-fit";
            public const string objectPosition = "object-position";
            public const string offset = "offset";
            public const string offsetAnchor = "offset-anchor";
            public const string offsetDistance = "offset-distance";
            public const string offsetPath = "offset-path";
            public const string offsetPosition = "offset-position";
            public const string offsetRotate = "offset-rotate";
            public const string opacity = "opacity";
            public const string order = "order";
            public const string orphans = "orphans";
            public const string outline = "outline";
            public const string outlineColor = "outline-color";
            public const string outlineOffset = "outline-offset";
            public const string outlineStyle = "outline-style";
            public const string outlineWidth = "outline-width";
            public const string overflow = "overflow";
            public const string overflowAnchor = "overflow-anchor";
            public const string overflowWrap = "overflow-wrap";
            public const string overflowX = "overflow-x";
            public const string overflowY = "overflow-y";
            public const string overscrollBehavior = "overscroll-behavior";
            public const string overscrollBehaviorBlock = "overscroll-behavior-block";
            public const string overscrollBehaviorInline = "overscroll-behavior-inline";
            public const string overscrollBehaviorX = "overscroll-behavior-x";
            public const string overscrollBehaviorY = "overscroll-behavior-y";

            public const string padding = "padding";
            public const string paddingBlock = "padding-block";
            public const string paddingBlockEnd = "padding-block-end";
            public const string paddingBlockStart = "padding-block-start";
            public const string paddingBottom = "padding-bottom";
            public const string paddingInline = "padding-inline";
            public const string paddingInlineEnd = "padding-inline-end";
            public const string paddingInlineStart = "padding-inline-start";
            public const string paddingLeft = "padding-left";
            public const string paddingRight = "padding-right";
            public const string paddingTop = "padding-top";
            public const string page = "@page";
            public const string pageBreakAfter = "page-break-after";
            public const string pageBreakBefore = "page-break-before";
            public const string pageBreakInside = "page-break-inside";
            public const string paintOrder = "paint-order";
            public const string perspective = "perspective";
            public const string perspectiveOrigin = "perspective-origin";
            public const string placeContent = "place-content";
            public const string placeItems = "place-items";
            public const string placeSelf = "place-self";
            public const string pointerEvents = "pointer-events";
            public const string position = "position";
            public const string @property = "@property";

            public const string quotes = "quotes";

            public const string resize = "resize";
            public const string right = "right";
            public const string rotate = "rotate";
            public const string rowGap = "row-gap";

            public const string scale = "scale";
            public const string scope = "@scope";
            public const string scrollBehavior = "scroll-behavior";
            public const string scrollMargin = "scroll-margin";
            public const string scrollMarginBlock = "scroll-margin-block";
            public const string scrollMarginBlockEnd = "scroll-margin-block-end";
            public const string scrollMarginBlockStart = "scroll-margin-block-start";
            public const string scrollMarginBottom = "scroll-margin-bottom";
            public const string scrollMarginInline = "scroll-margin-inline";
            public const string scrollMarginInlineEnd = "scroll-margin-inline-end";
            public const string scrollMarginInlineStart = "scroll-margin-inline-start";
            public const string scrollMarginLeft = "scroll-margin-left";
            public const string scrollMarginRight = "scroll-margin-right";
            public const string scrollMarginTop = "scroll-margin-top";
            public const string scrollPadding = "scroll-padding";
            public const string scrollPaddingBlock = "scroll-padding-block";
            public const string scrollPaddingBlockEnd = "scroll-padding-block-end";
            public const string scrollPaddingBlockStart = "scroll-padding-block-start";
            public const string scrollPaddingBottom = "scroll-padding-bottom";
            public const string scrollPaddingInline = "scroll-padding-inline";
            public const string scrollPaddingInlineEnd = "scroll-padding-inline-end";
            public const string scrollPaddingInlineStart = "scroll-padding-inline-start";
            public const string scrollPaddingLeft = "scroll-padding-left";
            public const string scrollPaddingRight = "scroll-padding-right";
            public const string scrollPaddingTop = "scroll-padding-top";
            public const string scrollSnapAlign = "scroll-snap-align";
            public const string scrollSnapStop = "scroll-snap-stop";
            public const string scrollSnapType = "scroll-snap-type";
            public const string scrollbarColor = "scrollbar-color";
            public const string shapeOutside = "shape-outside";
            public const string startingStyle = "@starting-style";
            public const string supports = "@supports";

            public const string tabSize = "tab-size";
            public const string tableLayout = "table-layout";
            public const string textAlign = "text-align";
            public const string textAlignLast = "text-align-last";
            public const string textCombineUpright = "text-combine-upright";
            public const string textDecoration = "text-decoration";
            public const string textDecorationColor = "text-decoration-color";
            public const string textDecorationLine = "text-decoration-line";
            public const string textDecorationStyle = "text-decoration-style";
            public const string textDecorationThickness = "text-decoration-thickness";
            public const string textEmphasis = "text-emphasis";
            public const string textEmphasisColor = "text-emphasis-color";
            public const string textEmphasisPosition = "text-emphasis-position";
            public const string textEmphasisStyle = "text-emphasis-style";
            public const string textIndent = "text-indent";
            public const string textJustify = "text-justify";
            public const string textOverflow = "text-overflow";
            public const string textShadow = "text-shadow";
            public const string textTransform = "text-transform";
            public const string textUnderlineOffset = "text-underline-offset";
            public const string textUnderlinePosition = "text-underline-position";
            public const string top = "top";
            public const string transform = "transform";
            public const string transformOrigin = "transform-origin";
            public const string transformStyle = "transform-style";
            public const string transition = "transition";
            public const string transitionDelay = "transition-delay";
            public const string transitionDuration = "transition-duration";
            public const string transitionProperty = "transition-property";
            public const string transitionTimingFunction = "transition-timing-function";
            public const string translate = "translate";

            public const string unicodeBidi = "unicode-bidi";
            public const string userSelect = "user-select";

            public const string verticalAlign = "vertical-align";
            public const string visibility = "visibility";

            public const string whiteSpace = "white-space";
            public const string widows = "widows";
            public const string width = "width";
            public const string wordBreak = "word-break";
            public const string wordSpacing = "word-spacing";
            public const string wordWrap = "word-wrap";
            public const string writingMode = "writing-mode";

            public const string zIndex = "z-index";
            public const string zoom = "zoom";
        }
        public class HtmlTag
        {
            public enum Types
            {
                Regular = 0,
                Empty = 1
            }

            private const string tagReqular = "<[tag][0][1]>[2]</[tag]>[3]";
            private const string tagEmpty = "<[tag][0][1]/>[2]";

            private Types TagTemplate { get; set; } = Types.Regular;
            private string _TagName { get; set; } = HtmlTags.div;

            public string Tag => _TagName;
            public string IDTag { get; set; } = string.Empty;
            public string InnerText { get; set; } = string.Empty;
            public List<NameValue> Attributes { get; set; } = new List<NameValue>();
            public List<NameValue> Styles { get; set; } = new List<NameValue>();
            public string Css { get; set; } = string.Empty;

            public virtual string HtmlText => Html();

            public HtmlTag() { }

            public HtmlTag(string tagName, Types tagType = Types.Regular)
            {
                if (!string.IsNullOrEmpty(tagName)) _TagName = tagName;
                TagTemplate = tagType;
            }

            public HtmlTag(string tagName, string tagAttributes, string tagStyles, Types tagType = Types.Regular)
            {
                if (!string.IsNullOrEmpty(tagName)) _TagName = tagName;
                TagTemplate = tagType;
                SetStyles(tagStyles);
                SetAttributes(tagAttributes);
            }

            public void SetTag(string tagName, Types tagType = Types.Regular)
            {
                if (!string.IsNullOrEmpty(tagName)) _TagName = tagName;
                TagTemplate = tagType;
            }

            public void SetTagType(Types tagType) => TagTemplate = tagType;

            public void SetId(string id = "")
            {
                if (string.IsNullOrEmpty(GetAttribute(HtmlAttributes.id)))
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        SetAttribute(HtmlAttributes.id, "HT" + Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty));
                    }
                    else
                    {
                        SetAttribute(HtmlAttributes.id, id);
                    }
                }
            }

            public void SetAttribute(string name, string value)
            {
                Attributes = new List<NameValue>();
                string cleanName = name.Trim();
                string cleanValue = value.Trim();

                var attribute = Attributes.Find(x => x.name == cleanName);
                if (attribute == null)
                {
                    if (cleanValue != string.Empty)
                    {
                        Attributes.Add(new NameValue { name = cleanName, value = cleanValue });
                    }
                }
                else
                {
                    if (cleanValue == string.Empty)
                    {
                        Attributes.Remove(attribute);
                    }
                    else
                    {
                        attribute.value = cleanValue;
                    }
                }
            }

            public void SetAttributes(List<NameValue> nameValues)
            {
                if (nameValues == null || nameValues.Count == 0) return;
                foreach (var nv in nameValues)
                {
                    SetAttribute(nv.name, nv.value);
                }
            }

            public void SetAttributes(string attributeText)
            {
                if (string.IsNullOrEmpty(attributeText)) return;

                string[] pairs = attributeText.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string pair in pairs)
                {
                    string[] parts = pair.Split(':');
                    if (parts.Length >= 2)
                    {
                        string n = parts[0].Trim();
                        string v = parts[1].Trim();

                        if (v != string.Empty)
                        {
                            var attribute = Attributes.Find(x => x.name == n);
                            if (attribute == null)
                            {
                                Attributes.Add(new NameValue { name = n, value = v });
                            }
                            else
                            {
                                if (n.StartsWith("on", StringComparison.OrdinalIgnoreCase))
                                {
                                    attribute.value += ";" + v;
                                }
                                else
                                {
                                    attribute.value = v;
                                }
                            }
                        }
                    }
                }
            }

            public bool IsAttribute(string name)
            {
                Attributes = new List<NameValue>();
                return Attributes.Any(x => x.name == name.Trim());
            }

            public bool IsStyle(string name)
            {
                Styles = new List<NameValue>();
                return Styles.Any(x => x.name == name.Trim());
            }

            public void SetStyle(string name, string value)
            {
                Styles = new List<NameValue>();
                string cleanName = name.Trim();
                string cleanValue = value.Trim();

                var style = Styles.Find(x => x.name == cleanName);
                if (style == null)
                {
                    if (cleanValue != string.Empty)
                    {
                        Styles.Add(new NameValue { name = cleanName, value = cleanValue });
                    }
                }
                else
                {
                    if (cleanValue == string.Empty)
                    {
                        Styles.Remove(style);
                    }
                    else
                    {
                        style.value = cleanValue;
                    }
                }
            }

            public void SetStyles(List<NameValue> nameValues)
            {
                if (nameValues == null || nameValues.Count == 0) return;
                foreach (var nv in nameValues)
                {
                    SetStyle(nv.name, nv.value);
                }
            }

            public void SetStyles(string styleText)
            {
                if (string.IsNullOrEmpty(styleText)) return;
                string[] pairs = styleText.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string pair in pairs)
                {
                    string[] parts = pair.Split(':');
                    if (parts.Length >= 2)
                    {
                        SetStyle(parts[0], parts[1]);
                    }
                }
            }

            public string GetAttribute(string name)
            {
                if (Attributes == null) return string.Empty;
                return Attributes.Find(x => x.name == name)?.value ?? string.Empty;
            }

            public string GetAttributes()
            {
                List<string> result = new List<string>();
                foreach (var attr in Attributes)
                {
                    if (attr.name.Equals(HtmlAttributes.alt, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add($"{attr.name}=\"{attr.value}\"");
                    }
                    else if (!string.IsNullOrWhiteSpace(attr.value))
                    {
                        result.Add($"{attr.name}=\"{attr.value}\"");
                    }
                }
                return string.Join(" ", result);
            }

            public string GetStyle(string name)
            {
                if (Styles == null) return string.Empty;
                return Styles.Find(x => x.name == name)?.value ?? string.Empty;
            }

            public string GetStyles()
            {
                List<string> result = new List<string>();
                foreach (var style in Styles)
                {
                    if (!string.IsNullOrEmpty(style.value))
                    {
                        result.Add($"{style.name}:{style.value};");
                    }
                }
                return string.Join(" ", result);
            }

            public void RemoveAttribute(string name)
            {
                Attributes?.RemoveAll(x => x.name == name);
            }

            public void RemoveStyle(string name)
            {
                Styles?.RemoveAll(x => x.name == name);
            }

            public void ClearAttributes() => Attributes?.Clear();
            public void ClearStyles() => Styles?.Clear();

            public void ClearAll()
            {
                InnerText = string.Empty;
                Css = string.Empty;
                Attributes?.Clear();
                Styles?.Clear();
            }

            public virtual string Html()
            {
                if (string.Equals(_TagName, HtmlTags.img, StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(GetAttribute(HtmlAttributes.alt)))
                {
                    SetAttribute(HtmlAttributes.alt, string.Empty);
                }

                string attrStr = GetAttributes();
                string styleStr = GetStyles();
                string template = (TagTemplate == Types.Regular) ? tagReqular : tagEmpty;

                return template.Replace("[tag]", Tag)
                               .Replace("[0]", string.IsNullOrEmpty(attrStr) ? string.Empty : " " + attrStr + " ")
                               .Replace("[1]", string.IsNullOrEmpty(styleStr) ? string.Empty : " style=\"" + styleStr + "\" ")
                               .Replace("[2]", InnerText)
                               .Replace("[3]", string.IsNullOrEmpty(Css) ? string.Empty : " <style>" + Css + "</style> ");
            }

            ~HtmlTag()
            {
                // Finalizer logic
            }
        }
        public class Grid
        {
            public string IDTag { get; set; } = string.Empty;
            public bool HideHeaders { get; set; } = false;
            public List<Column> Headers { get; set; } = new List<Column>();
            public List<Column> Columns { get; set; } = new List<Column>();
            public List<Row> Rows { get; set; } = new List<Row>();
            public HtmlTag Table { get; set; } = new HtmlTag(HtmlTags.table);
            private DataTable data = null;

            public string HtmlText => HtmlContents();

            public Grid()
            {
                Table.SetAttribute(HtmlAttributes.data_controlname, "Grid.Table");
                Table.SetStyle(HtmlStyles.width, "100%");
            }

            public Grid(DataTable dataTable, bool hideHeader = false) : this()
            {
                HideHeaders = hideHeader;
                DataSource(dataTable);
            }

            public void AddColumn(string colName)
            {
                Headers.Add(new Column { InnerText = colName });
                Columns.Add(new Column());
            }

            public void RemoveColumn(int colIndex)
            {
                Headers.RemoveAt(colIndex);
                Columns.RemoveAt(colIndex);
            }

            public void RemoveRow(int rowIndex) => Rows.RemoveAt(rowIndex);

            public void AddRow(string[] rowData)
            {
                if (rowData == null) return;
                var row = new Row();
                foreach (var text in rowData)
                {
                    row.Columns.Add(new Column { InnerText = text });
                }
                Rows.Add(row);
            }

            public void DataSource(DataTable dataTable)
            {
                Headers.Clear();
                Rows.Clear();
                Columns.Clear();
                data = dataTable;

                foreach (DataColumn dc in dataTable.Columns)
                {
                    AddColumn(dc.ColumnName);
                }

                foreach (DataRow dr in dataTable.Rows)
                {
                    var row = new Row();
                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        row.Columns.Add(new Column { InnerText = dr[dc].ToString() ?? string.Empty });
                    }
                    Rows.Add(row);
                }
            }

            #region Styles and Attributes Setters
            public void SetColumnStyle(int colIndex, string style, string value) => Columns[colIndex].SetStyle(style, value);
            public void SetColumnStyles(int colIndex, string styles) => Columns[colIndex].SetStyles(styles);
            public void SetColumnAttribute(int colIndex, string attribute, string value) => Columns[colIndex].SetAttribute(attribute, value);
            public void SetColumnAttributes(int colIndex, string attributes) => Columns[colIndex].SetAttributes(attributes);
            public void SetHeaderStyle(int headerIndex, string style, string value) => Headers[headerIndex].SetStyle(style, value);
            public void SetHeaderStyles(int headerIndex, string styles) => Headers[headerIndex].SetStyles(styles);
            public void SetHeaderAttribute(int headerIndex, string attribute, string value) => Headers[headerIndex].SetAttribute(attribute, value);
            public void SetHeaderAttributes(int headerIndex, string attributes) => Headers[headerIndex].SetAttributes(attributes);
            public void SetRowAttribute(int rowIndex, string attribute, string value) => Rows[rowIndex].SetAttribute(attribute, value);
            public void SetRowAttributes(int rowIndex, string attributes) => Rows[rowIndex].SetAttributes(attributes);
            public void SetRowStyle(int rowIndex, string style, string value) => Rows[rowIndex].SetStyle(style, value);
            public void SetRowStyles(int rowIndex, string styles) => Rows[rowIndex].SetStyles(styles);
            #endregion

            private string HtmlContents()
            {
                if (data == null)
                {
                    data = new DataTable();
                    foreach (var h in Headers) data.Columns.Add(h.InnerText);
                    foreach (var r in Rows)
                    {
                        var dr = data.NewRow();
                        for (int j = 0; j < Headers.Count; j++) dr[j] = r.Columns[j].InnerText;
                        data.Rows.Add(dr);
                    }
                }

                StringBuilder trHtmlBuilder = new StringBuilder();

                // Headers
                if (!HideHeaders)
                {
                    var trh = new TR();
                    StringBuilder ths = new StringBuilder();
                    foreach (var h in Headers)
                    {
                        var th = new TH { InnerText = h.InnerText };
                        h.Styles.ForEach(s => th.SetStyle(s.name, s.value));
                        h.Attributes.ForEach(a => th.SetAttribute(a.name, a.value));
                        ths.Append(th.Html());
                    }
                    trh.InnerText = ths.ToString();
                    trHtmlBuilder.Append(trh.Html());
                }

                // Rows
                for (int i = 0; i < Rows.Count; i++)
                {
                    var trd = new TR();
                    StringBuilder tds = new StringBuilder();
                    for (int j = 0; j < Columns.Count; j++)
                    {
                        var td = new TD();
                        td.InnerText = ReplaceValueInner(Rows[i].Columns[j].InnerText, i, j);
                        td.SetStyles(Rows[i].Columns[j].Styles);
                        td.SetAttributes(Rows[i].Columns[j].Attributes);
                        td.SetStyles(Columns[j].Styles);
                        td.SetAttributes(Columns[j].Attributes);
                        tds.Append(ReplaceValue(td.Html(), i, j));
                    }
                    trd.InnerText = tds.ToString();
                    trHtmlBuilder.Append(trd.Html());
                }

                Table.InnerText = trHtmlBuilder.ToString();
                return Table.Html();
            }

            private string ReplaceValue(string vlu, int rowIndex, int colIndex)
            {
                Regex regex = new Regex("{([0-9]*)}");
                vlu = regex.Replace(vlu, m => {
                    int idx = int.Parse(m.Groups[1].Value);
                    return data?.Rows[rowIndex][idx].ToString() ?? string.Empty;
                });

                return vlu.Replace("{colname}", Headers[colIndex].InnerText)
                          .Replace("{colvalue}", Rows[rowIndex].Columns[colIndex].InnerText)
                          .Replace("{colindex}", colIndex.ToString())
                          .Replace("{rowindex}", rowIndex.ToString());
            }

            private string ReplaceValueInner(string vlu, int rowIndex, int colIndex)
            {
                string originValue = data?.Rows[rowIndex][colIndex].ToString() ?? string.Empty;
                vlu = ReplaceValue(vlu, rowIndex, colIndex);

                if (IsFormattedValue(vlu))
                {
                    vlu = FormattedValue(vlu, originValue);
                    vlu = RemoveFormatted(vlu);
                }
                return vlu;
            }

            private bool IsFormattedValue(string Value)
            {
                string v = Value.ToLower();
                return v.StartsWith("@d ") || v.StartsWith("@f ") || v.StartsWith("@c ") ||
                       v.StartsWith("@e ") || v.StartsWith("@s ") || v.StartsWith("@r ");
            }
            private string RemoveFormatted(string Value)
            {
                return IsFormattedValue(Value) ? string.Empty : Value;
            }
            private string FormattedValue(string Value, string originValue = "")
            {
                string VValue = string.Empty;
                DataTable data = new DataTable();
                bool fbool = false;
                List<string> fmls = Value.Split('&').Select(x => x.Trim()).ToList();

                foreach (var fml in fmls)
                {
                    string lowerFml = fml.ToLower();
                    if (lowerFml.StartsWith("@c"))
                    {
                        string vcal = fml.Substring(2).Trim();
                        try { VValue += data.Compute(vcal, "").ToString(); fbool = true; } catch { }
                    }
                    else if (lowerFml.StartsWith("@f"))
                    {
                        string vcal = fml.Substring(2).Trim();
                        string[] parts = vcal.Split('|');
                        if (parts.Length == 2)
                        {
                            try { VValue += double.Parse(parts[0].Trim()).ToString(parts[1].Trim()); fbool = true; } catch { }
                        }
                    }
                    else if (lowerFml.StartsWith("@d"))
                    {
                        string vcal = fml.Substring(2).Trim();
                        string[] parts = vcal.Split('|');
                        if (parts.Length == 2)
                        {
                            try { VValue += DateTime.Parse(parts[0].Trim()).ToString(parts[1].Trim()); fbool = true; } catch { }
                        }
                    }
                    else if (lowerFml.StartsWith("@r"))
                    {
                        string vcal = fml.Substring(2).Trim();
                        string[] parts = vcal.Split('|');
                        if (parts.Length == 2)
                        {
                            string p1 = parts[0].Trim().ToLower();
                            foreach (string pair in parts[1].Split(','))
                            {
                                string[] m = pair.Split('.');
                                if (m[0].Trim().ToLower() == p1) { VValue += m.Last(); fbool = true; break; }
                            }
                        }
                    }
                }

                var styleFml = fmls.FirstOrDefault(x => x.ToLower().StartsWith("@s"));
                if (styleFml != null)
                {
                    string vcal = styleFml.Substring(2).Trim();
                    string[] parts = vcal.Split('|');
                    if (parts.Length == 2)
                    {
                        string p1 = parts[0].Trim().ToLower();
                        string currentVal = (string.IsNullOrEmpty(VValue) && !fbool) ? originValue : VValue;
                        foreach (string pair in parts[1].Split(','))
                        {
                            string[] m = pair.Split('.');
                            if (m[0].Trim().ToLower() == p1) { VValue = $"<div style=\"{m.Last().Trim()}\">{currentVal}</div>"; break; }
                        }
                    }
                }

                return string.IsNullOrEmpty(VValue) ? Value : VValue;
            }

            [Serializable] public class Row : HtmlTag { public List<Column> Columns { get; set; } = new List<Column>(); public Row() : base("tr") { } }
            [Serializable] public class Column : HtmlTag { public Column() : base("td") { } }
            protected class TR : HtmlTag { public TR() : base("tr") { } }
            protected class TH : HtmlTag { public TH() : base("th") { } }
            protected class TD : HtmlTag { public TD() : base("td") { } }
        }

    }
}