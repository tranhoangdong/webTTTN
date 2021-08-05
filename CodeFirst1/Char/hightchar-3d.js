﻿/*
 Highcharts JS v8.1.0 (2020-05-05)

 3D features for Highcharts JS

 License: www.highcharts.com/license
*/
(function (g) { "object" === typeof module && module.exports ? (g["default"] = g, module.exports = g) : "function" === typeof define && define.amd ? define("highcharts/highcharts-3d", ["highcharts"], function (y) { g(y); g.Highcharts = y; return g }) : g("undefined" !== typeof Highcharts ? Highcharts : void 0) })(function (g) {
    function y(r, c, p, x) { r.hasOwnProperty(c) || (r[c] = x.apply(null, p)) } g = g ? g._modules : {}; y(g, "parts-3d/Math.js", [g["parts/Globals.js"], g["parts/Utilities.js"]], function (r, c) {
        var p = c.pick, x = r.deg2rad; r.perspective3D = function (p,
            c, e) { c = 0 < e && e < Number.POSITIVE_INFINITY ? e / (p.z + c.z + e) : 1; return { x: p.x * c, y: p.y * c } }; r.perspective = function (m, c, e, A) {
                var w = c.options.chart.options3d, t = p(A, e ? c.inverted : !1), q = { x: c.plotWidth / 2, y: c.plotHeight / 2, z: w.depth / 2, vd: p(w.depth, 1) * p(w.viewDistance, 0) }, z = c.scale3d || 1; A = x * w.beta * (t ? -1 : 1); w = x * w.alpha * (t ? -1 : 1); var C = Math.cos(w), n = Math.cos(-A), b = Math.sin(w), h = Math.sin(-A); e || (q.x += c.plotLeft, q.y += c.plotTop); return m.map(function (a) {
                    var d = (t ? a.y : a.x) - q.x; var l = (t ? a.x : a.y) - q.y; a = (a.z || 0) - q.z; d = {
                        x: n * d - h *
                            a, y: -b * h * d + C * l - n * b * a, z: C * h * d + b * l + C * n * a
                    }; l = r.perspective3D(d, q, q.vd); l.x = l.x * z + q.x; l.y = l.y * z + q.y; l.z = d.z * z + q.z; return { x: t ? l.y : l.x, y: t ? l.x : l.y, z: l.z }
                })
            }; r.pointCameraDistance = function (m, c) { var e = c.options.chart.options3d, r = c.plotWidth / 2; c = c.plotHeight / 2; e = p(e.depth, 1) * p(e.viewDistance, 0) + e.depth; return Math.sqrt(Math.pow(r - p(m.plotX, m.x), 2) + Math.pow(c - p(m.plotY, m.y), 2) + Math.pow(e - p(m.plotZ, m.z), 2)) }; r.shapeArea = function (p) {
                var c = 0, e; for (e = 0; e < p.length; e++) {
                    var m = (e + 1) % p.length; c += p[e].x * p[m].y - p[m].x *
                        p[e].y
                } return c / 2
            }; r.shapeArea3d = function (p, c, e) { return r.shapeArea(r.perspective(p, c, e)) }
    }); y(g, "parts-3d/SVGRenderer.js", [g["parts/Globals.js"], g["parts/Utilities.js"]], function (r, c) {
        function p(a, b, f, F, h, D, E, l) {
            var k = [], u = D - h; return D > h && D - h > Math.PI / 2 + .0001 ? (k = k.concat(p(a, b, f, F, h, h + Math.PI / 2, E, l)), k = k.concat(p(a, b, f, F, h + Math.PI / 2, D, E, l))) : D < h && h - D > Math.PI / 2 + .0001 ? (k = k.concat(p(a, b, f, F, h, h - Math.PI / 2, E, l)), k = k.concat(p(a, b, f, F, h - Math.PI / 2, D, E, l))) : [["C", a + f * Math.cos(h) - f * d * u * Math.sin(h) + E, b + F * Math.sin(h) +
                F * d * u * Math.cos(h) + l, a + f * Math.cos(D) + f * d * u * Math.sin(D) + E, b + F * Math.sin(D) - F * d * u * Math.cos(D) + l, a + f * Math.cos(D) + E, b + F * Math.sin(D) + l]]
        } var x = c.animObject, m = c.defined, g = c.extend, e = c.merge, A = c.objectEach, w = c.pick, t = Math.cos, q = Math.PI, z = Math.sin, C = r.charts, n = r.color, b = r.deg2rad, h = r.perspective, a = r.SVGElement; c = r.SVGRenderer; var d = 4 * (Math.sqrt(2) - 1) / 3 / (q / 2); c.prototype.toLinePath = function (a, b) { var f = []; a.forEach(function (a) { f.push(["L", a.x, a.y]) }); a.length && (f[0][0] = "M", b && f.push(["Z"])); return f }; c.prototype.toLineSegments =
            function (a) { var b = [], f = !0; a.forEach(function (a) { b.push(f ? ["M", a.x, a.y] : ["L", a.x, a.y]); f = !f }); return b }; c.prototype.face3d = function (b) {
                var k = this, f = this.createElement("path"); f.vertexes = []; f.insidePlotArea = !1; f.enabled = !0; f.attr = function (f) {
                    if ("object" === typeof f && (m(f.enabled) || m(f.vertexes) || m(f.insidePlotArea))) {
                    this.enabled = w(f.enabled, this.enabled); this.vertexes = w(f.vertexes, this.vertexes); this.insidePlotArea = w(f.insidePlotArea, this.insidePlotArea); delete f.enabled; delete f.vertexes; delete f.insidePlotArea;
                        var b = h(this.vertexes, C[k.chartIndex], this.insidePlotArea), d = k.toLinePath(b, !0); b = r.shapeArea(b); b = this.enabled && 0 < b ? "visible" : "hidden"; f.d = d; f.visibility = b
                    } return a.prototype.attr.apply(this, arguments)
                }; f.animate = function (f) {
                    if ("object" === typeof f && (m(f.enabled) || m(f.vertexes) || m(f.insidePlotArea))) {
                    this.enabled = w(f.enabled, this.enabled); this.vertexes = w(f.vertexes, this.vertexes); this.insidePlotArea = w(f.insidePlotArea, this.insidePlotArea); delete f.enabled; delete f.vertexes; delete f.insidePlotArea;
                        var b = h(this.vertexes, C[k.chartIndex], this.insidePlotArea), d = k.toLinePath(b, !0); b = r.shapeArea(b); b = this.enabled && 0 < b ? "visible" : "hidden"; f.d = d; this.attr("visibility", b)
                    } return a.prototype.animate.apply(this, arguments)
                }; return f.attr(b)
            }; c.prototype.polyhedron = function (b) {
                var d = this, f = this.g(), k = f.destroy; this.styledMode || f.attr({ "stroke-linejoin": "round" }); f.faces = []; f.destroy = function () { for (var a = 0; a < f.faces.length; a++)f.faces[a].destroy(); return k.call(this) }; f.attr = function (b, k, h, l) {
                    if ("object" ===
                        typeof b && m(b.faces)) { for (; f.faces.length > b.faces.length;)f.faces.pop().destroy(); for (; f.faces.length < b.faces.length;)f.faces.push(d.face3d().add(f)); for (var u = 0; u < b.faces.length; u++)d.styledMode && delete b.faces[u].fill, f.faces[u].attr(b.faces[u], null, h, l); delete b.faces } return a.prototype.attr.apply(this, arguments)
                }; f.animate = function (b, k, h) {
                    if (b && b.faces) {
                        for (; f.faces.length > b.faces.length;)f.faces.pop().destroy(); for (; f.faces.length < b.faces.length;)f.faces.push(d.face3d().add(f)); for (var u = 0; u <
                            b.faces.length; u++)f.faces[u].animate(b.faces[u], k, h); delete b.faces
                    } return a.prototype.animate.apply(this, arguments)
                }; return f.attr(b)
            }; var l = {
                initArgs: function (a) { var b = this, f = b.renderer, d = f[b.pathType + "Path"](a), k = d.zIndexes; b.parts.forEach(function (a) { b[a] = f.path(d[a]).attr({ "class": "highcharts-3d-" + a, zIndex: k[a] || 0 }).add(b) }); b.attr({ "stroke-linejoin": "round", zIndex: k.group }); b.originalDestroy = b.destroy; b.destroy = b.destroyParts; b.forcedSides = d.forcedSides }, singleSetterForParts: function (a, b, f,
                    d, h, l) { var k = {}; d = [null, null, d || "attr", h, l]; var u = f && f.zIndexes; f ? (u && u.group && this.attr({ zIndex: u.group }), A(f, function (b, d) { k[d] = {}; k[d][a] = b; u && (k[d].zIndex = f.zIndexes[d] || 0) }), d[1] = k) : (k[a] = b, d[0] = k); return this.processParts.apply(this, d) }, processParts: function (a, b, f, d, h) { var k = this; k.parts.forEach(function (l) { b && (a = w(b[l], !1)); if (!1 !== a) k[l][f](a, d, h) }); return k }, destroyParts: function () { this.processParts(null, null, "destroy"); return this.originalDestroy() }
            }; var v = e(l, {
                parts: ["front", "top", "side"],
                pathType: "cuboid", attr: function (b, d, f, h) { if ("string" === typeof b && "undefined" !== typeof d) { var k = b; b = {}; b[k] = d } return b.shapeArgs || m(b.x) ? this.singleSetterForParts("d", null, this.renderer[this.pathType + "Path"](b.shapeArgs || b)) : a.prototype.attr.call(this, b, void 0, f, h) }, animate: function (b, d, f) {
                    if (m(b.x) && m(b.y)) {
                        b = this.renderer[this.pathType + "Path"](b); var k = b.forcedSides; this.singleSetterForParts("d", null, b, "animate", d, f); this.attr({ zIndex: b.zIndexes.group }); k !== this.forcedSides && (this.forcedSides = k,
                            v.fillSetter.call(this, this.fill))
                    } else a.prototype.animate.call(this, b, d, f); return this
                }, fillSetter: function (a) { this.forcedSides = this.forcedSides || []; this.singleSetterForParts("fill", null, { front: a, top: n(a).brighten(0 <= this.forcedSides.indexOf("top") ? 0 : .1).get(), side: n(a).brighten(0 <= this.forcedSides.indexOf("side") ? 0 : -.1).get() }); this.color = this.fill = a; return this }
            }); c.prototype.elements3d = { base: l, cuboid: v }; c.prototype.element3d = function (a, b) {
                var f = this.g(); g(f, this.elements3d[a]); f.initArgs(b);
                return f
            }; c.prototype.cuboid = function (a) { return this.element3d("cuboid", a) }; r.SVGRenderer.prototype.cuboidPath = function (a) {
                function b(a) { return 0 === E && 1 < a && 6 > a ? { x: e[a].x, y: e[a].y + 10, z: e[a].z } : e[0].x === e[7].x && 4 <= a ? { x: e[a].x + 10, y: e[a].y, z: e[a].z } : 0 === n && 2 > a || 5 < a ? { x: e[a].x, y: e[a].y, z: e[a].z + 10 } : e[a] } function f(a) { return e[a] } var d = a.x, k = a.y, l = a.z || 0, E = a.height, v = a.width, n = a.depth, p = C[this.chartIndex], c = p.options.chart.options3d.alpha, q = 0, e = [{ x: d, y: k, z: l }, { x: d + v, y: k, z: l }, { x: d + v, y: k + E, z: l }, {
                    x: d, y: k + E,
                    z: l
                }, { x: d, y: k + E, z: l + n }, { x: d + v, y: k + E, z: l + n }, { x: d + v, y: k, z: l + n }, { x: d, y: k, z: l + n }], z = []; e = h(e, p, a.insidePlotArea); var m = function (a, d, k) { var h = [[], -1], l = a.map(f), u = d.map(f); a = a.map(b); d = d.map(b); 0 > r.shapeArea(l) ? h = [l, 0] : 0 > r.shapeArea(u) ? h = [u, 1] : k && (z.push(k), h = 0 > r.shapeArea(a) ? [l, 0] : 0 > r.shapeArea(d) ? [u, 1] : [l, 0]); return h }; var t = m([3, 2, 1, 0], [7, 6, 5, 4], "front"); a = t[0]; var w = t[1]; t = m([1, 6, 7, 0], [4, 5, 2, 3], "top"); v = t[0]; var g = t[1]; t = m([1, 2, 5, 6], [0, 7, 4, 3], "side"); m = t[0]; t = t[1]; 1 === t ? q += 1E6 * (p.plotWidth - d) : t || (q +=
                    1E6 * d); q += 10 * (!g || 0 <= c && 180 >= c || 360 > c && 357.5 < c ? p.plotHeight - k : 10 + k); 1 === w ? q += 100 * l : w || (q += 100 * (1E3 - l)); return { front: this.toLinePath(a, !0), top: this.toLinePath(v, !0), side: this.toLinePath(m, !0), zIndexes: { group: Math.round(q) }, forcedSides: z, isFront: w, isTop: g }
            }; r.SVGRenderer.prototype.arc3d = function (d) {
                function h(a) { var b = !1, f = {}, d; a = e(a); for (d in a) -1 !== l.indexOf(d) && (f[d] = a[d], delete a[d], b = !0); return b ? f : !1 } var f = this.g(), k = f.renderer, l = "x y r innerR start end depth".split(" "); d = e(d); d.alpha = (d.alpha ||
                    0) * b; d.beta = (d.beta || 0) * b; f.top = k.path(); f.side1 = k.path(); f.side2 = k.path(); f.inn = k.path(); f.out = k.path(); f.onAdd = function () { var a = f.parentGroup, b = f.attr("class"); f.top.add(f);["out", "inn", "side1", "side2"].forEach(function (d) { f[d].attr({ "class": b + " highcharts-3d-side" }).add(a) }) };["addClass", "removeClass"].forEach(function (a) { f[a] = function () { var b = arguments;["top", "out", "inn", "side1", "side2"].forEach(function (d) { f[d][a].apply(f[d], b) }) } }); f.setPaths = function (a) {
                        var b = f.renderer.arc3dPath(a), d = 100 *
                            b.zTop; f.attribs = a; f.top.attr({ d: b.top, zIndex: b.zTop }); f.inn.attr({ d: b.inn, zIndex: b.zInn }); f.out.attr({ d: b.out, zIndex: b.zOut }); f.side1.attr({ d: b.side1, zIndex: b.zSide1 }); f.side2.attr({ d: b.side2, zIndex: b.zSide2 }); f.zIndex = d; f.attr({ zIndex: d }); a.center && (f.top.setRadialReference(a.center), delete a.center)
                    }; f.setPaths(d); f.fillSetter = function (a) {
                        var b = n(a).brighten(-.1).get(); this.fill = a; this.side1.attr({ fill: b }); this.side2.attr({ fill: b }); this.inn.attr({ fill: b }); this.out.attr({ fill: b }); this.top.attr({ fill: a });
                        return this
                    };["opacity", "translateX", "translateY", "visibility"].forEach(function (a) { f[a + "Setter"] = function (a, b) { f[b] = a;["out", "inn", "side1", "side2", "top"].forEach(function (d) { f[d].attr(b, a) }) } }); f.attr = function (b) { var d; "object" === typeof b && (d = h(b)) && (g(f.attribs, d), f.setPaths(f.attribs)); return a.prototype.attr.apply(f, arguments) }; f.animate = function (b, d, k) {
                        var l = this.attribs, u = "data-" + Math.random().toString(26).substring(2, 9); delete b.center; delete b.z; delete b.alpha; delete b.beta; var v = x(w(d, this.renderer.globalAnimation));
                        if (v.duration) { var F = h(b); f[u] = 0; b[u] = 1; f[u + "Setter"] = r.noop; F && (v.step = function (a, b) { function d(a) { return l[a] + (w(F[a], l[a]) - l[a]) * b.pos } b.prop === u && b.elem.setPaths(e(l, { x: d("x"), y: d("y"), r: d("r"), innerR: d("innerR"), start: d("start"), end: d("end"), depth: d("depth") })) }); d = v } return a.prototype.animate.call(this, b, d, k)
                    }; f.destroy = function () { this.top.destroy(); this.out.destroy(); this.inn.destroy(); this.side1.destroy(); this.side2.destroy(); return a.prototype.destroy.call(this) }; f.hide = function () {
                        this.top.hide();
                        this.out.hide(); this.inn.hide(); this.side1.hide(); this.side2.hide()
                    }; f.show = function (a) { this.top.show(a); this.out.show(a); this.inn.show(a); this.side1.show(a); this.side2.show(a) }; return f
            }; c.prototype.arc3dPath = function (a) {
                function b(a) { a %= 2 * Math.PI; a > Math.PI && (a = 2 * Math.PI - a); return a } var d = a.x, h = a.y, l = a.start, k = a.end - .00001, v = a.r, n = a.innerR || 0, c = a.depth || 0, e = a.alpha, m = a.beta, w = Math.cos(l), C = Math.sin(l); a = Math.cos(k); var r = Math.sin(k), g = v * Math.cos(m); v *= Math.cos(e); var x = n * Math.cos(m), A = n * Math.cos(e);
                n = c * Math.sin(m); var B = c * Math.sin(e); c = [["M", d + g * w, h + v * C]]; c = c.concat(p(d, h, g, v, l, k, 0, 0)); c.push(["L", d + x * a, h + A * r]); c = c.concat(p(d, h, x, A, k, l, 0, 0)); c.push(["Z"]); var H = 0 < m ? Math.PI / 2 : 0; m = 0 < e ? 0 : Math.PI / 2; H = l > -H ? l : k > -H ? -H : l; var y = k < q - m ? k : l < q - m ? q - m : k, G = 2 * q - m; e = [["M", d + g * t(H), h + v * z(H)]]; e = e.concat(p(d, h, g, v, H, y, 0, 0)); k > G && l < G ? (e.push(["L", d + g * t(y) + n, h + v * z(y) + B]), e = e.concat(p(d, h, g, v, y, G, n, B)), e.push(["L", d + g * t(G), h + v * z(G)]), e = e.concat(p(d, h, g, v, G, k, 0, 0)), e.push(["L", d + g * t(k) + n, h + v * z(k) + B]), e = e.concat(p(d,
                    h, g, v, k, G, n, B)), e.push(["L", d + g * t(G), h + v * z(G)]), e = e.concat(p(d, h, g, v, G, y, 0, 0))) : k > q - m && l < q - m && (e.push(["L", d + g * Math.cos(y) + n, h + v * Math.sin(y) + B]), e = e.concat(p(d, h, g, v, y, k, n, B)), e.push(["L", d + g * Math.cos(k), h + v * Math.sin(k)]), e = e.concat(p(d, h, g, v, k, y, 0, 0))); e.push(["L", d + g * Math.cos(y) + n, h + v * Math.sin(y) + B]); e = e.concat(p(d, h, g, v, y, H, n, B)); e.push(["Z"]); m = [["M", d + x * w, h + A * C]]; m = m.concat(p(d, h, x, A, l, k, 0, 0)); m.push(["L", d + x * Math.cos(k) + n, h + A * Math.sin(k) + B]); m = m.concat(p(d, h, x, A, k, l, n, B)); m.push(["Z"]); w = [["M",
                        d + g * w, h + v * C], ["L", d + g * w + n, h + v * C + B], ["L", d + x * w + n, h + A * C + B], ["L", d + x * w, h + A * C], ["Z"]]; d = [["M", d + g * a, h + v * r], ["L", d + g * a + n, h + v * r + B], ["L", d + x * a + n, h + A * r + B], ["L", d + x * a, h + A * r], ["Z"]]; r = Math.atan2(B, -n); h = Math.abs(k + r); a = Math.abs(l + r); l = Math.abs((l + k) / 2 + r); h = b(h); a = b(a); l = b(l); l *= 1E5; k = 1E5 * a; h *= 1E5; return { top: c, zTop: 1E5 * Math.PI + 1, out: e, zOut: Math.max(l, k, h), inn: m, zInn: Math.max(l, k, h), side1: w, zSide1: .99 * h, side2: d, zSide2: .99 * k }
            }
    }); y(g, "parts-3d/Tick3D.js", [g["parts/Utilities.js"]], function (g) {
        var c = g.addEvent, p =
            g.extend, r = g.wrap; return function () {
                function m() { } m.compose = function (p) { c(p, "afterGetLabelPosition", m.onAfterGetLabelPosition); r(p.prototype, "getMarkPath", m.wrapGetMarkPath) }; m.onAfterGetLabelPosition = function (c) { var e = this.axis.axis3D; e && p(c.pos, e.fix3dPosition(c.pos)) }; m.wrapGetMarkPath = function (c) {
                    var e = this.axis.axis3D, p = c.apply(this, [].slice.call(arguments, 1)); if (e) {
                        var m = p[0], t = p[1]; if ("M" === m[0] && "L" === t[0]) return e = [e.fix3dPosition({ x: m[1], y: m[2], z: 0 }), e.fix3dPosition({ x: t[1], y: t[2], z: 0 })],
                            this.axis.chart.renderer.toLineSegments(e)
                    } return p
                }; return m
            }()
    }); y(g, "parts-3d/Axis3D.js", [g["parts/Globals.js"], g["parts/Tick.js"], g["parts-3d/Tick3D.js"], g["parts/Utilities.js"]], function (g, c, p, x) {
        var m = x.addEvent, r = x.merge, e = x.pick, A = x.wrap, w = g.deg2rad, t = g.perspective, q = g.perspective3D, z = g.shapeArea, C = function () {
            function n(b) { this.axis = b } n.prototype.fix3dPosition = function (b, h) {
                var a = this.axis, d = a.chart; if ("colorAxis" === a.coll || !d.is3d()) return b; var l = w * d.options.chart.options3d.alpha, v = w * d.options.chart.options3d.beta,
                    k = e(h && a.options.title.position3d, a.options.labels.position3d); h = e(h && a.options.title.skew3d, a.options.labels.skew3d); var u = d.frame3d, f = d.plotLeft, n = d.plotWidth + f, c = d.plotTop, p = d.plotHeight + c; d = !1; var m = 0, q = 0, g = { x: 0, y: 1, z: 0 }; b = a.axis3D.swapZ({ x: b.x, y: b.y, z: 0 }); if (a.isZAxis) if (a.opposite) { if (null === u.axes.z.top) return {}; q = b.y - c; b.x = u.axes.z.top.x; b.y = u.axes.z.top.y; f = u.axes.z.top.xDir; d = !u.top.frontFacing } else {
                        if (null === u.axes.z.bottom) return {}; q = b.y - p; b.x = u.axes.z.bottom.x; b.y = u.axes.z.bottom.y; f =
                            u.axes.z.bottom.xDir; d = !u.bottom.frontFacing
                    } else if (a.horiz) if (a.opposite) { if (null === u.axes.x.top) return {}; q = b.y - c; b.y = u.axes.x.top.y; b.z = u.axes.x.top.z; f = u.axes.x.top.xDir; d = !u.top.frontFacing } else { if (null === u.axes.x.bottom) return {}; q = b.y - p; b.y = u.axes.x.bottom.y; b.z = u.axes.x.bottom.z; f = u.axes.x.bottom.xDir; d = !u.bottom.frontFacing } else if (a.opposite) { if (null === u.axes.y.right) return {}; m = b.x - n; b.x = u.axes.y.right.x; b.z = u.axes.y.right.z; f = u.axes.y.right.xDir; f = { x: f.z, y: f.y, z: -f.x } } else {
                        if (null === u.axes.y.left) return {};
                        m = b.x - f; b.x = u.axes.y.left.x; b.z = u.axes.y.left.z; f = u.axes.y.left.xDir
                    } "chart" !== k && ("flap" === k ? a.horiz ? (v = Math.sin(l), l = Math.cos(l), a.opposite && (v = -v), d && (v = -v), g = { x: f.z * v, y: l, z: -f.x * v }) : f = { x: Math.cos(v), y: 0, z: Math.sin(v) } : "ortho" === k ? a.horiz ? (g = Math.cos(l), k = Math.sin(v) * g, l = -Math.sin(l), v = -g * Math.cos(v), g = { x: f.y * v - f.z * l, y: f.z * k - f.x * v, z: f.x * l - f.y * k }, l = 1 / Math.sqrt(g.x * g.x + g.y * g.y + g.z * g.z), d && (l = -l), g = { x: l * g.x, y: l * g.y, z: l * g.z }) : f = { x: Math.cos(v), y: 0, z: Math.sin(v) } : a.horiz ? g = {
                        x: Math.sin(v) * Math.sin(l),
                        y: Math.cos(l), z: -Math.cos(v) * Math.sin(l)
                    } : f = { x: Math.cos(v), y: 0, z: Math.sin(v) }); b.x += m * f.x + q * g.x; b.y += m * f.y + q * g.y; b.z += m * f.z + q * g.z; d = t([b], a.chart)[0]; h && (0 > z(t([b, { x: b.x + f.x, y: b.y + f.y, z: b.z + f.z }, { x: b.x + g.x, y: b.y + g.y, z: b.z + g.z }], a.chart)) && (f = { x: -f.x, y: -f.y, z: -f.z }), b = t([{ x: b.x, y: b.y, z: b.z }, { x: b.x + f.x, y: b.y + f.y, z: b.z + f.z }, { x: b.x + g.x, y: b.y + g.y, z: b.z + g.z }], a.chart), d.matrix = [b[1].x - b[0].x, b[1].y - b[0].y, b[2].x - b[0].x, b[2].y - b[0].y, d.x, d.y], d.matrix[4] -= d.x * d.matrix[0] + d.y * d.matrix[2], d.matrix[5] -= d.x *
                        d.matrix[1] + d.y * d.matrix[3]); return d
            }; n.prototype.swapZ = function (b, h) { var a = this.axis; return a.isZAxis ? (h = h ? 0 : a.chart.plotLeft, { x: h + b.z, y: b.y, z: b.x - h }) : b }; return n
        }(); return function () {
            function n() { } n.compose = function (b) {
                r(!0, b.defaultOptions, n.defaultOptions); b.keepProps.push("axis3D"); m(b, "init", n.onInit); m(b, "afterSetOptions", n.onAfterSetOptions); m(b, "drawCrosshair", n.onDrawCrosshair); m(b, "destroy", n.onDestroy); b = b.prototype; A(b, "getLinePath", n.wrapGetLinePath); A(b, "getPlotBandPath", n.wrapGetPlotBandPath);
                A(b, "getPlotLinePath", n.wrapGetPlotLinePath); A(b, "getSlotWidth", n.wrapGetSlotWidth); A(b, "getTitlePosition", n.wrapGetTitlePosition); p.compose(c)
            }; n.onAfterSetOptions = function () { var b = this.chart, h = this.options; b.is3d && b.is3d() && "colorAxis" !== this.coll && (h.tickWidth = e(h.tickWidth, 0), h.gridLineWidth = e(h.gridLineWidth, 1)) }; n.onDestroy = function () { ["backFrame", "bottomFrame", "sideFrame"].forEach(function (b) { this[b] && (this[b] = this[b].destroy()) }, this) }; n.onDrawCrosshair = function (b) {
                this.chart.is3d() && "colorAxis" !==
                    this.coll && b.point && (b.point.crosshairPos = this.isXAxis ? b.point.axisXpos : this.len - b.point.axisYpos)
            }; n.onInit = function () { this.axis3D || (this.axis3D = new C(this)) }; n.wrapGetLinePath = function (b) { return this.chart.is3d() && "colorAxis" !== this.coll ? [] : b.apply(this, [].slice.call(arguments, 1)) }; n.wrapGetPlotBandPath = function (b) {
                if (!this.chart.is3d() || "colorAxis" === this.coll) return b.apply(this, [].slice.call(arguments, 1)); var h = arguments, a = h[2], d = []; h = this.getPlotLinePath({ value: h[1] }); a = this.getPlotLinePath({ value: a });
                if (h && a) for (var l = 0; l < h.length; l += 2) { var v = h[l], k = h[l + 1], u = a[l], f = a[l + 1]; "M" === v[0] && "L" === k[0] && "M" === u[0] && "L" === f[0] && d.push(v, k, f, ["L", u[1], u[2]], ["Z"]) } return d
            }; n.wrapGetPlotLinePath = function (b) {
                var h = this.axis3D, a = this.chart, d = b.apply(this, [].slice.call(arguments, 1)); if (!a.is3d() || "colorAxis" === this.coll || null === d) return d; var l = a.options.chart.options3d, v = this.isZAxis ? a.plotWidth : l.depth; l = a.frame3d; var k = d[0], u = d[1]; d = []; "M" === k[0] && "L" === u[0] && (h = [h.swapZ({ x: k[1], y: k[2], z: 0 }), h.swapZ({
                    x: k[1],
                    y: k[2], z: v
                }), h.swapZ({ x: u[1], y: u[2], z: 0 }), h.swapZ({ x: u[1], y: u[2], z: v })], this.horiz ? (this.isZAxis ? (l.left.visible && d.push(h[0], h[2]), l.right.visible && d.push(h[1], h[3])) : (l.front.visible && d.push(h[0], h[2]), l.back.visible && d.push(h[1], h[3])), l.top.visible && d.push(h[0], h[1]), l.bottom.visible && d.push(h[2], h[3])) : (l.front.visible && d.push(h[0], h[2]), l.back.visible && d.push(h[1], h[3]), l.left.visible && d.push(h[0], h[1]), l.right.visible && d.push(h[2], h[3])), d = t(d, this.chart, !1)); return a.renderer.toLineSegments(d)
            };
            n.wrapGetSlotWidth = function (b, h) {
                var a = this.chart, d = this.ticks, l = this.gridGroup; if (this.categories && a.frameShapes && a.is3d() && l && h && h.label) {
                    l = l.element.childNodes[0].getBBox(); var v = a.frameShapes.left.getBBox(), k = a.options.chart.options3d; a = { x: a.plotWidth / 2, y: a.plotHeight / 2, z: k.depth / 2, vd: e(k.depth, 1) * e(k.viewDistance, 0) }; var u, f; k = h.pos; var n = d[k - 1]; d = d[k + 1]; 0 !== k && n && n.label.xy && (u = q({ x: n.label.xy.x, y: n.label.xy.y, z: null }, a, a.vd)); d && d.label.xy && (f = q({ x: d.label.xy.x, y: d.label.xy.y, z: null }, a, a.vd));
                    d = { x: h.label.xy.x, y: h.label.xy.y, z: null }; d = q(d, a, a.vd); return Math.abs(u ? d.x - u.x : f ? f.x - d.x : l.x - v.x)
                } return b.apply(this, [].slice.call(arguments, 1))
            }; n.wrapGetTitlePosition = function (b) { var h = b.apply(this, [].slice.call(arguments, 1)); return this.axis3D ? this.axis3D.fix3dPosition(h, !0) : h }; n.defaultOptions = { labels: { position3d: "offset", skew3d: !1 }, title: { position3d: null, skew3d: null } }; return n
        }()
    }); y(g, "parts-3d/ZAxis.js", [g["parts/Axis.js"], g["parts/Utilities.js"]], function (g, c) {
        var p = this && this.__extends ||
            function () { var e = function (c, g) { e = Object.setPrototypeOf || { __proto__: [] } instanceof Array && function (e, n) { e.__proto__ = n } || function (e, n) { for (var b in n) n.hasOwnProperty(b) && (e[b] = n[b]) }; return e(c, g) }; return function (c, g) { function p() { this.constructor = c } e(c, g); c.prototype = null === g ? Object.create(g) : (p.prototype = g.prototype, new p) } }(), r = c.addEvent, m = c.merge, B = c.pick, e = c.splat, A = function () {
                function c() { } c.compose = function (e) {
                    r(e, "afterGetAxes", c.onAfterGetAxes); e = e.prototype; e.addZAxis = c.wrapAddZAxis; e.collectionsWithInit.zAxis =
                        [e.addZAxis]; e.collectionsWithUpdate.push("zAxis")
                }; c.onAfterGetAxes = function () { var c = this, g = this.options; g = g.zAxis = e(g.zAxis || {}); c.is3d() && (c.zAxis = [], g.forEach(function (e, n) { e.index = n; e.isX = !0; c.addZAxis(e).setScale() })) }; c.wrapAddZAxis = function (e) { return new w(this, e) }; return c
            }(), w = function (e) {
                function c(c, g) { c = e.call(this, c, g) || this; c.isZAxis = !0; return c } p(c, e); c.prototype.getSeriesExtremes = function () {
                    var e = this, c = e.chart; e.hasVisibleSeries = !1; e.dataMin = e.dataMax = e.ignoreMinPadding = e.ignoreMaxPadding =
                        void 0; e.stacking && e.stacking.buildStacks(); e.series.forEach(function (n) { !n.visible && c.options.chart && c.options.chart.ignoreHiddenSeries || (e.hasVisibleSeries = !0, n = n.zData, n.length && (e.dataMin = Math.min(B(e.dataMin, n[0]), Math.min.apply(null, n)), e.dataMax = Math.max(B(e.dataMax, n[0]), Math.max.apply(null, n)))) })
                }; c.prototype.setAxisSize = function () {
                    var c = this.chart; e.prototype.setAxisSize.call(this); this.width = this.len = c.options.chart && c.options.chart.options3d && c.options.chart.options3d.depth || 0; this.right =
                        c.chartWidth - this.width - this.left
                }; c.prototype.setOptions = function (c) { c = m({ offset: 0, lineWidth: 0 }, c); e.prototype.setOptions.call(this, c); this.coll = "zAxis" }; c.ZChartComposition = A; return c
            }(g); return w
    }); y(g, "parts-3d/Chart.js", [g["parts/Axis.js"], g["parts-3d/Axis3D.js"], g["parts/Globals.js"], g["parts/Utilities.js"], g["parts-3d/ZAxis.js"]], function (g, c, p, x, m) {
        function r(b, h) {
            var a = b.plotLeft, d = b.plotWidth + a, l = b.plotTop, e = b.plotHeight + l, k = a + b.plotWidth / 2, c = l + b.plotHeight / 2, f = Number.MAX_VALUE, n = -Number.MAX_VALUE,
            g = Number.MAX_VALUE, p = -Number.MAX_VALUE, m = 1; var q = [{ x: a, y: l, z: 0 }, { x: a, y: l, z: h }];[0, 1].forEach(function (a) { q.push({ x: d, y: q[a].y, z: q[a].z }) });[0, 1, 2, 3].forEach(function (a) { q.push({ x: q[a].x, y: e, z: q[a].z }) }); q = C(q, b, !1); q.forEach(function (a) { f = Math.min(f, a.x); n = Math.max(n, a.x); g = Math.min(g, a.y); p = Math.max(p, a.y) }); a > f && (m = Math.min(m, 1 - Math.abs((a + k) / (f + k)) % 1)); d < n && (m = Math.min(m, (d - k) / (n - k))); l > g && (m = 0 > g ? Math.min(m, (l + c) / (-g + l + c)) : Math.min(m, 1 - (l + c) / (g + c) % 1)); e < p && (m = Math.min(m, Math.abs((e - c) / (p - c))));
            return m
        } var e = x.addEvent, A = x.Fx, w = x.isArray, t = x.merge, q = x.pick; x = x.wrap; var z = p.Chart, C = p.perspective; z.prototype.is3d = function () { return this.options.chart.options3d && this.options.chart.options3d.enabled }; z.prototype.propsRequireDirtyBox.push("chart.options3d"); z.prototype.propsRequireUpdateSeries.push("chart.options3d"); e(z, "afterInit", function () { var b = this.options; this.is3d() && (b.series || []).forEach(function (h) { "scatter" === (h.type || b.chart.type || b.chart.defaultSeriesType) && (h.type = "scatter3d") }) });
        e(z, "addSeries", function (b) { this.is3d() && "scatter" === b.options.type && (b.options.type = "scatter3d") }); x(p.Chart.prototype, "isInsidePlot", function (b) { return this.is3d() || b.apply(this, [].slice.call(arguments, 1)) }); var n = p.getOptions(); t(!0, n, { chart: { options3d: { enabled: !1, alpha: 0, beta: 0, depth: 100, fitToPlot: !0, viewDistance: 25, axisLabelPosition: null, frame: { visible: "default", size: 1, bottom: {}, top: {}, left: {}, right: {}, back: {}, front: {} } } } }); e(z, "afterGetContainer", function () {
        this.styledMode && (this.renderer.definition({
            tagName: "style",
            textContent: ".highcharts-3d-top{filter: url(#highcharts-brighter)}\n.highcharts-3d-side{filter: url(#highcharts-darker)}\n"
        }), [{ name: "darker", slope: .6 }, { name: "brighter", slope: 1.4 }].forEach(function (b) { this.renderer.definition({ tagName: "filter", id: "highcharts-" + b.name, children: [{ tagName: "feComponentTransfer", children: [{ tagName: "feFuncR", type: "linear", slope: b.slope }, { tagName: "feFuncG", type: "linear", slope: b.slope }, { tagName: "feFuncB", type: "linear", slope: b.slope }] }] }) }, this))
        }); x(z.prototype, "setClassName",
            function (b) { b.apply(this, [].slice.call(arguments, 1)); this.is3d() && (this.container.className += " highcharts-3d-chart") }); e(p.Chart, "afterSetChartSize", function () {
                var b = this.options.chart.options3d; if (this.is3d()) {
                    b && (b.alpha = b.alpha % 360 + (0 <= b.alpha ? 0 : 360), b.beta = b.beta % 360 + (0 <= b.beta ? 0 : 360)); var h = this.inverted, a = this.clipBox, d = this.margin; a[h ? "y" : "x"] = -(d[3] || 0); a[h ? "x" : "y"] = -(d[0] || 0); a[h ? "height" : "width"] = this.chartWidth + (d[3] || 0) + (d[1] || 0); a[h ? "width" : "height"] = this.chartHeight + (d[0] || 0) + (d[2] ||
                        0); this.scale3d = 1; !0 === b.fitToPlot && (this.scale3d = r(this, b.depth)); this.frame3d = this.get3dFrame()
                }
            }); e(z, "beforeRedraw", function () { this.is3d() && (this.isDirtyBox = !0) }); e(z, "beforeRender", function () { this.is3d() && (this.frame3d = this.get3dFrame()) }); x(z.prototype, "renderSeries", function (b) { var h = this.series.length; if (this.is3d()) for (; h--;)b = this.series[h], b.translate(), b.render(); else b.call(this) }); e(z, "afterDrawChartBox", function () {
                if (this.is3d()) {
                    var b = this.renderer, h = this.options.chart.options3d, a =
                        this.get3dFrame(), d = this.plotLeft, l = this.plotLeft + this.plotWidth, e = this.plotTop, k = this.plotTop + this.plotHeight; h = h.depth; var c = d - (a.left.visible ? a.left.size : 0), f = l + (a.right.visible ? a.right.size : 0), n = e - (a.top.visible ? a.top.size : 0), g = k + (a.bottom.visible ? a.bottom.size : 0), m = 0 - (a.front.visible ? a.front.size : 0), q = h + (a.back.visible ? a.back.size : 0), w = this.hasRendered ? "animate" : "attr"; this.frame3d = a; this.frameShapes || (this.frameShapes = {
                            bottom: b.polyhedron().add(), top: b.polyhedron().add(), left: b.polyhedron().add(),
                            right: b.polyhedron().add(), back: b.polyhedron().add(), front: b.polyhedron().add()
                        }); this.frameShapes.bottom[w]({
                            "class": "highcharts-3d-frame highcharts-3d-frame-bottom", zIndex: a.bottom.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.bottom.color).brighten(.1).get(), vertexes: [{ x: c, y: g, z: m }, { x: f, y: g, z: m }, { x: f, y: g, z: q }, { x: c, y: g, z: q }], enabled: a.bottom.visible }, { fill: p.color(a.bottom.color).brighten(.1).get(), vertexes: [{ x: d, y: k, z: h }, { x: l, y: k, z: h }, { x: l, y: k, z: 0 }, { x: d, y: k, z: 0 }], enabled: a.bottom.visible }, {
                                fill: p.color(a.bottom.color).brighten(-.1).get(),
                                vertexes: [{ x: c, y: g, z: m }, { x: c, y: g, z: q }, { x: d, y: k, z: h }, { x: d, y: k, z: 0 }], enabled: a.bottom.visible && !a.left.visible
                            }, { fill: p.color(a.bottom.color).brighten(-.1).get(), vertexes: [{ x: f, y: g, z: q }, { x: f, y: g, z: m }, { x: l, y: k, z: 0 }, { x: l, y: k, z: h }], enabled: a.bottom.visible && !a.right.visible }, { fill: p.color(a.bottom.color).get(), vertexes: [{ x: f, y: g, z: m }, { x: c, y: g, z: m }, { x: d, y: k, z: 0 }, { x: l, y: k, z: 0 }], enabled: a.bottom.visible && !a.front.visible }, {
                                fill: p.color(a.bottom.color).get(), vertexes: [{ x: c, y: g, z: q }, { x: f, y: g, z: q }, {
                                    x: l, y: k,
                                    z: h
                                }, { x: d, y: k, z: h }], enabled: a.bottom.visible && !a.back.visible
                            }]
                        }); this.frameShapes.top[w]({
                            "class": "highcharts-3d-frame highcharts-3d-frame-top", zIndex: a.top.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.top.color).brighten(.1).get(), vertexes: [{ x: c, y: n, z: q }, { x: f, y: n, z: q }, { x: f, y: n, z: m }, { x: c, y: n, z: m }], enabled: a.top.visible }, { fill: p.color(a.top.color).brighten(.1).get(), vertexes: [{ x: d, y: e, z: 0 }, { x: l, y: e, z: 0 }, { x: l, y: e, z: h }, { x: d, y: e, z: h }], enabled: a.top.visible }, {
                                fill: p.color(a.top.color).brighten(-.1).get(),
                                vertexes: [{ x: c, y: n, z: q }, { x: c, y: n, z: m }, { x: d, y: e, z: 0 }, { x: d, y: e, z: h }], enabled: a.top.visible && !a.left.visible
                            }, { fill: p.color(a.top.color).brighten(-.1).get(), vertexes: [{ x: f, y: n, z: m }, { x: f, y: n, z: q }, { x: l, y: e, z: h }, { x: l, y: e, z: 0 }], enabled: a.top.visible && !a.right.visible }, { fill: p.color(a.top.color).get(), vertexes: [{ x: c, y: n, z: m }, { x: f, y: n, z: m }, { x: l, y: e, z: 0 }, { x: d, y: e, z: 0 }], enabled: a.top.visible && !a.front.visible }, {
                                fill: p.color(a.top.color).get(), vertexes: [{ x: f, y: n, z: q }, { x: c, y: n, z: q }, { x: d, y: e, z: h }, { x: l, y: e, z: h }],
                                enabled: a.top.visible && !a.back.visible
                            }]
                        }); this.frameShapes.left[w]({
                            "class": "highcharts-3d-frame highcharts-3d-frame-left", zIndex: a.left.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.left.color).brighten(.1).get(), vertexes: [{ x: c, y: g, z: m }, { x: d, y: k, z: 0 }, { x: d, y: k, z: h }, { x: c, y: g, z: q }], enabled: a.left.visible && !a.bottom.visible }, { fill: p.color(a.left.color).brighten(.1).get(), vertexes: [{ x: c, y: n, z: q }, { x: d, y: e, z: h }, { x: d, y: e, z: 0 }, { x: c, y: n, z: m }], enabled: a.left.visible && !a.top.visible }, {
                                fill: p.color(a.left.color).brighten(-.1).get(),
                                vertexes: [{ x: c, y: g, z: q }, { x: c, y: n, z: q }, { x: c, y: n, z: m }, { x: c, y: g, z: m }], enabled: a.left.visible
                            }, { fill: p.color(a.left.color).brighten(-.1).get(), vertexes: [{ x: d, y: e, z: h }, { x: d, y: k, z: h }, { x: d, y: k, z: 0 }, { x: d, y: e, z: 0 }], enabled: a.left.visible }, { fill: p.color(a.left.color).get(), vertexes: [{ x: c, y: g, z: m }, { x: c, y: n, z: m }, { x: d, y: e, z: 0 }, { x: d, y: k, z: 0 }], enabled: a.left.visible && !a.front.visible }, { fill: p.color(a.left.color).get(), vertexes: [{ x: c, y: n, z: q }, { x: c, y: g, z: q }, { x: d, y: k, z: h }, { x: d, y: e, z: h }], enabled: a.left.visible && !a.back.visible }]
                        });
                    this.frameShapes.right[w]({
                        "class": "highcharts-3d-frame highcharts-3d-frame-right", zIndex: a.right.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.right.color).brighten(.1).get(), vertexes: [{ x: f, y: g, z: q }, { x: l, y: k, z: h }, { x: l, y: k, z: 0 }, { x: f, y: g, z: m }], enabled: a.right.visible && !a.bottom.visible }, { fill: p.color(a.right.color).brighten(.1).get(), vertexes: [{ x: f, y: n, z: m }, { x: l, y: e, z: 0 }, { x: l, y: e, z: h }, { x: f, y: n, z: q }], enabled: a.right.visible && !a.top.visible }, {
                            fill: p.color(a.right.color).brighten(-.1).get(), vertexes: [{
                                x: l,
                                y: e, z: 0
                            }, { x: l, y: k, z: 0 }, { x: l, y: k, z: h }, { x: l, y: e, z: h }], enabled: a.right.visible
                        }, { fill: p.color(a.right.color).brighten(-.1).get(), vertexes: [{ x: f, y: g, z: m }, { x: f, y: n, z: m }, { x: f, y: n, z: q }, { x: f, y: g, z: q }], enabled: a.right.visible }, { fill: p.color(a.right.color).get(), vertexes: [{ x: f, y: n, z: m }, { x: f, y: g, z: m }, { x: l, y: k, z: 0 }, { x: l, y: e, z: 0 }], enabled: a.right.visible && !a.front.visible }, { fill: p.color(a.right.color).get(), vertexes: [{ x: f, y: g, z: q }, { x: f, y: n, z: q }, { x: l, y: e, z: h }, { x: l, y: k, z: h }], enabled: a.right.visible && !a.back.visible }]
                    });
                    this.frameShapes.back[w]({
                        "class": "highcharts-3d-frame highcharts-3d-frame-back", zIndex: a.back.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.back.color).brighten(.1).get(), vertexes: [{ x: f, y: g, z: q }, { x: c, y: g, z: q }, { x: d, y: k, z: h }, { x: l, y: k, z: h }], enabled: a.back.visible && !a.bottom.visible }, { fill: p.color(a.back.color).brighten(.1).get(), vertexes: [{ x: c, y: n, z: q }, { x: f, y: n, z: q }, { x: l, y: e, z: h }, { x: d, y: e, z: h }], enabled: a.back.visible && !a.top.visible }, {
                            fill: p.color(a.back.color).brighten(-.1).get(), vertexes: [{
                                x: c, y: g,
                                z: q
                            }, { x: c, y: n, z: q }, { x: d, y: e, z: h }, { x: d, y: k, z: h }], enabled: a.back.visible && !a.left.visible
                        }, { fill: p.color(a.back.color).brighten(-.1).get(), vertexes: [{ x: f, y: n, z: q }, { x: f, y: g, z: q }, { x: l, y: k, z: h }, { x: l, y: e, z: h }], enabled: a.back.visible && !a.right.visible }, { fill: p.color(a.back.color).get(), vertexes: [{ x: d, y: e, z: h }, { x: l, y: e, z: h }, { x: l, y: k, z: h }, { x: d, y: k, z: h }], enabled: a.back.visible }, { fill: p.color(a.back.color).get(), vertexes: [{ x: c, y: g, z: q }, { x: f, y: g, z: q }, { x: f, y: n, z: q }, { x: c, y: n, z: q }], enabled: a.back.visible }]
                    }); this.frameShapes.front[w]({
                        "class": "highcharts-3d-frame highcharts-3d-frame-front",
                        zIndex: a.front.frontFacing ? -1E3 : 1E3, faces: [{ fill: p.color(a.front.color).brighten(.1).get(), vertexes: [{ x: c, y: g, z: m }, { x: f, y: g, z: m }, { x: l, y: k, z: 0 }, { x: d, y: k, z: 0 }], enabled: a.front.visible && !a.bottom.visible }, { fill: p.color(a.front.color).brighten(.1).get(), vertexes: [{ x: f, y: n, z: m }, { x: c, y: n, z: m }, { x: d, y: e, z: 0 }, { x: l, y: e, z: 0 }], enabled: a.front.visible && !a.top.visible }, { fill: p.color(a.front.color).brighten(-.1).get(), vertexes: [{ x: c, y: n, z: m }, { x: c, y: g, z: m }, { x: d, y: k, z: 0 }, { x: d, y: e, z: 0 }], enabled: a.front.visible && !a.left.visible },
                        { fill: p.color(a.front.color).brighten(-.1).get(), vertexes: [{ x: f, y: g, z: m }, { x: f, y: n, z: m }, { x: l, y: e, z: 0 }, { x: l, y: k, z: 0 }], enabled: a.front.visible && !a.right.visible }, { fill: p.color(a.front.color).get(), vertexes: [{ x: l, y: e, z: 0 }, { x: d, y: e, z: 0 }, { x: d, y: k, z: 0 }, { x: l, y: k, z: 0 }], enabled: a.front.visible }, { fill: p.color(a.front.color).get(), vertexes: [{ x: f, y: g, z: m }, { x: c, y: g, z: m }, { x: c, y: n, z: m }, { x: f, y: n, z: m }], enabled: a.front.visible }]
                    })
                }
            }); z.prototype.retrieveStacks = function (b) {
                var h = this.series, a = {}, d, e = 1; this.series.forEach(function (l) {
                    d =
                    q(l.options.stack, b ? 0 : h.length - 1 - l.index); a[d] ? a[d].series.push(l) : (a[d] = { series: [l], position: e }, e++)
                }); a.totalStacks = e + 1; return a
            }; z.prototype.get3dFrame = function () {
                var b = this, h = b.options.chart.options3d, a = h.frame, d = b.plotLeft, e = b.plotLeft + b.plotWidth, c = b.plotTop, k = b.plotTop + b.plotHeight, n = h.depth, f = function (a) { a = p.shapeArea3d(a, b); return .5 < a ? 1 : -.5 > a ? -1 : 0 }, g = f([{ x: d, y: k, z: n }, { x: e, y: k, z: n }, { x: e, y: k, z: 0 }, { x: d, y: k, z: 0 }]), m = f([{ x: d, y: c, z: 0 }, { x: e, y: c, z: 0 }, { x: e, y: c, z: n }, { x: d, y: c, z: n }]), w = f([{ x: d, y: c, z: 0 },
                { x: d, y: c, z: n }, { x: d, y: k, z: n }, { x: d, y: k, z: 0 }]), t = f([{ x: e, y: c, z: n }, { x: e, y: c, z: 0 }, { x: e, y: k, z: 0 }, { x: e, y: k, z: n }]), r = f([{ x: d, y: k, z: 0 }, { x: e, y: k, z: 0 }, { x: e, y: c, z: 0 }, { x: d, y: c, z: 0 }]); f = f([{ x: d, y: c, z: n }, { x: e, y: c, z: n }, { x: e, y: k, z: n }, { x: d, y: k, z: n }]); var x = !1, A = !1, z = !1, B = !1;[].concat(b.xAxis, b.yAxis, b.zAxis).forEach(function (a) { a && (a.horiz ? a.opposite ? A = !0 : x = !0 : a.opposite ? B = !0 : z = !0) }); var y = function (a, b, d) {
                    for (var f = ["size", "color", "visible"], h = {}, e = 0; e < f.length; e++)for (var c = f[e], k = 0; k < a.length; k++)if ("object" === typeof a[k]) {
                        var n =
                            a[k][c]; if ("undefined" !== typeof n && null !== n) { h[c] = n; break }
                    } a = d; !0 === h.visible || !1 === h.visible ? a = h.visible : "auto" === h.visible && (a = 0 < b); return { size: q(h.size, 1), color: q(h.color, "none"), frontFacing: 0 < b, visible: a }
                }; a = { axes: {}, bottom: y([a.bottom, a.top, a], g, x), top: y([a.top, a.bottom, a], m, A), left: y([a.left, a.right, a.side, a], w, z), right: y([a.right, a.left, a.side, a], t, B), back: y([a.back, a.front, a], f, !0), front: y([a.front, a.back, a], r, !1) }; "auto" === h.axisLabelPosition ? (t = function (a, b) {
                    return a.visible !== b.visible ||
                        a.visible && b.visible && a.frontFacing !== b.frontFacing
                }, h = [], t(a.left, a.front) && h.push({ y: (c + k) / 2, x: d, z: 0, xDir: { x: 1, y: 0, z: 0 } }), t(a.left, a.back) && h.push({ y: (c + k) / 2, x: d, z: n, xDir: { x: 0, y: 0, z: -1 } }), t(a.right, a.front) && h.push({ y: (c + k) / 2, x: e, z: 0, xDir: { x: 0, y: 0, z: 1 } }), t(a.right, a.back) && h.push({ y: (c + k) / 2, x: e, z: n, xDir: { x: -1, y: 0, z: 0 } }), g = [], t(a.bottom, a.front) && g.push({ x: (d + e) / 2, y: k, z: 0, xDir: { x: 1, y: 0, z: 0 } }), t(a.bottom, a.back) && g.push({ x: (d + e) / 2, y: k, z: n, xDir: { x: -1, y: 0, z: 0 } }), m = [], t(a.top, a.front) && m.push({
                    x: (d +
                        e) / 2, y: c, z: 0, xDir: { x: 1, y: 0, z: 0 }
                }), t(a.top, a.back) && m.push({ x: (d + e) / 2, y: c, z: n, xDir: { x: -1, y: 0, z: 0 } }), w = [], t(a.bottom, a.left) && w.push({ z: (0 + n) / 2, y: k, x: d, xDir: { x: 0, y: 0, z: -1 } }), t(a.bottom, a.right) && w.push({ z: (0 + n) / 2, y: k, x: e, xDir: { x: 0, y: 0, z: 1 } }), k = [], t(a.top, a.left) && k.push({ z: (0 + n) / 2, y: c, x: d, xDir: { x: 0, y: 0, z: -1 } }), t(a.top, a.right) && k.push({ z: (0 + n) / 2, y: c, x: e, xDir: { x: 0, y: 0, z: 1 } }), d = function (a, d, f) {
                    if (0 === a.length) return null; if (1 === a.length) return a[0]; for (var h = 0, e = C(a, b, !1), c = 1; c < e.length; c++)f * e[c][d] >
                        f * e[h][d] ? h = c : f * e[c][d] === f * e[h][d] && e[c].z < e[h].z && (h = c); return a[h]
                }, a.axes = { y: { left: d(h, "x", -1), right: d(h, "x", 1) }, x: { top: d(m, "y", -1), bottom: d(g, "y", 1) }, z: { top: d(k, "y", -1), bottom: d(w, "y", 1) } }) : a.axes = { y: { left: { x: d, z: 0, xDir: { x: 1, y: 0, z: 0 } }, right: { x: e, z: 0, xDir: { x: 0, y: 0, z: 1 } } }, x: { top: { y: c, z: 0, xDir: { x: 1, y: 0, z: 0 } }, bottom: { y: k, z: 0, xDir: { x: 1, y: 0, z: 0 } } }, z: { top: { x: z ? e : d, y: c, xDir: z ? { x: 0, y: 0, z: 1 } : { x: 0, y: 0, z: -1 } }, bottom: { x: z ? e : d, y: k, xDir: z ? { x: 0, y: 0, z: 1 } : { x: 0, y: 0, z: -1 } } } }; return a
            }; A.prototype.matrixSetter = function () {
                if (1 >
                    this.pos && (w(this.start) || w(this.end))) { var b = this.start || [1, 0, 0, 1, 0, 0], h = this.end || [1, 0, 0, 1, 0, 0]; var a = []; for (var d = 0; 6 > d; d++)a.push(this.pos * h[d] + (1 - this.pos) * b[d]) } else a = this.end; this.elem.attr(this.prop, a, null, !0)
            }; m.ZChartComposition.compose(z); c.compose(g); ""
    }); y(g, "parts-3d/Series.js", [g["parts/Globals.js"], g["parts/Utilities.js"]], function (g, c) {
        var p = c.addEvent, r = c.pick, m = g.perspective; p(g.Series, "afterTranslate", function () { this.chart.is3d() && this.translate3dPoints() }); g.Series.prototype.translate3dPoints =
            function () { var c = this.chart, e = r(this.zAxis, c.options.zAxis[0]), g = [], p; for (p = 0; p < this.data.length; p++) { var t = this.data[p]; if (e && e.translate) { var q = e.logarithmic && e.val2lin ? e.val2lin(t.z) : t.z; t.plotZ = e.translate(q); t.isInside = t.isInside ? q >= e.min && q <= e.max : !1 } else t.plotZ = 0; t.axisXpos = t.plotX; t.axisYpos = t.plotY; t.axisZpos = t.plotZ; g.push({ x: t.plotX, y: t.plotY, z: t.plotZ }) } c = m(g, c, !0); for (p = 0; p < this.data.length; p++)t = this.data[p], e = c[p], t.plotX = e.x, t.plotY = e.y, t.plotZ = e.z }
    }); y(g, "parts-3d/Column.js", [g["parts/Globals.js"],
    g["parts/Utilities.js"], g["parts/Stacking.js"]], function (g, c, p) {
        function x(e) { var c = e.apply(this, [].slice.call(arguments, 1)); this.chart.is3d && this.chart.is3d() && (c.stroke = this.options.edgeColor || c.fill, c["stroke-width"] = A(this.options.edgeWidth, 1)); return c } function m(e, c, b) { var h = this.chart.is3d && this.chart.is3d(); h && (this.options.inactiveOtherPoints = !0); e.call(this, c, b); h && (this.options.inactiveOtherPoints = !1) } function r(e) {
            for (var c = [], b = 1; b < arguments.length; b++)c[b - 1] = arguments[b]; return this.series.chart.is3d() ?
                this.graphic && "g" !== this.graphic.element.nodeName : e.apply(this, c)
        } var e = c.addEvent, A = c.pick; c = c.wrap; var w = g.perspective, t = g.Series, q = g.seriesTypes, z = g.svg; c(q.column.prototype, "translate", function (e) { e.apply(this, [].slice.call(arguments, 1)); this.chart.is3d() && this.translate3dShapes() }); c(g.Series.prototype, "justifyDataLabel", function (e) { return arguments[2].outside3dPlot ? !1 : e.apply(this, [].slice.call(arguments, 1)) }); q.column.prototype.translate3dPoints = function () { }; q.column.prototype.translate3dShapes =
            function () {
                var e = this, c = e.chart, b = e.options, h = b.depth, a = (b.stacking ? b.stack || 0 : e.index) * (h + (b.groupZPadding || 1)), d = e.borderWidth % 2 ? .5 : 0, g; c.inverted && !e.yAxis.reversed && (d *= -1); !1 !== b.grouping && (a = 0); a += b.groupZPadding || 1; e.data.forEach(function (b) {
                b.outside3dPlot = null; if (null !== b.y) {
                    var k = b.shapeArgs, n = b.tooltipPos, f;[["x", "width"], ["y", "height"]].forEach(function (a) {
                        f = k[a[0]] - d; 0 > f && (k[a[1]] += k[a[0]] + d, k[a[0]] = -d, f = 0); f + k[a[1]] > e[a[0] + "Axis"].len && 0 !== k[a[1]] && (k[a[1]] = e[a[0] + "Axis"].len - k[a[0]]);
                        if (0 !== k[a[1]] && (k[a[0]] >= e[a[0] + "Axis"].len || k[a[0]] + k[a[1]] <= d)) { for (var c in k) k[c] = 0; b.outside3dPlot = !0 }
                    }); "rect" === b.shapeType && (b.shapeType = "cuboid"); k.z = a; k.depth = h; k.insidePlotArea = !0; g = { x: k.x + k.width / 2, y: k.y, z: a + h / 2 }; c.inverted && (g.x = k.height, g.y = b.clientX); b.plot3d = w([g], c, !0, !1)[0]; n = w([{ x: n[0], y: n[1], z: a + h / 2 }], c, !0, !1)[0]; b.tooltipPos = [n.x, n.y]
                }
                }); e.z = a
            }; c(q.column.prototype, "animate", function (e) {
                if (this.chart.is3d()) {
                    var c = arguments[1], b = this.yAxis, h = this, a = this.yAxis.reversed; z && (c ?
                        h.data.forEach(function (d) { null !== d.y && (d.height = d.shapeArgs.height, d.shapey = d.shapeArgs.y, d.shapeArgs.height = 1, a || (d.shapeArgs.y = d.stackY ? d.plotY + b.translate(d.stackY) : d.plotY + (d.negative ? -d.height : d.height))) }) : (h.data.forEach(function (a) { null !== a.y && (a.shapeArgs.height = a.height, a.shapeArgs.y = a.shapey, a.graphic && a.graphic.animate(a.shapeArgs, h.options.animation)) }), this.drawDataLabels()))
                } else e.apply(this, [].slice.call(arguments, 1))
            }); c(q.column.prototype, "plotGroup", function (e, c, b, h, a, d) {
            "dataLabelsGroup" !==
                c && this.chart.is3d() && (this[c] && delete this[c], d && (this.chart.columnGroup || (this.chart.columnGroup = this.chart.renderer.g("columnGroup").add(d)), this[c] = this.chart.columnGroup, this.chart.columnGroup.attr(this.getPlotBox()), this[c].survive = !0, "group" === c || "markerGroup" === c)) && (arguments[3] = "visible"); return e.apply(this, Array.prototype.slice.call(arguments, 1))
            }); c(q.column.prototype, "setVisible", function (e, c) {
                var b = this, h; b.chart.is3d() && b.data.forEach(function (a) {
                    h = (a.visible = a.options.visible = c = "undefined" ===
                        typeof c ? !A(b.visible, a.visible) : c) ? "visible" : "hidden"; b.options.data[b.data.indexOf(a)] = a.options; a.graphic && a.graphic.attr({ visibility: h })
                }); e.apply(this, Array.prototype.slice.call(arguments, 1))
            }); q.column.prototype.handle3dGrouping = !0; e(t, "afterInit", function () {
                if (this.chart.is3d() && this.handle3dGrouping) {
                    var e = this.options, c = e.grouping, b = e.stacking, h = A(this.yAxis.options.reversedStacks, !0), a = 0; if ("undefined" === typeof c || c) {
                        c = this.chart.retrieveStacks(b); a = e.stack || 0; for (b = 0; b < c[a].series.length &&
                            c[a].series[b] !== this; b++); a = 10 * (c.totalStacks - c[a].position) + (h ? b : -b); this.xAxis.reversed || (a = 10 * c.totalStacks - a)
                    } e.depth = e.depth || 25; this.z = this.z || 0; e.zIndex = a
                }
            }); c(q.column.prototype, "pointAttribs", x); c(q.column.prototype, "setState", m); c(q.column.prototype.pointClass.prototype, "hasNewShapeType", r); q.columnrange && (c(q.columnrange.prototype, "pointAttribs", x), c(q.columnrange.prototype, "setState", m), c(q.columnrange.prototype.pointClass.prototype, "hasNewShapeType", r), q.columnrange.prototype.plotGroup =
                q.column.prototype.plotGroup, q.columnrange.prototype.setVisible = q.column.prototype.setVisible); c(t.prototype, "alignDataLabel", function (e, c, b, h, a) {
                    var d = this.chart; h.outside3dPlot = c.outside3dPlot; if (d.is3d() && this.is("column")) {
                        var g = this.options, m = A(h.inside, !!this.options.stacking), k = d.options.chart.options3d, n = c.pointWidth / 2 || 0; g = { x: a.x + n, y: a.y, z: this.z + g.depth / 2 }; d.inverted && (m && (a.width = 0, g.x += c.shapeArgs.height / 2), 90 <= k.alpha && 270 >= k.alpha && (g.y += c.shapeArgs.width)); g = w([g], d, !0, !1)[0]; a.x = g.x -
                            n; a.y = c.outside3dPlot ? -9E9 : g.y
                    } e.apply(this, [].slice.call(arguments, 1))
                }); c(p.prototype, "getStackBox", function (c, e, b, h, a, d, g, m) { var k = c.apply(this, [].slice.call(arguments, 1)); if (e.is3d() && b.base) { var l = +b.base.split(",")[0], f = e.series[l]; l = e.options.chart.options3d; f && f instanceof q.column && (f = { x: k.x + (e.inverted ? g : d / 2), y: k.y, z: f.options.depth / 2 }, e.inverted && (k.width = 0, 90 <= l.alpha && 270 >= l.alpha && (f.y += d)), f = w([f], e, !0, !1)[0], k.x = f.x - d / 2, k.y = f.y) } return k })
    }); y(g, "parts-3d/Pie.js", [g["parts/Globals.js"],
    g["parts/Utilities.js"]], function (g, c) {
        var p = c.pick; c = c.wrap; var x = g.deg2rad, m = g.seriesTypes, r = g.svg; c(m.pie.prototype, "translate", function (e) {
            e.apply(this, [].slice.call(arguments, 1)); if (this.chart.is3d()) {
                var c = this, g = c.options, m = g.depth || 0, p = c.chart.options.chart.options3d, r = p.alpha, y = p.beta, n = g.stacking ? (g.stack || 0) * m : c._i * m; n += m / 2; !1 !== g.grouping && (n = 0); c.data.forEach(function (b) {
                    var e = b.shapeArgs; b.shapeType = "arc3d"; e.z = n; e.depth = .75 * m; e.alpha = r; e.beta = y; e.center = c.center; e = (e.end + e.start) / 2;
                    b.slicedTranslation = { translateX: Math.round(Math.cos(e) * g.slicedOffset * Math.cos(r * x)), translateY: Math.round(Math.sin(e) * g.slicedOffset * Math.cos(r * x)) }
                })
            }
        }); c(m.pie.prototype.pointClass.prototype, "haloPath", function (e) { var c = arguments; return this.series.chart.is3d() ? [] : e.call(this, c[1]) }); c(m.pie.prototype, "pointAttribs", function (e, c, g) { e = e.call(this, c, g); g = this.options; this.chart.is3d() && !this.chart.styledMode && (e.stroke = g.edgeColor || c.color || this.color, e["stroke-width"] = p(g.edgeWidth, 1)); return e });
        c(m.pie.prototype, "drawDataLabels", function (e) { if (this.chart.is3d()) { var c = this.chart.options.chart.options3d; this.data.forEach(function (e) { var g = e.shapeArgs, m = g.r, p = (g.start + g.end) / 2; e = e.labelPosition; var r = e.connectorPosition, n = -m * (1 - Math.cos((g.alpha || c.alpha) * x)) * Math.sin(p), b = m * (Math.cos((g.beta || c.beta) * x) - 1) * Math.cos(p);[e.natural, r.breakAt, r.touchingSliceAt].forEach(function (e) { e.x += b; e.y += n }) }) } e.apply(this, [].slice.call(arguments, 1)) }); c(m.pie.prototype, "addPoint", function (e) {
            e.apply(this,
                [].slice.call(arguments, 1)); this.chart.is3d() && this.update(this.userOptions, !0)
        }); c(m.pie.prototype, "animate", function (e) {
            if (this.chart.is3d()) {
                var c = arguments[1], g = this.options.animation, m = this.center, q = this.group, x = this.markerGroup; r && (!0 === g && (g = {}), c ? (q.oldtranslateX = p(q.oldtranslateX, q.translateX), q.oldtranslateY = p(q.oldtranslateY, q.translateY), c = { translateX: m[0], translateY: m[1], scaleX: .001, scaleY: .001 }, q.attr(c), x && (x.attrSetters = q.attrSetters, x.attr(c))) : (c = {
                    translateX: q.oldtranslateX, translateY: q.oldtranslateY,
                    scaleX: 1, scaleY: 1
                }, q.animate(c, g), x && x.animate(c, g)))
            } else e.apply(this, [].slice.call(arguments, 1))
        })
    }); y(g, "parts-3d/Scatter.js", [g["parts/Globals.js"], g["parts/Point.js"], g["parts/Utilities.js"]], function (g, c, p) {
        p = p.seriesType; var x = g.seriesTypes; p("scatter3d", "scatter", { tooltip: { pointFormat: "x: <b>{point.x}</b><br/>y: <b>{point.y}</b><br/>z: <b>{point.z}</b><br/>" } }, {
            pointAttribs: function (c) {
                var m = x.scatter.prototype.pointAttribs.apply(this, arguments); this.chart.is3d() && c && (m.zIndex = g.pointCameraDistance(c,
                    this.chart)); return m
            }, axisTypes: ["xAxis", "yAxis", "zAxis"], pointArrayMap: ["x", "y", "z"], parallelArrays: ["x", "y", "z"], directTouch: !0
        }, { applyOptions: function () { c.prototype.applyOptions.apply(this, arguments); "undefined" === typeof this.z && (this.z = 0); return this } }); ""
    }); y(g, "parts-3d/VMLAxis3D.js", [g["parts/Utilities.js"]], function (g) {
        var c = g.addEvent, p = function () { return function (c) { this.axis = c } }(); return function () {
            function g() { } g.compose = function (m) {
                m.keepProps.push("vml"); c(m, "init", g.onInit); c(m, "render",
                    g.onRender)
            }; g.onInit = function () { this.vml || (this.vml = new p(this)) }; g.onRender = function () { var c = this.vml; c.sideFrame && (c.sideFrame.css({ zIndex: 0 }), c.sideFrame.front.attr({ fill: c.sideFrame.color })); c.bottomFrame && (c.bottomFrame.css({ zIndex: 1 }), c.bottomFrame.front.attr({ fill: c.bottomFrame.color })); c.backFrame && (c.backFrame.css({ zIndex: 0 }), c.backFrame.front.attr({ fill: c.backFrame.color })) }; return g
        }()
    }); y(g, "parts-3d/VMLRenderer.js", [g["parts/Axis.js"], g["parts/Globals.js"], g["parts-3d/VMLAxis3D.js"]],
        function (g, c, p) {
            var r = c.SVGRenderer, m = c.VMLRenderer; m && (c.setOptions({ animate: !1 }), m.prototype.face3d = r.prototype.face3d, m.prototype.polyhedron = r.prototype.polyhedron, m.prototype.elements3d = r.prototype.elements3d, m.prototype.element3d = r.prototype.element3d, m.prototype.cuboid = r.prototype.cuboid, m.prototype.cuboidPath = r.prototype.cuboidPath, m.prototype.toLinePath = r.prototype.toLinePath, m.prototype.toLineSegments = r.prototype.toLineSegments, m.prototype.arc3d = function (c) {
                c = r.prototype.arc3d.call(this,
                    c); c.css({ zIndex: c.zIndex }); return c
            }, c.VMLRenderer.prototype.arc3dPath = c.SVGRenderer.prototype.arc3dPath, p.compose(g))
        }); y(g, "masters/highcharts-3d.src.js", [], function () { })
});
//# sourceMappingURL=highcharts-3d.js.map