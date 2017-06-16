//
// Please report any problems with this app template to contact@estimote.com
//

#import "ViewController.h"

#import "BeaconDetails.h"
#import "BeaconDetailsCloudFactory.h"
#import "CachingContentFactory.h"
#import "ProximityContentManager.h"
#import "Store.h"
#import "Location.h"
#import "Event.h"
#import "EventDetailViewController.h"
#import "EventTableCell.h"

@interface ViewController () <ProximityContentManagerDelegate>

@property (weak, nonatomic) IBOutlet UILabel *label;
@property (weak, nonatomic) IBOutlet UIImageView *image;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;

@property (nonatomic) ProximityContentManager *proximityContentManager;

@end

@implementation ViewController

@synthesize EventTableView, NotifySwitch;

-(void) refresh
{
  
    
    void (^eventsBlock)(void) = ^{
        
          [[NSOperationQueue mainQueue] addOperationWithBlock:^ {
              [EventTableView reloadData];
              [EventTableView.refreshControl endRefreshing];
          }];
    };
    
    [[Store SharedInstance] GetEvents:eventsBlock];
    
    
   
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self.activityIndicator startAnimating];
 

    
    
    EventTableView.autoresizingMask = UIViewAutoresizingFlexibleHeight|UIViewAutoresizingFlexibleWidth;
    EventTableView.delegate = self;
    EventTableView.dataSource = self;
    [EventTableView reloadData];

    EventTableView.refreshControl = [[UIRefreshControl alloc] init];
    EventTableView.refreshControl.backgroundColor =  [UIColor colorWithRed:14/255.0 green:29/255.0 blue:82/255.0 alpha:1.0];
    EventTableView.refreshControl.tintColor = [UIColor whiteColor];
    [EventTableView.refreshControl addTarget:self
                            action:@selector(refresh)
                  forControlEvents:UIControlEventValueChanged];
    
    
    void (^locationsBlock)(void) = ^{
        //done!
        [self InitializeBeacons];
        
        
       
      
         [[NSOperationQueue mainQueue] addOperationWithBlock:^ {
              [EventTableView reloadData];
             
         }];
        
    };
    
    void (^eventsBlock)(void) = ^{
        [[Store SharedInstance] GetLocations:locationsBlock];
    };
    
    void (^tracksBlock)(void) = ^{
        [[Store SharedInstance] GetEvents:eventsBlock];
    };
    
    UIDevice *currentDevice = [UIDevice currentDevice];
    NSString *deviceId = [[currentDevice identifierForVendor] UUIDString];
    NSLog(@"DeviceId:%@", deviceId);
    Store.SharedInstance.UserId = deviceId;
    
    [[Store SharedInstance] GetTracks:tracksBlock];
}

-(void) InitializeBeacons
{
    
    [[NSOperationQueue mainQueue] addOperationWithBlock:^ {
        
        //Your code goes in here
        NSLog(@"Main Thread Code");
        NSMutableArray *arrBeacons = [[NSMutableArray alloc] init];
        for (int i = 0; i < [[[Store SharedInstance] Locations] count]; i++)
        {
            Location *tempLocation =[[Store SharedInstance] Locations][i];
            NSLog(@"%@", tempLocation);
            BeaconID *tempBeacon = [[BeaconID alloc] initWithUUIDString:@"B9407F30-F5F8-466E-AFF9-25556B57FE6D" major:[[tempLocation Major] intValue] minor:[[tempLocation Minor] intValue]];
            
            [arrBeacons addObject:tempBeacon];
            
        }
        //do this first so always on is requested
        self.beaconNotificationsManager = [BeaconNotificationsManager new];
        for (int i = 0; i < arrBeacons.count; i++)
        {
            [self.beaconNotificationsManager enableNotificationsForBeaconID:
             arrBeacons[i]
                                                               enterMessage:@"Hello"
                                                                exitMessage:@"Goodbye"
             ];
            
        }

        self.proximityContentManager = [[ProximityContentManager alloc]
                                        initWithBeaconIDs:[NSArray arrayWithArray:arrBeacons]                                    beaconContentFactory:[[CachingContentFactory alloc] initWithBeaconContentFactory:[BeaconDetailsCloudFactory new]]];
        self.proximityContentManager.delegate = self;
        
        [self.proximityContentManager startContentUpdates];
        
    }];
    
}

Event *_lastEvent;
bool isEventDetailVisible = false;
EventDetailViewController *eventDetailViewController;

