using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


    public class Helpers : MonoBehaviour
    {
        #region Vectors
        public static class Vectors
        {
            public static Vector3 RotatePointAround(Vector3 point, Vector3 offset, Quaternion angle)
            {
                return angle * (point - offset) + offset;
            }

            public static Vector3 MoveWithPercent(Vector3 start, Vector3 target, float percent)
            {
                var dir = (target - start).normalized;
                var distance = Vector3.Distance(start, target);
                var pos = start + (dir * distance * percent);
                return pos;
            }

            public static Vector2 WorldToScreenPoint(Camera camera, Canvas canvas, Vector3 targetPos)
            {
                Vector2 myPositionOnScreen = camera.WorldToScreenPoint(targetPos);
                var scaleFactor = canvas.scaleFactor;
                return new Vector2(myPositionOnScreen.x / scaleFactor, myPositionOnScreen.y / scaleFactor);
            }

            public static Vector3 ScreenToWorldPoint(Camera camera, Vector2 screenPoint, float distanceFromCamera = 10f)
            {
                Vector3 vec = screenPoint;
                vec.z = distanceFromCamera;
                return camera.ScreenToWorldPoint(vec);
            }

            public static Vector2 ToVector2(float angle)
            {
                return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            }

            public static Vector2 AngleToVector2(float angle)
            {
                return new Vector2((float)Mathf.Sin(angle), -(float)Mathf.Cos(angle));
            }

            public static float ToAngle(Vector2 value)
            {
                return Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg;
            }

            public static List<Vector2> OrderbyAngle(List<Vector2> values)
            {
                return values.OrderBy(x => Mathf.Atan2(x.x, x.y)).ToList();
            }

            public static Vector3 ToYZ(Vector2 value)
            {
                return new Vector3(0, value.y, value.x);
            }

            public static Vector3 ToXZ(Vector2 value)
            {
                return new Vector3(value.x, 0, value.y);
            }

            public static Vector2 ClampVector2(Vector2 target, float xMax, float yMax)
            {
                var x = target.x;
                var y = target.y;
                x = Mathf.Clamp(x, -xMax, xMax);
                y = Mathf.Clamp(y, -yMax, yMax);
                return new Vector2(x, y);
            }

            public static Vector2 ClampVector2(Vector2 target, float xMin, float xMax, float yMin, float yMax)
            {
                var x = target.x;
                var y = target.y;
                x = Mathf.Clamp(x, xMin, xMax);
                y = Mathf.Clamp(y, yMin, yMax);
                return new Vector2(x, y);
            }

            public static Vector2 ClampVector2(Vector2 target, Vector2 minValues, Vector2 maxValues)
            {
                var x = target.x;
                var y = target.y;
                x = Mathf.Clamp(x, minValues.x, maxValues.x);
                y = Mathf.Clamp(y, minValues.y, maxValues.y);
                return new Vector2(x, y);
            }

            public static Vector2 RandomVector2(float maxValues)
            {
                var x = Random.Range(-maxValues, maxValues);
                var y = Random.Range(-maxValues, maxValues);
                return new Vector2(x, y);
            }

            public static Vector2 RandomVector2(float minValue, float maxValue)
            {
                var random = Random.Range(minValue, maxValue);
                return new Vector2(random, random);
            }

            public static Vector2 RandomVector2(float xMin, float xMax, float yMin, float yMax)
            {
                var x = Random.Range(xMin, xMax);
                var y = Random.Range(yMin, yMax);
                return new Vector2(x, y);
            }

            public static Vector2 RandomVector2(Vector2 minVlaues, Vector2 maxValues)
            {
                var x = Random.Range(minVlaues.x, maxValues.x);
                var y = Random.Range(minVlaues.y, maxValues.y);
                return new Vector2(x, y);
            }

            public static Vector3 ClampVector3(Vector3 target, float xMax, float yMax, float zMax)
            {
                var x = target.x;
                var y = target.y;
                var z = target.z;
                x = Mathf.Clamp(x, -xMax, xMax);
                y = Mathf.Clamp(y, -yMax, yMax);
                z = Mathf.Clamp(z, -zMax, zMax);
                return new Vector3(x, y, z);
            }

            public static Vector3 ClampVector3(Vector3 target, float xMin, float xMax, float yMin, float yMax, float zMin, float zMax)
            {
                var x = target.x;
                var y = target.y;
                var z = target.z;
                x = Mathf.Clamp(x, xMin, xMax);
                y = Mathf.Clamp(y, yMin, yMax);
                z = Mathf.Clamp(z, zMin, zMax);
                return new Vector3(x, y, z);
            }

            public static Vector3 ClampVector3(Vector3 target, Vector3 minValues, Vector3 maxValues)
            {
                var x = target.x;
                var y = target.y;
                var z = target.z;
                x = Mathf.Clamp(x, minValues.x, maxValues.x);
                y = Mathf.Clamp(y, minValues.y, maxValues.y);
                z = Mathf.Clamp(z, minValues.z, maxValues.z);
                return new Vector3(x, y, z);
            }

            public static Vector3 RandomVector3(float maxValues)
            {
                var x = Random.Range(-maxValues, maxValues);
                var y = Random.Range(-maxValues, maxValues);
                var z = Random.Range(-maxValues, maxValues);
                return new Vector3(x, y, z);
            }

            public static Vector3 RandomVector3(float minValue, float maxValue)
            {
                var random = Random.Range(minValue, maxValue);
                return new Vector3(random, random, random);
            }

            public static Vector3 RandomVector3(float xMin, float xMax, float yMin, float yMax, float zmin, float zMax)
            {
                var x = Random.Range(xMin, xMax);
                var y = Random.Range(yMin, yMax);
                var z = Random.Range(zmin, zMax);
                return new Vector3(x, y, z);
            }

            public static Vector3 RandomVector3(Vector3 minVlaues, Vector3 maxValues)
            {
                var x = Random.Range(minVlaues.x, maxValues.x);
                var y = Random.Range(minVlaues.y, maxValues.y);
                var z = Random.Range(minVlaues.z, maxValues.z);
                return new Vector3(x, y, z);
            }

            public static bool GetIntersectionPointInLine(Vector2 aStartPoint, Vector2 aEndPoint, Vector2 bStartPoint, Vector2 bEndPoint, bool checkALine, out Vector2 intersectionPos)
            {
                var isIntersects = GetIntersectionPoint(aStartPoint, aEndPoint, bStartPoint, bEndPoint, out intersectionPos);
                if (!isIntersects) return false;
                return checkALine ? IsPointBetweenTwoVector(aStartPoint, aEndPoint, intersectionPos) : IsPointBetweenTwoVector(bStartPoint, bEndPoint, intersectionPos);

            }

            public static bool GetIntersectionPoint(Vector2 aStartPoint, Vector2 aEndPoint, Vector2 bStartPoint, Vector2 bEndPoint, out Vector2 intersectPos)
            {
                var tmp = (bEndPoint.x - bStartPoint.x) * (aEndPoint.y - aStartPoint.y) - (bEndPoint.y - bStartPoint.y) * (aEndPoint.x - aStartPoint.x);
                if (tmp == 0)
                {
                    intersectPos = Vector2.zero;
                    return false;
                }
                var mu = ((aStartPoint.x - bStartPoint.x) * (aEndPoint.y - aStartPoint.y) - (aStartPoint.y - bStartPoint.y) * (aEndPoint.x - aStartPoint.x)) / tmp;
                intersectPos = new Vector2(bStartPoint.x + (bEndPoint.x - bStartPoint.x) * mu, bStartPoint.y + (bEndPoint.y - bStartPoint.y) * mu);
                return true;
            }

            public static bool IsPointBetweenTwoVector(Vector3 aStartPoint, Vector3 aEndPoint, Vector3 point)
            {
                return Vector3.Dot((aEndPoint - aStartPoint).normalized, (point - aEndPoint).normalized) <= 0f && Vector3.Dot((aStartPoint - aEndPoint).normalized, (point - aStartPoint).normalized) <= 0f;
            }

            public static bool IsValuesInSpace(float aPoint, float bPoint, float min, float max)
            {
                if (aPoint >= min && aPoint <= max) return true;
                if (bPoint >= min && bPoint <= max) return true;
                if (aPoint > bPoint)
                {
                    if (aPoint > max && bPoint < min) return true;
                }
                else if (bPoint > aPoint)
                {
                    if (bPoint > max && aPoint < min) return true;
                }
                return false;
            }

            public static Vector3 RoundV3(Vector3 value, int digits)
            {
                return new Vector3((float)System.Math.Round(value.x, digits), (float)System.Math.Round(value.y, digits), (float)System.Math.Round(value.z, digits));
            }
        }
        #endregion

        #region String
        public static class String
        {
            public static string SortArray(object[] values, char separationChar)
            {
                var newText = "";
                var lastObject = values.LastOrDefault();
                foreach (var item in values)
                {
                    if (item.Equals(lastObject)) newText += item.ToString();
                    else newText += item.ToString() + separationChar;
                }
                return newText;
            }


            public static string SortByMold(object[] values, char separationChar)
            {
                var newText = "";
                var lastObject = values.LastOrDefault();
                foreach (var item in values)
                {
                    if (item.Equals(lastObject)) newText += "[" + item + "]";
                    else newText += $"[{item}]{separationChar}";
                }
                return newText;
            }

            public static string SortArrayVariable(object[] values, char separationChar)
            {
                var newText = "";
                var lastObject = values.LastOrDefault();
                foreach (var item in values)
                {
                    if (item.Equals(lastObject)) newText += "'" + item + "'";
                    else newText += $"'{item}'{separationChar}";
                }
                return newText;
            }

            public static string SyncDictionary(Dictionary<string, object> values, char separationChar)
            {
                var newText = "";
                var lastObject = values.LastOrDefault();
                foreach (var item in values)
                {
                    if (item.Equals(lastObject)) newText += item.Key + "='" + item.Value + "'";
                    else newText += $"{item.Key}='{item.Value}'{separationChar}";
                }
                return newText;
            }

            public static string SyncArray(string[] objects, object[] values, char separationChar)
            {
                var newText = "";
                var lastObject = objects.LastOrDefault();
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects[i] == lastObject)
                    {
                        if (values[i] != null) newText += objects[i] + "='" + values[i] + "'";
                    }
                    else
                    {
                        if (values[i] != null) newText += objects[i] + "='" + values[i] + "'" + separationChar;
                    }
                }
                return newText;
            }
        }
        #endregion

        #region Maths
        public static class Maths
        {
            public static float GetValueWithPercent(float aValue, float bValue, float percent)
            {
                var diff = bValue - aValue;
                return aValue + (diff * percent);
            }

            public static float RoundDecimals(float target)
            {
                return (Mathf.Round(target * 100.0f) * 0.01f);
            }

            public static Vector2 RoundDecimals(Vector2 target)
            {
                return new Vector2(Mathf.Round(target.x * 100.0f) * 0.01f, Mathf.Round(target.y * 100.0f) * 0.01f);
            }

            public static bool IsValueInRange(float value, float min, float max)
            {
                return value >= min && value <= max;
            }

            public static Vector3 CalculateCubicBezierPoint(float time, Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 endPoint)
            {
                var u = 1 - time;
                var tt = time * time;
                var uu = u * u;
                var uuu = uu * u;
                var ttt = tt * time;
                var p = uuu * startPoint;
                p += 3 * uu * time * controlPoint1;
                p += 3 * u * tt * controlPoint2;
                p += ttt * endPoint;
                return p;
            }

            public static Vector2 CalculateCubicBezierPoint(float time, Vector2 startPoint, Vector2 controlPoint1, Vector2 controlPoint2, Vector2 endPoint)
            {
                var u = 1 - time;
                var tt = time * time;
                var uu = u * u;
                var uuu = uu * u;
                var ttt = tt * time;
                var p = uuu * startPoint;
                p += 3 * uu * time * controlPoint1;
                p += 3 * u * tt * controlPoint2;
                p += ttt * endPoint;
                return p;
            }

            public static Vector3 CalculateBezierPoint(float time, Vector3 startPoint, Vector3 controlPoint1, Vector3 endPoint)
            {
                time = Mathf.Clamp01(time);
                var oneMinusT = 1f - time;
                return oneMinusT * oneMinusT * startPoint + 2f * oneMinusT * time * controlPoint1 + time * time * endPoint;
            }

            public static double Round(double value, int digits)
            {
                return System.Math.Round(value, digits);
            }

            public static bool IsAngleInRange(float angle, float targetAngle, float decreaseVal, float increaseVal)
            {
                if (angle > targetAngle)
                {
                    if (angle <= 360)
                    {
                        if (targetAngle + increaseVal > 360) return true;
                    }
                    if (angle <= targetAngle + increaseVal) return true;
                    if (!(targetAngle - decreaseVal < 0)) return false;
                    var newMax = SubtractWithMax(targetAngle, decreaseVal, 360, 0);
                    if (angle >= newMax) return true;
                }
                else if (Math.Abs(targetAngle - angle) < float.Epsilon) return true;
                else
                {
                    if (targetAngle - decreaseVal < 0) return true;
                    if (angle >= targetAngle - decreaseVal) return true;
                    if (!(targetAngle + decreaseVal > 360)) return false;
                    var newMin = AdditionWithMax(targetAngle, increaseVal, 360, 0);
                    if (angle <= newMin) return true;
                }
                return false;
            }

            public static float ToDegree(float x, float y)
            {
                var value = (float)((Mathf.Atan2(x, y) / Mathf.PI) * 180f);
                if (value < 0) value += 360f;
                return value;
            }

            public static float AdditionWithMax(float value, float addValue, float maxValue, float min)
            {
                if (addValue > maxValue)
                {
                    var diff = Mathf.FloorToInt(addValue / maxValue);
                    addValue -= diff * maxValue;
                }
                if (value + addValue > maxValue) return min + (value + addValue) - maxValue;
                return value + addValue;
            }

            public static float SubtractWithMax(float value, float subtractValue, float maxValue, float min)
            {
                if (subtractValue > maxValue)
                {
                    var diff = Mathf.FloorToInt(subtractValue / maxValue);
                    subtractValue -= diff * maxValue;
                }
                if (value - subtractValue < min) return maxValue - (value + subtractValue);
                return value - subtractValue;
            }

            public static int SubtractWithMax(int value, int subtractValue, int maxValue, int min)
            {
                if (subtractValue > maxValue)
                {
                    var diff = Mathf.FloorToInt(subtractValue / maxValue);
                    subtractValue -= diff * maxValue;
                }
                if (value - subtractValue < min) return maxValue - (value + subtractValue);
                return value - subtractValue;
            }


            public static float GetLinearValue(float min, float max, int index, int maxCount, bool clampValue = true)
            {
                var value = (max - min) / maxCount;
                value = min + (value * index);
                if (!clampValue) return value;
                value = value > max ? max : value;
                value = value < min ? min : value;
                return value;
            }

            public static float GetLinearValue(float min, float max, float currentValue, float maxValue, bool clampValue = true)
            {
                var value = (max - min) / maxValue;
                value = min + (value * currentValue);
                if (!clampValue) return value;
                value = value > max ? max : value;
                value = value < min ? min : value;
                return value;
            }

            public static Vector3 GetLinearValue(Vector3 start, Vector3 end, int index, int maxCount, bool clampValue = true)
            {
                return new Vector3(GetLinearValue(start.x, end.x, index, maxCount, clampValue), GetLinearValue(start.y, end.y, index, maxCount, clampValue), GetLinearValue(start.z, end.z, index, maxCount, clampValue));
            }

            public static float Lerp(float a, float b, float t)
            {
                return (1 - t) * a + t * b;
            }

            public static float GetValueByLuck(float[] lucks)
            {
                var total = lucks.Sum();
                var randomPoint = Random.value * total;
                foreach (var t in lucks)
                {
                    if (randomPoint < t) return t;
                    randomPoint -= t;
                }
                return lucks.Length - 1;
            }

            public static float GetValueByLuck(List<float> lucks)
            {
                var total = lucks.Sum();
                var randomPoint = Random.value * total;
                foreach (var t in lucks)
                {
                    if (randomPoint < t) return t;
                    randomPoint -= t;
                }
                return lucks.Count - 1;
            }

            public static int GetItemByLuck(List<float> lucks)
            {
                var total = lucks.Sum();
                var randomPoint = Random.value * total;
                for (int i = 0; i < lucks.Count; i++)
                {
                    if (randomPoint < lucks[i]) return i;
                    randomPoint -= lucks[i];
                }
                return lucks.Count - 1;
            }

            public static int GetItemByLuck(float[] lucks)
            {
                var total = lucks.Sum();
                var randomPoint = Random.value * total;
                for (int i = 0; i < lucks.Length; i++)
                {
                    if (randomPoint < lucks[i]) return i;
                    randomPoint -= lucks[i];
                }
                return lucks.Length - 1;
            }
        }
        #endregion

        #region Collections
        public static class Collections
        { 
            public static T[] GetArray<T>(params T[] values)
            {
                return values;
            }

            public static List<T> ChangeIndex<T>(List<T> list, int changeIndex, int toIndex)
            {
                if (changeIndex == toIndex) return list;
                object a = list[changeIndex];
                object b = list[toIndex];
                list.Remove((T)a);
                list.Remove((T)b);
                if (changeIndex > toIndex)
                {
                    list.Insert(toIndex, (T)a);
                    list.Insert(changeIndex, (T)b);
                }
                else
                {
                    list.Insert(changeIndex, (T)b);
                    list.Insert(toIndex, (T)a);
                }
                return list;
            }

            public static List<T> ShuffleList<T>(List<T> targetList)
            {
                var r = new System.Random();
                for (int i = 0; i < targetList.Count; i++)
                {
                    var obj = targetList[i];
                    targetList.Remove(obj);
                    var index = r.Next(0, targetList.Count);
                    targetList.Insert(index, obj);
                }
                return targetList;
            }

            public static List<T> ReverseList<T>(List<T> list)
            {
                var count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    var last = list[count - 1];
                    list.Remove(last);
                    list.Insert(i, last);
                }
                return list;
            }

            public static List<float> Round(List<float> values, int digits)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    values[i] = (float)System.Math.Round(values[i], digits);
                }
                return values;
            }
        }
        #endregion

        #region Colors
        public static class Colors
        {
            public static Color GetColorWithPercent(Color a, Color b, float percent)
            {
                return new Color(Maths.GetValueWithPercent(a.r, b.r, percent), Maths.GetValueWithPercent(a.g, b.g, percent), Maths.GetValueWithPercent(a.b, b.b, percent));
            }
        
            public static bool IsEqual(Color a, Color b)
            {
                return Math.Abs(a.r - b.r) < float.Epsilon && Math.Abs(a.g - b.g) < float.Epsilon && Math.Abs(a.b - b.b) < float.Epsilon;
            }

            public static Color InvertColor(Color color)
            {
                return new Color(1.0f - color.r, 1.0f - color.g, 1.0f - color.b);
            }

            public static Color ToColor(string str)
            {
                if (str.Contains("#") == false) str = "#" + str;
                ColorUtility.TryParseHtmlString(str, out var color);
                return color;
            }

            public static string ToString(Color color)
            {
                return ColorUtility.ToHtmlStringRGBA(color);
            }

            public static Color SetAlpha(Color targetColor, float alphaValue)
            {
                var alphaColor = targetColor;
                alphaColor.a = alphaValue;
                return alphaColor;
            }

            public static bool IsColorInRange(float sensitve, Color color, Color targetColor)
            {
                return Maths.IsValueInRange(color.r, targetColor.r - sensitve, targetColor.r + sensitve) && Maths.IsValueInRange(color.g, targetColor.g - sensitve, targetColor.g + sensitve) && Maths.IsValueInRange(color.b, targetColor.b - sensitve, targetColor.b + sensitve);
            }
        }
        #endregion

        #region Meshes
        public static class Meshes
        {
            public static List<Vector3> GetOutlineVertices(Mesh mesh, float height)
            {
                var points = new List<Vector3>();
                var triangles = mesh.triangles;
                var vertices = mesh.vertices;
                var edges = new Dictionary<string, KeyValuePair<int, int>>();
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    for (int e = 0; e < 3; e++)
                    {
                        var vert1 = triangles[i + e];
                        var vert2 = triangles[i + e + 1 > i + 2 ? i : i + e + 1];
                        var edge = Mathf.Min(vert1, vert2) + ":" + Mathf.Max(vert1, vert2);
                        if (edges.ContainsKey(edge)) edges.Remove(edge);
                        else edges.Add(edge, new KeyValuePair<int, int>(vert1, vert2));
                    }
                }
                var lookup = new Dictionary<int, int>();
                foreach (var edge in edges.Values.Where(edge => lookup.ContainsKey(edge.Key) == false))
                {
                    lookup.Add(edge.Key, edge.Value);
                }
                var bringForward = new Vector3(0f, 0f, -0.1f);
                var startVert = 0;
                var nextVert = startVert;
                var highestVert = startVert;
                while (true)
                {
                    points.Add(vertices[nextVert] + bringForward);
                    nextVert = lookup[nextVert];
                    if (nextVert > highestVert) highestVert = nextVert;
                    if (nextVert != startVert) continue;
                    points.Add(vertices[nextVert] + bringForward);
                    if (lookup.ContainsKey(highestVert + 1))
                    {
                        startVert = highestVert + 1;
                        nextVert = startVert;
                        continue;
                    }
                    break;
                }
                points = points.Distinct().ToList();
                points.RemoveAll(x => Math.Abs(x.y - height) > float.Epsilon);
                return points;
            }

            public static bool IsPointInPolygon(Vector2 point, Vector2[] polygon)
            {
                int polygonLength = polygon.Length, i = 0;
                var inside = false;
                float pointX = point.x, pointY = point.y;
                var endPoint = polygon[polygonLength - 1];
                var endX = endPoint.x;
                var endY = endPoint.y;
                while (i < polygonLength)
                {
                    var startX = endX; var startY = endY;
                    endPoint = polygon[i++];
                    endX = endPoint.x; endY = endPoint.y;
                    inside ^= (endY > pointY ^ startY > pointY) && ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
                }
                return inside;
            }

            public static Vector3[] GetAbEdge(Mesh mesh, int triangleIndex)
            {
                if (triangleIndex < 0) return null;
                return triangleIndex < (mesh.triangles.Length / 3) ? Collections.GetArray(mesh.vertices[mesh.triangles[triangleIndex * 3]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 1]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 2]]) : null;
            }

            public static Vector3[] GetBCEdge(Mesh mesh, int triangleIndex)
            {
                if (triangleIndex < 0) return null;
                return triangleIndex < (mesh.triangles.Length / 3) ? Collections.GetArray(mesh.vertices[mesh.triangles[(triangleIndex * 3) + 1]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 2]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 2]]) : null;
            }

            public static Vector3[] GetCaEdge(Mesh mesh, int triangleIndex)
            {
                if (triangleIndex < 0) return null;
                return triangleIndex < (mesh.triangles.Length / 3) ? Collections.GetArray(mesh.vertices[mesh.triangles[(triangleIndex * 3)]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 2]], mesh.vertices[mesh.triangles[(triangleIndex * 3) + 2]]) : null;
            }

            public static Vector3 GetIntersectionPoint(Vector3 aPoint, Vector3 bPoint, float searchValue, Vector3 searchPattern)
            {
                float x = 0;
                float y = 0;
                float z = 0;
                Vector2 intersectionPoint;
                if (searchPattern == Vector3.up)
                {
                    if (!Vectors.IsValuesInSpace(aPoint.y, bPoint.y, searchValue, searchValue)) return new Vector3(x, y, z);
                    y = searchValue;
                    if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.x, aPoint.y), new Vector2(bPoint.x, bPoint.y), new Vector2(aPoint.x, searchValue), new Vector2(bPoint.x, searchValue), true, out intersectionPoint))
                    {
                        x = intersectionPoint.x;
                        if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.z, aPoint.y), new Vector2(bPoint.z, bPoint.y), new Vector2(aPoint.z, searchValue), new Vector2(bPoint.z, searchValue), true, out intersectionPoint))
                        {
                            z = intersectionPoint.x;
                        }
                    }
                    else
                    {
                        x = aPoint.x;
                        z = aPoint.z;
                    }
                }
                else if (searchPattern == Vector3.right)
                {
                    if (!Vectors.IsValuesInSpace(aPoint.x, bPoint.x, searchValue, searchValue)) return new Vector3(x, y, z);
                    x = searchValue;
                    if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.z, aPoint.x), new Vector2(bPoint.z, bPoint.x), new Vector2(aPoint.z, searchValue), new Vector2(bPoint.z, searchValue), true, out intersectionPoint))
                    {
                        z = intersectionPoint.x;
                        if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.y, aPoint.x), new Vector2(bPoint.y, bPoint.x), new Vector2(aPoint.y, searchValue), new Vector2(bPoint.y, searchValue), true, out intersectionPoint))
                        {
                            y = intersectionPoint.x;
                        }
                    }
                    else
                    {
                        z = aPoint.z;
                        y = aPoint.y;
                    }
                }
                else if (searchPattern == Vector3.forward)
                {
                    if (!Vectors.IsValuesInSpace(aPoint.z, bPoint.z, searchValue, searchValue)) return new Vector3(x, y, z);
                    z = searchValue;
                    if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.y, aPoint.z), new Vector2(bPoint.y, bPoint.z), new Vector2(aPoint.y, searchValue), new Vector2(bPoint.y, searchValue), true, out intersectionPoint))
                    {
                        y = intersectionPoint.x;
                        if (Vectors.GetIntersectionPointInLine(new Vector2(aPoint.x, aPoint.z), new Vector2(bPoint.x, bPoint.z), new Vector2(aPoint.x, searchValue), new Vector2(bPoint.x, searchValue), true, out intersectionPoint))
                        {
                            x = intersectionPoint.x;
                        }
                    }
                    else
                    {
                        x = aPoint.x;
                        y = aPoint.y;
                    }
                }
                return new Vector3(x, y, z);
            }

            public static List<Vector2> GetHalfLoopPoints(Mesh mesh, float min, float max, float sensitive, Vector3 dir)
            {
                var verticalPoints = new List<Vector2>();
                var count = (int)Mathf.Abs((min - max) / sensitive) + 1;
                var height = min;
                var triangleCount = mesh.triangles.Length / 3;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < triangleCount; i++)
                    {
                        var points = Meshes.GetAbEdge(mesh, i);
                        var point = (Meshes.GetIntersectionPoint(points[0], points[1], height, dir));
                        if (point != Vector3.zero)
                        {
                            verticalPoints.Add(new Vector2(Vector2.Distance(Vector2.zero, new Vector2(point.x, point.z)), height));
                            break;
                        }

                        points = Meshes.GetBCEdge(mesh, i);
                        point = (Meshes.GetIntersectionPoint(points[0], points[1], height, dir));
                        if (point != Vector3.zero)
                        {
                            verticalPoints.Add(new Vector2(Vector2.Distance(Vector2.zero, new Vector2(point.x, point.z)), height));
                            break;
                        }

                        points = Meshes.GetCaEdge(mesh, i);
                        point = (Meshes.GetIntersectionPoint(points[0], points[1], height, dir));
                        if (point == Vector3.zero) continue;
                        verticalPoints.Add(new Vector2(Vector2.Distance(Vector2.zero, new Vector2(point.x, point.z)), height));
                        break;
                    }
                    height += sensitive;
                    height = (float)System.Math.Round(height, 3);
                }
                return verticalPoints;
            }
        }
        #endregion

        #region Physic
        public static class Physic
        {
            public static RaycastHit GetScreenToRaycastHit(Camera camera, Vector3 screenPos)
            {
                var ray = camera.ScreenPointToRay(screenPos);
                Physics.Raycast(ray, out var hit);
                return hit;
            }

            public static RaycastHit GetRaycastHit(Vector3 startPoint, Vector3 direction)
            {
                var ray = new Ray(startPoint, direction);
                Physics.Raycast(ray, out var hit);
                return hit;
            }

            public static RaycastHit GetScreenToRaycastHit(Camera camera, Vector3 screenPos, float maxDistance)
            {
                var ray = camera.ScreenPointToRay(screenPos);
                Physics.Raycast(ray, out var hit, maxDistance);
                return hit;
            }

            public static RaycastHit GetScreenToRaycastHit(Camera camera, Vector3 screenPos, float maxDistance, LayerMask layer)
            {
                var ray = camera.ScreenPointToRay(screenPos);
                Physics.Raycast(ray, out var hit, maxDistance, layer);
                return hit;
            }

            public static Vector3 CannonBallisticVelocity(Vector3 startPos, Vector3 destination, float angle)
            {
                var dir = destination - startPos; 
                var height = dir.y; 
                dir.y = 0; 
                var dist = dir.magnitude;
                var a = angle * Mathf.Deg2Rad;
                dir.y = dist * Mathf.Tan(a);
                dist += height / Mathf.Tan(a);
                var velocity = Mathf.Sqrt(dist * UnityEngine.Physics.gravity.magnitude / Mathf.Sin(2 * a));
                return velocity * dir.normalized;
            }

            public static Vector3 CannonBallisticVelocity(Vector3 startPos, Vector3 destination, float angle, float gravity)
            {
                var dir = destination - startPos; 
                var height = dir.y;
                dir.y = 0; 
                var dist = dir.magnitude;
                var a = angle * Mathf.Deg2Rad;
                dir.y = dist * Mathf.Tan(a);
                dist += height / Mathf.Tan(a);
                var velocity = Mathf.Sqrt(dist * gravity / Mathf.Sin(2 * a));
                return velocity * dir.normalized; 
            }
        }
        #endregion

        #region Effects
        public static class Effects
        {
            public static bool Timer(float timer, float duration, System.Action<float> onTimerUpdateWithPercent = null)
            {
                if (!(timer < duration)) return true;
                timer += Time.deltaTime;
                onTimerUpdateWithPercent?.Invoke(timer / duration);
                return false;
            }

            public static bool Timer(float timer, float duration, float timerSpeed, System.Action<float> onTimerUpdateWithPercent = null)
            {
                if (!(timer < duration)) return true;
                timer += timerSpeed;
                onTimerUpdateWithPercent?.Invoke(timer / duration);
                return false;
            }

            public static bool ReverseTimer(float timer, float targetTime, System.Action<float> onTimerUpdateWithRemaning = null)
            {
                if (!(timer > targetTime)) return true;
                timer -= Time.deltaTime;
                onTimerUpdateWithRemaning?.Invoke(timer - targetTime);
                return false;
            }

            public static bool ReverseTimer(float timer, float targetTime, float timerSpeed, System.Action<float> onTimerUpdateWithRemaning = null)
            {
                if (!(timer > targetTime)) return true;
                timer -= timerSpeed;
                onTimerUpdateWithRemaning?.Invoke(timer - targetTime);
                return false;
            }

            public static Vector3 Shake(float shakeValue)
            {
                return Random.insideUnitSphere * shakeValue * Time.deltaTime;
            }
        }
        #endregion
    }
    
    public static class Extensions
{
    #region Properties
    
