//
//  EventDetailViewController.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/12/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "EventDetailViewController.h"
#import "Store.h"

@interface EventDetailViewController ()

@end

@implementation EventDetailViewController

@synthesize NameLabel, TimeLabel, PresenterLabel, SummaryLabel;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
  
    
    [self UpdateDisplayValues];
    
    
    self.navigationItem.hidesBackButton = YES;
    UIBarButtonItem *newBackButton = [[UIBarButtonItem alloc] initWithTitle:@"Back" style:UIBarButtonItemStyleBordered target:self action:@selector(back:)];
    self.navigationItem.leftBarButtonItem = newBackButton;
    
}

- (void) back:(UIBarButtonItem *)sender {
    // Perform your custom actions
    // ...
    // Go back to the previous ViewController
    Store.SharedInstance.IsEventDetailVisible = false;
    [self.navigationController popViewControllerAnimated:YES];
}

-(void) UpdateDisplayValues {
    
    NSLog(@"Current Event: %@",Store.SharedInstance.CurrentEvent);

    NameLabel.text = Store.SharedInstance.CurrentEvent.Name;
    
    
    NSDateFormatter *endDateFormatter = [[NSDateFormatter alloc] init];
    //NSLocale *loc = [[NSLocale alloc] initWithLocaleIdentifier:@"en_US"];
    //[endDateFormatter setLocale:loc];
    //endDateFormatter.timeZone = [NSTimeZone setDefaultTimeZone:@"GMT/UTC - 5:00"];
    
    
    endDateFormatter.timeStyle = NSDateFormatterShortStyle;
    endDateFormatter.dateStyle = NSDateFormatterNoStyle;
    
    NSDateFormatter *startDateFormatter = [[NSDateFormatter alloc] init];
    startDateFormatter.timeStyle = NSDateFormatterShortStyle;
    startDateFormatter.dateStyle = NSDateFormatterShortStyle;
    
    NSString *startDate = [startDateFormatter stringFromDate:Store.SharedInstance.CurrentEvent.StartDate];
    
     NSString *endDate = [endDateFormatter stringFromDate:Store.SharedInstance.CurrentEvent.EndDate];
    

    
    NSString *timeString = [NSString stringWithFormat:@"%@ - %@", startDate, endDate];
    
    TimeLabel.text = timeString;
    PresenterLabel.text = Store.SharedInstance.CurrentEvent.Presenter;
    SummaryLabel.text = Store.SharedInstance.CurrentEvent.Summary;
    
    
    [NameLabel sizeToFit];
    [PresenterLabel sizeToFit];
    [SummaryLabel sizeToFit];
    [TimeLabel sizeToFit];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
