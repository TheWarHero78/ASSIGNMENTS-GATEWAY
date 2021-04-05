export class Cars {
  car:any
  nextCar:any;
  getNextCar:any;
  constructor(){
    this.car = 'Audi';
    this.nextCar = function() {
      this.car = 'BMW';
      return this.car;
    },
    this.getNextCar = function() {
      return this.nextCar();
    }
  };
}