- (void)proximityContentManager:(ProximityContentManager *)proximityContentManager didUpdateContent:(id)content {
    
    if (Store.SharedInstance.CheckLocation)
    {
    
    [self.activityIndicator stopAnimating];
    [self.activityIndicator removeFromSuperview];
    
    BeaconDetails *beaconDetails = content;
    if (beaconDetails == nil)
    {
        if (_lastEvent != nil)
        {
            void (^sessionBlock)(void) = ^{
                
            };
            [[Store SharedInstance] NewSession:_lastEvent withEntering:false withBlock:sessionBlock];
        }
        _lastEvent = nil;
        if (Store.SharedInstance.IsEventDetailVisible)
        {
            //isEventDetailVisible = false;
            //[self.navigationController popViewControllerAnimated:YES];
            eventDetailViewController.RadioImage.hidden = true;
            eventDetailViewController.ProximityLabel.hidden = true;
        }
    }
    else if (beaconDetails != nil)
    {
    
    Event *proximityEvent = [[Store SharedInstance] ProximityEvent:beaconDetails.beaconName];
    if (proximityEvent == nil)
    {
        if (Store.SharedInstance.IsEventDetailVisible)
        {
            //isEventDetailVisible = false;
            //[self.navigationController popViewControllerAnimated:YES];
            eventDetailViewController.RadioImage.hidden = true;
            eventDetailViewController.ProximityLabel.hidden = true;
        }
    }
    else if (proximityEvent != _lastEvent)
    {
          NSLog(@"Event Name:%@", proximityEvent.Name);
        _lastEvent = proximityEvent;
        
       
 
        Store.SharedInstance.CurrentEvent = proximityEvent;
        
      if (Store.SharedInstance.IsEventDetailVisible)
      {
     
          [eventDetailViewController UpdateDisplayValues];
          eventDetailViewController.RadioImage.hidden = false;
          eventDetailViewController.ProximityLabel.hidden = false;
      }
      else
      {
            if (eventDetailViewController == nil)
            {
                eventDetailViewController = [self.storyboard instantiateViewControllerWithIdentifier:@"Event Detail"];
            }
             [self.navigationController pushViewController: eventDetailViewController  animated:YES];
            Store.SharedInstance.IsEventDetailVisible = true;
          eventDetailViewController.RadioImage.hidden = false;
          eventDetailViewController.ProximityLabel.hidden = false;
           [eventDetailViewController UpdateDisplayValues];
       }
        
       

        void (^sessionBlock)(void) = ^{
           
        };
        
        [[Store SharedInstance] NewSession:proximityEvent withEntering:true withBlock:sessionBlock];
    }
        
        
    }
    if (beaconDetails) {
       // self.view.backgroundColor = beaconDetails.backgroundColor;
        self.label.text = [NSString stringWithFormat:@"You're in %@'s range!", beaconDetails.beaconName];
        self.image.hidden = NO;
    } else {
        //self.view.backgroundColor = BeaconDetails.neutralColor;
        self.label.text = @"No beacons in range.";
        self.image.hidden = YES;
    }
        
    }
}

- (UIStatusBarStyle)preferredStatusBarStyle {
    return UIStatusBarStyleLightContent;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)DoneButtonClick:(id)sender {
    
    
    //submit to webservice here
    
}


- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Number of rows is the number of time zones in the region for the specified section.
    
    if (Store.SharedInstance.Events.count == 0)
    {
        return 1;
    }
    else
    {
         return [[[Store SharedInstance] FilteredEvents] count];
    }
   

}


- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section {
    // The header for the section is the region name -- get this from the region at the section index.
   
    return @"Upcoming Events";
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *MyIdentifier = @"MyReuseIdentifier";

    
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:MyIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle  reuseIdentifier:MyIdentifier];
    }
   
    
    if (Store.SharedInstance.FilteredEvents.count == 0)
    {
        cell.textLabel.text = @"Loading schedule...";
        
    }
    else
    {
         Event *event = [[[Store SharedInstance] FilteredEvents] objectAtIndex:indexPath.row];
        cell.textLabel.text = event.Name;
       // NSLog(@"Table Event Name:%@", event.Name);
        NSString *timeToStart;
        //NSLog(@"Now:%@", [NSDate date]);
      
        timeToStart   = [self timeAgo:event.StartDate];
       
        cell.detailTextLabel.text = timeToStart;
    
    }
    
    cell.backgroundColor = [UIColor colorWithRed:14/255.0 green:29/255.0 blue:82/255.0 alpha:1.0];
    cell.textLabel.textColor = [UIColor whiteColor];
     cell.detailTextLabel.textColor = [UIColor whiteColor];
    return cell;
}

-(void) tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Event *event = [[[Store SharedInstance] FilteredEvents] objectAtIndex:indexPath.row];
    Store.SharedInstance.CurrentEvent = event;
    
    
    if (eventDetailViewController == nil)
    {
        eventDetailViewController = [self.storyboard instantiateViewControllerWithIdentifier:@"Event Detail"];
    }
     [eventDetailViewController UpdateDisplayValues];
    [self.navigationController pushViewController: eventDetailViewController  animated:YES];
    Store.SharedInstance.IsEventDetailVisible = true;
   
}



