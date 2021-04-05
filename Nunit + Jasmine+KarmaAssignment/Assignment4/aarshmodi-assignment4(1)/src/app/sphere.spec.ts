import { Sphere } from './sphere';

describe('Sphere', () => {
  it('should create an instance', () => {
    expect(new Sphere()).toBeTruthy();
  });

  describe(" Sphere The 'toHaveBeenCalled' spy matcher", function () {
    it('should track that the spy was called', function () {
      var s = new Sphere();
      spyOn(s, 'area');
      s.area(2);
      expect(s.area).toHaveBeenCalled();
    });
  });

  describe(" Sphere  The 'toHaveBeenCalledWith' spy matcher", function () {
    it('should track the arguments of its calls', function () {
      var s = new Sphere();
      spyOn(s, 'area');
      s.area(2);
      expect(s.area).toHaveBeenCalledWith(2);
    })
  });

  describe(" Sphere The 'toHaveBeenCalledTimes' spy matcher", function () {
    it('should track the number of times the spy was called', function () {
      var s = new Sphere();
      spyOn(s, 'area');
      s.area(2);
      expect(s.area).toHaveBeenCalledTimes(1);
    });
  });
});




