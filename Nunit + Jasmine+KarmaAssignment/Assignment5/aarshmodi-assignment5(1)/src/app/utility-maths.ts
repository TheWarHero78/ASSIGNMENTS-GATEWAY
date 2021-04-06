export class UtilityMaths {

  public areaOfCircle(r: number) {
    return Math.PI * (r * r);
  }

  public areaOfTriangle(base: number, height: number) {
    return base * height / 2;
  }

  public areaOfRectangle(width: number, height: number) {
    return width * height;
  }

  public areaOfCone(radius: number, sh: number) {
    return Math.PI * radius * sh;
  }

  public areaOfSphere(radius: number) {
    return 4*Math.PI*(radius*radius);
  }

}
