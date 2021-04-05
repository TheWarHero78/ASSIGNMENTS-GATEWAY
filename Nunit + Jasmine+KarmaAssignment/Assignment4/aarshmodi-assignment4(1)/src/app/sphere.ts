export class Sphere {
  area:any;
  constructor(){
    this.area=function(r) {
      return 4*Math.PI*(r*r);
    }
  }
}
