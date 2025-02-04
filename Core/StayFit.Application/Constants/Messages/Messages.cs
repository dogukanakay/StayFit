using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Constants.Messages
{
    public static class Messages
    {

        //Validation Messages Register
        public const string PasswordCannotBeEmpty = "Password cannot be empty.";
        public const string PasswordMinLength = "Password must be at least 8 characters long.";
        public const string PasswordMaxLength = "Password cannot be longer than 36 characters.";
        public const string PasswordMustContainUppercase = "Password must contain at least one uppercase letter.";
        public const string PasswordMustContainLowercase = "Password must contain at least one lowercase letter.";
        public const string PasswordMustContainDigit = "Password must contain at least one digit.";
        public const string PasswordCannotContainSpaces = "Password cannot contain spaces.";

        public const string EmailCannotBeEmpty = "Email cannot be empty.";
        public const string InvalidEmailFormat = "Please enter a valid email address.";
        public const string EmailFormatNotValid = "Email address is not in a valid format.";

        public const string PhoneCannotBeEmpty = "Phone number cannot be empty.";
        public const string InvalidPhoneNumber = "Please enter a valid phone number. (Example: +905555555555 or 05555555555)";
        public const string PhoneMaxLengthExceeded = "Phone number cannot be longer than 15 characters.";

        public const string FirstNameCannotBeEmpty = "First name cannot be empty.";
        public const string FirstNameMaxLengthExceeded = "First name cannot be longer than 50 characters.";

        public const string LastNameCannotBeEmpty = "Last name cannot be empty.";
        public const string LastNameMaxLengthExceeded = "Last name cannot be longer than 50 characters.";

        public const string WeightCannotBeEmptyOrZero = "Weight value cannot be empty or zero.";
        public const string HeightCannotBeEmptyOrZero = "Height value cannot be empty or zero.";

        public const string BioCannotBeEmpty = "Bio cannot be empty.";
        public const string BioMinLength = "Bio must be at least 30 characters long.";
        public const string BioMaxLength = "Bio cannot be longer than 200 characters.";

        //Validation Messages WeeklyProgress
        public const string WaistCircumferenceCannotBeEmpty = "Waist circumference cannot be empty.";
        public const string NeckCircumferenceCannotBeEmpty = "Neck circumference cannot be empty.";
        public const string WaistMustBeGreaterThanNeck = "Waist circumference must be greater than neck circumference.";

        //Validation Messages UpdatePassword
        public const string CurrentPasswordCannotBeEmpty = "Current password cannot be empty.";
        public const string NewPasswordCannotBeSameAsCurrent = "New password cannot be the same as the current password.";


        //Register Messages
        public const string RegistrationSuccessful = "Registration successful.";
        public const string RegistrationFailed = "Registration failed.";
        public const string EmailAlreadyExists = "This email is already registered.";
        public const string PhoneAlreadyExists = "This phone number is already registered.";

        //Login Messages
        public const string LoginSuccessful = "Login successful.";
        public const string LoginFailed = "Incorrect password or username.";

        //UpdatePassword Messages
        public const string IncorrectCurrentPassword = "Incorrect current password.";
        public const string PasswordUpdatedSuccessful = "Password updated successfuly.";
        public const string PasswordUpdatedFailed = "Password could not be updated.";

        //DietDays Messages

        public const string DietDayAlreadyExist = "There is already a diet list registered for today.";
        public const string DietDayCreatedSuccessful = "Diet day created successfuly.";
        public const string DietDayCreatedFailed = "Diet day create failed.";
        public const string DietDayNotFound = "Diet day not found.";
        public const string DietDayDeletedSuccessful = "Diet day deleted successfuly.";
        public const string DietDayDeletedFailed = "Diet day delete failed.";
        public const string DietDayCannotCompleted = "You can only enter completion for today.";
        public const string DietDayComletedSuccessful = "Congratulations. You've completed the diet day.";
        public const string DietDayComletedFailed = "The diet day is not marked as completed.";
        public const string DietDayListedSuccessful = "Diet days listed successfully";


        //DietPlan Messages
        public const string DietPlanAlreadyExist = "There is already a diet plan for these date ranges.";
        public const string DietPlanCreatedSuccessful = "Diet plan created successfuly.";
        public const string DietPlanCreatedFailed = "Diet plan create failed.";
        public const string DietPlanNotFoundById = "No diet plan found for this id.";
        public const string DietPlanDeletedSuccessful = "The diet plan has been deleted successfully.";
        public const string DietPlanDeletedFailed = "There was a problem deleting the diet plan.";
        public const string DietPlanNotFoundForSubscription = "No diet plan found for this subscription.";
        public const string DietPlanNotFoundForMember = "No diet plan found for this member.";
        public const string DietPlanListedSuccessful = "Diet plan listed successfully";


        //Diet Messages
        public const string DietCreatedSuccessful = "Diet list created successfuly.";
        public const string DietDeletedSuccessful = "Diet deleted successfuly.";
        public const string DietCreatedFailed = "Diet list created successfuly.";
        public const string DietDeletedFailed = "Diet  delete failed.";
        public const string DietNotFound = "Diet not found.";
        public const string DietUpdatedByAI = "Your new diet will be ready shortly.";
        public const string DietNotFoundForToday = "No diet found for today.";
        public const string DietListedSuccessful = "Diet list listed successfully";


        //Exercise Messages
        public const string ExerciseCreatedSuccessful = "Exercise list created successfuly.";
        public const string ExerciseCreatedFailed = "Exercise list create failed.";
        public const string ExerciseDeletedSuccessful = "Exercise deleted successfuly.";
        public const string ExerciseDeletedFailed = "Exercise delete failed.";
        public const string ExerciseNotFound = "Exercise not found.";
        public const string ExerciseNotFoundForToday = "No exercise found for today.";
        public const string ExerciseListedSuccessful = "Exercise list listed successfully";

        //Member Messages
        public const string MemberProfileUpdatedSuccessful = "Profile updated successfuly.";
        public const string MemberProfileUpdatedFailed = "Profile update failed.";
        public const string MemberProfileLoadedSuccessful = "Member profile loaded successfully.";
        public const string MemberProfileNotFound = "Member profile not found.";

        //Subscription Messages
        public const string SubscriptionCreatedSuccessful = "Subscription created successfuly.";
        public const string SubscriptionCreatedFailed = "Subscription create failed.";
        public const string SubscriptionNotFound = "No subscription found.";
        public const string SubscriptionListedSuccessfuly = "Subscription listed successfuly.";
        public const string SubscriptionIdWrong = "The subscription is wrong.";

        //Trainer Messages
        public const string TrainerProfileUpdatedSuccessful = "Profile updated successfuly.";
        public const string TrainerProfileUpdatedFailed = "Profile update failed.";
        public const string TrainerNotFound = "Trainer not found.";
        public const string TrainerListedSuccessful = "Trainers listed successfuly.";
        public const string TrainerProfileLoadedSuccessful = "Trainer profile loaded successfully.";
        public const string TrainerProfileNotFound = "Trainer profile not found.";


        //User Messages
        public const string PhotoUpdatedSuccessful = "Profile photo update successfuly.";
        public const string PhotoUpdatedFailed = "Profile photo update failed.";

        //WeeklyProgress Messages
        public const string WeeklyProgressCreatedSuccessful = "Weekly progress created successfuly.";
        public const string WeeklyProgressCreatedByAI = "Measurements are being made by AI. You will receive a notification when the process is complete.";
        public const string WeeklyProgressCreatedFailed = "Weekly progress create failed.";
        public const string WeeklyProgressImageNotFound = "The transaction could not be completed. 2 photos should be sent, 1 from the front and 1 from the side.";
        public const string WeeklyProgressNotFound = "No progress found.";
        public const string WeeklyProgressListedSuccessful = "Weekly progresses listed successfuly";


        //WorkoutDay Messages
        public const string WorkoutDayAlreadyExist = "There is already a exercise list registered for today.";
        public const string WorkoutDayCreatedSuccessful = "Workout day created successfuly.";
        public const string WorkoutDayDeletedSuccessful = "Workout day deleted successfuly.";
        public const string WorkoutDayUpdatedSuccessful = "Workout day updated successfuly.";
        public const string WorkoutDayCreateFailed = "Workout day create failed.";
        public const string WorkoutDayDeleteFailed = "Workout day delete failed.";
        public const string WorkoutDayUpdateFailed = "Workout day update failed.";
        public const string WorkoutDayNotFound = "Workout day not found.";
        public const string WorkoutDayComletedSuccessful = "Congratulations. You've completed the workout day.";
        public const string WorkoutDayComleteFailed = "The workout day is not marked as completed.";
        public const string WorkoutDayCannotCompleted = "You can only enter completion for today.";
        public const string WorkoutDayListedSuccessful = "Workout days listed successfuly.";


        //WorkoutPlan Messages
        public const string WorkoutPlanAlreadyExist = "There is already a workout plan for these date ranges.";
        public const string WorkoutPlanCreatedSuccessful = "Workout plan created successfuly.";
        public const string WorkoutPlanUpdatedSuccessful = "Workout plan updated successfuly.";
        public const string WorkoutPlanCreateFailed = "Workout plan create failed.";
        public const string WorkoutPlanUpdateFailed = "Workout plan update failed.";
        public const string WorkoutPlanNotFoundById = "No workout plan found for this id.";
        public const string WorkoutPlanNotFound = "No workout plan found.";
        public const string WorkoutPlanDeletedSuccessful = "The workout plan has been deleted successfully.";
        public const string WorkoutPlanDeleteFailed = "There was a problem deleting the workout plan.";
        public const string WorkoutPlanListedSuccessful = "Workout plans listed successfuly.";


        //FoodInformation Messages
        public const string FoodInformationsNotFound = "Food not found.";
        public const string FoodInformationsListedSuccessful = "Foods listed successfuly.";


    }
}
