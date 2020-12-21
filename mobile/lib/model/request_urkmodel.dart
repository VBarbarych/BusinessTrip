class RequestUrkModel {
  final String username;
  final String unit;
  final String purpose;
  final String payment;
  final String department;
  final String outlay;
  final String city;
  final String country;
  final String transport;
  final String insitution;
  final String dateform;
  final String dateto;
  final String route;
  final String reason;
  const RequestUrkModel(
      {this.username,
      this.unit,
      this.payment,
      this.purpose,
      this.city,
      this.dateform,
      this.dateto,
      this.department,
      this.insitution,
      this.outlay,
      this.reason,
      this.route,
      this.transport,
      this.country});
  factory RequestUrkModel.fromJson(Map<String, dynamic> json) =>
      RequestUrkModel(
        username: json['username'],
        unit: json['unit'],
        payment: json['payment'],
        purpose: json['purpose'],
        city: json['city'],
        dateform: json['dateform'],
        dateto: json['dateto'],
        department: json['department'],
        insitution: json['insitution'],
        outlay: json['outlay'],
        reason: json['reason'],
        route: json['route'],
        transport: json['transport'],
        country: json['country']
      );
  Map<String, dynamic> toJson() {
    return {
      'username': username,
      'unit': unit,
      'purpose': purpose,
      'payment': payment,
      'department': department,
      'outlay': outlay,
      'city': city,
      'dateform': dateform,
      'dateto': dateto,
      'insitution': insitution,
      'reason': reason,
      'route': route,
      'transport': transport,
      'country': country
    };
  }
}
