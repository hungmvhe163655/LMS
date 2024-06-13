import React, { useState } from "react";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  InputOTP,
  InputOTPGroup,
  InputOTPSeparator,
  InputOTPSlot,
} from "@/components/ui/input-otp";

const validCode = "012345";

// FormSchema and Validation
const FormSchema = z.object({
  email: z.string().min(6, {
    message: "Email must have more than 6 characters",
  }),
});

const ValidateEmail: React.FC = () => {
  const [isOTPSent, setIsOTPSent] = useState(false);
  const [otp, setOtp] = useState(Array(6).fill(""));

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: "",
    },
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    console.log(data);
    setIsOTPSent(true);
  }

  function handleOTPChange(index: number, value: string) {
    const newOtp = [...otp];
    newOtp[index] = value;
    setOtp(newOtp);
  }

  function handleOTPSubmit() {
    const enteredCode = otp.join("");
    if (enteredCode === validCode) {
      alert("OTP is correct");
    } else {
      alert("OTP is incorrect");
    }
  }

  return (
    <div>
      <Card className="card">
        <CardHeader>
          <CardTitle>Login</CardTitle>
          <CardDescription>
            Welcome to SAP Lab Management System
          </CardDescription>
        </CardHeader>
        <CardContent className="card-content">
          <Form {...form}>
            <form
              onSubmit={form.handleSubmit(onSubmit)}
              className="w-2/3 space-y-6"
            >
              {/* Email or Phone Number Input Field */}
              <FormField
                control={form.control}
                name="email"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Email Or Phone Number</FormLabel>
                    <FormControl>
                      <Input placeholder="example@gmail.com" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button type="submit">Send email</Button>
            </form>
          </Form>

          {isOTPSent && (
            <div>
              <InputOTP
                maxLength={6}
                onChange={(value, index) => handleOTPChange(index, value)}
              >
                <InputOTPGroup>
                  <InputOTPSlot index={0} />
                  <InputOTPSlot index={1} />
                  <InputOTPSlot index={2} />
                  <InputOTPSlot index={3} />
                  <InputOTPSlot index={4} />
                  <InputOTPSlot index={5} />
                </InputOTPGroup>
              </InputOTP>
              <Button onClick={handleOTPSubmit}>Verify OTP</Button>
            </div>
          )}
        </CardContent>
        <CardFooter></CardFooter>
      </Card>
    </div>
  );
};

export default ValidateEmail;