    /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            global::System.Random rng = new global::System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static List<T> Shuffle<T>(List<T> _list)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                T temp = _list[i];
                int randomIndex = UnityEngine.Random.Range(i, _list.Count);
                _list[i] = _list[randomIndex];
                _list[randomIndex] = temp;
            }

            return _list;
        }

        /// <summary>
        /// Return a random item from the list.
        /// Sampling with replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new global::System.IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Removes a random item from the list, returning that item.
        /// Sampling without replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new global::System.IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = UnityEngine.Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

    public static float GetRandom(this float value, float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static int GetRandom(this int value, int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static long Lerp(this long value, long target, float t)
    {
        float val = 1 - t;

        if (value < target)
        {
            if (value >= target * val)
            {
                return target;
            }
        }
        else
        {
            if (value <= target * val)
            {
                return target;
            }
        }

        return (long)((1 - t) * (float)value + t * (float)target);
    }

    public static int Lerp(this int value, int target, float t)
    {
        float val = 1 - t;

        if (value < target)
        {
            if (value >= target * val)
            {
                return target;
            }
        }
        else
        {
            if (value <= target * val)
            {
                return target;
            }
        }

        return (int)((1 - t) * (float)value + t * (float)target);
    }

    public static float Lerp(this float value, float target, float t)
    {
        return Mathf.Lerp(value, target, t);
    }


    public static float ToFloat(this string value)
    {
        float val = 0;
        float.TryParse(value, out val);
        return val;
    }

    public static int ToInt(this string value)
    {
        int val = 0;
        int.TryParse(value, out val);
        return val;
    }

    public static string ToCoinValues(this int value)
    {
        if (value > 999999999 || value < -999999999)
        {
            return value.ToString("0,,,.###B", System.Globalization.CultureInfo.InvariantCulture);
        }
        else if (value > 999999 || value < -999999)
        {
            return value.ToString("0,,.##M", System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            return value.ToString("n0");
        }
    }

    public static string ToCoinValues(this long value)
    {
        if (value > 999999999 || value < -999999999)
        {
            return value.ToString("0,,,.###B", System.Globalization.CultureInfo.InvariantCulture);
        }
        else if (value > 999999 || value < -999999)
        {
            return value.ToString("0,,.##M", System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            return value.ToString("n0");
        }
    }

    #endregion

    #region Unity Properties

    public static ParticleSystem SetStartColor(this ParticleSystem particleSystem, Color color)
    {
        var main = particleSystem.main;
        main.startColor = color;
        return particleSystem;
    }

    public static Texture2D ToTexture2D(this Texture texture)
    {
        return Texture2D.CreateExternalTexture(
            texture.width,
            texture.height,
           TextureFormat.RGBA32,
            false, false,
            texture.GetNativeTexturePtr());
    }

    public static float GetRandom(this Vector2 val)
    {
        return UnityEngine.Random.Range(val.x, val.y);
    }

    public static bool HasComponent<T>(this Component gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    public static void SetActiveGameObject(this Component comp, bool statue)
    {
        comp.gameObject.SetActive(statue);
    }

    public static Transform ResetLocal(this Transform target)
    {
        target.localPosition = Vector3.zero;
        target.localRotation = Quaternion.identity;
        target.localScale = Vector3.one;
        return target;
    }

    public static Vector3 IsNan(this Vector3 val, Vector3 defaultValue)
    {
        if (float.IsNaN(val.x) || float.IsInfinity(val.x))
        {
            val.x = defaultValue.x;
        }

        if (float.IsNaN(val.y) || float.IsInfinity(val.y))
        {
            val.y = defaultValue.y;
        }

        if (float.IsNaN(val.z) || float.IsInfinity(val.z))
        {
            val.z = defaultValue.z;
        }

        return val;
    }

    public static Transform LerpRotation(this Transform target, Quaternion targetRot, float t, bool lockX, bool lockY,
        bool lockZ)
    {
        Vector3 targetEuler = targetRot.eulerAngles;
        if (lockX)
            targetEuler.x = target.localEulerAngles.x;

        if (lockY)
            targetEuler.y = target.localEulerAngles.y;

        if (lockZ)
            targetEuler.z = target.localEulerAngles.z;


        target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(targetEuler), t);
        return target;
    }

    #endregion

    #region Collections

    public static T AddItem<T>(this List<T> list, T item)
    {
        if (list == null)
            list = new List<T>();

        list.Add(item);

        return item;
    }

    public static T GetLastItem<T>(this List<T> list)
    {
        return list[list.Count - 1];
    }

    public static T GetLastItem<T>(this T[] list)
    {
        return list[list.Length - 1];
    }

    public static List<T> CreateOrClear<T>(this List<T> list)
    {
        if (list == null)
        {
            list = new List<T>();
        }
        else
        {
            list.Clear();
        }

        return list;
    }

    public static T Find<T>(this T[] array, Predicate<T> match)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (match(array[i]))
            {
                return array[i];
            }
        }

        return default;
    }

    public static List<T> FindAll<T>(this T[] array, Predicate<T> match)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Length; i++)
        {
            if (match(array[i]))
            {
                list.Add(array[i]);
            }
        }

        return list;
    }

    public static T GetRandom<T>(this IEnumerable<T> values)
    {
        return values.ElementAt(UnityEngine.Random.Range(0, values.Count()));
    }
    
    public static T GetRandomWithCondition<T>(this List<T> list, Func<T, bool> condition)
    {
        return list.Where(condition).GetRandom();
    }

    public static T GetRandomWithCondition<T>(this T[] list, Func<T, bool> condition)
    {
        return list.Where(condition).GetRandom();
    }

    public static T GetRandomItem<T>(this List<T> list) {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    
    public static T GetRandom<T>(this T[] list)
    {
        return list[UnityEngine.Random.Range(0, list.Length)];
    }

    public static int GetRandomIndex<T>(this T[] list)
    {
        return UnityEngine.Random.Range(0, list.Length);
    }

    public static int GetRandomIndex<T>(this List<T> list)
    {
        return UnityEngine.Random.Range(0, list.Count);
    }

    public static T[] GetRandomItems<T>(this T[] list, int count)
    {
        T[] arrays = new T[count];
        int diff = list.Length / count;
        int startIndex = 0;

        for (int i = 0; i < count; i++)
        {
            int endIndex = (i * diff) + diff;
            int index = UnityEngine.Random.Range(startIndex, endIndex);
            arrays[i] = list[index];
            startIndex = endIndex;
        }

        return arrays;
    }

    public static List<T> GetRandomItems<T>(this List<T> list, int count)
    {
        List<T> arrays = new List<T>();
        int diff = list.Count / count;
        int startIndex = 0;

        for (int i = 0; i < count; i++)
        {
            int endIndex = (i * diff) + diff;
            int index = UnityEngine.Random.Range(startIndex, endIndex);
            arrays.Add(list[index]);
            startIndex = endIndex;
        }

        return arrays;
    }

    public static T[] ShuffleArray<T>(this T[] list)
    {
        System.Random r = new System.Random();
        for (int i = 0; i < list.Length; i++)
        {
            var obj = list[i];
            int index = r.Next(0, list.Length);
            var randomObj = list[index];
            list[index] = obj;
            list[i] = randomObj;
        }

        return list;
    }

    public static List<T> ShuffleList<T>(this List<T> list)
    {
        System.Random r = new System.Random();
        for (int i = 0; i < list.Count; i++)
        {
            var obj = list[i];
            list.Remove(obj);
            int index = r.Next(0, list.Count);
            list.Insert(index, obj);
        }

        return list;
    }

    public static List<T> SetIndex<T>(this List<T> list, int index, int targetIndex)
    {
        if (targetIndex < list.Count)
        {
            T targetObj = list[targetIndex];
            T obj = list[index];

            list[targetIndex] = obj;
            list[index] = targetObj;
        }

        return list;
    }

    public static T[] SetIndex<T>(this T[] list, int index, int targetIndex)
    {
        if (targetIndex < list.Length)
        {
            T targetObj = list[targetIndex];
            T obj = list[index];

            list[targetIndex] = obj;
            list[index] = targetObj;
        }

        return list;
    }

    #endregion
}