- (NSString *)timeToStart: (double) deltaSeconds withMinutes:(double) deltaMinutes withDate:(NSDate *) theDate
{
    //NSDate *now = [NSDate date];
   // double deltaSeconds = [theDate timeIntervalSinceDate:now];
    //double deltaMinutes = deltaSeconds / 60.0f;
    if (deltaSeconds < 0)
    {
    deltaSeconds *= -1;
    }
    if (deltaMinutes < 0)
    {
        deltaMinutes *= -1;
    }
    
    int minutes;
    
    if(deltaSeconds < 5)
    {
        return @"Just now";
    }
    else if(deltaSeconds < 60)
    {
        return [self stringFromFormat:@"In %i seconds" withValue:deltaSeconds withDate:theDate];
    }
    else if(deltaSeconds < 120)
    {
        return @"A minute ago";
    }
    else if (deltaMinutes < 60)
    {
        return [self stringFromFormat:@"In %i minutes" withValue:deltaMinutes withDate:theDate];
    }
    else if (deltaMinutes < 120)
    {
        return @"An hour ago";
    }
    else if (deltaMinutes < (24 * 60))
    {
        minutes = (int)floor(deltaMinutes/60);
        return [self stringFromFormat:@"In %i hours" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 2))
    {
        return @"Tomorrow";
    }
    else if (deltaMinutes < (24 * 60 * 7))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24));
        return [self stringFromFormat:@"In %i days" withValue:minutes withDate:theDate];    }
    else if (deltaMinutes < (24 * 60 * 14))
    {
        return @"Next week";
    }
    else if (deltaMinutes < (24 * 60 * 31))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24 * 7));
        return [self stringFromFormat:@"In %i weeks" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 61))
    {
        return @"next month";
    }
    else if (deltaMinutes < (24 * 60 * 365.25))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24 * 30));
        return [self stringFromFormat:@"In %i months" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 731))
    {
        return @"Next year";
    }
    
    minutes = (int)floor(deltaMinutes/(60 * 24 * 365));
    return [self stringFromFormat:@"In %i years" withValue:minutes withDate:theDate];
    
}

- (NSString *)timeAgo: (NSDate *) theDate
{
    NSDate *now = [NSDate date];
    double deltaSeconds = [now timeIntervalSinceDate:theDate];
    double deltaMinutes = deltaSeconds / 60.0f;
    
    int minutes;
    if (deltaSeconds < 0)
    {
        return [self timeToStart:deltaSeconds withMinutes:deltaMinutes withDate:theDate];
    }
    else  if(deltaSeconds < 5)
    {
        return @"Just now";
    }
    else if(deltaSeconds < 60)
    {
        return [self stringFromFormat:@"%i seconds ago" withValue:deltaSeconds withDate:theDate];
    }
    else if(deltaSeconds < 120)
    {
        return @"A minute ago";
    }
    else if (deltaMinutes < 60)
    {
        return [self stringFromFormat:@"%i minutes ago" withValue:deltaMinutes withDate:theDate];
    }
    else if (deltaMinutes < 120)
    {
        return @"An hour ago";
    }
    else if (deltaMinutes < (24 * 60))
    {
        minutes = (int)floor(deltaMinutes/60);
        return [self stringFromFormat:@"%i hours ago" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 2))
    {
        return @"Yesterday";
    }
    else if (deltaMinutes < (24 * 60 * 7))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24));
        return [self stringFromFormat:@"%i days ago" withValue:minutes withDate:theDate];    }
    else if (deltaMinutes < (24 * 60 * 14))
    {
        return @"Last week";
    }
    else if (deltaMinutes < (24 * 60 * 31))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24 * 7));
        return [self stringFromFormat:@"%i weeks ago" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 61))
    {
        return @"Last month";
    }
    else if (deltaMinutes < (24 * 60 * 365.25))
    {
        minutes = (int)floor(deltaMinutes/(60 * 24 * 30));
        return [self stringFromFormat:@"%i months ago" withValue:minutes withDate:theDate];
    }
    else if (deltaMinutes < (24 * 60 * 731))
    {
        return @"Last year";
    }
    
    minutes = (int)floor(deltaMinutes/(60 * 24 * 365));
    return [self stringFromFormat:@"%i years ago" withValue:minutes withDate:theDate];
}

- (NSString *) stringFromFormat:(NSString *)format withValue:(NSInteger)value withDate:(NSDate*) theDate
{
    // NSString * localeFormat = [NSString stringWithFormat:format, value];
    return [NSString stringWithFormat:(format), value];
}

- (IBAction)NotifySwitchChanged:(id)sender {
    
        if ([NotifySwitch isOn])
        {
            Store.SharedInstance.CheckLocation = true;
            //notification telling them to go to settings to turn on location to always and
            //to turn on bluetooth
            NSString *message = @"Please be sure that you have enabled location for this app in your settings, and to enable bluetooth on your phone.";
            
            UIAlertController *alertController = [UIAlertController alertControllerWithTitle:@"Looking for Events!" message:message preferredStyle:UIAlertControllerStyleAlert];
            [alertController addAction:[UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault handler:nil]];
            [self presentViewController:alertController animated:YES completion:nil];
            
        }
        else
        {
            Store.SharedInstance.CheckLocation = false;
        }
    
}
@end
